using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Recovery2
{
    class CenteredMessageBox : IDisposable
    {
        private int _mTries;
        private Form _mOwner;
        private readonly Font _mFont;

        public CenteredMessageBox(Form owner, Font font)
        {
            _mOwner = owner;
            _mFont = font;
            owner.BeginInvoke(new MethodInvoker(FindDialog));
        }

        private struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            public Rect(int left, int top, int right, int bottom)
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
            }
        }

        private void FindDialog()
        {
            // Enumerate windows to find the message box
            if (_mTries < 0) return;
            var callback = new EnumThreadWndProc(CheckWindow);
            if (!EnumThreadWindows(GetCurrentThreadId(), callback, IntPtr.Zero))
            {
                return;
            }

            if (++_mTries < 10)
            {
                _mOwner.BeginInvoke(new MethodInvoker(FindDialog));
            }
        }

        private bool CheckWindow(IntPtr hWnd, IntPtr lp)
        {
            // Checks if <hWnd> is a dialog
            var sb = new StringBuilder(260);
            GetClassName(hWnd, sb, sb.Capacity);
            if (sb.ToString() != "#32770") return true;
            // Got it, get the STATIC control that displays the text
            var hText = GetDlgItem(hWnd, 0xffff);
            if (hText != IntPtr.Zero)
            {
                SendMessage(hText, WmSetfont, _mFont.ToHfont(), (IntPtr) 1);

                var WM_GETTEXT = 0xD;

                var hwndText = GetDlgItem(hWnd, 0xFFFF);
                var sb1 = new StringBuilder {Capacity = 2048};
                GetWindowText(hwndText, sb1, 2048);
                var text = sb1.ToString();

                var hndl = Marshal.AllocHGlobal(text.Length);
                SendMessage(hText, WM_GETTEXT, hndl, hndl);
                SizeF textSize;
                using (var g = _mOwner.CreateGraphics())
                {
                    textSize = g.MeasureString(text + "MMM", _mFont);
                }

                var dlgRect = new Rect();
                GetWindowRect(hWnd, ref dlgRect);
                MoveWindow(hWnd,
                    _mOwner.Left + (_mOwner.Width - dlgRect.Right + dlgRect.Left) / 2,
                    _mOwner.Top + (_mOwner.Height - dlgRect.Bottom + dlgRect.Top) / 2,
                    (int) textSize.Width + 90,
                    dlgRect.Bottom - dlgRect.Top,
                    true);
                MoveWindow(hText,
                    70,
                    10,
                    (int) textSize.Width,
                    (int) textSize.Height,
                    true);
                SetWindowPos(hText, hWnd, 70, 30, 1920, 1080, 0);
            }

            // Done
            return false;
        }

        public void Dispose()
        {
            _mTries = -1;
            _mOwner = null;
            _mFont?.Dispose();
        }

        // P/Invoke declarations
        private const int WmSetfont = 0x30;
        // private const int WmGetfont = 0x31;

        private delegate bool EnumThreadWndProc(IntPtr hWnd, IntPtr lp);

        [DllImport("user32.dll")]
        private static extern bool EnumThreadWindows(int tid, EnumThreadWndProc callback, IntPtr lp);

        [DllImport("kernel32.dll")]
        private static extern int GetCurrentThreadId();

        [DllImport("user32.dll")]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder buffer, int buflen);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDlgItem(IntPtr hWnd, int item);

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        [DllImport("user32.dll")]
        private static extern bool MoveWindow(IntPtr hWnd, int x, int y, int w, int h, bool repaint);

        [DllImport("user32")]
        private static extern bool SetWindowPos(IntPtr hwnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy,
            UInt32 wFlags);

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, ref Rect rc);

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hwnd,
            StringBuilder lpString, int nMaxCount);
    }
}