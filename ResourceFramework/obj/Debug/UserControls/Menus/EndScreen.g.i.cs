﻿#pragma checksum "D:\GitHub\KraakJeRot\ResourceFramework\UserControls\Menus\EndScreen.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8CE551C8BBD0555D41D8E8D6E33C88D2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ResourceFramework.UserControls.Additional;
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


namespace ResourceFramework.UserControls.Menus {
    
    
    public partial class EndScreen : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Canvas canvasMainScreen;
        
        internal System.Windows.Media.ScaleTransform CanvasScale;
        
        internal System.Windows.Controls.Image BackGroundImage;
        
        internal System.Windows.Controls.TextBlock txtTotalPoints;
        
        internal ResourceFramework.UserControls.Additional.SignPost SignPost;
        
        internal System.Windows.Controls.Image imgHighscoresPressed;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/ResourceFramework;component/UserControls/Menus/EndScreen.xaml", System.UriKind.Relative));
            this.canvasMainScreen = ((System.Windows.Controls.Canvas)(this.FindName("canvasMainScreen")));
            this.CanvasScale = ((System.Windows.Media.ScaleTransform)(this.FindName("CanvasScale")));
            this.BackGroundImage = ((System.Windows.Controls.Image)(this.FindName("BackGroundImage")));
            this.txtTotalPoints = ((System.Windows.Controls.TextBlock)(this.FindName("txtTotalPoints")));
            this.SignPost = ((ResourceFramework.UserControls.Additional.SignPost)(this.FindName("SignPost")));
            this.imgHighscoresPressed = ((System.Windows.Controls.Image)(this.FindName("imgHighscoresPressed")));
        }
    }
}

