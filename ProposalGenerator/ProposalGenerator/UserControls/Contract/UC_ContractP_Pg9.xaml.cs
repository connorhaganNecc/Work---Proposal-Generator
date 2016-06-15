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
    public partial class ContractP_Pg9 : UserControl
    {
        int ClosingTypeIndex = 0;
        int TermsTypeIndex = 0;

        public ContractP_Pg9(ContractDataManager myData)
        {
            InitializeComponent();
        }

        public ContractP_Pg9(bool ignore, ContractDataManager myData)
        {
            InitializeComponent();
            forceCombosLoad();
            

        }

        private void forceCombosLoad()
        {
            List<string> newList = new List<string>();
            newList.Add("Short"); newList.Add("Long");
            TermsSelection.ItemsSource = newList;
            TermsSelection.SelectedIndex = 0;
        }

        private void ComboBox_ClosingSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_ClosingLoaded(object sender, RoutedEventArgs e)
        {
            ComboBox box = sender as ComboBox;
            box.ItemsSource = new ClosingTypes().myList;
            box.SelectedIndex = ClosingTypeIndex;
        }

        private void ComboBox_TermsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_TermsLoaded(object sender, RoutedEventArgs e)
        {
            ComboBox box = sender as ComboBox;
            List<string> newList = new List<string>();
            newList.Add("Short"); newList.Add("Long");
            box.ItemsSource = newList;
            box.SelectedIndex = TermsTypeIndex;
        }

        #region buttons
        private void btn_ReturnToMain(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainWindow());
        }

        private void btn_NextPage(object sender, RoutedEventArgs e)
        {
            PageSwitcher myParent;
            ContractDataManager myData;
            myParent = MetroWindow.GetWindow(this) as PageSwitcher;
            myData = myParent.contractData;

            

            if(RetainerAmount.Text != null && RetainerAmount.Text != "")
            {
                myData.retainer = int.Parse(RetainerAmount.Text);
            }
            else
            {
                myData.retainer = 50;
            }
            switch(((ComboBoxItem)SigSelect.SelectedItem).Content.ToString())
            {
                case "John Closer":
                    myData.author.name = "John M. Morin, P.E.";
                    myData.author.title = "Principal";
                    break;
                case "Scott Closer":
                    myData.author.name = "Scott P. Cameron, P.E.";
                    myData.author.title = "Principal";
                    break;
                case "Phil Closer":
                    myData.author.name = "Phillip A. Yetman, P.L.S.";
                    myData.author.title = "Project Manager";
                    break;
                case "Mike Closer":
                    myData.author.name = "Michael C. Laham, P.E.";
                    myData.author.title = "Project Manager";
                    break;
                default:
                    break;
            }
            myData.TermsType = TermsSelection.SelectedItem.ToString();

            bool finish = DocumentController.WriteContractProp(myData);

            if(finish)
            {
                Switcher.Switch(new MainWindow());
            }
        }
        private void btn_Cancel(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainWindow());
        }
        private void btn_Back(object sender, RoutedEventArgs e)
        {
            
        }
        #endregion

        private void SigSelect_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }

}
