﻿#pragma checksum "D:\GitHub\KraakJeRot\ResourceFramework\UserControls\Menus\ChooseSideScreen.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5CA18645246DC3BCEE1BA79873763AFA"
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
    
    
    public partial class ChooseSideScreen : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Canvas canvasChooseSideScreen;
        
        internal System.Windows.Controls.Image BackgroundImage;
        
        internal System.Windows.Controls.Canvas npcME;
        
        internal System.Windows.Controls.Canvas npcKraker;
        
        internal ResourceFramework.UserControls.Additional.SignPost SignPost;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/ResourceFramework;component/UserControls/Menus/ChooseSideScreen.xaml", System.UriKind.Relative));
            this.canvasChooseSideScreen = ((System.Windows.Controls.Canvas)(this.FindName("canvasChooseSideScreen")));
            this.BackgroundImage = ((System.Windows.Controls.Image)(this.FindName("BackgroundImage")));
            this.npcME = ((System.Windows.Controls.Canvas)(this.FindName("npcME")));
            this.npcKraker = ((System.Windows.Controls.Canvas)(this.FindName("npcKraker")));
            this.SignPost = ((ResourceFramework.UserControls.Additional.SignPost)(this.FindName("SignPost")));
        }
    }
}

