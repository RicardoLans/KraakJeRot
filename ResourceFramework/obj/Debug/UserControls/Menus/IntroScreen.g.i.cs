﻿#pragma checksum "D:\GitHub\KraakJeRot\ResourceFramework\UserControls\Menus\IntroScreen.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3B9A7D676EFC546ED7D6C99A701BE174"
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


namespace ResourceFramework.UserControls.Menus {
    
    
    public partial class IntroScreen : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Canvas canvasMainScreen;
        
        internal System.Windows.Controls.Image BackgroundImage;
        
        internal System.Windows.Controls.Image imgStartGamePressed;
        
        internal System.Windows.Controls.Image imgHelpPressed;
        
        internal System.Windows.Controls.Image imgCreditsPressed;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/ResourceFramework;component/UserControls/Menus/IntroScreen.xaml", System.UriKind.Relative));
            this.canvasMainScreen = ((System.Windows.Controls.Canvas)(this.FindName("canvasMainScreen")));
            this.BackgroundImage = ((System.Windows.Controls.Image)(this.FindName("BackgroundImage")));
            this.imgStartGamePressed = ((System.Windows.Controls.Image)(this.FindName("imgStartGamePressed")));
            this.imgHelpPressed = ((System.Windows.Controls.Image)(this.FindName("imgHelpPressed")));
            this.imgCreditsPressed = ((System.Windows.Controls.Image)(this.FindName("imgCreditsPressed")));
        }
    }
}

