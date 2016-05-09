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
    public partial class PropPg1 : UserControl, ISwitchable
    {
        PageSwitcher myParent;
        DataManager myData;

        public PropPg1()
        {
            InitializeComponent();
        }

        private void btn_ReturnToMain(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainWindow());
        }

       

        private void btn_NextPage(object sender, RoutedEventArgs e)
        {
            myParent = MetroWindow.GetWindow(this) as PageSwitcher;
            myData = new DataManager();
            myData = myParent.myData;

            AddressExData property = new AddressExData();
            property.lot = propLot.Text;
            property.map = propMap.Text;
            property.state = "MA";
            property.street = propAddress.Text;
            property.town = propTown.Text;
            property.zip = propZip.Text;
            

            myData.PropertyLocation = property;

            ContactData client = new ContactData();
            client.FirstName = FNAME.Text;
            client.LastName = LNAME.Text;
            client.phone = prepPhone.Text;
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


            myData.ProposalType = Combo.SelectedItem.ToString();
            Switcher.Switch(new OpeningArea());
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

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox box = sender as ComboBox;
            box.ItemsSource = new ProposalTypes().myList;
            box.SelectedIndex = 0;
        }
    }
}
