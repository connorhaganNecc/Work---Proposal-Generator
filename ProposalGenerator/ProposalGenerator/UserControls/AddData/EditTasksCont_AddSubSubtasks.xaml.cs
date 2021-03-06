﻿using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;

using MahApps.Metro.Controls;
namespace ProposalGenerator
{
    /// <summary>
    /// Interaction logic for EditTasks.xaml
    /// </summary>
    public partial class EditTasksCont_AddSubSubtasks : UserControl, ISwitchable
    {
        ContractTaskList myList;
        int currIndex;
        int subIndex;


        public EditTasksCont_AddSubSubtasks(int inIndex, int subSubindex, ContractTaskList inList)
        {
            InitializeComponent();
            myList = inList;
            subIndex = subSubindex;
            currIndex = inIndex;
            //Header.Content = myList.myTasks[currIndex].HeadLevelItem;
        }
        //public EditTasksCont(ContractTaskList inList, int inIndex)
        //{
        //    InitializeComponent();
        //    myList = inList;
        //    List<string> taskListString = new List<string>();
        //    myList.myTasks.Sort((x, y) => x.HeadLevelItem.CompareTo(y.HeadLevelItem));
        //    for (int i = 0; i < myList.myTasks.Count; i++)
        //    {
        //        taskListString.Add(myList.myTasks[i].HeadLevelItem);
        //    }
        //    TaskSelector.ItemsSource = taskListString;

        //    currIndex = inIndex;
        //    TaskSelector.SelectedIndex = currIndex;
        //}
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void btn_ReturnToMain(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainWindow());
        }
        
        private void btn_Finish(object sender, RoutedEventArgs e)
        {
            //if(currIndex>=0 && currIndex<myList.myTasks.Count)
            //{
            //    myList.myTasks[currIndex].HeadLevelItem = HeadText.Text;
            //    myList.myTasks[currIndex].ServiceItemNum = Convert.ToInt32(ServiceItem.Text);
            //    myList.myTasks[currIndex].Description = Description.Text;
            //    ContractTaskSerializer.SerializeContractTasks(myList);
            //    Switcher.Switch(new AddData());
            //}
            //else
            //{
            //    Switcher.Switch(new AddData());
            //}
            if(!string.IsNullOrWhiteSpace(nameBox.Text))
            {
                SubSubtask temp = new SubSubtask();
                temp.name = nameBox.Text;
                myList.myTasks[currIndex].subTasks[subIndex].SubItems.Add(temp);
            }
            Switcher.Switch(new EditSubSub(currIndex, subIndex, myList));
        }

        private void TaskSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //for(int i = 0; i < myList.myTasks.Count; i++)
            //{
            //    if(TaskSelector.SelectedValue.ToString() ==  myList.myTasks[i].HeadLevelItem)
            //    {
            //        HeadText.Text = myList.myTasks[i].HeadLevelItem;
            //        ServiceItem.Text = myList.myTasks[i].ServiceItemNum.ToString();
            //        currIndex = i;
            //        Description.Text = myList.myTasks[i].Description;
            //    }
            //}
        }

        private void btn_AddNewSubtask(object sender, RoutedEventArgs e)
        {

        }


        //private void btn_EditTaskText(object sender, RoutedEventArgs e)
        //{
        //    if(TaskSelector.SelectedIndex >=0)
        //        Switcher.Switch(new EditTaskText(myList, TaskSelector.SelectedIndex));
        //    else
        //    {
        //        MessageBox.Show("Please select a task first");
        //    }
        //}
    }
}
