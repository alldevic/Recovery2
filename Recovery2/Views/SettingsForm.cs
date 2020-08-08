using System;
using System.Windows.Forms;
using Recovery2.Models;

namespace Recovery2.Views
{
    public partial class SettingsForm : Form
    {
        private GlobalConfig _config;
        public SettingsForm()
        {
            _config = new GlobalConfig();
            InitializeComponent();
        }

        public SettingsForm(GlobalConfig config)
        {
            _config = config;
            InitializeComponent();
        }
        
        
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            GridConfig.SelectedObject = _config;
        }
    }
}