﻿#pragma checksum "..\..\..\..\UserControls\AddData\EditTasksCont_Subtasks.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6DFDAB3550A6C78737DCB4532C567C72"
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
    /// EditTasksCont_Subtasks
    /// </summary>
    public partial class EditTasksCont_Subtasks : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 41 "..\..\..\..\UserControls\AddData\EditTasksCont_Subtasks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TaskSelector;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\UserControls\AddData\EditTasksCont_Subtasks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button newSubtask;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\UserControls\AddData\EditTasksCont_Subtasks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Header;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\UserControls\AddData\EditTasksCont_Subtasks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SubtaskClass;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\UserControls\AddData\EditTasksCont_Subtasks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DescriptionBox;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\UserControls\AddData\EditTasksCont_Subtasks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label AllowSubSubtasksLabel;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\UserControls\AddData\EditTasksCont_Subtasks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox AllowSubSubtaks;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\UserControls\AddData\EditTasksCont_Subtasks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditSubSub;
        
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
            System.Uri resourceLocater = new System.Uri("/ProposalGenerator;component/usercontrols/adddata/edittaskscont_subtasks.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserControls\AddData\EditTasksCont_Subtasks.xaml"
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
            
            #line 42 "..\..\..\..\UserControls\AddData\EditTasksCont_Subtasks.xaml"
            this.TaskSelector.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TaskSelector_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.newSubtask = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\..\UserControls\AddData\EditTasksCont_Subtasks.xaml"
            this.newSubtask.Click += new System.Windows.RoutedEventHandler(this.btn_AddNewSubtask);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Header = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.SubtaskClass = ((System.Windows.Controls.ComboBox)(target));
            
            #line 49 "..\..\..\..\UserControls\AddData\EditTasksCont_Subtasks.xaml"
            this.SubtaskClass.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ClassSelector_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.DescriptionBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.AllowSubSubtasksLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.AllowSubSubtaks = ((System.Windows.Controls.CheckBox)(target));
            
            #line 58 "..\..\..\..\UserControls\AddData\EditTasksCont_Subtasks.xaml"
            this.AllowSubSubtaks.Checked += new System.Windows.RoutedEventHandler(this.subsubTasks_Checked);
            
            #line default
            #line hidden
            
            #line 58 "..\..\..\..\UserControls\AddData\EditTasksCont_Subtasks.xaml"
            this.AllowSubSubtaks.Unchecked += new System.Windows.RoutedEventHandler(this.subsubTasks_Unchecked);
            
            #line default
            #line hidden
            return;
            case 8:
            this.EditSubSub = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\..\UserControls\AddData\EditTasksCont_Subtasks.xaml"
            this.EditSubSub.Click += new System.Windows.RoutedEventHandler(this.editsubsub_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 89 "..\..\..\..\UserControls\AddData\EditTasksCont_Subtasks.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_ReturnToMain);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 96 "..\..\..\..\UserControls\AddData\EditTasksCont_Subtasks.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_Finish);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

