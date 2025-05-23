using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_6
{
    public interface IThemeStrategy
    {
        void Apply(Control root);
    }
}
