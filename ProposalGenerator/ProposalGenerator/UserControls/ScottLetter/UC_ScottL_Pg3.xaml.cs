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
using MahApps.Metro.Controls;
namespace ProposalGenerator
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ScottL_Pg3 : UserControl
    {
        PageSwitcher myParent;
        DataManager myData;
        TaskList myTaskList;
        List<TaskStructure> Unselect;
        List<TaskStructure> Select;

        List<TaskStructure> NormalTasks;
        List<TaskStructure> ExtraTasks;
        List<TaskStructure> NormalTasksSource;
        List<TaskStructure> ExtraTasksSource;
        
        public ScottL_Pg3(DataManager myData)
        {
            myParent = MetroWindow.GetWindow(this) as PageSwitcher;

            myTaskList = TaskSerializer.DeserializeTaskList();
            InitializeComponent();

            ExtraTasks = new List<TaskStructure>();
            NormalTasks = new List<TaskStructure>();
            NormalTasksSource = new List<TaskStructure>();
            ExtraTasksSource = new List<TaskStructure>();

            Unselect = myTaskList.myTasks;
            for (int i = 0; i < Unselect.Count; i++)
            {
                bool noMatch = true;
                for (int k = 0; k < Unselect[i].tags.Count; k++)
                {
                    if(Unselect[i].tags[k] == myData.ProposalType)
                    {
                        NormalTasks.Add(Unselect[i]);
                        NormalTasksSource.Add(Unselect[i]);
                        noMatch = false;
                    }
                }
                if(noMatch)
                {
                    ExtraTasks.Add(Unselect[i]);
                    ExtraTasksSource.Add(Unselect[i]);
                }
            }

            
            UnselectedNormalList.ItemsSource = NormalTasksSource;
            UnselectedExtraList.ItemsSource = ExtraTasksSource;

            Select = new List<TaskStructure>();
        }
        public ScottL_Pg3(bool IGNORE, DataManager myData)
        {
            myParent = MetroWindow.GetWindow(this) as PageSwitcher;

            myTaskList = TaskSerializer.DeserializeTaskList();

            Select = myData.SelectedTasks.myTasks;

            InitializeComponent();

            ExtraTasks = new List<TaskStructure>();
            NormalTasks = new List<TaskStructure>();
            NormalTasksSource = new List<TaskStructure>();
            ExtraTasksSource = new List<TaskStructure>();

            Unselect = myTaskList.myTasks;

            for (int i = 0; i < Unselect.Count; i++)
            {
                bool noMatch = true;
                bool duplicate = false;
                for(int p = 0; p < Select.Count; p++)
                {
                    if((Select[p].Header == Unselect[i].Header))
                    {
                        duplicate = true;
                    }
                }
                if(!duplicate)
                {
                    for (int k = 0; k < Unselect[i].tags.Count; k++)
                    {
                        if (Unselect[i].tags[k] == myData.ProposalType)
                        {
                            NormalTasks.Add(Unselect[i]);
                            NormalTasksSource.Add(Unselect[i]);
                            noMatch = false;
                        }
                    }
                    if (noMatch)
                    {
                        ExtraTasks.Add(Unselect[i]);
                        ExtraTasksSource.Add(Unselect[i]);
                    }
                }
            }


            UnselectedNormalList.ItemsSource = NormalTasksSource;
            UnselectedExtraList.ItemsSource = ExtraTasksSource;
            SelectedList.ItemsSource = Select;
        }
        private void btn_ReturnToMain(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainWindow());
        }

        private void btn_RemoveTask(object sender, RoutedEventArgs e)
        {
            myParent = MetroWindow.GetWindow(this) as PageSwitcher;
            myData = new DataManager();
            myData = myParent.myData;
            if (SelectedList.SelectedValue != null)
            {
                TaskStructure currTask = SelectedList.SelectedValue as TaskStructure;
                int currItemIndex = SelectedList.SelectedIndex;
                bool nomatch = true;
                for(int i = 0; i < currTask.tags.Count; i++)
                {
                    if(currTask.tags[i] == myData.ProposalType)
                    {
                        NormalTasksSource.Add(currTask);
                        NormalTasksSource.Sort((x, y) => x.Header.CompareTo(y.Header));
                        UnselectedNormalList.ItemsSource = null;
                        UnselectedNormalList.ItemsSource = NormalTasksSource;
                        if (Select != null)
                        {
                            Select.RemoveAt(currItemIndex);
                        }
                        SelectedList.ItemsSource = null;
                        SelectedList.ItemsSource = Select;
                        nomatch = false;
                    }
                }
                        
                   
                if(nomatch)
                {
                    ExtraTasksSource.Add(currTask);
                    ExtraTasksSource.Sort((x, y) => x.Header.CompareTo(y.Header));
                    UnselectedExtraList.ItemsSource = null;
                    UnselectedExtraList.ItemsSource = ExtraTasksSource;
                    if (Select != null)
                    {
                        Select.RemoveAt(currItemIndex);
                    }
                    SelectedList.ItemsSource = null;
                    SelectedList.ItemsSource = Select;
                    nomatch = false;
                }


                //Unselect.Add(currTask);

                //UnselectedNormalList.ItemsSource = null;
                //UnselectedNormalList.ItemsSource = Unselect;

                //if (Select != null)
                //{
                //    Select.RemoveAt(currItemIndex);
                //}

                //SelectedList.ItemsSource = null;
                //SelectedList.ItemsSource = Select;
            }
        }

        private void btn_AddTask(object sender, RoutedEventArgs e)
        {
            if (UnselectedNormalList.SelectedValue != null)
            {
                TaskStructure currTask = UnselectedNormalList.SelectedValue as TaskStructure;
                int currItemIndex = UnselectedNormalList.SelectedIndex;

                Select.Add(currTask);


                SelectedList.ItemsSource = null;
                SelectedList.ItemsSource = Select;

                if (NormalTasksSource != null)
                {
                    NormalTasksSource.RemoveAt(currItemIndex);
                }

                UnselectedNormalList.ItemsSource = null;
                UnselectedNormalList.ItemsSource = NormalTasksSource;
                UnselectedNormalList.SelectedIndex = 0;
            }
            else if(UnselectedExtraList.SelectedValue != null)
            {
                TaskStructure currTask = UnselectedExtraList.SelectedValue as TaskStructure;
                int currItemIndex = UnselectedExtraList.SelectedIndex;

                Select.Add(currTask);


                SelectedList.ItemsSource = null;
                SelectedList.ItemsSource = Select;

                if (ExtraTasksSource != null)
                {
                    ExtraTasksSource.RemoveAt(currItemIndex);
                }

                UnselectedExtraList.ItemsSource = null;
                UnselectedExtraList.ItemsSource = ExtraTasksSource;
                UnselectedExtraList.SelectedIndex = 0;
            }
        }
        private void btn_NextPage(object sender, RoutedEventArgs e)
        {
            myParent = MetroWindow.GetWindow(this) as PageSwitcher;
            myData = new DataManager();
            myData = myParent.myData;
            myData.PAGE3VISIT = true;
            if (Select.Count >0)
            {
                
                for (int i = 0; i < Select.Count; i++)
                {
                    if (Select[i].fee == "%VARFEE%")
                    {

                    }
                }

                myData.SelectedTasks.myTasks = Select;

                Switcher.Switch(new ScottL_Pg4(myParent));
            }
            else
            {
                if(MessageBox.Show("You have no tasks selected, are you sure you want to continue?", "No Tasks", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    if(!myData.PAGE5VISIT)
                    {
                        Switcher.Switch(new ScottL_Pg5(myData));
                    }
                    else
                    {
                        Switcher.Switch(new ScottL_Pg5(false, myData));
                    }
                }
            }
            
            //DocumentController.WriteLetterProposal(myData);
        }
        private void btn_Back(object sender, RoutedEventArgs e)
        {
            myParent = MetroWindow.GetWindow(this) as PageSwitcher;
            myData = new DataManager();
            myData = myParent.myData;
            myData.PAGE3VISIT = true;
            Switcher.Switch(new ScottL_Pg2(false, myData));
        }

        private void btn_MoveUp(object sender, RoutedEventArgs e)
        {
            int index = SelectedList.SelectedIndex;
            if(index > 0)
            {
                TaskStructure item = SelectedList.SelectedItem as TaskStructure;
                Select[index] = Select[index - 1];
                Select[index - 1] = item;
                SelectedList.ItemsSource = null;
                SelectedList.ItemsSource = Select;
                SelectedList.SelectedIndex = index - 1;
            }
            
        }
        private void btn_MoveDown(object sender, RoutedEventArgs e)
        {
            int index = SelectedList.SelectedIndex;
            if (index < Select.Count-1)
            {
                TaskStructure item = SelectedList.SelectedItem as TaskStructure;
                Select[index] = Select[index + 1];
                Select[index + 1] = item;
                SelectedList.ItemsSource = null;
                SelectedList.ItemsSource = Select;
                SelectedList.SelectedIndex = index + 1;
            }
            
        }

        private void lb_ExtraSelectChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if(UnselectedExtraList.SelectedItem!= null)
            {
                UnselectedNormalList.UnselectAll();
            }
        }
        private void lb_NormalSelectChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (UnselectedNormalList.SelectedItem != null)
            {
                UnselectedExtraList.UnselectAll();
            }
        }
    }
}
