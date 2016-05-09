﻿using System;
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
using System.Windows.Shapes;

using MahApps.Metro.Controls;
namespace ProposalGenerator
{
    /// <summary>
    /// Interaction logic for PageSwitcher.xaml
    /// </summary>
    public partial class PageSwitcher : MetroWindow
    {
        public DataManager myData;

        public PageSwitcher()
        {
            InitializeComponent();
            myData = new DataManager();
            Switcher.pageSwitcher = this;
            Switcher.Switch(new MainWindow());
        }

        public void Navigate(UserControl nextPage)
        { 
            this.Content = nextPage;
        }
        public void Navigate(UserControl nextPage, object state)
        {
            this.Content = nextPage;
            ISwitchable s = nextPage as ISwitchable;

            if(s != null)
            {
                s.UtilizeState(state);
            }
            else
            {
                throw new ArgumentException("NextPage is not ISwitchable! " + nextPage.Name.ToString());
            }
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
