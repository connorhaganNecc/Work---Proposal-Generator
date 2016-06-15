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
    /// Interaction logic for NewTask.xaml
    /// </summary>
    public partial class NewContTask : UserControl, ISwitchable
    {

        public NewContTask()
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
            Switcher.Switch(new PropPg1());
        }
        private void btn_Finish(object sender, RoutedEventArgs e)
        {
            ContractTaskList myList = ContractTaskSerializer.DeserializeContractTasks();

            ContractTask newTask = new ContractTask();
            newTask.HeadLevelItem = HeadText.Text;
            myList.myTasks.Add(newTask);

            

            ContractTaskSerializer.SerializeContractTasks(myList);
            Switcher.Switch(new AddData());

        }
    }
}
