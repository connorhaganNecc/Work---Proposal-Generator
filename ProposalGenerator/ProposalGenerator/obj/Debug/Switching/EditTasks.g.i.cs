﻿#pragma checksum "..\..\..\Switching\EditTasks.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "219E031710C42EFB8D0F680A14F05521"
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
    /// EditTasks
    /// </summary>
    public partial class EditTasks : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\..\Switching\EditTasks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TaskSelector;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Switching\EditTasks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox HeadText;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Switching\EditTasks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Fee;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Switching\EditTasks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BodyText;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Switching\EditTasks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox UnselectedTags;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\Switching\EditTasks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox SelectedTags;
        
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
            System.Uri resourceLocater = new System.Uri("/ProposalGenerator;component/switching/edittasks.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Switching\EditTasks.xaml"
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
            this.TaskSelector = ((System.Windows.Controls.ComboBox)(target));
            
            #line 37 "..\..\..\Switching\EditTasks.xaml"
            this.TaskSelector.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TaskSelector_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.HeadText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Fee = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.BodyText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.UnselectedTags = ((System.Windows.Controls.ListBox)(target));
            return;
            case 6:
            this.SelectedTags = ((System.Windows.Controls.ListBox)(target));
            return;
            case 7:
            
            #line 80 "..\..\..\Switching\EditTasks.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_AddTask);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 82 "..\..\..\Switching\EditTasks.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_RemoveTask);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 91 "..\..\..\Switching\EditTasks.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_ReturnToMain);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 98 "..\..\..\Switching\EditTasks.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_Finish);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

