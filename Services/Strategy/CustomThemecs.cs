using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_6
{
    public class CustomTheme : IThemeStrategy
    {
        private readonly Color _backColor;
        private readonly Color _foreColor;

        public CustomTheme(Color back, Color fore)
        {
            _backColor = back;
            _foreColor = fore;
        }

        public void Apply(Control root)
        {
            if (root.Tag?.ToString() != "Theme:font" && root.Tag?.ToString() != "NOCHANGE")
            {
                root.BackColor = _backColor;
                root.ForeColor = _foreColor;
            }
            foreach (Control ctrl in root.Controls)
                Apply(ctrl);
        }
    }
}
