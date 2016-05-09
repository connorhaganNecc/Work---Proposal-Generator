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
    public partial class NewTask : UserControl, ISwitchable
    {

        public NewTask()
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
            TaskStructure myTask = new TaskStructure();
            myTask.Header = HeadText.Text;
            myTask.Body = BodyText.Text;
            TaskList myList = TaskSerializer.DeserializeTaskList();
            myList.myTasks.Add(myTask);

            TaskSerializer.SerializeTaskList(myList);
            Switcher.Switch(new AddData());
        }
    }
}
