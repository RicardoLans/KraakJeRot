﻿#pragma checksum "D:\GitHub\KraakJeRot\ResourceFramework\UserControls\Levels\Level1.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B8D6EBCB4B0B7EE0236A0F3593F5C0DD"
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


namespace ResourceFramework.UserControls.Levels {
    
    
    public partial class Level1 : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Canvas levelSurfaceME;
        
        internal System.Windows.Controls.Canvas levelSurfaceKraker;
        
        internal System.Windows.Controls.Canvas LevelBackground;
        
        internal System.Windows.Controls.Image Image;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/ResourceFramework;component/UserControls/Levels/Level1.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.levelSurfaceME = ((System.Windows.Controls.Canvas)(this.FindName("levelSurfaceME")));
            this.levelSurfaceKraker = ((System.Windows.Controls.Canvas)(this.FindName("levelSurfaceKraker")));
            this.LevelBackground = ((System.Windows.Controls.Canvas)(this.FindName("LevelBackground")));
            this.Image = ((System.Windows.Controls.Image)(this.FindName("Image")));
        }
    }
}
