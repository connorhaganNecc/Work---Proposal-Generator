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
    public partial class SettingsMain : UserControl
    {
        public SettingsMain()
        {
            InitializeComponent();
        }



        #region buttons
        private void btn_ReturnToMain(object sender, RoutedEventArgs e)
        {
            SettingsSerializer.SerializeSettings(Data.Settings.myData);
            Switcher.Switch(new MainWindow());
        }

        
        #endregion

        private void btn_setTasks(object sender, RoutedEventArgs e)
        {
            Data.Settings.OpenTaskFileDialog();
        }
        private void btn_setContTasks(object sender, RoutedEventArgs e)
        {
            Data.Settings.OpenContractTaskFileDialog();
        }
        private void btn_setAdd(object sedner, RoutedEventArgs e)
        {
            Data.Settings.OpenAddFileDialog();
        }

        private void btn_setOutput(object sender, RoutedEventArgs e)
        {
            Data.Settings.OpenOutputFileDialog();
        }
    }

}
