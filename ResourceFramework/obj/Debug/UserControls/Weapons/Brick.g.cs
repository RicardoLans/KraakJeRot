﻿#pragma checksum "D:\GitHub\KraakJeRot\ResourceFramework\UserControls\Weapons\Brick.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9495693B8A2EEC6BEF201BBEDC128F06"
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


namespace ResourceFramework.UserControls.Weapon {
    
    
    public partial class Brick : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Canvas weaponOrigin;
        
        internal System.Windows.Controls.Canvas weaponBulletOrigin;
        
        internal System.Windows.Controls.Viewbox Brick1;
        
        internal System.Windows.Shapes.Path Top_16;
        
        internal System.Windows.Shapes.Path Right_17;
        
        internal System.Windows.Shapes.Path Front_18;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/ResourceFramework;component/UserControls/Weapons/Brick.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.weaponOrigin = ((System.Windows.Controls.Canvas)(this.FindName("weaponOrigin")));
            this.weaponBulletOrigin = ((System.Windows.Controls.Canvas)(this.FindName("weaponBulletOrigin")));
            this.Brick1 = ((System.Windows.Controls.Viewbox)(this.FindName("Brick1")));
            this.Top_16 = ((System.Windows.Shapes.Path)(this.FindName("Top_16")));
            this.Right_17 = ((System.Windows.Shapes.Path)(this.FindName("Right_17")));
            this.Front_18 = ((System.Windows.Shapes.Path)(this.FindName("Front_18")));
        }
    }
}
