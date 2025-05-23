using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_6 
{ 
    public class DarkTheme : IThemeStrategy
{
    public void Apply(Control root)
    {
            if (root.Tag?.ToString() != "Theme:font" && root.Tag?.ToString() != "NOCHANGE")
            {
                root.BackColor = Color.FromArgb(56,62,66);
                root.ForeColor = Color.White;
            }
            else if (root.Tag?.ToString() == "Theme:font" && root.Tag?.ToString() != "NOCHANGE")
            {
                root.BackColor = Color.Black;
                root.ForeColor = Color.White;
            }

            foreach (Control ctrl in root.Controls)
            Apply(ctrl);
    }
}
}
