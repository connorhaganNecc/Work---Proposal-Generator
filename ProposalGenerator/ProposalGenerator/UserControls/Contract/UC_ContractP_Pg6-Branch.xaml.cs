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
    ///

    
    public partial class ContractP_Pg6_Branch : UserControl
    {
        List<bool[]> hasChecked;
        ContractDataManager myData;
        int currentTaskIndex = 0;
        int currentSubtaskIndex = 0;
        int currentSubSubtaskIndex = 0;
        int currentMax = 0;

        SubSubtask currentTask;
        
        
        bool nextPage = false;

        public ContractP_Pg6_Branch(ContractDataManager inData)
        {
            InitializeComponent();
            myData = inData;
            hasChecked = new List<bool[]>();
            if (myData.myTaskList.Count <= 0)
            {
                nextPage = true;
            }
            nextItem();
            
            //myData = inData;
            //for (int i = 0; i < myData.myTaskList.Count; i++)
            //{
            //    int count = myData.myTaskList[i].subTasks.Count;
            //    hasChecked.Add(new bool[count]);
            //}
            
            //nextItem();
            
        }
        public ContractP_Pg6_Branch(bool IGNORE, ContractDataManager inData)
        {
            InitializeComponent();
            hasChecked = new List<bool[]>();
            myData = inData;
            for (int i = 0; i < myData.myTaskList.Count; i++)
            {
                int count = myData.myTaskList[i].subTasks.Count;
                hasChecked.Add(new bool[count]);
            }
            if (!(myData.myTaskList[currentTaskIndex].allowsSubTasks &&
                myData.myTaskList[currentTaskIndex].subTasks[currentSubtaskIndex].allowSubSub &&
                myData.myTaskList[currentTaskIndex].subTasks[currentSubtaskIndex].SubItems.Count > 0))
            {
                nextItem();
            }
        }
        private void nextItem()
        {
            bool done = false;
            if(currentTaskIndex >= myData.myTaskList.Count)
            {
                done = true;
                nextPage = true;
            }

            if (currentSubSubtaskIndex < currentMax-1)
            {
                TextRange tr = new TextRange(description.Document.ContentStart, description.Document.ContentEnd);
                currentTask.description = RTFConverter.convertTR(tr);
                currentSubSubtaskIndex++;
                currentTask = myData.myTaskList[currentTaskIndex].subTasks[currentSubtaskIndex].SubItems[currentSubSubtaskIndex];
                done = true;
                HeaderLabel.Content = myData.myTaskList[currentTaskIndex].HeadLevelItem + " - " + myData.myTaskList[currentTaskIndex].subTasks[currentSubtaskIndex].name + " - " + myData.myTaskList[currentTaskIndex].subTasks[currentSubtaskIndex].SubItems[currentSubSubtaskIndex].name + " " + (currentSubSubtaskIndex +1).ToString();
                description.Document.Blocks.Clear();
                description.AppendText(currentTask.description);
            }
            else
            {
                if(currentMax>0)
                {
                    TextRange tr = new TextRange(description.Document.ContentStart, description.Document.ContentEnd);
                    currentTask.description = RTFConverter.convertTR(tr);
                    currentMax = 0;
                    currentSubtaskIndex++;
                    currentSubSubtaskIndex = 0;
                }
            }
            while(!done)
            {
                if (currentTaskIndex >= myData.myTaskList.Count)
                {
                    done = true;
                    nextPage = true;
                }
                else if (!done &&
                    myData.myTaskList[currentTaskIndex].allowsSubTasks &&
                    currentSubtaskIndex < myData.myTaskList[currentTaskIndex].subTasks.Count)
                {
                    if (myData.myTaskList[currentTaskIndex].subTasks[currentSubtaskIndex].allowSubSub)
                    {
                        currentMax = myData.myTaskList[currentTaskIndex].subTasks[currentSubtaskIndex].SubItems.Count;
                        currentSubSubtaskIndex = 0;
                        if (currentMax > 0)
                        {
                            currentTask = myData.myTaskList[currentTaskIndex].subTasks[currentSubtaskIndex].SubItems[currentSubSubtaskIndex];
                            done = true;
                            HeaderLabel.Content = myData.myTaskList[currentTaskIndex].HeadLevelItem + " - " + myData.myTaskList[currentTaskIndex].subTasks[currentSubtaskIndex].name + " - " + myData.myTaskList[currentTaskIndex].subTasks[currentSubtaskIndex].SubItems[currentSubSubtaskIndex].name + " 1";
                            description.Document.Blocks.Clear();
                            description.AppendText(currentTask.description);
                        }
                        else
                        {
                            currentSubtaskIndex++;
                        }

                    }
                    else
                    {
                        currentSubtaskIndex++;
                        currentMax = 0;
                    }
                }
                else
                {
                    if (!done)
                    {
                        currentTaskIndex++;
                        currentSubtaskIndex = 0;
                        currentMax = 0;
                    }
                }
            }
            
            
            if(nextPage)
            {
                navigateNext();
            }
            if(!done)
            {
                //nextItem();
            }

            
            //if (currentTaskIndex < myData.myTaskList.Count && (myData.myTaskList[currentTaskIndex].allowsSubTasks &&
            //    myData.myTaskList[currentTaskIndex].subTasks[currentSubtaskIndex].allowSubSub &&
            //    myData.myTaskList[currentTaskIndex].subTasks[currentSubtaskIndex].SubItems.Count > 0))
            //{
            //    if (currentSubSubtaskIndex > 0)
            //    {
            //        TextRange tr = new TextRange(description.Document.ContentStart, description.Document.ContentEnd);
            //        myData.myTaskList[currentTaskIndex].subTasks[currentSubtaskIndex].SubItems[currentSubSubtaskIndex - 1].description = RTFConverter.convertTR(tr);
            //    }

            //    currentSubSubtaskIndex++;
            //    if (currentSubSubtaskIndex > myData.myTaskList[currentTaskIndex].subTasks[currentSubtaskIndex].SubItems.Count)
            //    {
            //        currentSubSubtaskIndex = 0;
            //        currentTaskIndex++;
            //    }
                
            //}
            
            //else if(currentTaskIndex < myData.myTaskList.Count && !(myData.myTaskList[currentTaskIndex].allowsSubTasks &&
            //    myData.myTaskList[currentTaskIndex].subTasks[currentSubtaskIndex].allowSubSub &&
            //    myData.myTaskList[currentTaskIndex].subTasks[currentSubtaskIndex].SubItems.Count > 0) )
            //{
            //    while (!done)
            //    {
            //        if (currentTaskIndex < myData.myTaskList.Count)
            //        {
            //            if (myData.myTaskList[currentTaskIndex].allowsSubTasks)
            //            {
            //                if (currentSubtaskIndex < myData.myTaskList[currentTaskIndex].subTasks.Count)
            //                {
            //                    if (myData.myTaskList[currentTaskIndex].subTasks[currentSubtaskIndex].allowSubSub && myData.myTaskList[currentTaskIndex].subTasks[currentSubtaskIndex].SubItems.Count > 0)
            //                    {
            //                        done = true;
            //                        hasChecked[currentTaskIndex][currentSubtaskIndex] = true;
            //                        Title.Text = myData.myTaskList[currentTaskIndex].subTasks[currentSubtaskIndex].name + " - " + myData.myTaskList[currentTaskIndex].subTasks[currentSubtaskIndex].SubItems[0].name;
            //                        currentSubSubtaskIndex = 0;
            //                    }
            //                    else
            //                    {
            //                        if(myData.myTaskList[currentTaskIndex].subTasks[currentSubtaskIndex].allowSubSub)
            //                        {
            //                            TextRange tr = new TextRange(description.Document.ContentStart, description.Document.ContentEnd);
            //                            myData.myTaskList[currentTaskIndex].subTasks[currentSubtaskIndex].SubItems[currentSubSubtaskIndex - 1].description = RTFConverter.convertTR(tr);
            //                        }
            //                        currentSubtaskIndex++;
            //                    }
            //                }
            //                else
            //                {
            //                    currentTaskIndex++;
            //                    currentSubtaskIndex = 0;
            //                }
            //            }
            //            else
            //            {
            //                currentTaskIndex++;
            //            }
            //        }
            //        else
            //        {
            //            done = true;
            //            nextPage = true;
            //        }
            //    }
            //}
            
            //else
            //{
                
            //    nextPage = true;
            //}
            
        }
    

        private void btn_ReturnToMain(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainWindow());
        }

        
        private void btn_NextPage(object sender, RoutedEventArgs e)
        {
            if(currentTaskIndex >= myData.myTaskList.Count)
            {
                navigateNext();
            }
            if(!nextPage)
            {
                nextItem();
            }

            if (nextPage) 
            {
                navigateNext();
            }
        }
        private void btn_Back(object sender, RoutedEventArgs e)
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

