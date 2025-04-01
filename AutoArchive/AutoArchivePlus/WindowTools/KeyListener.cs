/*
 * Copyright (c) 2023-2026 BugZhang(BugLordl). All rights reserved.
 * Licensed under the Apache License(Version 2.0). See LICENSE file in the project root for full license information.
 * Version: v1.0.0
 * Author:  BugZhang(BugLordl)
 * Url:     https://github.com/BugLordI/EldenRingAutoArchive
 */
using KeyboardTool.Enums;
using KeyboardTool;
using System;
using System.Collections.Generic;

namespace AutoArchivePlus.WindowTools
{
    internal class KeyListener
    {
        static List<String> hookIds = new List<String>();

        public static String RegisterHotKey(KeysEnum key, Action<object, object> callback, ModifierKeysEnum modifierKeys = ModifierKeysEnum.NONE)
        {
            var hookId = KeyboardFactory.RegisterKey(key, callback, modifierKeyCode: modifierKeys);
            hookIds.Add(hookId);
            return hookId;
        }

        public static void RemoveKeyListener(String hookId)
        {
            if (hookId == null)
            {
                foreach (var item in hookIds)
                {
                    KeyboardFactory.UnRegisterKey(item);
                }
            }
            else
            {
                KeyboardFactory.UnRegisterKey(hookId);
            }
        }
    }
}
