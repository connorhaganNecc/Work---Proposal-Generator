using MahApps.Metro.Controls;
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

namespace ProposalGenerator
{
    /// <summary>
    /// Interaction logic for ProposalTypePicker.xaml
    /// </summary>
    public partial class ScottL_Pg5 : UserControl
    {
        int currTextBox = 0;
        DataManager myData;

        public ScottL_Pg5()
        {
            InitializeComponent();
            startAdd("demo");
        }
        public ScottL_Pg5(DataManager inData)
        {
            InitializeComponent();
            myData = inData;
            setupAddServ();
        }
        public ScottL_Pg5(bool IGNORE, DataManager inData)
        {
            InitializeComponent();
            myData = inData;
            for(int i = 0; i < myData.AdditServNotInc.Count; i++)
            {
                startAdd(myData.AdditServNotInc[i]);
            }
        }

        private void setupAddServ()
        {
            AdditionalServiceList myList = AdditionalItemsSerializer.DeserializeList();
            bool ignore;
            for(int i = 0; i < myList.itemList.Count; i++)
            {
                ignore = false;
                for (int j = 0; j < myList.itemList[i].ignoreTaskTags.Count; j++)
                {
                    for (int k = 0; k < myData.SelectedTasks.myTasks.Count; k++)
                    {
                        if (myList.itemList[i].ignoreTaskTags[j] == myData.SelectedTasks.myTasks[k].Header)
                        {
                            ignore = true;
                        }
                    }
                }
                for(int j = 0; j < myList.itemList[i].ignoreTypeTags.Count; j++)
                {
                    if (myList.itemList[i].ignoreTypeTags[j] == myData.ProposalType)
                    {
                        ignore = true;
                    }
                }
                if(!ignore)
                {
                    startAdd(myList.itemList[i].text);
                }

                
                
            }
            startAdd("Any work not specifically described herein.");
        }

        private void startAdd(string text)
        {
            TextBox newText = new TextBox();
            TextBlock newL = new TextBlock();
            Button newB = new Button();

            newL.Name = "addServL_" + currTextBox.ToString();
            newL.Margin = new Thickness(15);
            newL.Text = (currTextBox + 1).ToString();

            newText.Name = "addServ_" + currTextBox.ToString();
            newText.Margin = new Thickness(10);
            newText.Text = text;

            newB.Name = "addServB_" + currTextBox.ToString();
            newB.Content = "Remove Item";
            newB.Margin = new Thickness(10);
            newB.FontSize = 9;

            newB.AddHandler(Button.ClickEvent, new RoutedEventHandler(buttonSPB_Click));

            currTextBox++;
            SP.Children.Add(newText);
            SP.RegisterName(newText.Name, newText);
            SPL.Children.Add(newL);
            SPL.RegisterName(newL.Name, newL);
            SPB.Children.Add(newB);
            SPB.RegisterName(newB.Name, newB);
        }

        #region buttons
        private void btn_ReturnToMain(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainWindow());
        }

