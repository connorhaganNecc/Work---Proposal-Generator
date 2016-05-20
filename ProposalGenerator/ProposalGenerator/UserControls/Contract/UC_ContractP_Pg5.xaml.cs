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
    public partial class ContractP_Pg5 : UserControl
    {
        PageSwitcher myParent;
        ContractDataManager myData;
        int currIndex = 0;

        ContractTaskList officialList;
        
        public ContractP_Pg5(ContractDataManager inData)
        {
            InitializeComponent();
            UnselectSource = new List<string>();
            SelectSource = new List<string>();

            officialList = ContractTaskSerializer.DeserializeContractTasks();

            myData = inData;
            ContractTaskList myList = ContractTaskSerializer.DeserializeContractTasks();

            Unselect = myList.myTasks;

            UnselectSource = new List<string>();
            for(int i = 0; i < Unselect.Count; i++)
            {
                UnselectSource.Add(Unselect[i].HeadLevelItem);
                
            }

            UnselectedNormalList.ItemsSource = UnselectSource;
            Select = new List<ContractTask>();
            SelectedList.ItemsSource = SelectSource;
        }
        public ContractP_Pg5(bool IGNORE, ContractDataManager inData)
        { 
            InitializeComponent();

            myData = inData;
            ContractTaskList myList = ContractTaskSerializer.DeserializeContractTasks();
            List<string> tempList = new List<string>();
            for (int i = 0; i < myList.myTasks.Count; i++)
            {
                for (int j = 0; j < myData.myTaskList.Count; j++)
                {
                    if(myList.myTasks[i].HeadLevelItem == myData.myTaskList[j].HeadLevelItem)
                    {
                        myList.myTasks.RemoveAt(i);
                        j = 9999;
                    }
                }    
            }
            Unselect = myList.myTasks;

            UnselectedNormalList.ItemsSource = Unselect;
            Select = myData.myTaskList;
            SelectedList.ItemsSource = Select;
        }
        private void btn_ReturnToMain(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainWindow());
        }

        private void btn_RemoveTask(object sender, RoutedEventArgs e)
        {
            myParent = MetroWindow.GetWindow(this) as PageSwitcher;
            myData = new ContractDataManager();
            myData = myParent.contractData;
            if (SelectedList.SelectedValue != null)
            {
                string temp = SelectedList.SelectedValue.ToString();

                ContractTask tempTask = null;
                
                for(int i = 0; i < officialList.myTasks.Count;i++)
                {
                    if(officialList.myTasks[i].HeadLevelItem == temp)
                    {
                        tempTask = officialList.myTasks[i];
                        i = 9999;
                    }
                }

                for(int i = 0; i < SelectSource.Count; i++)
                {
                    if(SelectSource[i] == tempTask.HeadLevelItem)
                    {
                        SelectSource.RemoveAt(i);
                        i = 9999;
                    }
                }

                UnselectSource.Add(tempTask.HeadLevelItem);

                UnselectedNormalList.ItemsSource = null;
                SelectedList.ItemsSource = null;

                UnselectedNormalList.ItemsSource = UnselectSource;
                SelectedList.ItemsSource = SelectSource;

                //ContractTask currTask = SelectedList.SelectedValue as ContractTask;
                //int currItemIndex = SelectedList.SelectedIndex;

                //Unselect.Add(currTask);
                //Unselect.Sort((x, y) => x.HeadLevelItem.CompareTo(y.HeadLevelItem));
                //UnselectedNormalList.ItemsSource = null;
                //UnselectedNormalList.ItemsSource = Unselect;
                //if (Select != null)
                //{
                //    Select.RemoveAt(currItemIndex);
                //}
                //SelectedList.ItemsSource = null;
                //SelectedList.ItemsSource = Select;






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
                string temp = UnselectedNormalList.SelectedValue.ToString();

                ContractTask tempTask = null;

                for (int i = 0; i < officialList.myTasks.Count; i++)
                {
                    if (officialList.myTasks[i].HeadLevelItem == temp)
                    {
                        tempTask = officialList.myTasks[i];
                        i = 9999;
                    }
                }

                for (int i = 0; i < UnselectSource.Count; i++)
                {
                    if (UnselectSource[i] == tempTask.HeadLevelItem)
                    {
                        UnselectSource.RemoveAt(i);
                        i = 9999;
                    }
                }

                SelectSource.Add(tempTask.HeadLevelItem);

                UnselectedNormalList.ItemsSource = null;
                SelectedList.ItemsSource = null;

                UnselectedNormalList.ItemsSource = UnselectSource;
                SelectedList.ItemsSource = SelectSource;
                //    ContractTask currTask = UnselectedNormalList.SelectedValue as ContractTask;
                //    int currItemIndex = UnselectedNormalList.SelectedIndex;

                //    Select.Add(currTask);


                //    SelectedList.ItemsSource = null;
                //    SelectedList.ItemsSource = Select;

                //    if (Unselect != null)
                //    {
                //        Unselect.RemoveAt(currItemIndex);
                //    }

                //    UnselectedNormalList.ItemsSource = null;
                //    UnselectedNormalList.ItemsSource = Unselect;
                //    UnselectedNormalList.SelectedIndex = 0;
            }

        }
        private void btn_NextPage(object sender, RoutedEventArgs e)
        {
            myParent = MetroWindow.GetWindow(this) as PageSwitcher;
            myData = new ContractDataManager();
            myData = myParent.contractData;
            myData.PAGE4VISIT = true;
            if (SelectSource.Count > 0)
            {
                List<ContractTask> MyTaskList = new List<ContractTask>();
                for(int i = 0; i < SelectSource.Count; i++)
                {
                    for(int j = 0; j < officialList.myTasks.Count; j++)
                    {
                        if(SelectSource[i] == officialList.myTasks[j].HeadLevelItem)
                        {
                            MyTaskList.Add(officialList.myTasks[j]);
                            j = 10000;
                        }
                    }
                }

                myData.myTaskList = MyTaskList;
                Switcher.Switch(new ContractP_Pg5(myData));

                //    myData.myTaskList = Select;

                //    Switcher.Switch(new ScottL_Pg4(myParent));
                //}
                //else
                //{
                //    if(MessageBox.Show("You have no tasks selected, are you sure you want to continue?", "No Tasks", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                //    {
                //        if(!myData.PAGE5VISIT)
                //        {
                //            //Switcher.Switch(new ScottL_Pg5(myData));
                //        }
                //        else
                //        {
                //            //Switcher.Switch(new ScottL_Pg5(false, myData));
                //        }
                //    }
                //}

                //DocumentController.WriteLetterProposal(myData);
            }
        }
        private void btn_Back(object sender, RoutedEventArgs e)
        {
            myParent = MetroWindow.GetWindow(this) as PageSwitcher;
            myData = new ContractDataManager();
            myData = myParent.contractData;
            myData.PAGE3VISIT = true;
            Switcher.Switch(new ContractP_Pg3(false, myData));
        }

        private void btn_MoveUp(object sender, RoutedEventArgs e)
        {
            int index = SelectedList.SelectedIndex;
            if (index > 0)
            {
                string item = SelectedList.SelectedItem.ToString();
                SelectSource[index] = SelectSource[index - 1];
                SelectSource[index - 1] = item;
                SelectedList.ItemsSource = null;
                SelectedList.ItemsSource = SelectSource;
                SelectedList.SelectedIndex = index - 1;
            }

        }
        private void btn_MoveDown(object sender, RoutedEventArgs e)
        {
            int index = SelectedList.SelectedIndex;
            if (index < SelectSource.Count - 1)
            {
                string item = SelectedList.SelectedItem.ToString();
                SelectSource[index] = SelectSource[index + 1];
                SelectSource[index + 1] = item;
                SelectedList.ItemsSource = null;
                SelectedList.ItemsSource = SelectSource;
                SelectedList.SelectedIndex = index + 1;
            }

        }

        private void lb_ExtraSelectChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
        private void lb_NormalSelectChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
