﻿#pragma checksum "..\..\..\..\UserControls\Contract\UC_ScottL_Pg2.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C3CDE856BBEAB076F107C95911B26C60"
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
    /// ScottL_Pg2
    /// </summary>
    public partial class ScottL_Pg2 : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 51 "..\..\..\..\UserControls\Contract\UC_ScottL_Pg2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox myCheckBox;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\UserControls\Contract\UC_ScottL_Pg2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ReLabel;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\UserControls\Contract\UC_ScottL_Pg2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CustomRE;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\UserControls\Contract\UC_ScottL_Pg2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Dear;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\..\UserControls\Contract\UC_ScottL_Pg2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CustomArea;
        
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
            System.Uri resourceLocater = new System.Uri("/ProposalGenerator;component/usercontrols/contract/uc_scottl_pg2.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserControls\Contract\UC_ScottL_Pg2.xaml"
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
            this.myCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 51 "..\..\..\..\UserControls\Contract\UC_ScottL_Pg2.xaml"
            this.myCheckBox.Checked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 51 "..\..\..\..\UserControls\Contract\UC_ScottL_Pg2.xaml"
            this.myCheckBox.Unchecked += new System.Windows.RoutedEventHandler(this.CheckBox_Unchecked);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ReLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.CustomRE = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Dear = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.CustomArea = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            
            #line 88 "..\..\..\..\UserControls\Contract\UC_ScottL_Pg2.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_ReturnToMain);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 103 "..\..\..\..\UserControls\Contract\UC_ScottL_Pg2.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_NextPage);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 108 "..\..\..\..\UserControls\Contract\UC_ScottL_Pg2.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_Back);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 113 "..\..\..\..\UserControls\Contract\UC_ScottL_Pg2.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_Cancel);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

