﻿#pragma checksum "D:\GitHub\KraakJeRot\ResourceFramework\UserControls\HUD\CountDownTimer\Flipper.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "18161D897196FF25B6674FA6C63C66F3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace ResourceFramework.UserControls.HUD {
    
    
    public partial class Flipper : System.Windows.Controls.UserControl {
        
        internal System.Windows.Media.Animation.Storyboard Storyboard1;
        
        internal System.Windows.Controls.Border LayoutRoot;
        
        internal System.Windows.Controls.Border BlockTop;
        
        internal System.Windows.Controls.Viewbox vb1;
        
        internal System.Windows.Controls.TextBlock textBlockTop;
        
        internal System.Windows.Controls.Border BlockBottom;
        
        internal System.Windows.Controls.Viewbox vb2;
        
        internal System.Windows.Controls.TextBlock textBlockBottom;
        
        internal System.Windows.Controls.Border BlockFlipTop;
        
        internal System.Windows.Controls.Viewbox vb3;
        
        internal System.Windows.Controls.TextBlock textBlockFlipTop;
        
        internal System.Windows.Controls.Border BlockFlipBottom;
        
        internal System.Windows.Controls.Viewbox vb4;
        
        internal System.Windows.Controls.TextBlock textBlockFlipBottom;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/ResourceFramework;component/UserControls/HUD/CountDownTimer/Flipper.xaml", System.UriKind.Relative));
            this.Storyboard1 = ((System.Windows.Media.Animation.Storyboard)(this.FindName("Storyboard1")));
            this.LayoutRoot = ((System.Windows.Controls.Border)(this.FindName("LayoutRoot")));
            this.BlockTop = ((System.Windows.Controls.Border)(this.FindName("BlockTop")));
            this.vb1 = ((System.Windows.Controls.Viewbox)(this.FindName("vb1")));
            this.textBlockTop = ((System.Windows.Controls.TextBlock)(this.FindName("textBlockTop")));
            this.BlockBottom = ((System.Windows.Controls.Border)(this.FindName("BlockBottom")));
            this.vb2 = ((System.Windows.Controls.Viewbox)(this.FindName("vb2")));
            this.textBlockBottom = ((System.Windows.Controls.TextBlock)(this.FindName("textBlockBottom")));
            this.BlockFlipTop = ((System.Windows.Controls.Border)(this.FindName("BlockFlipTop")));
            this.vb3 = ((System.Windows.Controls.Viewbox)(this.FindName("vb3")));
            this.textBlockFlipTop = ((System.Windows.Controls.TextBlock)(this.FindName("textBlockFlipTop")));
            this.BlockFlipBottom = ((System.Windows.Controls.Border)(this.FindName("BlockFlipBottom")));
            this.vb4 = ((System.Windows.Controls.Viewbox)(this.FindName("vb4")));
            this.textBlockFlipBottom = ((System.Windows.Controls.TextBlock)(this.FindName("textBlockFlipBottom")));
        }
    }
}

