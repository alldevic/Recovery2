using System;
using System.Windows.Forms;
using NLog;
using Recovery2.Models;
using static Recovery2.Utils;

namespace Recovery2
{
    public partial class MainForm : Form
    {
        private static Logger _log;
        private User _user;

        public MainForm()
        {
            InitializeComponent();
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