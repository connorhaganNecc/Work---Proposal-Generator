﻿#pragma checksum "..\..\..\..\UserControls\Contract\UC_ContractP_Pg5.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "80D82DFFBDA22632C66464B203D966DE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls;
using ProposalGenerator.UserControls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ProposalGenerator {
    
    
    /// <summary>
    /// ContractP_Pg5
    /// </summary>
    public partial class ContractP_Pg5 : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\..\..\UserControls\Contract\UC_ContractP_Pg5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox UnselectedNormalList;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\UserControls\Contract\UC_ContractP_Pg5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox SelectedList;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ProposalGenerator;component/usercontrols/contract/uc_contractp_pg5.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserControls\Contract\UC_ContractP_Pg5.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.UnselectedNormalList = ((System.Windows.Controls.ListBox)(target));
            
            #line 39 "..\..\..\..\UserControls\Contract\UC_ContractP_Pg5.xaml"
            this.UnselectedNormalList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lb_NormalSelectChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 54 "..\..\..\..\UserControls\Contract\UC_ContractP_Pg5.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_RemoveTask);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 57 "..\..\..\..\UserControls\Contract\UC_ContractP_Pg5.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_AddTask);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SelectedList = ((System.Windows.Controls.ListBox)(target));
            return;
            case 5:
            
            #line 75 "..\..\..\..\UserControls\Contract\UC_ContractP_Pg5.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_MoveUp);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 78 "..\..\..\..\UserControls\Contract\UC_ContractP_Pg5.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_MoveDown);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 86 "..\..\..\..\UserControls\Contract\UC_ContractP_Pg5.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_ReturnToMain);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 100 "..\..\..\..\UserControls\Contract\UC_ContractP_Pg5.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_NextPage);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 105 "..\..\..\..\UserControls\Contract\UC_ContractP_Pg5.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_Back);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

