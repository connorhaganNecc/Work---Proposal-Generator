using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using Novacode;
using MahApps.Metro.Controls;
namespace ProposalGenerator
{
    /// <summary>
    /// Interaction logic for PropPg1.xaml
    /// </summary>
    public partial class ContractP_Pg1 : UserControl, ISwitchable
    {
        PageSwitcher myParent;
        ContractDataManager myData;
        int comboStartIndex;
        int titleStartIndex;
        public ContractP_Pg1()
        {
            comboStartIndex = -1;
            InitializeComponent();
        }

        public ContractP_Pg1(bool IGNORE, ContractDataManager myData)
        {
            comboStartIndex = -1;
            InitializeComponent();
            AutoFillOldData(myData);
        }


        private void AutoFillOldData(ContractDataManager myData)
        {
            ForceComboLoad();
            //Handle Proposal Type
            for (int i = 0; i < Combo.Items.Count; i++)
            {
                if(Combo.Items[i].ToString() == myData.ProposalType.ToString())
                {
                    comboStartIndex = i;
                }
            }

            //Property stuff
            propAssMap.Text = myData.Property.map;
            propAssBlock.Text = myData.Property.block;
            propAssLot.Text = myData.Property.lot;


            propAddress.Text = myData.Property.street;
            propTown.Text = myData.Property.town;
            propZip.Text = myData.Property.zip;

            FNAME.Text = myData.Client.FirstName;
            LNAME.Text = myData.Client.LastName;
            prepState.Text = myData.Client.state;
            prepAddress.Text = myData.Client.street;
            prepTown.Text = myData.Client.town;
            prepZip.Text = myData.Client.zip;

            if (!(string.IsNullOrWhiteSpace(myData.Client.co)) && !(myData.Client.co == "NULL"))
            {
                CO.Text = myData.Client.co;
            }
            string temp = myData.Client.title;

            switch(myData.Client.title)
            {
                case "":
                case "None":
                    TitleBox.SelectedIndex = 0;
                    titleStartIndex = 0;
                    break;
                case "Mr.":
                    titleStartIndex = 1;
                    TitleBox.SelectedIndex = 1;
                    break;
                case "Ms.":
                    titleStartIndex = 2;
                    TitleBox.SelectedIndex = 2;
                    break;
                case "Mrs.":
                    titleStartIndex = 3;
                    TitleBox.SelectedIndex = 3;
                    break;
                default:
                    titleStartIndex = 0;
                    break;
            }
            if(myData.propertyDataSameAsClient)
            {
                sameClientCheck.IsChecked = true;
            }
           
           
        }



        private void btn_ReturnToMain(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainWindow());
        }

       

        private void btn_NextPage(object sender, RoutedEventArgs e)
        {


            myParent = MetroWindow.GetWindow(this) as PageSwitcher;
            myData = new ContractDataManager();
            myData = myParent.contractData;

            myData.PAGE1VISIT = true;

            AddressExData property = new AddressExData();
            property.lot = propAssLot.Text;
            property.map = propAssMap.Text;
            property.block = propAssBlock.Text;
            property.state = "MA";
            property.street = propAddress.Text;
            property.town = propTown.Text;
            property.zip = propZip.Text;
            

            myData.Property = property;

            ContactData client = new ContactData();
            client.FirstName = FNAME.Text;
            client.LastName = LNAME.Text;
            client.phone = "0";
            client.state = prepState.Text;
            client.street = prepAddress.Text;
            client.town = prepTown.Text;
            client.zip = prepZip.Text;

            if (!(string.IsNullOrWhiteSpace(CO.Text)))
            {
                client.co = CO.Text;
            }
            if (!(TitleBox.Text == "None"))
            {
                client.title = TitleBox.Text;
            }
            myData.Client = client;

            if (sameClientCheck.IsChecked.Value)
            {
                myData.propertyDataSameAsClient = true;
                property.street = client.street;
                property.town = client.town;
                property.zip = client.zip;
            }

            myData.ProposalType = Combo.SelectedItem.ToString();

            //DocumentController.WriteContractProp(myData);
            if(!myData.PAGE2VISIT)
            {
                Switcher.Switch(new ContractP_Pg2(myData));
            }
            else
            {
                Switcher.Switch(new ContractP_Pg2(false, myData));
            }

            
                
        }
        private void btn_Cancel(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainWindow());
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ForceComboLoad()
        { 
            Combo.ItemsSource = new ProposalTypes().myList;
            Combo.SelectedIndex = 0;
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox box = sender as ComboBox;
            box.ItemsSource = new ProposalTypes().myList;
            if(comboStartIndex >=0)
            {
                box.SelectedIndex = comboStartIndex;
            }
            else
            {
                box.SelectedIndex = 0;
            }
        }
        private void TitleBox_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox box = sender as ComboBox;
            if(titleStartIndex >=0)
            {
                box.SelectedIndex = titleStartIndex;
            }
            else
            {
                box.SelectedIndex = 0;
            }
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            propAddressLabel.Visibility = Visibility.Hidden;
            propAddress.Visibility = Visibility.Hidden;
            propTown.Visibility = Visibility.Hidden;
            propTownLabel.Visibility = Visibility.Hidden;
            propZip.Visibility = Visibility.Hidden;
            propZipLabel.Visibility = Visibility.Hidden;
           
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            propAddressLabel.Visibility = Visibility.Visible;
            propAddress.Visibility = Visibility.Visible;
            propTown.Visibility = Visibility.Visible;
            propTownLabel.Visibility = Visibility.Visible;
            propZip.Visibility = Visibility.Visible;
            propZipLabel.Visibility = Visibility.Visible;
        }
    }
}
