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
    public partial class AddAddItems : UserControl
    {
        public AddAddItems()
        {
            InitializeComponent();
        }



        #region buttons
        private void btn_ReturnToMain(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainWindow());
        }

        private void btn_NextPage(object sender, RoutedEventArgs e)
        {
            //Serialize Task List Here
            AdditionalServiceItem temp = new AdditionalServiceItem();
            temp.name = TB_Name.Text;
            temp.text = TB_Text.Text;

            AdditionalServiceList newList = AdditionalItemsSerializer.DeserializeList();
            newList.itemList.Add(temp);

            AdditionalItemsSerializer.SerializeList(newList);
            Switcher.Switch(new AddData());
        }
        private void btn_Cancel(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new AddData());
        }
        #endregion
    }

}
