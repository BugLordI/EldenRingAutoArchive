/*
 * Copyright (c) 2023-2026 BugZhang(BugLordl). All rights reserved.
 * Licensed under the Apache License(Version 2.0). See LICENSE file in the project root for full license information.
 * Version: v1.0.0
 * Author:  BugZhang(BugLordl)
 * Url:     https://github.com/BugLordI/EldenRingAutoArchive
 */
using System.Windows;
using System.Windows.Controls;

namespace AutoArchivePlus.Forms
{
    /// <summary>
    /// HomePage.xaml 的交互逻辑
    /// </summary>
    public partial class HomePage : UserControl
    {
        #region properties

        public static readonly DependencyProperty ParentWindowProperty;

        #endregion


        static HomePage()
        {
            ParentWindowProperty = DependencyProperty.Register("ParentWindow", typeof(Window), typeof(HomePage));
        }

        public HomePage()
        {
            InitializeComponent();
        }

        public Window ParentWindow
        {
            get
            {
                return (Window)GetValue(ParentWindowProperty);
            }
            set
            {
                SetValue(ParentWindowProperty, value);
            }
        }
    }
}
