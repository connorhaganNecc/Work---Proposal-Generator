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
using System.Windows.Shapes;

using MahApps.Metro.Controls;
namespace ProposalGenerator
{
    /// <summary>
    /// Interaction logic for AddData.xaml
    /// </summary>
    public partial class AddData : UserControl, ISwitchable
    {
        public AddData()
        {
            InitializeComponent();
        }
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void btn_ReturnToMain(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainWindow());
        }
        private void btn_CreateTask(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new NewTask());
        }
        private void btn_EditTasks(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new EditTasks());
        }
        private void btn_EditAddItems(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new EditAddItems());
        }
        private void btn_AddAddItems(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new AddAddItems());
        }

        private void btn_AddContItems(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new NewContTask());
        }

        private void btn_EditContItems(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new EditTasksCont());
        }
    }
}
