using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Lab_6
{
    public class WindowResizeHandler
    {
        private const int HTLEFT = 10;
        private const int HTRIGHT = 11;
        private const int HTTOP = 12;
        private const int HTTOPLEFT = 13;
        private const int HTTOPRIGHT = 14;
        private const int HTBOTTOM = 15;
        private const int HTBOTTOMLEFT = 16;
        private const int HTBOTTOMRIGHT = 17;
        private const int HTCLIENT = 1;
        private const int WM_NCHITTEST = 0x84;

        private const int RESIZE_AREA_SIZE = 10;

        private readonly Form form;

        public WindowResizeHandler(Form form)
        {
            this.form = form;
        }

        public bool HandleWndProc(ref Message m)
        {
            if (m.Msg == WM_NCHITTEST)
            {
                Point cursor = form.PointToClient(Cursor.Position);

                bool top = cursor.Y < RESIZE_AREA_SIZE;
                bool bottom = cursor.Y > form.ClientSize.Height - RESIZE_AREA_SIZE;
                bool left = cursor.X < RESIZE_AREA_SIZE;
                bool right = cursor.X > form.ClientSize.Width - RESIZE_AREA_SIZE;

                if (top && left)
                {
                    m.Result = (IntPtr)HTTOPLEFT;
                    return true;
                }
                else if (top && right)
                {
                    m.Result = (IntPtr)HTTOPRIGHT;
                    return true;
                }
                else if (bottom && left)
                {
                    m.Result = (IntPtr)HTBOTTOMLEFT;
                    return true;
                }
                else if (bottom && right)
                {
                    m.Result = (IntPtr)HTBOTTOMRIGHT;
                    return true;
                }
                else if (left)
                {
                    m.Result = (IntPtr)HTLEFT;
                    return true;
                }
                else if (right)
                {
                    m.Result = (IntPtr)HTRIGHT;
                    return true;
                }
                else if (top)
                {
                    m.Result = (IntPtr)HTTOP;
                    return true;
                }
                else if (bottom)
                {
                    m.Result = (IntPtr)HTBOTTOM;
                    return true;
                }
                else
                {
                    m.Result = (IntPtr)HTCLIENT;
                    return true;
                }
            }

            return false;
        }
    }
}
