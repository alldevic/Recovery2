using System;
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
    }
}