using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for EditTasks.xaml
    /// </summary>
    public partial class EditTasksCont : UserControl, ISwitchable
    {
        ContractTaskList myList;
        int currIndex;
        bool hasLoaded = false;


        public EditTasksCont()
        {
            InitializeComponent();
            myList = ContractTaskSerializer.DeserializeContractTasks();
            List<string> taskListString = new List<string>();
            myList.myTasks.Sort((x,y) => x.HeadLevelItem.CompareTo(y.HeadLevelItem));
            for(int i = 0; i < myList.myTasks.Count; i++)
            {
                taskListString.Add(myList.myTasks[i].HeadLevelItem);
            }
            TaskSelector.ItemsSource = taskListString;
            currIndex = -1;
        }
        public EditTasksCont(ContractTaskList inList, int inIndex)
        {
            InitializeComponent();
            myList = inList;
            List<string> taskListString = new List<string>();
            myList.myTasks.Sort((x, y) => x.HeadLevelItem.CompareTo(y.HeadLevelItem));
            for (int i = 0; i < myList.myTasks.Count; i++)
            {
                taskListString.Add(myList.myTasks[i].HeadLevelItem);
            }
            TaskSelector.ItemsSource = taskListString;
            
            currIndex = inIndex;
            AllowSubtasks.IsChecked = myList.myTasks[currIndex].allowsSubTasks;
            TaskSelector.SelectedIndex = currIndex;
        }
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void btn_ReturnToMain(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainWindow());
        }
        
        void SaveData()
        {
            myList.myTasks[currIndex].HeadLevelItem = HeadText.Text;
            if(!String.IsNullOrWhiteSpace(ServiceItem.Text))
            {
                myList.myTasks[currIndex].ServiceItemNum = Convert.ToInt32(ServiceItem.Text);
            }
            
            myList.myTasks[currIndex].Description = Description.Text;
            myList.myTasks[currIndex].allowsSubTasks = (bool)AllowSubtasks.IsChecked;
            myList.myTasks[currIndex].CompensationText = CompensationText.Text;
            ContractTaskSerializer.SerializeContractTasks(myList);
        }

        private void btn_Finish(object sender, RoutedEventArgs e)
        {
            if(currIndex>=0 && currIndex<myList.myTasks.Count)
            {
                SaveData();
                Switcher.Switch(new AddData());
            }
            else
            {
                Switcher.Switch(new AddData());
            }
        }

        private void TaskSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(currIndex>=0 && hasLoaded)
            {
                SaveData();
            }
            
            for(int i = 0; i < myList.myTasks.Count; i++)
            {
                if(TaskSelector.SelectedValue.ToString() ==  myList.myTasks[i].HeadLevelItem)
                {
                    HeadText.Text = myList.myTasks[i].HeadLevelItem;
                    ServiceItem.Text = myList.myTasks[i].ServiceItemNum.ToString();
                    currIndex = i;
                    Description.Text = myList.myTasks[i].Description;
                    AllowSubtasks.IsChecked = myList.myTasks[i].allowsSubTasks;
                    CompensationText.Text = myList.myTasks[i].CompensationText;

                    if(AllowSubtasks.IsChecked == true)
                    {

                    }
                }
            }

            if(!hasLoaded)
            {
                hasLoaded = true;
            }
        }

        private void btn_EditSubtasks(object sender, RoutedEventArgs e)
        {
            if(currIndex>=0)
            {

                SaveData();
                Switcher.Switch(new EditTasksCont_Subtasks(currIndex, myList));
            }
        }

        private void allowSubtasks_Checked(object sender, RoutedEventArgs e)
        {
            editSubtasks.Visibility = Visibility.Visible;
        }
        private void allowSubtasks_Unchecked(object sender, RoutedEventArgs e)
        {
            editSubtasks.Visibility = Visibility.Hidden;
        }


        //private void btn_EditTaskText(object sender, RoutedEventArgs e)
        //{
        //    if(TaskSelector.SelectedIndex >=0)
        //        Switcher.Switch(new EditTaskText(myList, TaskSelector.SelectedIndex));
        //    else
        //    {
        //        MessageBox.Show("Please select a task first");
        //    }
        //}
    }
}
