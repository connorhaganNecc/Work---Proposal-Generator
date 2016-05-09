using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProposalGenerator
{
    public static class Switcher
    {
        public static PageSwitcher pageSwitcher = new PageSwitcher();
        
        public static void Switch(UserControl newPage)
        {
            pageSwitcher.Navigate(newPage);
        }

        public static void Switch(UserControl newPage, object state)
        {
            pageSwitcher.Navigate(newPage, state);
        }
    }
}
