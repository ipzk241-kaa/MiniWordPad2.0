using System.Drawing;
using System.Windows.Forms;

namespace Lab_6
{
    public class ThemeManager
    {
        private IThemeStrategy _currentStrategy;

        public void SetStrategy(IThemeStrategy strategy)
        {
            _currentStrategy = strategy;
        }

        public void ApplyTheme(Control root)
        {
            _currentStrategy?.Apply(root);
        }
    }
}
