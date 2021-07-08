using System;
using System.Drawing;
using System.Windows.Forms;
using Recovery2.Extensions;

namespace Recovery2.Views
{
    public partial class HelpingView : Form
    {
        public HelpingView()
        {
            InitializeComponent();
        }

        private void HelpingView_Load(object sender, EventArgs e)
        {
            label2.Text = "Нажимаем ПРОБЕЛ\nлевой рукой";
            label4.Text = "Нажимаем ENTER\nправой рукой";
            Utils.ScaleFont(label1);
            Utils.ScaleFont(label2);
            Utils.ScaleFont(label3, label2.Font.Size);
            Utils.ScaleFont(label4, label2.Font.Size);
            Utils.ScaleFont(richLabel1);
            Utils.ScaleFont(button1, shift: -8);
            richLabel1.Rtf =
                @"{\rtf1\ansi\ansicpg1251\qc Одновременно с выполнением этого задания нужно придумать и \lineназвать как можно больше способов \bнеобычного\b0  использования \lineпредмета, указанного в заголовке экрана";
            richLabel1.SelectAll();
            
            SizeF extent = TextRenderer.MeasureText(richLabel1.SelectedText, richLabel1.SelectionFont);

            var hRatio = richLabel1.Height / extent.Height;
            var wRatio = richLabel1.Width / extent.Width;
            var ratio = (hRatio < wRatio) ? hRatio : wRatio;

            var newSize = richLabel1.SelectionFont.Size * ratio - 1;

            richLabel1.Font = new Font(richLabel1.SelectionFont.FontFamily, newSize, richLabel1.SelectionFont.Style);
            richLabel1.DeselectAll();
            richLabel1.Rtf =
                @"{\rtf1\ansi\ansicpg1251\qc Одновременно с выполнением этого задания нужно придумать и \lineназвать как можно больше способов \bнеобычного\b0  использования \lineпредмета, указанного в заголовке экрана";
        }
    }
}