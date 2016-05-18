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
    public partial class ScottL_Pg2 : UserControl, ISwitchable
    {
        PageSwitcher myParent;
        DataManager myData;

        public ScottL_Pg2(DataManager inData)
        {
            
            InitializeComponent();
            myData = inData;
            CustomRE.Visibility = Visibility.Hidden;
            ReLabel.Visibility = Visibility.Hidden;
            if(myData.ProposalType != "Septic Repair")
            {
                CustomArea.Text = "The Morin-Cameron Group, Inc. is pleased to provide you with this proposal for engineering and surveying services, in connection with the above referenced lot, for the terms and conditions contained herewith. ";
                myCheck.Visibility = Visibility.Hidden;
                myCheckLabel.Visibility = Visibility.Hidden;
            }
            else
            {
                CustomArea.Text = "The Morin-Cameron Group, Inc. is pleased to provide you with this proposal for engineering and surveying services, in connectgion with the replacement of the septic system at your proerpty, for the terms and conditions contained herewith.";
                CustomArea.Text += "\n\nIt was a pleasure speaking with you the other day regarding your existing septic system. Based on our discussion you have indicated that your septic system failed a Title 5 inspection and, therefore, needs to be replaced.";
            }
            

        }
        public ScottL_Pg2(bool IGNORE, DataManager inData)
        {

            InitializeComponent();
            CustomRE.Visibility = Visibility.Hidden;
            ReLabel.Visibility = Visibility.Hidden;
            myData = inData;

            string dearFixed = myData.DearLine;
            dearFixed = dearFixed.Replace(":", "");
            dearFixed = dearFixed.Remove(0, 5);
            Dear.Text = dearFixed;

            CustomArea.Text = myData.CustomParagraph;

            if(myData.useCustomReLine)
            {
                myCheckBox.IsChecked = true;
                CustomRE.Text = myData.CustomReLine;
            }
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
            myData.DearLine = "";
            myData.DearLine = "Dear ";
            myData.DearLine += Dear.Text + ":";
            myData.CustomParagraph = CustomArea.Text;

            if(myCheckBox.IsChecked.Value)
            {
                myData.useCustomReLine = true;
                myData.CustomReLine = CustomRE.Text;
            }
            myData.PAGE2VISIT = true;
            if(myData.PAGE3VISIT)
            {
                Switcher.Switch(new ScottL_Pg3(false, myData));
            }
            else
            {
                Switcher.Switch(new ScottL_Pg3(myData));
            }
        }

        private void btn_Back(object sender, RoutedEventArgs e)
        {
            myParent = MetroWindow.GetWindow(this) as PageSwitcher;
            myData = new DataManager();
            myData = myParent.myData;
            myData.DearLine = "";
            myData.DearLine = "Dear ";
            myData.DearLine += Dear.Text + ":";
            myData.CustomParagraph = CustomArea.Text;

            if (myCheckBox.IsChecked.Value)
            {
                myData.useCustomReLine = true;
                myData.CustomReLine = CustomRE.Text;
            }
            myData.PAGE2VISIT = true;
            Switcher.Switch(new ScottL_Pg1(true, myData));
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

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ReLabel.Visibility = Visibility.Visible;
            CustomRE.Visibility = Visibility.Visible;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CustomRE.Visibility = Visibility.Hidden;
            ReLabel.Visibility = Visibility.Hidden;
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {

            CustomArea.Text = "The Morin-Cameron Group, Inc. is pleased to provide you with this proposal for engineering and surveying services, in connectgion with the replacement of the septic system at your proerpty, for the terms and conditions contained herewith.";
            CustomArea.Text += "\n\nIt was a pleasure speaking with you the other day regarding your existing septic system. Based on our discussion you have indicated that your septic system failed a Title 5 inspection and, therefore, needs to be replaced. Based on our review of available on-line data, it appears wetland resource areas exist at the rear of our property. Any work proposed within 100 feet of the wetlands requires a permit from the %TOWN% Conservation Commission. It appears that some work may be located within 100 feet of these wetlands; therefore, we have included a task to have the wetlands delineated and a task to file appropriate application with the %TOWN% Conservation Commission. Your property is also located within areas mapped by Natural Heritage as estimated habitat for rare wildlife and priority habitat for rare species. If a filing with the Conservation Commission is required additional information will be submitted to Natural Heritage, as required.";
            CustomArea.Text = CustomArea.Text.Replace("%TOWN%", myData.PropertyLocation.town);

        }

        private void myCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            CustomArea.Text = "The Morin-Cameron Group, Inc. is pleased to provide you with this proposal for engineering and surveying services, in connectgion with the replacement of the septic system at your proerpty, for the terms and conditions contained herewith.";
            CustomArea.Text += "\n\nIt was a pleasure speaking with you the other day regarding your existing septic system. Based on our discussion you have indicated that your septic system failed a Title 5 inspection and, therefore, needs to be replaced.";
        }
    }
}
