using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Recovery2.Models;

namespace Recovery2.Views
{
    public partial class ContestView : Form
    {
        private readonly User _user;
        private readonly Queue<ContestItem> _queue;
        private readonly Keys _closeKey;


        private readonly Stopwatch _swt = new Stopwatch();
        private readonly Timer _timer = new Timer();
        private ContestItem _curr;

        private readonly ContestResult _result;

        public ContestView(GlobalConfig config, User user, Queue<ContestItem> queue)
        {
            if (!config.ContestDebug && config.HideCursor)
            {
                Cursor.Hide();
            }

            _user = user;
            _queue = queue;
            _timer.Tick += TimerOnTick;
            InitializeComponent();
            ContestLabel.Text = config.Title;
            _closeKey = config.CloseKey;
            ScaleFont(ContestLabel);

            switch (config.FrameSize.Type)
            {
                case FrameSize.SizeType.Percent:

                    tableLayoutPanel2.ColumnStyles[0].SizeType = SizeType.Percent;
                    tableLayoutPanel2.ColumnStyles[0].Width = (100 - config.FrameSize.Width) / 2f;
                    tableLayoutPanel2.ColumnStyles[1].SizeType = SizeType.Percent;
                    tableLayoutPanel2.ColumnStyles[1].Width = config.FrameSize.Width;
                    tableLayoutPanel2.ColumnStyles[2].SizeType = SizeType.Percent;
                    tableLayoutPanel2.ColumnStyles[2].Width = (100 - config.FrameSize.Width) / 2f;

                    tableLayoutPanel2.RowStyles[0].SizeType = SizeType.Percent;
                    tableLayoutPanel2.RowStyles[0].Height = (100 - config.FrameSize.Height) / 2f;
                    tableLayoutPanel2.RowStyles[1].SizeType = SizeType.Percent;
                    tableLayoutPanel2.RowStyles[1].Height = config.FrameSize.Height;
                    tableLayoutPanel2.RowStyles[2].SizeType = SizeType.Percent;
                    tableLayoutPanel2.RowStyles[2].Height = (100 - config.FrameSize.Height) / 2f;

                    break;
                case FrameSize.SizeType.Pixel:
                    tableLayoutPanel2.ColumnStyles[0].SizeType = SizeType.Percent;
                    tableLayoutPanel2.ColumnStyles[0].Width = 50;
                    tableLayoutPanel2.ColumnStyles[1].SizeType = SizeType.Absolute;
                    tableLayoutPanel2.ColumnStyles[1].Width = config.FrameSize.Width;
                    tableLayoutPanel2.ColumnStyles[2].SizeType = SizeType.Percent;
                    tableLayoutPanel2.ColumnStyles[2].Width = 50;

                    tableLayoutPanel2.RowStyles[0].SizeType = SizeType.Percent;
                    tableLayoutPanel2.RowStyles[0].Height = 50;
                    tableLayoutPanel2.RowStyles[1].SizeType = SizeType.Absolute;
                    tableLayoutPanel2.RowStyles[1].Height = config.FrameSize.Height;
                    tableLayoutPanel2.RowStyles[2].SizeType = SizeType.Percent;
                    tableLayoutPanel2.RowStyles[2].Height = 50;

                    break;
            }

            if (!config.ContestDebug)
            {
                TopMost = true;
                WindowState = FormWindowState.Maximized;
                FormBorderStyle = FormBorderStyle.None;
                BackColor = config.BlackscreenItem.Color;
                ContestLabel.ForeColor = Color.FromArgb(
                    Color.White.A - BackColor.A,
                    Color.White.R - BackColor.R,
                    Color.White.G - BackColor.G,
                    Color.White.B - BackColor.B);
            }

            _result = new ContestResult(_user)
            {
                Results = new List<ContestResultItem>(),
                Created = DateTime.Now
            };

            ContestImage.Focus();
            StartRunner();
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            _swt.Stop();
            _timer.Enabled = false;
            _timer.Stop();

            if (!_curr.Name.StartsWith(@"Blackscreen") && !_fl)
            {
                _result.Results.Add(new ContestResultItem
                {
                    Elapsed = _swt.ElapsedMilliseconds,
                    Item = _curr,
                    Success = _curr.Key == Keys.None,
                });
                _swt.Reset();
            }

            if (_queue.Count == 0)
            {
                GenerateReport();
                Close();
                return;
            }

            _curr = _queue.Dequeue();
            
            if (_curr.Type == ContentItemType.Image && File.Exists(_curr.ImagePath))
            {
                ContestImage.Image = Image.FromFile(_curr.ImagePath);
                ContestImage.BackColor = BackColor;
            }
            else
            {
                ContestImage.Image = new Bitmap(1,1);
                ContestImage.BackColor = _curr.Color;
            }
            _timer.Interval = (int) _curr.Delay;
            _swt.Reset();
            _timer.Enabled = true;
            _timer.Start();
            _swt.Start();
            _fl = false;
        }

