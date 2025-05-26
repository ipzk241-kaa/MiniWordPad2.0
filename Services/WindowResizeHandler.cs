using System;
using System.Collections.Generic;
using System.Drawing;
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

        private static readonly Dictionary<Form, WindowResizeHandler> instances = new Dictionary<Form, WindowResizeHandler>();

        private readonly Form form;

        private WindowResizeHandler(Form form)
        {
            this.form = form;
        }

        public static WindowResizeHandler GetInstance(Form form)
        {
            if (instances.ContainsKey(form))
                return instances[form];

            var handler = new WindowResizeHandler(form);
            instances[form] = handler;
            return handler;
        }

        public bool HandleWndProc(ref Message m)
        {
            if (m.Msg != WM_NCHITTEST)
                return false;

            Point cursor = form.PointToClient(Cursor.Position);

            bool top = cursor.Y < RESIZE_AREA_SIZE;
            bool bottom = cursor.Y > form.ClientSize.Height - RESIZE_AREA_SIZE;
            bool left = cursor.X < RESIZE_AREA_SIZE;
            bool right = cursor.X > form.ClientSize.Width - RESIZE_AREA_SIZE;

            var key = (top, bottom, left, right);

            var cornerMap = new Dictionary<(bool, bool, bool, bool), int>
            {
                { (true, false, true, false), HTTOPLEFT },
                { (true, false, false, true), HTTOPRIGHT },
                { (false, true, true, false), HTBOTTOMLEFT },
                { (false, true, false, true), HTBOTTOMRIGHT },
                { (false, false, true, false), HTLEFT },
                { (false, false, false, true), HTRIGHT },
                { (true, false, false, false), HTTOP },
                { (false, true, false, false), HTBOTTOM },
            };

            m.Result = (IntPtr)(cornerMap.TryGetValue(key, out int result) ? result : HTCLIENT);
            return true;
        }
    }
}