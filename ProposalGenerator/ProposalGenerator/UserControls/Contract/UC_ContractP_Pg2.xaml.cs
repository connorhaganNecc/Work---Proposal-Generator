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
    public partial class ContractP_Pg2 : UserControl, ISwitchable
    {
        PageSwitcher myParent;
        ContractDataManager myData;

        public ContractP_Pg2(ContractDataManager inData)
        {
            
            InitializeComponent();
            myData = inData;
            

        }
        public ContractP_Pg2(bool IGNORE, ContractDataManager inData)
        {

            InitializeComponent();

            CustomArea.Text = inData.CustomParagraph;
        }

        private void btn_ReturnToMain(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainWindow());
        }

        

        private void btn_NextPage(object sender, RoutedEventArgs e)
        {
            myParent = MetroWindow.GetWindow(this) as PageSwitcher;
            myData = myParent.contractData;

            myData.CustomParagraph = CustomArea.Text;
            myData.PAGE2VISIT = true;

            DocumentController.WriteContractProp(myData);
            if(myData.PAGE3VISIT)
            {
                //Switcher.Switch(new ScottL_Pg3(false, myData));
            }
            else
            {
                //Switcher.Switch(new ScottL_Pg3(myData));
            }
        }

        private void btn_Back(object sender, RoutedEventArgs e)
        {
            myParent = MetroWindow.GetWindow(this) as PageSwitcher;
            myData = myParent.contractData;
            myData.CustomParagraph = CustomArea.Text;

            myData.PAGE2VISIT = true;
            Switcher.Switch(new ContractP_Pg1(true, myData));
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
