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
    public partial class EditTasks : UserControl, ISwitchable
    {
        TaskList myList;
        int currIndex;
        List<string> Unselected;
        List<string> Selected;


        public EditTasks()
        {
            InitializeComponent();
            myList = TaskSerializer.DeserializeTaskList();
            List<string> taskListString = new List<string>();
            myList.myTasks.Sort((x,y) => x.Header.CompareTo(y.Header));
            for(int i = 0; i < myList.myTasks.Count; i++)
            {
                taskListString.Add(myList.myTasks[i].Header);
            }
            TaskSelector.ItemsSource = taskListString;
            currIndex = -1;
            Unselected = new ProposalTypes().myList;
            Unselected.Sort((x, y) => x.CompareTo(y));
            Selected = new List<string>();
            UnselectedTags.ItemsSource = Unselected;
            
        }
        public EditTasks(TaskList inList, int inIndex)
        {
            InitializeComponent();
            myList = inList;
            List<string> taskListString = new List<string>();
            myList.myTasks.Sort((x, y) => x.Header.CompareTo(y.Header));
            for (int i = 0; i < myList.myTasks.Count; i++)
            {
                taskListString.Add(myList.myTasks[i].Header);
            }
            TaskSelector.ItemsSource = taskListString;
            
            Unselected = new ProposalTypes().myList;
            Unselected.Sort((x, y) => x.CompareTo(y));
            Selected = new List<string>();
            UnselectedTags.ItemsSource = Unselected;

            currIndex = inIndex;
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
        
        private void btn_Finish(object sender, RoutedEventArgs e)
        {
            if(currIndex>=0 && currIndex<myList.myTasks.Count)
            {
                myList.myTasks[currIndex].Header = HeadText.Text;
                Selected = SelectedTags.ItemsSource as List<string>;
                myList.myTasks[currIndex].tags = Selected;
                myList.myTasks[currIndex].fee = Fee.Text;
                myList.myTasks[currIndex].serviceItemNum = Convert.ToInt32(HelperFunctions.StripAlphabetic(ServiceItem.Text));
                TaskSerializer.SerializeTaskList(myList);
                Switcher.Switch(new AddData());
            }
            else
            {
                Switcher.Switch(new AddData());
            }
        }

        private void TaskSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            for(int i = 0; i < myList.myTasks.Count; i++)
            {
                if(TaskSelector.SelectedValue.ToString() ==  myList.myTasks[i].Header)
                {
                    HeadText.Text = myList.myTasks[i].Header;
                    Fee.Text = myList.myTasks[i].fee;
                    ServiceItem.Text = myList.myTasks[i].serviceItemNum.ToString();
                    currIndex = i;

                    Unselected = new ProposalTypes().myList;
                    Unselected.Sort((x, y) => x.CompareTo(y));
                    Selected.Clear();
                    for(int j = 0; j < myList.myTasks[i].tags.Count; j++)
                    {
                        Selected.Add(myList.myTasks[i].tags[j]);   
                        for(int k = Unselected.Count-1; k >= 0; k--)
                        {
                            if(Unselected[k] == myList.myTasks[i].tags[j])
                            {
                                Unselected.RemoveAt(k);
                            }
                        }
                    }

                    UnselectedTags.ItemsSource = null;
                    UnselectedTags.ItemsSource = Unselected;

                    

                    SelectedTags.ItemsSource = null;
                    SelectedTags.ItemsSource = Selected;
                    
                }
            }
        }

        private void btn_AddTask(object sender, RoutedEventArgs e)
        {
            if(UnselectedTags.SelectedValue != null)
            {
                string currentItemText = UnselectedTags.SelectedValue.ToString();
                int currentItemIndex = UnselectedTags.SelectedIndex;

                Selected.Add(currentItemText);

                SelectedTags.ItemsSource = null;
                SelectedTags.ItemsSource = Selected;

                if (Unselected != null)
                {
                    Unselected.RemoveAt(currentItemIndex);
                }

                UnselectedTags.ItemsSource = null;
                UnselectedTags.ItemsSource = Unselected;
            }

        }

        private void btn_DeleteTask(object sender, RoutedEventArgs e)
        {
            if(TaskSelector.SelectedIndex>=0)
            {
                MessageBoxResult dialogResult = System.Windows.MessageBox.Show("Are you sure you want to delete task?", "Delete Task", MessageBoxButton.YesNo);
                if(dialogResult == MessageBoxResult.Yes)
                {
                    myList.myTasks.RemoveAt(TaskSelector.SelectedIndex);
                    TaskSerializer.SerializeTaskList(myList);
                    Switcher.Switch(new EditTasks());
                }
            }
        }

        private void btn_RemoveTask(object sender, RoutedEventArgs e)
        {
            if(SelectedTags.SelectedValue != null)
            {
                string currentItemText = SelectedTags.SelectedValue.ToString();
                int currentItemIndex = SelectedTags.SelectedIndex;

                Unselected.Add(currentItemText);
                UnselectedTags.ItemsSource = null;
                UnselectedTags.ItemsSource = Unselected;

                if (Selected != null)
                {
                    Selected.RemoveAt(currentItemIndex);
                }

                SelectedTags.ItemsSource = null;
                SelectedTags.ItemsSource = Selected;
            }
        }
        private void btn_EditTaskText(object sender, RoutedEventArgs e)
        {
            if(TaskSelector.SelectedIndex >=0)
                Switcher.Switch(new EditTaskText(myList, TaskSelector.SelectedIndex));
            else
            {
                System.Windows.MessageBox.Show("Please select a task first");
            }
        }
    }
}
