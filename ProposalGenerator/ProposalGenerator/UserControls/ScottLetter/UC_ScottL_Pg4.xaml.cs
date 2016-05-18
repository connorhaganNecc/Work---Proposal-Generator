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
    /// Interaction logic for ProposalTypePicker.xaml
    /// </summary>
    public partial class ScottL_Pg4 : UserControl
    {
        PageSwitcher myParent;
        DataManager myData;
        TaskList myList;
        int currIndex = -1;
        public ScottL_Pg4()
        {
            InitializeComponent();
        }
        public ScottL_Pg4(PageSwitcher inParent)
        {
            InitializeComponent();
            myParent = inParent;
            myData = myParent.myData;
            myList = myData.SelectedTasks;
            myData.PAGE4VISIT = true;
            nextTask();
        }
        public ScottL_Pg4(PageSwitcher inParent, int in_currIndex)
        {
            InitializeComponent();
            myParent = inParent;
            myData = myParent.myData;
            myList = myData.SelectedTasks;
            myData.PAGE4VISIT = true;
            currIndex = in_currIndex-1;
            nextTask();
        }
        public ScottL_Pg4(bool IGNORE, PageSwitcher inParent, DataManager inData)
        {
            InitializeComponent();
            myParent = inParent;
            myData = inData;
            myList = myData.SelectedTasks;
            myData.PAGE4VISIT = true;
            currIndex = myList.myTasks.Count - 2;
            nextTask();
        }

        private void saveTask()
        {
            HandleReplacementTags();
            myList.myTasks[currIndex].fee = taskFee.Text;
            myList.myTasks[currIndex].Header = taskHeader.Text;
        }
        
        private void clearReplacementFields()
        {
            OpF1.Visibility = Visibility.Hidden;
            OpL1.Visibility = Visibility.Hidden;
            OpF2.Visibility = Visibility.Hidden;
            OpL2.Visibility = Visibility.Hidden;
            OpF3.Visibility = Visibility.Hidden;
            OpL3.Visibility = Visibility.Hidden;
            OpL4.Visibility = Visibility.Hidden;
            OpF4.Visibility = Visibility.Hidden;

            //Clear replacement fields
            OpF1.Text = "";
            OpF2.Text = "";
            OpF3.Text = "";
            OpF4.Text = "";
        }

        private void nextTask()
        {
            clearReplacementFields();
            currIndex++;

            HeaderLabel.Content = (currIndex + 1).ToString() + ".) " + myList.myTasks[currIndex].Header;
            taskHeader.Text = myList.myTasks[currIndex].Header;
            taskFee.Text = myList.myTasks[currIndex].fee;

            if (taskFee.Text == "%VARFEE%")
            {
                taskFee.Text = "Please enter a fee.";
            }
            string myText = myList.myTasks[currIndex].Body;
            CheckReplacementTags(myText);
        }

        //private void nextTask()
        //{
        //    if (currIndex > 0)
        //    {
        //        myList.myTasks[currIndex - 1].fee = taskFee.Text;
        //        HandleReplacementTags();
        //    }
        //    clearReplacementFields();

        //    HeaderLabel.Content = (currIndex+1).ToString() + ".) " + myList.myTasks[currIndex].Header;
        //    taskHeader.Text = myList.myTasks[currIndex].Header;
        //    taskFee.Text = myList.myTasks[currIndex].fee;

        //    if (taskFee.Text == "%VARFEE%")
        //    {
        //        taskFee.Text = "Please enter a fee.";
        //    }

            

        //    bool done = false;
        //    int index = 0;
        //    string myText = myList.myTasks[currIndex].Body;

        //    CheckReplacementTags(myText);

        //    currIndex++;
        //}
        private void prevTask()
        {
            clearReplacementFields();
            currIndex--;

            HeaderLabel.Content = (currIndex + 1).ToString() + ".) " + myList.myTasks[currIndex].Header;
            taskHeader.Text = myList.myTasks[currIndex].Header;
            taskFee.Text = myList.myTasks[currIndex].fee;

            if (taskFee.Text == "%VARFEE%")
            {
                taskFee.Text = "Please enter a fee.";
            }

            
            string myText = myList.myTasks[currIndex].Body;
            CheckReplacementTags(myText);


        }
        private void CheckReplacementTags(string myText)
        {
            int currTagNum = 0;
            if (myText.Contains(ReplacementTags.getBetweenTag()))
            {
                currTagNum++;
                EnableOptionalBoxes(currTagNum, ReplacementTags.getBetweenText());
            }
            if (myText.Contains(ReplacementTags.getCondNumTag()))
            {
                currTagNum++;
                EnableOptionalBoxes(currTagNum, ReplacementTags.getCondNumText());
            }
            if (myText.Contains(ReplacementTags.getCornersTag()))
            {
                currTagNum++;
                EnableOptionalBoxes(currTagNum, ReplacementTags.getCornersText());
            }
            if (myText.Contains(ReplacementTags.getFilingFeeTag()))
            {
                currTagNum++;
                EnableOptionalBoxes(currTagNum, ReplacementTags.getFilingFeeText());
            }
            if (myText.Contains(ReplacementTags.getFtNumTag()))
            {
                currTagNum++;
                EnableOptionalBoxes(currTagNum, ReplacementTags.getFtNumText());
            }
            if (myText.Contains(ReplacementTags.getHrFeeTag()))
            {
                currTagNum++;
                EnableOptionalBoxes(currTagNum, ReplacementTags.getHrFeeText());
            }
            if (myText.Contains(ReplacementTags.getLotNumTag()))
            {
                currTagNum++;
                EnableOptionalBoxes(currTagNum, ReplacementTags.getLotNumText());
            }
            if (myText.Contains(ReplacementTags.getSideTag()))
            {
                currTagNum++;
                EnableOptionalBoxes(currTagNum, ReplacementTags.getSideText());
            }
            if (myText.Contains(ReplacementTags.getSubConTag()))
            {
                currTagNum++;
                EnableOptionalBoxes(currTagNum, ReplacementTags.getSubConText());
            }
            if (myText.Contains(ReplacementTags.getTownFeeTag()))
            {
                currTagNum++;
                EnableOptionalBoxes(currTagNum, ReplacementTags.getTownFeeText());
            }

        }

        private void EnableOptionalBoxes(int currNum, string newText)
        {
            switch (currNum)
            {
                case 1:
                    OpL1.Content = newText;
                    OpL1.Visibility = Visibility.Visible;
                    OpF1.Visibility = Visibility.Visible;
                    break;
                case 2:
                    OpL2.Content = newText;
                    OpL2.Visibility = Visibility.Visible;
                    OpF2.Visibility = Visibility.Visible;
                    break;
                case 3:
                    OpL3.Content = newText;
                    OpL3.Visibility = Visibility.Visible;
                    OpF3.Visibility = Visibility.Visible;
                    break;
                case 4:
                    OpL4.Content = newText;
                    OpL4.Visibility = Visibility.Visible;
                    OpF4.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }

        }

        private void HandleReplacementTags()
        {
            for(int i = 1; i <= 4; i++)
            {
                switch(i)
                {
                    case 1:
                        if(OpL1.Visibility == Visibility.Visible)
                        {
                            DoReplacement(OpL1.Content.ToString(), OpF1.Text);
                            if(OpL1.Content.ToString() == ReplacementTags.getTownFeeText() && myList.myTasks[currIndex].Header == "SSD (septic design repair)")
                            {
                                if(!string.IsNullOrEmpty(OpF1.Text))
                                {
                                    myData.septicReviewFee = Convert.ToSingle(OpF1.Text);
                                }
                                
                                myData.septicReviewNum = currIndex +1;
                            }
                            else if(OpL1.Content.ToString() == ReplacementTags.getTownFeeText() && myList.myTasks[currIndex].Header == "Soil Testing")
                            {
                                if(!string.IsNullOrEmpty(OpF1.Text))
                                {
                                    myData.soilTestingFee = Convert.ToSingle(OpF1.Text);
                                }
                               
                            }
                        }
                        break;
                    case 2:
                        if (OpL2.Visibility == Visibility.Visible)
                        {
                            DoReplacement(OpL2.Content.ToString(), OpF2.Text);
                            if (OpL2.Content.ToString() == ReplacementTags.getTownFeeText() && myList.myTasks[currIndex].Header == "SSD (septic design repair)")
                            {
                                if(!string.IsNullOrEmpty(OpF2.Text))
                                {
                                    myData.septicReviewFee = Convert.ToSingle(OpF2.Text);
                                }
                                
                                myData.septicReviewNum = currIndex+1;
                            }
                            else if (OpL2.Content.ToString() == ReplacementTags.getTownFeeText() && myList.myTasks[currIndex].Header == "Soil Testing")
                            {
                                if(!string.IsNullOrEmpty(OpF2.Text))
                                {
                                    myData.soilTestingFee = Convert.ToSingle(OpF2.Text);
                                }
                               
                            }
                        }
                        break;
                    case 3:
                        if (OpL3.Visibility == Visibility.Visible)
                        {
                            DoReplacement(OpL3.Content.ToString(), OpF3.Text);
                            if (OpL3.Content.ToString() == ReplacementTags.getTownFeeText() && myList.myTasks[currIndex].Header == "SSD (septic design repair)")
                            {
                                if(!string.IsNullOrEmpty(OpF3.Text))
                                {
                                    myData.septicReviewFee = Convert.ToSingle(OpF3.Text);
                                }
                                
                                myData.septicReviewNum = currIndex+1;
                            }
                            else if (OpL3.Content.ToString() == ReplacementTags.getTownFeeText() && myList.myTasks[currIndex].Header == "Soil Testing")
                            {
                                if(!string.IsNullOrEmpty(OpF3.Text))
                                {
                                    myData.soilTestingFee = Convert.ToSingle(OpF3.Text);
                                }
                               
                            }
                        }
                        break;
                    case 4:
                        if (OpL4.Visibility == Visibility.Visible)
                        {
                            DoReplacement(OpL4.Content.ToString(), OpF4.Text);
                            if (OpL4.Content.ToString() == ReplacementTags.getTownFeeText() && myList.myTasks[currIndex].Header == "SSD (septic design repair)")
                            {
                                if(!string.IsNullOrEmpty(OpF4.Text))
                                {
                                    myData.septicReviewFee = Convert.ToSingle(OpF4.Text);
                                }
                                
                                myData.septicReviewNum = currIndex+1;
                            }
                            else if (OpL4.Content.ToString() == ReplacementTags.getTownFeeText() && myList.myTasks[currIndex].Header == "Soil Testing")
                            {
                                if(!string.IsNullOrEmpty(OpF4.Text))
                                {
                                    myData.soilTestingFee = Convert.ToSingle(OpF4.Text);
                                }
                                
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            while(myList.myTasks[currIndex].Body.Contains(ReplacementTags.getTownTag()))
            {
                myList.myTasks[currIndex].Body = myList.myTasks[currIndex].Body.Replace(ReplacementTags.getTownTag(), myData.PropertyLocation.town);
            }
            while (myList.myTasks[currIndex].Body.Contains(ReplacementTags.getSepticOrSitePlanTag()))
            {
                if(myData.ProposalType == "Septic Repair")
                {
                    myList.myTasks[currIndex].Body = myList.myTasks[currIndex].Body.Replace(ReplacementTags.getSepticOrSitePlanTag(), "septic repair plan");
                }
                else
                {
                    myList.myTasks[currIndex].Body = myList.myTasks[currIndex].Body.Replace(ReplacementTags.getSepticOrSitePlanTag(), "site plan");
                }
            }
        }

        private void DoReplacement(string labelString, string boxString)
        {
            if(labelString == ReplacementTags.getBetweenText())
            {
                myList.myTasks[currIndex].Body = myList.myTasks[currIndex].Body.Replace(ReplacementTags.getBetweenTag(), boxString);
            }
            else if (labelString == ReplacementTags.getCondNumText())
            {
                myList.myTasks[currIndex].Body = myList.myTasks[currIndex].Body.Replace(ReplacementTags.getCondNumTag(), boxString);
            }
            else if (labelString == ReplacementTags.getCornersText())
            {
                myList.myTasks[currIndex].Body = myList.myTasks[currIndex].Body.Replace(ReplacementTags.getCornersTag(), boxString);
            }
            else if (labelString == ReplacementTags.getFilingFeeText())
            {
                myList.myTasks[currIndex].Body = myList.myTasks[currIndex].Body.Replace(ReplacementTags.getFilingFeeTag(), boxString);
            }
            else if (labelString == ReplacementTags.getFtNumText())
            {
                myList.myTasks[currIndex].Body = myList.myTasks[currIndex].Body.Replace(ReplacementTags.getFtNumTag(), boxString);
            }
            else if (labelString == ReplacementTags.getHrFeeText())
            {
                myList.myTasks[currIndex].Body = myList.myTasks[currIndex].Body.Replace(ReplacementTags.getHrFeeTag(), boxString);
            }
            else if (labelString == ReplacementTags.getLotNumText())
            {
                myList.myTasks[currIndex].Body = myList.myTasks[currIndex].Body.Replace(ReplacementTags.getLotNumTag(), boxString);
            }
            else if (labelString == ReplacementTags.getSideText())
            {
                myList.myTasks[currIndex].Body = myList.myTasks[currIndex].Body.Replace(ReplacementTags.getSideTag(), boxString);
            }
            else if (labelString == ReplacementTags.getSubConText())
            {
                myList.myTasks[currIndex].Body = myList.myTasks[currIndex].Body.Replace(ReplacementTags.getSubConTag(), boxString);
            }
            else if (labelString == ReplacementTags.getTownFeeText())
            {
                myList.myTasks[currIndex].Body = myList.myTasks[currIndex].Body.Replace(ReplacementTags.getTownFeeTag(), boxString);
            }
            else
            {
                //MessageBox.Show("NO MATCH");
            }
        }

        #region buttons
        private void btn_ReturnToMain(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainWindow());
        }

        private void btn_Back(object sender, RoutedEventArgs e)
        {
            myData.PAGE4VISIT = true;
            saveTask();
            if(currIndex>0)
            {
                prevTask();
            }
            else
            {
                Switcher.Switch(new ScottL_Pg3(false, myData));
            }
        }

        private void btn_NextPage(object sender, RoutedEventArgs e)
        {
            myData.PAGE4VISIT = true;
            if(currIndex< myList.myTasks.Count-1)
            {
                saveTask();
                nextTask();
            }
            else
            {
                myList.myTasks[currIndex].fee = taskFee.Text;
                HandleReplacementTags();
                myData.SelectedTasks = myList;
                //myList.myTasks[currIndex - 1].Body = taskBody.Text;
                //DocumentController.WriteLetterProposal(myData);
                if(!myData.PAGE6VISIT)
                {
                    Switcher.Switch(new ScottL_Pg6(myData));
                }
                else
                {
                    Switcher.Switch(new ScottL_Pg6(false,myData));
                }
            }
        }
        private void btn_Cancel(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainWindow());
        }

        #endregion

        private void btn_EditTaskText(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new EditTaskTextSL(myList, currIndex, myParent));
        }
    }

}
