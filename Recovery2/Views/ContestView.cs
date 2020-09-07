using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Recovery2.Models;

namespace Recovery2.Views
{
    public partial class ContestView : Form
    {
        private readonly GlobalConfig _config;
        private readonly User _user;
        private readonly Queue<ContestItem> _queue;
        public ContestView(GlobalConfig config, User user, Queue<ContestItem> queue)
        {
            _config = config;
            _user = user;
            _queue = queue;
            
            InitializeComponent();
            ContestLabel.Text = config.Title;
            ScaleFont(ContestLabel);
            if (config.ContestDebug)
            {
                return;
            }

            TopMost = true;
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            BackColor = _config.BlackscreenItem.Color;
            ContestLabel.ForeColor = Color.FromArgb(
                Color.White.A - BackColor.A,
                Color.White.R - BackColor.R,
                Color.White.G - BackColor.G,
                Color.White.B - BackColor.B);
        }

        public sealed override Color BackColor
        {
            get => base.BackColor;
            set => base.BackColor = value;
        }

        private void ContestView_SizeChanged(object sender, EventArgs e)
        {
            ScaleFont(ContestLabel);
        }

        private void ScaleFont(Label lab)
        {
            SizeF extent = TextRenderer.MeasureText(lab.Text, lab.Font);

            var hRatio = lab.Height / extent.Height;
            var wRatio = lab.Width / extent.Width;
            var ratio = (hRatio < wRatio) ? hRatio : wRatio;

            var newSize = lab.Font.Size * ratio - 1;

            lab.Font = new Font(lab.Font.FontFamily, newSize, lab.Font.Style);
        }
    }
}