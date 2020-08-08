using System;
using System.Windows.Forms;
using Recovery2.Models;

namespace Recovery2
{
    public partial class MainForm : Form
    {
        private User _user;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _user = new User();
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
            _user = new User();
        }
    }
}