        private void btn_NextPage(object sender, RoutedEventArgs e)
        {
            List<string> AddServ = new List<string>();
            for (int i = 0; i < currTextBox; i++)
            {
                TextBox foundBox = (TextBox)SP.FindName("addServ_" + i.ToString());
                if(foundBox!= null)
                {
                    AddServ.Add(foundBox.Text);
                }
            }
            PageSwitcher myParent = MetroWindow.GetWindow(this) as PageSwitcher;

            myParent.myData.AdditServNotInc = AddServ;
            myParent.myData.PAGE5VISIT = true;
            if(!myData.PAGE6VISIT)
            {
                Switcher.Switch(new ScottL_Pg6(myData));
            }
            else
            {
                Switcher.Switch(new ScottL_Pg6(false, myData));
            }
                
        }
        private void btn_Cancel(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainWindow());
        }
        private void btn_Back(object sender, RoutedEventArgs e)
        {
            PageSwitcher myParent = MetroWindow.GetWindow(this) as PageSwitcher;

            DataManager myData = myParent.myData;
            myData.PAGE5VISIT = true;

            List<string> AddServ = new List<string>();
            for (int i = 0; i < currTextBox; i++)
            {
                TextBox foundBox = (TextBox)SP.FindName("addServ_" + i.ToString());
                if (foundBox != null)
                {
                    AddServ.Add(foundBox.Text);
                }
            }
            myData.AdditServNotInc = AddServ;

            if (myParent.myData.PAGE4VISIT)
            {
                Switcher.Switch(new ScottL_Pg4(false, myParent, myData));
            }
            else
            {
                Switcher.Switch(new ScottL_Pg3(false, myData));
            }
        }
        
        private void btn_Add(object sender, RoutedEventArgs e)
        {
            TextBox newText = new TextBox();
            TextBlock newL = new TextBlock();
            Button newB = new Button();

            newL.Name = "addServL_" + currTextBox.ToString();
            newL.Margin = new Thickness(15);
            newL.Text = (currTextBox + 1).ToString();

            newText.Name = "addServ_" + currTextBox.ToString();
            newText.Margin = new Thickness(10);

            newB.Name = "addServB_" + currTextBox.ToString();
            newB.Content = "Remove Item";
            newB.Margin = new Thickness(10);
            newB.FontSize = 9;

            newB.AddHandler(Button.ClickEvent, new RoutedEventHandler(buttonSPB_Click));

            currTextBox++;
            SP.Children.Add(newText);
            SP.RegisterName(newText.Name, newText);
            SPL.Children.Add(newL);
            SPL.RegisterName(newL.Name, newL);
            SPB.Children.Add(newB);
            SPB.RegisterName(newB.Name, newB);
        }

        void buttonSPB_Click(object sender, RoutedEventArgs e)
        {
            Button send = sender as Button;
            string name = send.Name;
            string[] splitted = name.Split('_');

            int number = Convert.ToInt32(HelperFunctions.StripAlphabetic(splitted[splitted.Length - 1]));


            if (number >= 0 && number < currTextBox)
            {
                TextBox foundBox = (TextBox)SP.FindName("addServ_" + (number).ToString());
                TextBlock foundBlock = (TextBlock)SPL.FindName("addServL_" + (number).ToString());
                Button foundButton = (Button)SPB.FindName("addServB_" + number.ToString());

                if(foundBox != null)
                {
                    string oldBoxName = foundBox.Name;
                    string oldBlockName = foundBlock.Name;
                    string oldButtonName = foundButton.Name;

                    string tempBoxName = oldBlockName;
                    string tempBlockName = oldBlockName;
                    string tempButtonName = oldButtonName;

                    SP.UnregisterName(foundBox.Name);
                    SP.Children.Remove(foundBox);

                    SPL.UnregisterName(foundBlock.Name);
                    SPL.Children.Remove(foundBlock);

                    SPB.UnregisterName(foundButton.Name);
                    SPB.Children.Remove(foundButton);

                    foundBox = (TextBox)SP.FindName("addServ_" + (number + 1).ToString());
                    foundBlock = (TextBlock)SPL.FindName("addServL_" + (number + 1).ToString());
                    foundButton = (Button)SPB.FindName("addServB_" + (number + 1).ToString());

                    while(foundBlock!=null)
                    {
                        SP.UnregisterName(foundBox.Name);
                        SP.Children.Remove(foundBox);

                        SPL.UnregisterName(foundBlock.Name);
                        SPL.Children.Remove(foundBlock);

                        SPB.UnregisterName(foundButton.Name);
                        SPB.Children.Remove(foundButton);

                        tempBoxName = foundBox.Name;
                        tempBlockName = foundBlock.Name;
                        tempButtonName = foundButton.Name;

                        foundBox.Name = oldBoxName;
                        foundBlock.Name = oldBlockName;
                        foundButton.Name = oldButtonName;

                        SP.Children.Add(foundBox);
                        SP.RegisterName(foundBox.Name, foundBox);

                        SPL.Children.Add(foundBlock);
                        SPL.RegisterName(foundBlock.Name, foundBlock);

                        SPB.Children.Add(foundButton);
                        SPB.RegisterName(foundButton.Name, foundButton);

                        oldBoxName = tempBoxName;
                        oldBlockName = tempBlockName;
                        oldButtonName = tempButtonName;

                        foundBlock.Text = (number + 1).ToString();

                        number++;
                        foundBox = (TextBox)SP.FindName("addServ_" + (number + 1).ToString());
                        foundBlock = (TextBlock)SPL.FindName("addServL_" + (number + 1).ToString());
                        foundButton = (Button)SPB.FindName("addServB_" + (number + 1).ToString());
                    }
                }

                //        if(foundBox!= null)
                //        {
                //            SP.UnregisterName(foundBox.Name);
                //            SP.Children.Remove(foundBox);

                //            SPL.UnregisterName(foundBlock.Name);
                //            SPL.Children.Remove(foundBlock);

                //            SPB.UnregisterName(foundButton.Name);
                //            SPB.Children.Remove(foundButton);

                //        }
                //        foundBox = (TextBox)SP.FindName("addServ_" + (number+1).ToString());
                //        foundBlock = (TextBlock)SPL.FindName("addServL_" + (number+1).ToString());
                //        foundButton = (Button)SPB.FindName("addServB_" + (number+1).ToString());

                //        while(foundButton!= null)
                //        {
                //            oldBoxName = foundBox.Name;
                //            oldBlockName = foundBlock.Name;
                //            oldButtonName = foundButton.Name;

                //            foundBox.Name = tempBoxName;
                //            foundButton.Name = tempButtonName;
                //            foundBlock.Name = tempBlockName;
                //            SP.UnregisterName(oldBoxName);
                //            SPL.UnregisterName(oldBlockName);
                //            SPB.UnregisterName(oldButtonName);
                //            SP.RegisterName(foundBox.Name, foundBox);
                //            SPL.UnregisterName(foundBlock.Name);
                //            SPL.RegisterName(foundBlock.Name, foundBlock);
                //            SPB.RegisterName(foundButton.Name, foundButton);


                //            tempBoxName = oldBlockName;
                //            tempBlockName = oldBlockName;
                //            tempButtonName = oldButtonName;

                //            foundBlock.Text = (Convert.ToInt32(foundBlock.Text) - 1).ToString();
                //            number++;

                //            foundBox = (TextBox)SP.FindName("addServ_" + (number + 1).ToString());
                //            foundBlock = (TextBlock)SPL.FindName("addServL_" + (number + 1).ToString());
                //            foundButton = (Button)SPB.FindName("addServB_" + (number + 1).ToString());
                //        }
                currTextBox--;
            }


        }
        private void btn_RemoveLast(object sender, RoutedEventArgs e)
        {
            TextBox foundBox = (TextBox)SP.FindName("addServ_" + (currTextBox - 1).ToString());
            TextBlock foundBlock = (TextBlock)SPL.FindName("addServL_" + (currTextBox - 1).ToString());
            if (foundBox != null)
            {
                SP.UnregisterName(foundBox.Name);
                SP.Children.Remove(foundBox);
                SPL.UnregisterName(foundBlock.Name);
                SPL.Children.Remove(foundBlock);
                currTextBox--;
            }
        }
        #endregion
    }

}
