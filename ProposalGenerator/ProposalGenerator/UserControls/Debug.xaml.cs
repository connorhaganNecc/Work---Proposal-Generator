using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Novacode;
using System.Diagnostics;

namespace ProposalGenerator
{
    /// <summary>
    /// Interaction logic for ProposalTypePicker.xaml
    /// </summary>
    public partial class Debug : UserControl
    {
        public Debug()
        {
            InitializeComponent();
        }



        #region buttons
        private void btn_WriteTasks(object sender, RoutedEventArgs e)
        {
            DocumentController.ClearFilename();
            TaskList myList = TaskSerializer.DeserializeTaskList();
            DocumentController.WriteTaskList(myList);
            Process.Start("WINWORD.EXE", "\"" + DocumentController.GetFilename() + "\"");
        }
        private void btn_ReturnToMain(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainWindow());
        }

        //private void btn_TestFormatting(object sender, RoutedEventArgs e)
        //{
        //    DocumentController.ClearFilename();
        //    DocumentController.OpenFileDialog();
        //    TaskList myList = TaskSerializer.DeserializeTaskList();
        //    for (int i = 0; i < myList.myTasks.Count(); i++)
        //    {
        //        //DocumentController.WriteTask(myList.myTasks[i], i+1);
                
        //    }

            
            


        //}
        private void btn_Cancel(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new DebugTaskText());
        }
    }

}