        private void StartRunner()
        {
            if (_queue.Count == 0)
            {
                GenerateReport();
                Close();
                return;
            }

            _curr = _queue.Dequeue();
            if (_curr.Type == ContentItemType.Image && File.Exists(_curr.ImagePath))
            {
                ContestImage.Image = Image.FromFile(_curr.ImagePath);
                ContestImage.BackColor = BackColor;
            }
            else if (_curr.Type == ContentItemType.Text)
            {
                ContestImage.BackColor = _curr.Color;
                ContestImage.Image = new Bitmap(ContestImage.Width, ContestImage.Height);
                var g = Graphics.FromImage(pictureBox1.Image);
                g.DrawString("+", new Font("Arial", 24), new SolidBrush(Color.White), new Point(ContestImage.Width / 2 - 12, 
                                                                                                ContestImage.Height / 2 - 12));
                g.Dispose();
            }
            else
            {
                ContestImage.Image = new Bitmap(1,1);
                ContestImage.BackColor = _curr.Color;
            }
            

            _timer.Interval = (int) _curr.Delay;
            _timer.Start();
            _swt.Reset();
            _swt.Start();
        }

        private void GenerateReport()
        {
            var pos = _result.Results.Count(x => x.Success);
            var all = _result.Results.Count;
            Cursor.Show();
            using (new CenteredMessageBox(this,
                new Font(Font.FontFamily, 12, Font.Style, Font.Unit, Font.GdiCharSet,
                    Font.GdiVerticalFont)))
            {
                MessageBox.Show(
                    $@"{_user.LastName} {_user.FirstName} {_user.SecondName}{Environment.NewLine}Правильно: {pos}{Environment.NewLine}Всего: {all}",
                    @"Тестирование завершено", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CsvReport.WriteCsv(new[] {_result});
        }


        public sealed override Color BackColor
        {
            get => base.BackColor;
            set => base.BackColor = value;
        }

        private void ContestView_SizeChanged(object sender, EventArgs e) => ScaleFont(ContestLabel);

        private void ScaleFont(Label lab)
        {
            SizeF extent = TextRenderer.MeasureText(lab.Text, lab.Font);

            var hRatio = lab.Height / extent.Height;
            var wRatio = lab.Width / extent.Width;
            var ratio = (hRatio < wRatio) ? hRatio : wRatio;

            var newSize = lab.Font.Size * ratio - 1;

            lab.Font = new Font(lab.Font.FontFamily, newSize, lab.Font.Style);
        }

        private void ContestView_FormClosing(object sender, FormClosingEventArgs e)
        {
            _swt.Stop();
            _timer.Stop();
            _timer.Dispose();
        }

        private bool _fl;

        private void ContestView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == _closeKey)
            {
                _timer.Stop();
                _swt.Stop();
                GenerateReport();
                Close();
                return;
            }

            if (_curr.Name.StartsWith(@"Blackscreen") || _fl)
            {
                return;
            }

            _fl = true;
            _swt.Stop();

            _result.Results.Add(new ContestResultItem
            {
                Elapsed = _swt.ElapsedMilliseconds,
                Item = _curr,
                Success = e.KeyCode == _curr.Key,
            });
        }
    }
}