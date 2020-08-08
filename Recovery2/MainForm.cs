using System;
using System.ComponentModel;
using System.Windows.Forms;
using NLog;
using Recovery2.Models;

namespace Recovery2
{
    public partial class MainForm : Form
    {
        private User _user;
        private static Logger _log;

        public MainForm()
        {
            InitializeComponent();
        }

        private void AddRadioCheckedBinding<T>(RadioButton radio, object dataSource, string dataMember, T trueValue)
        {
            var binding = new Binding(nameof(RadioButton.Checked), dataSource, dataMember, true,
                DataSourceUpdateMode.OnPropertyChanged);
            binding.Parse += (s, a) =>
            {
                if ((bool) a.Value) a.Value = trueValue;
            };
            binding.Format += (s, a) => a.Value = ((T) a.Value).Equals(trueValue);
            radio.DataBindings.Add(binding);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _log = LogManager.GetCurrentClassLogger();
            _user = new User();
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

        private void ButtonClear_Click(object sender, EventArgs e) => _user.Clear();

        private void ButtonConfig_Click(object sender, EventArgs e) => new SettingsForm().Show();

        private void ButtonBegin_Click(object sender, EventArgs e)
        {
            _log.Trace($"_user.LastName=\"{_user.LastName}\"");
        }
    }
}