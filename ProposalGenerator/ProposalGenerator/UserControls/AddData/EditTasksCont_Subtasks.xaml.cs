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
    public partial class EditTasksCont_Subtasks : UserControl, ISwitchable
    {
        ContractTaskList myList;
        int currIndex;
        int subIndex;
        bool hasLoaded = false;

        public EditTasksCont_Subtasks(int inIndex, ContractTaskList inList)
        {
            InitializeComponent();
            myList = inList;
            currIndex = inIndex;
            Header.Content = myList.myTasks[currIndex].HeadLevelItem;
            subIndex = TaskSelector.SelectedIndex; 
            List<string> tempStrings = new List<string>();
            for(int i = 0; i < myList.myTasks[currIndex].subTasks.Count; i++)
            {
                tempStrings.Add(myList.myTasks[currIndex].subTasks[i].name);
            }
            TaskSelector.ItemsSource = tempStrings;
        }
        public EditTasksCont_Subtasks(int inIndex, int subIndex,ContractTaskList inList)
        {
            InitializeComponent();
            myList = inList;
            currIndex = inIndex;
            Header.Content = myList.myTasks[currIndex].HeadLevelItem;
            List<string> tempStrings = new List<string>();
            for (int i = 0; i < myList.myTasks[currIndex].subTasks.Count; i++)
            {
                tempStrings.Add(myList.myTasks[currIndex].subTasks[i].name);
            }
            TaskSelector.ItemsSource = tempStrings;
            if(subIndex > 0 && subIndex < tempStrings.Count)
            {
                TaskSelector.SelectedIndex = subIndex;
            }
        }
        //public EditTasksCont(ContractTaskList inList, int inIndex)
        //{
        //    InitializeComponent();
        //    myList = inList;
        //    List<string> taskListString = new List<string>();
        //    myList.myTasks.Sort((x, y) => x.HeadLevelItem.CompareTo(y.HeadLevelItem));
        //    for (int i = 0; i < myList.myTasks.Count; i++)
        //    {
        //        taskListString.Add(myList.myTasks[i].HeadLevelItem);
        //    }
        //    TaskSelector.ItemsSource = taskListString;

        //    currIndex = inIndex;
        //    TaskSelector.SelectedIndex = currIndex;
        //}
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
            if (subIndex >= 0)
            {
                if (SubtaskClass.SelectedIndex == 0)
                {
                    myList.myTasks[currIndex].subTasks[subIndex].myClass = ContractSubtaskClass.Bullet;
                }
                else
                {
                    myList.myTasks[currIndex].subTasks[subIndex].myClass = ContractSubtaskClass.Letter;
                }
                myList.myTasks[currIndex].subTasks[subIndex].allowSubSub = (bool)AllowSubSubtaks.IsChecked;
                myList.myTasks[currIndex].subTasks[subIndex].text = DescriptionBox.Text;
                myList.myTasks[currIndex].subTasks[subIndex].CompensationText = CompensationName.Text;
                ContractTaskSerializer.SerializeContractTasks(myList);
            }
        }

        private void btn_Finish(object sender, RoutedEventArgs e)
        {
            //if(currIndex>=0 && currIndex<myList.myTasks.Count)
            //{
            //    myList.myTasks[currIndex].HeadLevelItem = HeadText.Text;
            //    myList.myTasks[currIndex].ServiceItemNum = Convert.ToInt32(ServiceItem.Text);
            //    myList.myTasks[currIndex].Description = Description.Text;
            //    ContractTaskSerializer.SerializeContractTasks(myList);
            //    Switcher.Switch(new AddData());
            //}
            //else
            //{
            //    Switcher.Switch(new AddData());
            //}
            SaveData();
            Switcher.Switch(new EditTasksCont(myList, currIndex));
        }

        private void TaskSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(hasLoaded)
            {
                SaveData();
            }
            
            subIndex = TaskSelector.SelectedIndex;
            if (myList.myTasks[currIndex].subTasks[TaskSelector.SelectedIndex].myClass == ContractSubtaskClass.Bullet)
            {
                SubtaskClass.SelectedIndex = 0;
            }
            else
            {
                SubtaskClass.SelectedIndex = 1;
            }
            AllowSubSubtaks.IsChecked = myList.myTasks[currIndex].subTasks[TaskSelector.SelectedIndex].allowSubSub;
            DescriptionBox.Text = myList.myTasks[currIndex].subTasks[TaskSelector.SelectedIndex].text;
            CompensationName.Text = myList.myTasks[currIndex].subTasks[TaskSelector.SelectedIndex].CompensationText;
            //for(int i = 0; i < myList.myTasks.Count; i++)
            //{
            //    if(TaskSelector.SelectedValue.ToString() ==  myList.myTasks[i].HeadLevelItem)
            //    {
            //        HeadText.Text = myList.myTasks[i].HeadLevelItem;
            //        ServiceItem.Text = myList.myTasks[i].ServiceItemNum.ToString();
            //        currIndex = i;
            //        Description.Text = myList.myTasks[i].Description;
            //    }
            //}
            if(!hasLoaded)
            {
                hasLoaded = true;
            }
        }
        private void ClassSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SubtaskClass.SelectedIndex == 1)
            {
                AllowSubSubtaks.Visibility = Visibility.Visible;
                AllowSubSubtasksLabel.Visibility = Visibility.Visible;
            }
            else
            {
                AllowSubSubtaks.Visibility = Visibility.Hidden;
                AllowSubSubtasksLabel.Visibility = Visibility.Hidden;
            }
        }
        private void btn_AddNewSubtask(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new EditTasksCont_AddSubtasks(currIndex, myList));
        }

        private void subsubTasks_Checked(object sender, RoutedEventArgs e)
        {
            EditSubSub.Visibility = Visibility.Visible;
        }
        private void subsubTasks_Unchecked(object sender, RoutedEventArgs e)
        {
            EditSubSub.Visibility = Visibility.Hidden;
        }

        private void editsubsub_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new EditSubSub(currIndex, TaskSelector.SelectedIndex, myList));
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
