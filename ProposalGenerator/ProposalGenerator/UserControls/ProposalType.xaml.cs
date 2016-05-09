using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProposalGenerator
{
    /// <summary>
    /// Interaction logic for ProposalTypePicker.xaml
    /// </summary>
    public partial class ProposalType : UserControl
    {
        public ProposalType()
        {
            InitializeComponent();
        }



        #region buttons
        private void btn_ReturnToMain(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainWindow());
        }

        private void btn_JohnLProp(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new PropPg1());
        }
        private void btn_ScottLProp(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new ScottL_Pg1());
        }
        #endregion
    }

}
