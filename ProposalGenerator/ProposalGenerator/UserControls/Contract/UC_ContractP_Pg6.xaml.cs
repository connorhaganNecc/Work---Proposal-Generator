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
    /// Interaction logic for ContractP_Pg5.xaml
    /// 
    /// Sub-Subtask
    /// 
    /// TODO: 
    /// </summary>
    public partial class ContractP_Pg6 : UserControl
    {
        ContractDataManager myData;
        int currentTaskIndex = 0;
        int currentSubtaskIndex = 0;
        
        bool nextPage = false;
        List<string> selectedList;
        List<string> unselect;

        public ContractP_Pg6(ContractDataManager inData)
        {
            InitializeComponent();
            myData = inData;

            myData.PAGE6VISIT = true;
            unselect = new List<string>();
            selectedList = new List<string>();
            nextItem();
        }
        public ContractP_Pg6(bool IGNORE, ContractDataManager inData)
        {
            InitializeComponent();
            myData = inData;

            myData.PAGE6VISIT = true;
            unselect = new List<string>();
            selectedList = new List<string>();
            nextItem();
        }
        private void nextItem()
        {
            bool done = false;
            int count = 0;
            if (currentTaskIndex < myData.myTaskList.Count)
            {
                if (currentSubtaskIndex < myData.myTaskList[currentTaskIndex].subTasks.Count)
                {
                    if (myData.myTaskList[currentTaskIndex].subTasks[currentSubtaskIndex].allowSubSub)
                    {
                        List<ContractTask> officialList = ContractTaskSerializer.DeserializeContractTasks().myTasks;
                        for (int i = 0; i < officialList.Count; i++)
                        {
                            if (officialList[i].HeadLevelItem == myData.myTaskList[currentTaskIndex].HeadLevelItem)
                            {
                                for (int j = 0; j < officialList[i].subTasks.Count; j++)
                                {
                                    if (officialList[i].subTasks[j].name == myData.myTaskList[currentTaskIndex].subTasks[currentSubtaskIndex].name)
                                    {
                                        if (selectedList.Count > 0)
                                        {
                                            myData.myTaskList[currentTaskIndex].subTasks[currentSubtaskIndex].SubItems = new List<SubSubtask>();
                                            for (int k = 0; k < selectedList.Count; k++)
                                            {
                                                for (int p = 0; p < officialList[i].subTasks[j].SubItems.Count; p++)
                                                {
                                                    if (selectedList[k] == officialList[i].subTasks[j].SubItems[p].name)
                                                    {
                                                        count++;
                                                        myData.myTaskList[currentTaskIndex].subTasks[currentSubtaskIndex].SubItems.Add(officialList[i].subTasks[j].SubItems[p]);
                                                        count = myData.myTaskList[currentTaskIndex].subTasks[currentSubtaskIndex].SubItems.Count;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            while (!done)
            {
                if (currentTaskIndex < myData.myTaskList.Count)
                {
                    if (myData.myTaskList[currentTaskIndex].allowsSubTasks)
                    {
                        if (currentSubtaskIndex < myData.myTaskList[currentTaskIndex].subTasks.Count)
                        {
                            if (myData.myTaskList[currentTaskIndex].subTasks[currentSubtaskIndex].allowSubSub)
                            {
                                done = true;
                            }
                            else
                            {
                                currentSubtaskIndex++;
                            }
                        }
                        else
                        {
                            currentTaskIndex++;
                            currentSubtaskIndex = 0;
                        }
                    }
                    else
                    {
                        currentTaskIndex++;
                    }
                }
                else
                {
                    done = true;
                    nextPage = true;
                }
            }

            if (done && !nextPage)
            {
                HeaderLabel.Content = myData.myTaskList[currentTaskIndex].subTasks[currentSubtaskIndex].name;
                List<ContractTask> officialList = ContractTaskSerializer.DeserializeContractTasks().myTasks;
                for (int i = 0; i < officialList.Count; i++)
                {
                    if (officialList[i].HeadLevelItem == myData.myTaskList[currentTaskIndex].HeadLevelItem)
                    {
                        for (int j = 0; j < officialList[i].subTasks.Count; j++)
                        {
                            if (officialList[i].subTasks[j].name == myData.myTaskList[currentTaskIndex].subTasks[currentSubtaskIndex].name)
                            {
                                for (int k = 0; k < officialList[i].subTasks[j].SubItems.Count; k++)
                                {
                                    unselect.Add(officialList[i].subTasks[j].SubItems[k].name);
                                }
                            }
                        }
                    }

                }
            }

            if(nextPage)
            {
                currentSubtaskIndex = 1000000;
                currentTaskIndex = 100000000;
                navigateNext();
            }
            UnselectedNormalList.ItemsSource = unselect;
            SelectedList.ItemsSource = selectedList;
        }

        private void btn_ReturnToMain(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainWindow());
        }

        private void btn_RemoveTask(object sender, RoutedEventArgs e)
        {
            if(SelectedList.SelectedItem!= null)
            {
                selectedList.RemoveAt(SelectedList.SelectedIndex);
            }

            SelectedList.ItemsSource = null;
            SelectedList.ItemsSource = selectedList;
        }


        private void btn_AddTask(object sender, RoutedEventArgs e)
        {
            if(UnselectedNormalList.SelectedItem != null)
            {
                selectedList.Add(UnselectedNormalList.SelectedItem.ToString());
            }
            SelectedList.ItemsSource = null;
            SelectedList.ItemsSource = selectedList;
        }
        private void btn_NextPage(object sender, RoutedEventArgs e)
        {
            if(!nextPage)
            {
                nextItem();
            }
            else
            {
                navigateNext();
            }
        }
        private void btn_Back(object sender, RoutedEventArgs e)
        {
            
        }

        private void btn_MoveUp(object sender, RoutedEventArgs e)
        {
           
        }

        private void btn_MoveDown(object sender, RoutedEventArgs e)
        {

        }

        private void lb_ExtraSelectChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
        private void lb_NormalSelectChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
        private void navigateNext()
        {

                if (!myData.PAGE7VISIT)
                {
                    Switcher.Switch(new ContractP_Pg7(myData));
                }
                else
                {
                    Switcher.Switch(new ContractP_Pg7(false, myData));
                }
        }
}
}

