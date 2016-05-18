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
    public partial class ContractP_Pg3 : UserControl
    {
        int currTextBox = 0;
        ContractDataManager myData;

        public ContractP_Pg3()
        {
            InitializeComponent();
            startAdd("demo");
        }
        public ContractP_Pg3(ContractDataManager inData)
        {
            InitializeComponent();
            myData = inData;
            setupAddServ();
        }
        public ContractP_Pg3(bool IGNORE, ContractDataManager inData)
        {
            InitializeComponent();
            myData = inData;
            for(int i = 0; i < myData.Assumptions.Count; i++)
            {
                startAdd(myData.Assumptions[i]);
            }
        }

        private void setupAddServ()
        {
            
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

            myParent.contractData.Assumptions = AddServ;
            myParent.contractData.PAGE3VISIT = true;

            DocumentController.WriteContractProp(myData);
            if(false)
            {
                //Switcher.Switch(new ScottL_Pg6());
            }
            else
            {
                //Switcher.Switch(new ScottL_Pg6(false, myData));
            }
                
        }
        private void btn_Cancel(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainWindow());
        }
        private void btn_Back(object sender, RoutedEventArgs e)
        {
            PageSwitcher myParent = MetroWindow.GetWindow(this) as PageSwitcher;

            ContractDataManager myData = myParent.contractData;
            myData.PAGE3VISIT = true;

            List<string> AddServ = new List<string>();
            for (int i = 0; i < currTextBox; i++)
            {
                TextBox foundBox = (TextBox)SP.FindName("addServ_" + i.ToString());
                if (foundBox != null)
                {
                    AddServ.Add(foundBox.Text);
                }
            }
            myData.Assumptions = AddServ;

            if (myParent.contractData.PAGE2VISIT)
            {
                Switcher.Switch(new ContractP_Pg2(false,myData));
            }
            else
            {
                Switcher.Switch(new ContractP_Pg2( myData));
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

            int number = Convert.ToInt32(splitted[splitted.Length - 1]);


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
