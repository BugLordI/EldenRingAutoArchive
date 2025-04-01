/*
 * Copyright (c) 2023-2026 BugZhang(BugLordl). All rights reserved.
 * Licensed under the Apache License(Version 2.0). See LICENSE file in the project root for full license information.
 * Version: v1.0.0
 * Author:  BugZhang(BugLordl)
 * Url:     https://github.com/BugLordI/EldenRingAutoArchive
 */
using AutoArchivePlus.Language;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace AutoArchivePlus.Component
{
    /// <summary>
    /// NavigationMenuItem.xaml 的交互逻辑
    /// </summary>
    public partial class NavigationMenuItem : UserControl
    {
        #region Properties

        public static readonly DependencyProperty TypeNameProperty;

        public static readonly DependencyProperty ItemNameProperty;

        public static readonly DependencyProperty ItemIconProperty;

        public static readonly DependencyProperty ItemIconWidthProperty;

        public static readonly DependencyProperty ItemIconHeightProperty;

        public static readonly DependencyProperty ItemIconMarginProperty;

        public static readonly DependencyProperty IsSelectProperty;

        public static readonly DependencyProperty ItemClickedCommandProperty;

        public static readonly DependencyProperty CloseMenuCommandProperty;

        #endregion

        static NavigationMenuItem()
        {
            TypeNameProperty = DependencyProperty.Register("TypeName", typeof(string), typeof(NavigationMenuItem));
            ItemNameProperty = DependencyProperty.Register("ItemName", typeof(string), typeof(NavigationMenuItem));
            ItemIconProperty = DependencyProperty.Register("ItemIcon", typeof(ImageSource), typeof(NavigationMenuItem));
            ItemIconWidthProperty = DependencyProperty.Register("ItemIconWidth", typeof(double), typeof(NavigationMenuItem));
            ItemIconHeightProperty = DependencyProperty.Register("ItemIconHeight", typeof(double), typeof(NavigationMenuItem));
            ItemIconMarginProperty = DependencyProperty.Register(" ItemIconMargin", typeof(Thickness), typeof(NavigationMenuItem), new PropertyMetadata(new Thickness(7, 0, 0, 0)));
            IsSelectProperty = DependencyProperty.Register("IsSelect", typeof(bool), typeof(NavigationMenuItem));
            ItemClickedCommandProperty = DependencyProperty.Register("ItemClickedCommand", typeof(ICommand), typeof(NavigationMenuItem));
            CloseMenuCommandProperty = DependencyProperty.Register("CloseMenuCommand", typeof(ICommand), typeof(NavigationMenuItem));
        }

        public NavigationMenuItem()
        {
            InitializeComponent();
        }


        private void self_Loaded(object sender, RoutedEventArgs e)
        {
            closeProgramMenu.Command = CloseMenuCommand;
            closeProgramMenu.CommandParameter = this.DataContext;
        }

        public string TypeName
        {
            get
            {
                return (string)GetValue(TypeNameProperty);
            }
            set
            {
                SetValue(TypeNameProperty, value);
            }
        }

        public string ItemName
        {
            get
            {
                return (string)GetValue(ItemNameProperty);
            }
            set
            {
                SetValue(ItemNameProperty, value);
            }
        }

        public ImageSource ItemIcon
        {
            get
            {
                return (ImageSource)GetValue(ItemIconProperty);
            }
            set
            {
                SetValue(ItemIconProperty, value);
            }
        }

        public double ItemIconWidth
        {
            get
            {
                return (double)GetValue(ItemIconWidthProperty);
            }
            set
            {
                SetValue(ItemIconWidthProperty, value);
            }
        }

        public double ItemIconHeight
        {
            get
            {
                return (double)GetValue(ItemIconHeightProperty);
            }
            set
            {
                SetValue(ItemIconHeightProperty, value);
            }
        }

        public Thickness ItemIconMargin
        {
            get
            {
                return (Thickness)GetValue(ItemIconMarginProperty);
            }
            set
            {
                SetValue(ItemIconMarginProperty, value);
            }
        }

        public bool IsSelect
        {
            get
            {
                return (bool)GetValue(IsSelectProperty);
            }
            set
            {
                SetValue(IsSelectProperty, value);
            }
        }

        public ICommand ItemClickedCommand
        {
            get
            {
                return (ICommand)GetValue(ItemClickedCommandProperty);
            }
            set
            {
                SetValue(ItemClickedCommandProperty, value);
            }
        }

        public ICommand CloseMenuCommand
        {
            get
            {
                return (ICommand)GetValue(CloseMenuCommandProperty);
            }
            set
            {
                SetValue(CloseMenuCommandProperty, value);
            }
        }

        private void defaultMenu_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (TypeName == LanguageManager.Instance["Home"])
            {
                e.Handled = true;
            }
        }
    }
}
