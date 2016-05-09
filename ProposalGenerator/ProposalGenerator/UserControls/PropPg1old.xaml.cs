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
    public partial class PropPg1old : UserControl, ISwitchable
    {
        PageSwitcher myParent;
        DataManager myData;

        public PropPg1old()
        {
            InitializeComponent();
        }

        private void btn_ReturnToMain(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainWindow());
        }

        private void btn_OpenSaveDialog(object sender, RoutedEventArgs e)
        {
            DocumentController.OpenFileDialog();
        }

        private void btn_NextPage(object sender, RoutedEventArgs e)
        {
            myParent = MetroWindow.GetWindow(this) as PageSwitcher;
            myData = new DataManager();
            myData = myParent.myData;

            AddressExData passing = new AddressExData();
            passing.lot = propLot.Text;
            passing.map = propMap.Text;
            passing.state = "MA";
            passing.street = propAddress.Text;
            passing.town = propTown.Text;
            passing.zip = propZip.Text;
            passing.ToUpper();

            myData.PropertyLocation = passing;

            ContactData passing2 = new ContactData();
            passing2.FirstName = prepName.Text;
            passing2.phone = prepPhone.Text;
            passing2.state = prepState.Text;
            passing2.street = prepAddress.Text;
            passing2.town = prepTown.Text;
            passing2.zip = prepZip.Text;

            myData.Client = passing2;

            Switcher.Switch(new OpeningArea());
        }
        private void btn_Cancel(object sender, RoutedEventArgs e)
        {

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
