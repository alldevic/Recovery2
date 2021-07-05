using System;
using System.Windows.Forms;

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
            richLabel1.Rtf =
                @"{\rtf1\ansi\ansicpg1251\qc Одновременно с выполнением этого задания нужно придумать и назвать как можно больше способов \bнеобычного\b0  использования предмета, указанного в заголовке экрана";
        }
    }
}