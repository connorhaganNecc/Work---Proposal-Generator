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
using System.Xml.Serialization;
using System.IO;

using MahApps.Metro.Controls;

namespace ProposalGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : UserControl, ISwitchable
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_CreateProposal(object sender, RoutedEventArgs e)
        {
            clearAll();
            Switcher.Switch(new ProposalType());

        }
        private void btn_About(object sender, RoutedEventArgs e)
        {

        }
        private void btn_AddData(object sender, RoutedEventArgs e)
        {
            clearAll();
            Switcher.Switch(new AddData());
        }
        private void btn_Debug(object sender, RoutedEventArgs e)
        {
            clearAll();
            Switcher.Switch(new Debug());
        }
        public void UtilizeState(object state)
        {
            clearAll();
            throw new NotImplementedException();
        }

        private void btn_Settings(object sender, RoutedEventArgs e)
        {
            clearAll();
            Switcher.Switch(new SettingsMain());
        }

        private void btn_Close(object sender, RoutedEventArgs e)
        {
            clearAll();
            Application.Current.Shutdown();
        }

        private void clearAll()
        {
            DataManager myData;
            PageSwitcher myParent;
            myParent = MetroWindow.GetWindow(this) as PageSwitcher;
            myData = new DataManager();
            myData = myParent.myData;
            myParent.myData = new DataManager();
            DocumentController.ClearFilename();
        }
    }
}

//DEMO ON SERIALIZING
//
//ProposalGenerator.DataStructures.TaskStructure myStruct = new DataStructures.TaskStructure();
//myStruct.Body = "THIS IS THE BODY";
//            myStruct.Description = "A sample object";
//            myStruct.Header = "TESTING";
//            myStruct.ID = 1;
//            myStruct.Title = "Wow so test";

//            List<ProposalGenerator.DataStructures.TaskStructure> mylist = new List<DataStructures.TaskStructure>();
//mylist.Add(myStruct);
//            mylist.Add(myStruct);
//            mylist.Add(myStruct);
//            mylist.Add(myStruct);
//            mylist.Add(myStruct);

//            XmlSerializer serial = new XmlSerializer(typeof(List<ProposalGenerator.DataStructures.TaskStructure>));
//TextWriter writeFS = new StreamWriter(@"C:\demo\tasks.xml");

//serial.Serialize(writeFS, mylist);
//            writeFS.Close();