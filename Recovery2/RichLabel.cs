using System;
using System.Windows.Forms;

namespace Recovery2
{
    public class RichLabel : RichTextBox
    {
        public RichLabel()
        {
            ReadOnly = true;
            BorderStyle = BorderStyle.None;
            TabStop = false;
            
            SetStyle(ControlStyles.Selectable, false);
            SetStyle(ControlStyles.UserMouse, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            
            MouseEnter += delegate
            {
                Cursor = Cursors.Default;
            };
        }

        protected override void OnEnter(EventArgs e)
        {
            if (!DesignMode) Parent.SelectNextControl(this, true, true, true, true);
            base.OnEnter(e);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg < 0x201 || m.Msg > 0x20e)
                base.WndProc(ref m);
        }
    }
}