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
    public partial class EditAddItems : UserControl
    {
        List<string> UnselectTaskTags;
        List<string> SelectedTaskTags;
        List<string> UnselectTypeTags;
        List<string> SelectedTypeTags;

        List<string> AdditionalServiceNames;
        int currIndex;
        AdditionalServiceList myList;
        

        public EditAddItems()
        {
            InitializeComponent();
            myList = AdditionalItemsSerializer.DeserializeList();
            myList.itemList.Sort((x, y) => x.name.CompareTo(y.name));
            SetupComboBox();
            ResetUnselect();
            ClearSelect();
            currIndex = -1;
        }

        private void SetupComboBox()
        {
            AdditionalServiceNames = new List<string>();
            for(int i = 0; i < myList.itemList.Count; i++)
            {
                AdditionalServiceNames.Add(myList.itemList[i].name);
            }
            ItemSelector.ItemsSource = AdditionalServiceNames;
        }

        private void ClearSelect()
        {
            SelectedTaskTags = new List<string>();
            SelectedIgnoreTask.ItemsSource = SelectedTaskTags;

            SelectedTypeTags = new List<string>();
            SelectedIgnoreType.ItemsSource = SelectedTypeTags;
        }

        private void pullSelect()
        {
            SelectedTaskTags = myList.itemList[currIndex].ignoreTaskTags;
            SelectedIgnoreTask.ItemsSource = SelectedTaskTags;

            SelectedTypeTags = myList.itemList[currIndex].ignoreTypeTags;
            SelectedIgnoreType.ItemsSource = SelectedTypeTags;
        }

        private void ResetUnselect()
        {
            UnselectTaskTags = new List<string>();
            TaskList temp = TaskSerializer.DeserializeTaskList();
            for (int i = 0; i < temp.myTasks.Count; i++)
            {
                UnselectTaskTags.Add(temp.myTasks[i].Header);
            }
            UnselectTaskTags.Sort((x, y) => x.CompareTo(y));

            UnselectedIgnoreTask.ItemsSource = UnselectTaskTags;

            UnselectTypeTags = new ProposalTypes().myList;

            UnselectedIgnoreType.ItemsSource = UnselectTypeTags;

        }

        private void setupUnselect()
        {
            UnselectTaskTags = new List<string>();
            UnselectTypeTags = new List<string>();

            TaskList temp = TaskSerializer.DeserializeTaskList();
            for (int i = 0; i < temp.myTasks.Count; i++)
            {
                bool fail = false;
                for(int j = 0; j < SelectedTaskTags.Count; j++)
                {
                    if (temp.myTasks[i].Header == SelectedTaskTags[j])
                    {
                        fail = true;
                    }
                }
                if(!fail)
                {
                    UnselectTaskTags.Add(temp.myTasks[i].Header);
                }
            }
            UnselectTaskTags.Sort((x, y) => x.CompareTo(y));

            UnselectedIgnoreTask.ItemsSource = UnselectTaskTags;

            List<string> tempList = new ProposalTypes().myList;
            for(int i = 0; i < tempList.Count; i++)
            {
                bool fail = false;
                for (int j = 0; j < SelectedTypeTags.Count; j++)
                {
                    if(SelectedTypeTags[j] == tempList[i])
                    {
                        fail = true;
                    }
                }
                if(!fail)
                {
                    UnselectTypeTags.Add(tempList[i]);
                }
            }
            
            
            UnselectedIgnoreType.ItemsSource = UnselectTypeTags;
        }

        private void btn_RemoveSelected(object sender, RoutedEventArgs e)
        {
            if (SelectedIgnoreTask.SelectedIndex >= 0)
            {
                string myString = SelectedIgnoreTask.SelectedItem as string;
                UnselectTaskTags.Add(myString);
                SelectedTaskTags.RemoveAt(SelectedIgnoreTask.SelectedIndex);

                SelectedIgnoreTask.ItemsSource = null;
                UnselectedIgnoreTask.ItemsSource = null;

                SelectedTaskTags.Sort((x, y) => x.CompareTo(y));
                UnselectTaskTags.Sort((x, y) => x.CompareTo(y));

                SelectedIgnoreTask.ItemsSource = SelectedTaskTags;
                UnselectedIgnoreTask.ItemsSource = UnselectTaskTags;
                myList.itemList[currIndex].ignoreTypeTags = SelectedTaskTags;
            }
        }
        private void btn_AddSelected(object sender, RoutedEventArgs e)
        {
            if (UnselectedIgnoreTask.SelectedIndex >= 0)
            {
                string myString = UnselectedIgnoreTask.SelectedItem as string;
                SelectedTaskTags.Add(myString);
                UnselectTaskTags.RemoveAt(UnselectedIgnoreTask.SelectedIndex);

                SelectedIgnoreTask.ItemsSource = null;
                UnselectedIgnoreTask.ItemsSource = null;

                SelectedTaskTags.Sort((x, y) => x.CompareTo(y));
                UnselectTaskTags.Sort((x, y) => x.CompareTo(y));

                SelectedIgnoreTask.ItemsSource = SelectedTaskTags;
                UnselectedIgnoreTask.ItemsSource = UnselectTaskTags;

                myList.itemList[currIndex].ignoreTypeTags = SelectedTaskTags;
            }
        }
        private void btn_RemoveSelected2(object sender, RoutedEventArgs e)
        {
            if (SelectedIgnoreType.SelectedIndex >= 0)
            {
                string myString = SelectedIgnoreType.SelectedItem as string;
                UnselectTypeTags.Add(myString);
                SelectedTypeTags.RemoveAt(SelectedIgnoreType.SelectedIndex);

                SelectedIgnoreType.ItemsSource = null;
                UnselectedIgnoreType.ItemsSource = null;

                SelectedTypeTags.Sort((x, y) => x.CompareTo(y));
                UnselectTypeTags.Sort((x, y) => x.CompareTo(y));

                SelectedIgnoreType.ItemsSource = SelectedTypeTags;
                UnselectedIgnoreType.ItemsSource = UnselectTypeTags;

                myList.itemList[currIndex].ignoreTypeTags = SelectedTypeTags;
            }
        }
        private void btn_AddSelected2(object sender, RoutedEventArgs e)
        {
            if (UnselectedIgnoreType.SelectedIndex >= 0)
            {
                string myString = UnselectedIgnoreType.SelectedItem as string;
                SelectedTypeTags.Add(myString);
                UnselectTypeTags.RemoveAt(UnselectedIgnoreType.SelectedIndex);

                SelectedIgnoreType.ItemsSource = null;
                UnselectedIgnoreType.ItemsSource = null;

                SelectedTypeTags.Sort((x, y) => x.CompareTo(y));
                UnselectTypeTags.Sort((x, y) => x.CompareTo(y));

                SelectedIgnoreType.ItemsSource = SelectedTypeTags;
                UnselectedIgnoreType.ItemsSource = UnselectTypeTags;

                myList.itemList[currIndex].ignoreTypeTags = SelectedTypeTags;
            }
        }
        #region buttons
        private void btn_ReturnToMain(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainWindow());
        }

        private void btn_NextPage(object sender, RoutedEventArgs e)
        {
            //Serialize Task List Here
            myList.itemList[ItemSelector.SelectedIndex].name = TB_Name.Text;
            myList.itemList[ItemSelector.SelectedIndex].text = TB_Text.Text;
            AdditionalItemsSerializer.SerializeList(myList);
            Switcher.Switch(new AddData());
        }
        private void btn_Cancel(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new AddData());
        }
        #endregion

        private void ItemSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (currIndex > -1)
            {
                myList.itemList[currIndex].text = TB_Text.Text;
                myList.itemList[currIndex].name = TB_Name.Text;
            }
            TB_Name.Text = myList.itemList[ItemSelector.SelectedIndex].name;
            TB_Text.Text = myList.itemList[ItemSelector.SelectedIndex].text;
            currIndex = ItemSelector.SelectedIndex;
            pullSelect();
            setupUnselect();
        }
    }

}
