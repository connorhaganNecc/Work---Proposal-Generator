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
    /// Subtask selection for each selected task
    /// 
    /// TODO: 
    /// </summary>
    public partial class ContractP_Pg5 : UserControl
    {
        ContractDataManager myData;
        int currIndex = 0;
        ContractTask curTask;

        List<string> UnselectSource;
        List<string> SelectSource;

        List<ContractSubTask> UnselectedSubtasks;
        List<ContractSubTask> SelectedSubtasks;
        ContractTaskList officialList;

        public ContractP_Pg5(ContractDataManager inData)
        {
            InitializeComponent();
            inData.PAGE5VISIT = true;
            myData = inData;
            officialList = ContractTaskSerializer.DeserializeContractTasks();
            UnselectSource = new List<string>();
            SelectSource = new List<string>();
            UnselectedSubtasks = new List<ContractSubTask>();
            SelectedSubtasks = new List<ContractSubTask>();
            currIndex = 0;
            if(myData.myTaskList.Count > 0)
            {
                bool found = false;
                for(int i = 0; i < officialList.myTasks.Count; i++)
                {
                    if(officialList.myTasks[i].HeadLevelItem == myData.myTaskList[currIndex].HeadLevelItem)
                    {
                        officialList.myTasks[i].HeadLevelItem = officialList.myTasks[i].HeadLevelItem;
                        curTask = officialList.myTasks[i];
                        found = true;
                    }
                    else
                    {
                        
                    }
                }
                if(!found)
                {
                    MessageBox.Show("MAJOR ERROR PLEASE CONTACT CONNOR");
                }
                //If the task allows subtasks
                if(curTask.allowsSubTasks)
                {
                    HeaderLabel.Content = curTask.HeadLevelItem;
                    if (myData.myTaskList[currIndex].subTasks.Count > 0)
                    {
                        for (int l = 0; l < myData.myTaskList[currIndex].subTasks.Count; l++)
                        {
                            //If its not already in the list, add it
                            if (!SelectSource.Contains(myData.myTaskList[currIndex].subTasks[l].name))
                                SelectSource.Add(myData.myTaskList[currIndex].subTasks[l].name);
                        }
                        for (int i = 0; i < curTask.subTasks.Count; i++)
                        {
                            bool match = false;
                            for (int l = 0; l < SelectSource.Count; l++)
                            {
                                if (curTask.subTasks[i].name == SelectSource[l])
                                {
                                    match = true;
                                }
                            }
                            if (!match)
                            {
                                UnselectSource.Add(curTask.subTasks[i].name);
                            }

                        }
                    }
                    else
                    {
                        for (int i = 0; i < curTask.subTasks.Count; i++)
                        {
                            UnselectSource.Add(curTask.subTasks[i].name);
                        }
                    }
                }
                //Else move to the next one
                else
                {
                    btn_NextPage(null, null);
                }
            }
            SelectedList.ItemsSource = SelectSource;
            UnselectedNormalList.ItemsSource = UnselectSource;

            //            officialList = ContractTaskSerializer.DeserializeContractTasks();

            //            myData = inData;
            //            ContractTaskList myList = ContractTaskSerializer.DeserializeContractTasks();

            //            Unselect = myList.myTasks;

            //            UnselectSource = new List<string>();
            //            for(int i = 0; i < Unselect.Count; i++)
            //            {
            //                UnselectSource.Add(Unselect[i].HeadLevelItem);

            //            }

            //            UnselectedNormalList.ItemsSource = UnselectSource;
            //            Select = new List<ContractTask>();
            //            SelectedList.ItemsSource = SelectSource;
        }
        public ContractP_Pg5(bool IGNORE, ContractDataManager inData)
        {
            InitializeComponent();
            myData = inData;
            officialList = ContractTaskSerializer.DeserializeContractTasks();
            UnselectSource = new List<string>();
            SelectSource = new List<string>();
            UnselectedSubtasks = new List<ContractSubTask>();
            SelectedSubtasks = new List<ContractSubTask>();
            currIndex = 0;
            if (myData.myTaskList.Count > 0)
            {
                bool found = false;
                for (int i = 0; i < officialList.myTasks.Count; i++)
                {
                    if (officialList.myTasks[i].HeadLevelItem == myData.myTaskList[currIndex].HeadLevelItem)
                    {
                        curTask = officialList.myTasks[i];
                        found = true;
                    }
                    else
                    {

                    }
                }
                if (!found)
                {
                    MessageBox.Show("MAJOR ERROR PLEASE CONTACT CONNOR");
                }
                //If the task allows subtasks
                if (curTask.allowsSubTasks)
                {
                    HeaderLabel.Content = curTask.HeadLevelItem;
                    if (myData.myTaskList[currIndex].subTasks.Count > 0)
                    {
                        for (int l = 0; l < myData.myTaskList[currIndex].subTasks.Count; l++)
                        {
                            //If its not already in the list, add it
                            if (!SelectSource.Contains(myData.myTaskList[currIndex].subTasks[l].name))
                                SelectSource.Add(myData.myTaskList[currIndex].subTasks[l].name);
                        }
                        for (int i = 0; i < curTask.subTasks.Count; i++)
                        {
                            bool match = false;
                            for (int l = 0; l < SelectSource.Count; l++)
                            {
                                if (curTask.subTasks[i].name == SelectSource[l])
                                {
                                    match = true;
                                }
                            }
                            if (!match)
                            {
                                UnselectSource.Add(curTask.subTasks[i].name);
                            }

                        }
                    }
                    else
                    {
                        for (int i = 0; i < curTask.subTasks.Count; i++)
                        {
                            UnselectSource.Add(curTask.subTasks[i].name);
                        }
                    }
                }
                //Else move to the next one
                else
                {
                    btn_NextPage(null, null);
                }
            }
            SelectedList.ItemsSource = SelectSource;
            UnselectedNormalList.ItemsSource = UnselectSource;
            //            InitializeComponent();

            //            myData = inData;
            //            ContractTaskList myList = ContractTaskSerializer.DeserializeContractTasks();
            //            List<string> tempList = new List<string>();
            //            for (int i = 0; i < myList.myTasks.Count; i++)
            //            {
            //                for (int j = 0; j < myData.myTaskList.Count; j++)
            //                {
            //                    if(myList.myTasks[i].HeadLevelItem == myData.myTaskList[j].HeadLevelItem)
            //                    {
            //                        myList.myTasks.RemoveAt(i);
            //                        j = 9999;
            //                    }
            //                }    
            //            }
            //            Unselect = myList.myTasks;

            //            UnselectedNormalList.ItemsSource = Unselect;
            //            Select = myData.myTaskList;
            //            SelectedList.ItemsSource = Select;
        }
        private void btn_ReturnToMain(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainWindow());
        }

        private void btn_RemoveTask(object sender, RoutedEventArgs e)
        {
            if (SelectedList.SelectedIndex >= 0)
            {
                string temp = SelectedList.SelectedValue.ToString();
                ContractSubTask tempTask = null;

                for (int i = 0; i < curTask.subTasks.Count; i++)
                {
                    if (curTask.subTasks[i].name == temp)
                    {
                        tempTask = curTask.subTasks[i];
                        i = 100000;
                    }
                }
                for (int i = 0; i < SelectSource.Count; i++)
                {
                    if (SelectSource[i] == tempTask.name)
                    {
                        SelectSource.RemoveAt(i);
                        i = 99999;
                    }
                }

                UnselectSource.Add(tempTask.name);

                SelectedList.ItemsSource = null;
                UnselectedNormalList.ItemsSource = null;

                SelectedList.ItemsSource = SelectSource;
                UnselectedNormalList.ItemsSource = UnselectSource;
                //myParent = MetroWindow.GetWindow(this) as PageSwitcher;
                //myData = new ContractDataManager();
                //myData = myParent.contractData;
                //if (SelectedList.SelectedValue != null)
                //{
                //    string temp = SelectedList.SelectedValue.ToString();

                //    ContractTask tempTask = null;

                //    for (int i = 0; i < officialList.myTasks.Count; i++)
                //    {
                //        if (officialList.myTasks[i].HeadLevelItem == temp)
                //        {
                //            tempTask = officialList.myTasks[i];
                //            i = 9999;
                //        }
                //    }

                //    for (int i = 0; i < SelectSource.Count; i++)
                //    {
                //        if (SelectSource[i] == tempTask.HeadLevelItem)
                //        {
                //            SelectSource.RemoveAt(i);
                //            i = 9999;
                //        }
                //    }

                //    UnselectSource.Add(tempTask.HeadLevelItem);

                //    UnselectedNormalList.ItemsSource = null;
                //    SelectedList.ItemsSource = null;

                //    UnselectedNormalList.ItemsSource = UnselectSource;
                //    SelectedList.ItemsSource = SelectSource;

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
            if (UnselectedNormalList.SelectedIndex >= 0)
            {
                string temp = UnselectedNormalList.SelectedValue.ToString();
                ContractSubTask tempTask = null;
                
                for(int i = 0; i < curTask.subTasks.Count; i++)
                {
                    if(curTask.subTasks[i].name == temp)
                    {
                        tempTask = curTask.subTasks[i];
                        i = 100000;
                    }
                }
                for(int i = 0; i < UnselectSource.Count;i++)
                {
                    if(UnselectSource[i] == tempTask.name)
                    {
                        UnselectSource.RemoveAt(i);
                        i = 99999;
                    }
                }

                SelectSource.Add(tempTask.name);

                SelectedList.ItemsSource = null;
                UnselectedNormalList.ItemsSource = null;

                SelectedList.ItemsSource = SelectSource;
                UnselectedNormalList.ItemsSource = UnselectSource;

            }
        }
        private void btn_NextPage(object sender, RoutedEventArgs e)
        {
            //STORE PERVIOUS STUFF HERE
            for(int i = 0; i < SelectSource.Count; i++)
            {
                for(int k = 0; k < curTask.subTasks.Count; k++)
                {
                    if(SelectSource[i] == curTask.subTasks[k].name)
                    {
                        ContractSubTask tempSubtask = new ContractSubTask();
                        tempSubtask.allowSubSub = curTask.subTasks[k].allowSubSub;
                        tempSubtask.myClass = curTask.subTasks[k].myClass;
                        tempSubtask.name = curTask.subTasks[k].name;
                        tempSubtask.text = curTask.subTasks[k].text;
                        tempSubtask.rtfText = curTask.subTasks[k].rtfText;

                        myData.myTaskList[currIndex].subTasks.Add(tempSubtask);
                    }
                }
            }


            currIndex++;
            
            if (currIndex < myData.myTaskList.Count)
            {
                bool found = false;
                UnselectSource = new List<string>();
                SelectSource = new List<string>();
                UnselectedSubtasks = new List<ContractSubTask>();
                SelectedSubtasks = new List<ContractSubTask>();
                //Setting current task
                for (int i = 0; i < officialList.myTasks.Count; i++)
                {
                    if (officialList.myTasks[i].HeadLevelItem == myData.myTaskList[currIndex].HeadLevelItem)
                    {
                        curTask = officialList.myTasks[i];
                        found = true;
                    }
                }
                if (!found)
                {
                    MessageBox.Show("MAJOR ERROR PLEASE CONTACT CONNOR");
                }
                //If the task allows subtasks
                if (curTask.allowsSubTasks)
                {
                    HeaderLabel.Content = curTask.HeadLevelItem;
                    if (myData.myTaskList[currIndex].subTasks.Count >0)
                    {
                        for(int l = 0; l < myData.myTaskList[currIndex].subTasks.Count; l++)
                        {
                            //If its not already in the list, add it
                            if(!SelectSource.Contains(myData.myTaskList[currIndex].subTasks[l].name))
                                SelectSource.Add(myData.myTaskList[currIndex].subTasks[l].name);
                        }
                        for (int i = 0; i < curTask.subTasks.Count; i++)
                        {
                            bool match = false;
                            for (int l = 0; l < SelectSource.Count; l++)
                            {
                                if(curTask.subTasks[i].name == SelectSource[l])
                                {
                                    match = true;
                                }
                            }
                            if(!match)
                            {
                                UnselectSource.Add(curTask.subTasks[i].name);
                            }
                            
                        }
                    }
                    else
                    {
                        for (int i = 0; i < curTask.subTasks.Count; i++)
                        {
                            UnselectSource.Add(curTask.subTasks[i].name);
                        }
                    }
                   
                }
                //Else move to the next one
                else
                {
                    btn_NextPage(null, null);
                }
            }
            else
            {
                bool found = false;
                for(int i = 0; i < myData.myTaskList.Count; i++)
                {
                    for(int j = 0; j < myData.myTaskList[i].subTasks.Count; j++)
                    {
                        if(myData.myTaskList[i].subTasks[j].allowSubSub)
                        {
                            myData.hasSubSubtasks = true;
                            found = true;
                        }
                    }
                }
                if(!found)
                {
                    myData.hasSubSubtasks = false;
                }
                if(!myData.PAGE6VISIT && myData.hasSubSubtasks)
                {
                    Switcher.Switch(new ContractP_Pg6(myData));
                }
                else if(myData.PAGE6VISIT && myData.hasSubSubtasks)
                {
                    Switcher.Switch(new ContractP_Pg6(false, myData));
                }
                else if(!myData.PAGE7VISIT && !myData.hasSubSubtasks)
                {
                    Switcher.Switch(new ContractP_Pg7(myData));
                }
                else
                {
                    Switcher.Switch(new ContractP_Pg7(false, myData));
                }
            }
            UnselectedNormalList.ItemsSource = null;
            UnselectedNormalList.ItemsSource = UnselectSource;
            SelectedList.ItemsSource = null;
            SelectedList.ItemsSource = SelectSource;
            //            myParent = MetroWindow.GetWindow(this) as PageSwitcher;
            //            myData = new ContractDataManager();
            //            myData = myParent.contractData;
            //            myData.PAGE4VISIT = true;
            //            if (SelectSource.Count > 0)
            //            {
            //                List<ContractTask> MyTaskList = new List<ContractTask>();
            //                for(int i = 0; i < SelectSource.Count; i++)
            //                {
            //                    for(int j = 0; j < officialList.myTasks.Count; j++)
            //                    {
            //                        if(SelectSource[i] == officialList.myTasks[j].HeadLevelItem)
            //                        {
            //                            MyTaskList.Add(officialList.myTasks[j]);
            //                            j = 10000;
            //                        }
            //                    }
            //                }

            //                myData.myTaskList = MyTaskList;
            //                Switcher.Switch(new ContractP_Pg5(myData));

            //                //    myData.myTaskList = Select;

            //                //    Switcher.Switch(new ScottL_Pg4(myParent));
            //                //}
            //                //else
            //                //{
            //                //    if(MessageBox.Show("You have no tasks selected, are you sure you want to continue?", "No Tasks", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            //                //    {
            //                //        if(!myData.PAGE5VISIT)
            //                //        {
            //                //            //Switcher.Switch(new ScottL_Pg5(myData));
            //                //        }
            //                //        else
            //                //        {
            //                //            //Switcher.Switch(new ScottL_Pg5(false, myData));
            //                //        }
            //                //    }
            //                //}

            //                //DocumentController.WriteLetterProposal(myData);
            //            }
        }
        private void btn_Back(object sender, RoutedEventArgs e)
        {
            if(currIndex >= myData.myTaskList.Count)
            {
                currIndex = myData.myTaskList.Count - 1;
            }
            //STORE PERVIOUS STUFF HERE
            for (int i = 0; i < SelectSource.Count; i++)
            {
                for (int k = 0; k < curTask.subTasks.Count; k++)
                {
                    if (SelectSource[i] == curTask.subTasks[k].name)
                    {
                        ContractSubTask tempSubtask = new ContractSubTask();
                        tempSubtask.allowSubSub = curTask.subTasks[k].allowSubSub;
                        tempSubtask.myClass = curTask.subTasks[k].myClass;
                        tempSubtask.name = curTask.subTasks[k].name;
                        tempSubtask.text = curTask.subTasks[k].text;
                        tempSubtask.rtfText = curTask.subTasks[k].rtfText;

                        myData.myTaskList[currIndex].subTasks.Add(tempSubtask);
                    }
                }
            }

            currIndex--;
            if (currIndex >= 0)
            {
                bool found = false;
                UnselectSource = new List<string>();
                SelectSource = new List<string>();
                UnselectedSubtasks = new List<ContractSubTask>();
                SelectedSubtasks = new List<ContractSubTask>();

                for (int i = 0; i < officialList.myTasks.Count; i++)
                {
                    if (officialList.myTasks[i].HeadLevelItem == myData.myTaskList[currIndex].HeadLevelItem)
                    {
                        curTask = officialList.myTasks[i];
                        found = true;
                    }
                }
                if (!found)
                {
                    MessageBox.Show("MAJOR ERROR PLEASE CONTACT CONNOR");
                }
                //If the task allows subtasks
                if (curTask.allowsSubTasks)
                {
                    HeaderLabel.Content = curTask.HeadLevelItem;
                    if (myData.myTaskList[currIndex].subTasks.Count > 0)
                    {
                        for (int l = 0; l < myData.myTaskList[currIndex].subTasks.Count; l++)
                        {
                            //If its not already in the list, add it
                            if (!SelectSource.Contains(myData.myTaskList[currIndex].subTasks[l].name))
                                SelectSource.Add(myData.myTaskList[currIndex].subTasks[l].name);
                        }
                        for (int i = 0; i < curTask.subTasks.Count; i++)
                        {
                            bool match = false;
                            for (int l = 0; l < SelectSource.Count; l++)
                            {
                                if (curTask.subTasks[i].name == SelectSource[l])
                                {
                                    match = true;
                                }
                            }
                            if (!match)
                            {
                                UnselectSource.Add(curTask.subTasks[i].name);
                            }

                        }
                    }
                    else
                    {
                        for (int i = 0; i < curTask.subTasks.Count; i++)
                        {
                            UnselectSource.Add(curTask.subTasks[i].name);
                        }
                    }
                }
                //Else move to the next one
                else
                {
                    btn_Back(null, null);
                }
            }
            else
            {
                Switcher.Switch(new ContractP_Pg4(false, myData));
            }
            UnselectedNormalList.ItemsSource = null;
            UnselectedNormalList.ItemsSource = UnselectSource;
            SelectedList.ItemsSource = null;
            SelectedList.ItemsSource = SelectSource;
            //            myParent = MetroWindow.GetWindow(this) as PageSwitcher;
            //            myData = new ContractDataManager();
            //            myData = myParent.contractData;
            //            myData.PAGE3VISIT = true;
            //            Switcher.Switch(new ContractP_Pg3(false, myData));
        }

        private void btn_MoveUp(object sender, RoutedEventArgs e)
        {
            //            int index = SelectedList.SelectedIndex;
            //            if (index > 0)
            //            {
            //                string item = SelectedList.SelectedItem.ToString();
            //                SelectSource[index] = SelectSource[index - 1];
            //                SelectSource[index - 1] = item;
            //                SelectedList.ItemsSource = null;
            //                SelectedList.ItemsSource = SelectSource;
            //                SelectedList.SelectedIndex = index - 1;
        }

        //        }
        private void btn_MoveDown(object sender, RoutedEventArgs e)
        {
            //            int index = SelectedList.SelectedIndex;
            //            if (index < SelectSource.Count - 1)
            //            {
            //                string item = SelectedList.SelectedItem.ToString();
            //                SelectSource[index] = SelectSource[index + 1];
            //                SelectSource[index + 1] = item;
            //                SelectedList.ItemsSource = null;
            //                SelectedList.ItemsSource = SelectSource;
            //                SelectedList.SelectedIndex = index + 1;
            //            }

        }

        private void lb_ExtraSelectChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
        private void lb_NormalSelectChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
}
}

