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
