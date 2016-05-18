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
    public partial class ContractP_Pg4 : UserControl
    {
        PageSwitcher myParent;
        ContractDataManager myData;
        TaskList myTaskList;
        List<ContractTask> Unselect;
        List<ContractTask> Select;
        
        public ContractP_Pg4(DataManager myData)
        {
            myParent = MetroWindow.GetWindow(this) as PageSwitcher;

            myTaskList = TaskSerializer.DeserializeTaskList();
            InitializeComponent();

            Unselect = new BasicContractTasks().ContractTaskList;
           

            
            UnselectedNormalList.ItemsSource = Unselect;

            Select = new List<ContractTask>();
            SelectedList.ItemsSource = Select;
        }
        public ContractP_Pg4(bool IGNORE, ContractDataManager myData)
        {
            myParent = MetroWindow.GetWindow(this) as PageSwitcher;

            myTaskList = TaskSerializer.DeserializeTaskList();

            Select = myData.myTaskList;

            InitializeComponent();

            Unselect = new BasicContractTasks().ContractTaskList;

            for (int i = 0; i < Unselect.Count; i++)
            {
                bool noMatch = true;
                bool duplicate = false;
                for(int p = 0; p < Select.Count; p++)
                {
                    if((Select[p].HeadLevelItem == Unselect[i].HeadLevelItem))
                    {
                        duplicate = true;
                    }
                }
                if(duplicate)
                {
                    Unselect.RemoveAt(i);
                }
            }


            UnselectedNormalList.ItemsSource = Unselect;
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
                ContractTask currTask = SelectedList.SelectedValue as ContractTask;
                int currItemIndex = SelectedList.SelectedIndex;
                
                Unselect.Add(currTask);
                Unselect.Sort((x, y) => x.HeadLevelItem.CompareTo(y.HeadLevelItem));
                UnselectedNormalList.ItemsSource = null;
                UnselectedNormalList.ItemsSource = Unselect;
                if (Select != null)
                {
                    Select.RemoveAt(currItemIndex);
                }
                SelectedList.ItemsSource = null;
                SelectedList.ItemsSource = Select;
                              
                        
                   
                


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
                ContractTask currTask = UnselectedNormalList.SelectedValue as ContractTask;
                int currItemIndex = UnselectedNormalList.SelectedIndex;

                Select.Add(currTask);


                SelectedList.ItemsSource = null;
                SelectedList.ItemsSource = Select;

                if (Unselect != null)
                {
                    Unselect.RemoveAt(currItemIndex);
                }

                UnselectedNormalList.ItemsSource = null;
                UnselectedNormalList.ItemsSource = Unselect;
                UnselectedNormalList.SelectedIndex = 0;
            }
            
        }
        private void btn_NextPage(object sender, RoutedEventArgs e)
        {
            myParent = MetroWindow.GetWindow(this) as PageSwitcher;
            myData = new ContractDataManager();
            myData = myParent.contractData;
            myData.PAGE3VISIT = true;
            if (Select.Count >0)
            {
                

                myData.myTaskList = Select;

                Switcher.Switch(new ScottL_Pg4(myParent));
            }
            else
            {
                if(MessageBox.Show("You have no tasks selected, are you sure you want to continue?", "No Tasks", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    if(!myData.PAGE5VISIT)
                    {
                        //Switcher.Switch(new ScottL_Pg5(myData));
                    }
                    else
                    {
                        //Switcher.Switch(new ScottL_Pg5(false, myData));
                    }
                }
            }
            
            //DocumentController.WriteLetterProposal(myData);
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
            if(index > 0)
            {
                ContractTask item = SelectedList.SelectedItem as ContractTask;
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
                ContractTask item = SelectedList.SelectedItem as ContractTask;
                Select[index] = Select[index + 1];
                Select[index + 1] = item;
                SelectedList.ItemsSource = null;
                SelectedList.ItemsSource = Select;
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
