/*
 * Copyright (c) 2023-2026 BugZhang(BugLordl). All rights reserved.
 * Licensed under the Apache License(Version 2.0). See LICENSE file in the project root for full license information.
 * Version: v1.0.0
 * Author:  BugZhang(BugLordl)
 * Url:     https://github.com/BugLordI/EldenRingAutoArchive
 */
using System;
using System.Windows.Input;

namespace AutoArchivePlus.Command
{
    internal class ControlCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<object> executeMethod;

        public ControlCommand(Action<object> executeMethod)
        {
            this.executeMethod = executeMethod;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            executeMethod?.Invoke(parameter);
        }
    }
}
