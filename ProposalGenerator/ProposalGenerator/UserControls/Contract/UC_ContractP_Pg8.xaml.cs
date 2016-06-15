using MahApps.Metro.Controls;
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
    public partial class ContractP_Pg8 : UserControl
    {
        int currTextBox = 0;
        ContractDataManager myData;

        public ContractP_Pg8(ContractDataManager inData)
        {
            InitializeComponent();
            myData = inData;
            InitializePage(false);

        }
        public ContractP_Pg8(bool IGNORE, ContractDataManager inData)
        {
            InitializeComponent();
            myData = inData;
            InitializePage(true);
        }

        void InitializePage(bool hasVisited)
        {
            if(!hasVisited)
            {
                
                int count = 0;
                
                for(int x = 0; x < myData.myTaskList.Count; x++)
                {
                    TextBlock tempLabel = new TextBlock();
                    TextBox tempBox = new TextBox();
                    tempLabel.Name = "Base_L_" + x.ToString();
                    tempLabel.Text = myData.myTaskList[x].HeadLevelItem;
                    tempLabel.FontSize = 12;
                    
                    tempLabel.Margin = new Thickness(15);
                    tempBox.Name = "Base_B_" + x.ToString();
                    tempBox.Text = myData.myTaskList[x].cost.ToString();
                    tempBox.Margin = new Thickness(10);

                    
                    count++;

                    SP1.Children.Add(tempLabel);
                    SP1.RegisterName(tempLabel.Name, tempLabel);
                    SP3.Children.Add(tempBox);
                    SP3.RegisterName(tempBox.Name, tempBox);

                    Separator temp = new Separator();
                    temp.Name = "Sep_" + x.ToString() + "_1";
                    temp.Height = 1;
                    temp.Margin = new Thickness(-1);
                    SP1.Children.Add(temp);
                    SP1.RegisterName(temp.Name, temp);
                    Separator temp2 = new Separator();
                    temp2.Name = "Sep_" + x.ToString() + "_2";
                    temp2.Height = 1;
                    temp2.Margin = new Thickness(-1);
                    SP3.Children.Add(temp2);
                    SP3.RegisterName(temp2.Name, temp2);

                    for (int y = 0; y < myData.myTaskList[x].subTasks.Count; y++)
                    {
                        if(myData.myTaskList[x].subTasks[y].myClass == ContractSubtaskClass.Letter)
                        {
                            TextBlock tempLabelSub = new TextBlock();
                            TextBox tempBoxSub = new TextBox();

                            tempLabelSub.Name = "Sub_L_" + x.ToString() + "_" + y.ToString();
                            tempLabelSub.Text = "----->" + myData.myTaskList[x].subTasks[y].name;
                            tempLabelSub.Margin = new Thickness(15);
                            tempLabelSub.FontSize = 12;

                            tempBoxSub.Name = "Sub_B_" + x.ToString() + "_" + y.ToString();
                            tempBoxSub.Margin = new Thickness(10);
                            tempBoxSub.Text = myData.myTaskList[x].subTasks[y].cost.ToString();
                            SP1.Children.Add(tempLabelSub);
                            SP1.RegisterName(tempLabelSub.Name, tempLabelSub);
                            SP3.Children.Add(tempBoxSub);
                            SP3.RegisterName(tempBoxSub.Name, tempBoxSub);

                            Separator temp3 = new Separator();
                            temp3.Name = "Sep_" + x.ToString() + "_" + y.ToString() + "_1";
                            temp3.Height = 3;
                            SP1.Children.Add(temp3);
                            SP1.RegisterName(temp3.Name, temp3);
                            Separator temp4 = new Separator();
                            temp4.Height = 3;
                            temp4.Name = "Sep_" + x.ToString() + "_" + y.ToString() + "_2";
                            SP3.Children.Add(temp4);
                            SP3.RegisterName(temp4.Name, temp4);
                        }
                    }
                }
            }
            else
            {

            }
        }

        void SavePage()
        {
            for(int i = 0; i < myData.myTaskList.Count; i++)
            {
                TextBox myBox = SP3.FindChild<TextBox>("Base_B_" + i.ToString());
                if(!(myBox == null))
                {
                    float.TryParse(myBox.Text, out myData.myTaskList[i].cost);
                }

                for(int j = 0; j < myData.myTaskList[i].subTasks.Count; j++)
                {
                    if(myData.myTaskList[i].subTasks[j].myClass == ContractSubtaskClass.Letter)
                    {
                        myBox = SP3.FindChild<TextBox>("Sub_B_" + i.ToString() + "_" + j.ToString());
                        if (!(myBox == null))
                        {
                            float.TryParse(myBox.Text, out myData.myTaskList[i].subTasks[j].cost);
                        }
                    }

                }
            }
        }

        #region buttons
        private void btn_ReturnToMain(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainWindow());
        }

        private void btn_NextPage(object sender, RoutedEventArgs e)
        {
            SavePage();
            Switcher.Switch(new ContractP_Pg9(myData));
        }
        private void btn_Cancel(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainWindow());
        }
        private void btn_Back(object sender, RoutedEventArgs e)
        {
            
        }
        
       
        void buttonSPB_Click(object sender, RoutedEventArgs e)
        {
            


        }
        private void btn_RemoveLast(object sender, RoutedEventArgs e)
        {
            
        }
        #endregion
    }

}
