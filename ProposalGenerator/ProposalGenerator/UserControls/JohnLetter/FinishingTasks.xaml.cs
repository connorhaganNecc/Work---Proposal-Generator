﻿using System;
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
    public partial class FinishingTasks : UserControl
    {
        PageSwitcher myParent;
        DataManager myData;
        TaskList myList;
        int currIndex = 0;
        public FinishingTasks()
        {
            InitializeComponent();
        }
        public FinishingTasks(PageSwitcher inParent)
        {
            InitializeComponent();
            myParent = inParent;
            myData = myParent.myData;
            myList = myData.SelectedTasks;
            nextTask();
        }
        public FinishingTasks(PageSwitcher inParent, int in_currIndex)
        {
            InitializeComponent();
            myParent = inParent;
            myData = myParent.myData;
            myList = myData.SelectedTasks;
            currIndex = in_currIndex;
            nextTask();
        }


        private void nextTask()
        {
            if (currIndex > 0)
            {
                myList.myTasks[currIndex - 1].fee = taskFee.Text;
                HandleReplacementTags();
            }
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

            HeaderLabel.Content = myList.myTasks[currIndex].Header;
            taskHeader.Text = myList.myTasks[currIndex].Header;
            taskFee.Text = myList.myTasks[currIndex].fee;

            if (taskFee.Text == "%VARFEE%")
            {
                taskFee.Text = "Please enter a fee.";
            }

            

            
            string myText = myList.myTasks[currIndex].Body;

            CheckReplacementTags(myText);

            currIndex++;
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
                            if(OpL1.Content.ToString() == ReplacementTags.getTownFeeText() && myList.myTasks[currIndex-1].Header == "SSD (septic design repair)")
                            {
                                if(!string.IsNullOrEmpty(OpF1.Text))
                                {
                                    myData.septicReviewFee = Convert.ToSingle(HelperFunctions.StripAlphabetic(OpF1.Text));
                                }
                                
                                myData.septicReviewNum = currIndex;
                            }
                            else if(OpL1.Content.ToString() == ReplacementTags.getTownFeeText() && myList.myTasks[currIndex - 1].Header == "Soil Testing")
                            {
                                if(!string.IsNullOrEmpty(OpF1.Text))
                                {
                                    myData.soilTestingFee = Convert.ToSingle(HelperFunctions.StripAlphabetic(OpF1.Text));
                                }
                               
                            }
                        }
                        break;
                    case 2:
                        if (OpL2.Visibility == Visibility.Visible)
                        {
                            DoReplacement(OpL2.Content.ToString(), OpF2.Text);
                            if (OpL2.Content.ToString() == ReplacementTags.getTownFeeText() && myList.myTasks[currIndex - 1].Header == "SSD (septic design repair)")
                            {
                                if(!string.IsNullOrEmpty(OpF2.Text))
                                {
                                    myData.septicReviewFee = Convert.ToSingle(HelperFunctions.StripAlphabetic(OpF2.Text));
                                }
                                
                                myData.septicReviewNum = currIndex;
                            }
                            else if (OpL2.Content.ToString() == ReplacementTags.getTownFeeText() && myList.myTasks[currIndex - 1].Header == "Soil Testing")
                            {
                                if(!string.IsNullOrEmpty(OpF2.Text))
                                {
                                    myData.soilTestingFee = Convert.ToSingle(HelperFunctions.StripAlphabetic(OpF2.Text));
                                }
                               
                            }
                        }
                        break;
                    case 3:
                        if (OpL3.Visibility == Visibility.Visible)
                        {
                            DoReplacement(OpL3.Content.ToString(), OpF3.Text);
                            if (OpL3.Content.ToString() == ReplacementTags.getTownFeeText() && myList.myTasks[currIndex - 1].Header == "SSD (septic design repair)")
                            {
                                if(!string.IsNullOrEmpty(OpF3.Text))
                                {
                                    myData.septicReviewFee = Convert.ToSingle(HelperFunctions.StripAlphabetic(OpF3.Text));
                                }
                                
                                myData.septicReviewNum = currIndex;
                            }
                            else if (OpL3.Content.ToString() == ReplacementTags.getTownFeeText() && myList.myTasks[currIndex - 1].Header == "Soil Testing")
                            {
                                if(!string.IsNullOrEmpty(OpF3.Text))
                                {
                                    myData.soilTestingFee = Convert.ToSingle(HelperFunctions.StripAlphabetic(OpF3.Text));
                                }
                               
                            }
                        }
                        break;
                    case 4:
                        if (OpL4.Visibility == Visibility.Visible)
                        {
                            DoReplacement(OpL4.Content.ToString(), OpF4.Text);
                            if (OpL4.Content.ToString() == ReplacementTags.getTownFeeText() && myList.myTasks[currIndex - 1].Header == "SSD (septic design repair)")
                            {
                                if(!string.IsNullOrEmpty(OpF4.Text))
                                {
                                    myData.septicReviewFee = Convert.ToSingle(HelperFunctions.StripAlphabetic(OpF4.Text));
                                }
                                
                                myData.septicReviewNum = currIndex;
                            }
                            else if (OpL4.Content.ToString() == ReplacementTags.getTownFeeText() && myList.myTasks[currIndex - 1].Header == "Soil Testing")
                            {
                                if(!string.IsNullOrEmpty(OpF4.Text))
                                {
                                    myData.soilTestingFee = Convert.ToSingle(HelperFunctions.StripAlphabetic(OpF4.Text));
                                }
                                
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            while(myList.myTasks[currIndex-1].Body.Contains(ReplacementTags.getTownTag()))
            {
                myList.myTasks[currIndex - 1].Body = myList.myTasks[currIndex - 1].Body.Replace(ReplacementTags.getTownTag(), myData.PropertyLocation.town);
            }

            string tempText;
            if(myData.ProposalType != "Septic Repair"  && myData.ProposalType != "Scott SSD Repair")
            {
                tempText = "site plan";
            }
            else
            {
                tempText = "replacement Sanitary Disposal System Design";
            }

            while (myList.myTasks[currIndex - 1].Body.Contains(ReplacementTags.getSepticOrSitePlanTag()))
            {
                myList.myTasks[currIndex - 1].Body = myList.myTasks[currIndex - 1].Body.Replace(ReplacementTags.getSepticOrSitePlanTag(), tempText);
            }
        }

        private void DoReplacement(string labelString, string boxString)
        {
            if(labelString == ReplacementTags.getBetweenText())
            {
                myList.myTasks[currIndex - 1].Body = myList.myTasks[currIndex - 1].Body.Replace(ReplacementTags.getBetweenTag(), boxString);
            }
            else if (labelString == ReplacementTags.getCondNumText())
            {
                myList.myTasks[currIndex - 1].Body = myList.myTasks[currIndex - 1].Body.Replace(ReplacementTags.getCondNumTag(), boxString);
            }
            else if (labelString == ReplacementTags.getCornersText())
            {
                myList.myTasks[currIndex - 1].Body = myList.myTasks[currIndex - 1].Body.Replace(ReplacementTags.getCornersTag(), boxString);
            }
            else if (labelString == ReplacementTags.getFilingFeeText())
            {
                myList.myTasks[currIndex - 1].Body = myList.myTasks[currIndex - 1].Body.Replace(ReplacementTags.getFilingFeeTag(), boxString);
            }
            else if (labelString == ReplacementTags.getFtNumText())
            {
                myList.myTasks[currIndex - 1].Body = myList.myTasks[currIndex - 1].Body.Replace(ReplacementTags.getFtNumTag(), boxString);
            }
            else if (labelString == ReplacementTags.getHrFeeText())
            {
                myList.myTasks[currIndex - 1].Body = myList.myTasks[currIndex - 1].Body.Replace(ReplacementTags.getHrFeeTag(), boxString);
            }
            else if (labelString == ReplacementTags.getLotNumText())
            {
                myList.myTasks[currIndex - 1].Body = myList.myTasks[currIndex - 1].Body.Replace(ReplacementTags.getLotNumTag(), boxString);
            }
            else if (labelString == ReplacementTags.getSideText())
            {
                myList.myTasks[currIndex - 1].Body = myList.myTasks[currIndex - 1].Body.Replace(ReplacementTags.getSideTag(), boxString);
            }
            else if (labelString == ReplacementTags.getSubConText())
            {
                myList.myTasks[currIndex - 1].Body = myList.myTasks[currIndex - 1].Body.Replace(ReplacementTags.getSubConTag(), boxString);
            }
            else if (labelString == ReplacementTags.getTownFeeText())
            {
                myList.myTasks[currIndex - 1].Body = myList.myTasks[currIndex - 1].Body.Replace(ReplacementTags.getTownFeeTag(), boxString);
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

        private void btn_NextPage(object sender, RoutedEventArgs e)
        {
            if(currIndex<= myList.myTasks.Count-1)
            {
                nextTask();
            }
            else
            {
                myList.myTasks[currIndex - 1].fee = taskFee.Text;
                HandleReplacementTags();
                myData.SelectedTasks = myList;
                //myList.myTasks[currIndex - 1].Body = taskBody.Text;
                //DocumentController.WriteLetterProposal(myData);
                Switcher.Switch(new LastOptions());
            }
        }
        private void btn_Cancel(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainWindow());
        }

        #endregion

        private void btn_EditTaskText(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new EditTaskTextJL(myList, currIndex-1, myParent));
        }
    }

}
