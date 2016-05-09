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
    public partial class OpeningArea : UserControl, ISwitchable
    {
        PageSwitcher myParent;
        DataManager myData;

        public OpeningArea()
        {
            
            InitializeComponent();
            CustomRE.Visibility = Visibility.Hidden;
            ReLabel.Visibility = Visibility.Hidden;
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

            Switcher.Switch(new TaskPage(myData));
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
    }
}
