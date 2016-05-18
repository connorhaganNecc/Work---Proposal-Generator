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
    public partial class ScottL_Pg6 : UserControl
    {
        int ClosingTypeIndex = 0;
        int TermsTypeIndex = 0;

        public ScottL_Pg6(DataManager myData)
        {
            InitializeComponent();
        }

        public ScottL_Pg6(bool ignore, DataManager myData)
        {
            InitializeComponent();
            forceCombosLoad();
            for(int i = 0; i < SigSelect.Items.Count; i++)
            {
                ComboBoxItem temp = SigSelect.Items[i] as ComboBoxItem;

                if (temp.Content.ToString() == myData.SigCloser)
                {
                    SigSelect.SelectedIndex = i;
                }
            }
            for(int i = 1; i < ClosingSelection.Items.Count; i++)
            {
                string temp = ClosingSelection.Items[i] as string;
                if(temp == myData.ClosingType)
                {
                    ClosingTypeIndex = i;
                }
            }
            for(int i = 0; i < TermsSelection.Items.Count; i++)
            {
                string temp = TermsSelection.Items[i] as string;
                if(temp == myData.TermsType)
                {
                    TermsTypeIndex = i;
                }
            }

            RetainerAmount.Text = myData.retainerAmount.ToString();

        }

        private void forceCombosLoad()
        {
            ClosingSelection.ItemsSource = new ClosingTypes().myList;
            ClosingSelection.SelectedIndex = 0;

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
            DataManager myData;
            myParent = MetroWindow.GetWindow(this) as PageSwitcher;
            myData = new DataManager();
            myData = myParent.myData;

            if(RetainerAmount.Text != null && RetainerAmount.Text != "")
            {
                myData.retainerAmount = float.Parse(RetainerAmount.Text);
            }
            else
            {
                myData.retainerAmount = 50;
            }
            myData.SigCloser = ((ComboBoxItem)SigSelect.SelectedItem).Content.ToString();
            myData.ClosingType = ClosingSelection.SelectedItem.ToString();
            myData.TermsType = TermsSelection.SelectedItem.ToString();

            bool finish = DocumentController.WriteScottLProp(myData);

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
            PageSwitcher myParent;
            DataManager myData;
            myParent = MetroWindow.GetWindow(this) as PageSwitcher;
            myData = myParent.myData;

            myData.PAGE6VISIT = true;
            myData.SigCloser = ((ComboBoxItem)SigSelect.SelectedItem).Content.ToString();
            myData.ClosingType = ClosingSelection.SelectedItem.ToString();
            myData.TermsType = TermsSelection.SelectedItem.ToString();
            if (RetainerAmount.Text != null && RetainerAmount.Text != "")
            {
                myData.retainerAmount = float.Parse(RetainerAmount.Text);
            }
            else
            {
                myData.retainerAmount = 50;
            }
            if (myParent.myData.PAGE4VISIT)
            {
                Switcher.Switch(new ScottL_Pg4(false, myParent, myData));
            }
            else
            {
                Switcher.Switch(new ScottL_Pg3(false, myData));
            }
        }
        #endregion

        private void SigSelect_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }

}
