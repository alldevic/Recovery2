using System;
using System.Drawing;
using System.Windows.Forms;
using Recovery2.Models;

namespace Recovery2.Views
{
    public partial class SettingsForm : Form
    {
        private readonly GlobalConfig _config;

        public SettingsForm(GlobalConfig config)
        {
            _config = config;
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e) => GridConfig.SelectedObject = _config;

        private void ButtonDefault_Click(object sender, EventArgs e)
        {
            using (new CenteredMessageBox(this,
                new Font(Font.FontFamily, 12, Font.Style, Font.Unit, Font.GdiCharSet,
                    Font.GdiVerticalFont)))
            {
                DialogResult = MessageBox.Show(@"Сбросить параметры?", @"Сброс", MessageBoxButtons.YesNo) ==
                               DialogResult.Yes
                    ? DialogResult.Abort
                    : DialogResult.No;
            }
        }
    }
}