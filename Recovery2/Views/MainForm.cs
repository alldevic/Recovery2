using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NLog;
using Recovery2.Configs;
using Recovery2.Models;
using static Recovery2.Extensions.Utils;

namespace Recovery2.Views
{
    public partial class MainForm : Form
    {
        private static Logger _log;
        private User _user;
        private ConfigLoader _configLoader;
        private Random _random = new Random();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetIcon(this, 0);
            Text = $@"Восстановление";
            _log = LogManager.GetCurrentClassLogger();
            _user = new User();
            _configLoader = new ConfigLoader();
            _configLoader.Load();
            TextLastName.DataBindings.Add("Text", _user, $"{nameof(_user.LastName)}");
            TextFirstName.DataBindings.Add("Text", _user, $"{nameof(_user.FirstName)}");
            TextSecondName.DataBindings.Add("Text", _user, $"{nameof(_user.SecondName)}");
            TextAge.DataBindings.Add("Text", _user, $"{nameof(_user.Age)}");
            AddRadioCheckedBinding(RadioMale, _user, $"{nameof(_user.Gender)}", Gender.Male);
            AddRadioCheckedBinding(RadioFemale, _user, $"{nameof(_user.Gender)}", Gender.Female);
        }

        private void TextAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            _user.Clear();
        }

        private void ButtonConfig_Click(object sender, EventArgs e)
        {
            switch (new SettingsForm(_configLoader.GlobalConfig).ShowDialog())
            {
                case DialogResult.Yes:
                case DialogResult.OK:
                    _configLoader.Save();
                    break;
                case DialogResult.No:
                case DialogResult.Cancel:
                    _configLoader.Load();
                    break;
                case DialogResult.Abort:
                    _configLoader.LoadDefaults();
                    break;
                default:
                    _configLoader.Load();
                    _log.Warn("Необработанное поведение в результате настройки");
                    break;
            }
        }

        private void ButtonBegin_Click(object sender, EventArgs e)
        {
            if (!_user.IsValid())
            {
                _log.Info(@"Данные пациента заполнены не полностью!");
                using (new CenteredMessageBox(this,
                    new Font(Font.FontFamily, 12, Font.Style, Font.Unit, Font.GdiCharSet,
                        Font.GdiVerticalFont)))
                {
                    MessageBox.Show(@"Данные пациента заполнены не полностью!");
                }

                return;
            }

            var config = _configLoader.GlobalConfig;
            var contestQueue = new Queue<ContestItem>();
            var tmpItem = config.Items.Last();
            for (var i = 0; i < config.Count; i++)
            {
                tmpItem = GetNext(tmpItem, config);
                contestQueue.Enqueue(new ContestItem
                {
                    Color = tmpItem.Color,
                    Delay = tmpItem.Delay == 0 ? config.DefaultDelay : tmpItem.Delay,
                    Key = tmpItem.Key,
                    Name = $"Item{i}"
                });

                if (config.Blackscreen)
                {
                    contestQueue.Enqueue(new ContestItem
                    {
                        Color = config.BlackscreenItem.Color,
                        Delay = config.BlackscreenItem.Delay == 0 ? config.DefaultDelay : config.BlackscreenItem.Delay,
                        Key = config.BlackscreenItem.Key,
                        Name = $"Blackscreen{i}"
                    });
                }
            }

            if (config.Count == 0)
            {
                _log.Warn(@"Количество объектов равно 0!");
                using (new CenteredMessageBox(this,
                    new Font(Font.FontFamily, 12, Font.Style, Font.Unit, Font.GdiCharSet,
                        Font.GdiVerticalFont)))
                {
                    MessageBox.Show(@"Количество объектов равно 0!");
                }
            }

            using (new CenteredMessageBox(this,
                new Font(Font.FontFamily, 12, Font.Style, Font.Unit, Font.GdiCharSet,
                    Font.GdiVerticalFont)))
            {
                MessageBox.Show(@"Как только на экране возникнет изображение, Вам необходимо как можно быстрее выполнять следующую задачу:

1. Необходимо реагировать правой рукой нажатием клавиши ENTER в случае предъявления красного прямоугольника
и клавиши ПРОБЕЛ левой рукой при предъявлении зеленого прямоугольника. На прямоугольник желтого цвета реагировать не нужно.

2. Одновременно с выполнением первого задания придумывать как можно больше способов нестандартного
использования предмета, указанного в заголовке экрана.
", @"Инструкция");
            }
            
            new ContestView(_configLoader.GlobalConfig, _user, contestQueue).Show();
        }

        private ContestItem GetNext(ContestItem curr, GlobalConfig config)
        {
            return config.Random
                ? config.Items[_random.Next(config.Items.Count)]
                : config.Items
                    .SkipWhile(x => x != curr)
                    .Skip(1)
                    .DefaultIfEmpty(config.Items[0])
                    .FirstOrDefault();
        }
    }
}
