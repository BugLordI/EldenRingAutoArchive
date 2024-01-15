using HandyControl.Controls;
using HandyControl.Data;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AutoArchivePlus.WindowTools
{
    public static class GlobalMessage
    {
        public static void ShowMessage(this Panel panel, String message)
        {
            Application.Current.Dispatcher?.Invoke(delegate
            {
                Growl growl = new Growl
                {
                    Height = panel.Height,
                    Width = 200,
                    Message = message,
                    Time = DateTime.Now,
                    Icon = panel.TryFindResource("SuccessGeometry") as Geometry,
                    IconBrush= panel.TryFindResource("SuccessBrush") as Brush,
                    //_showCloseButton = growlInfo.ShowCloseButton,
                    //ActionBeforeClose = growlInfo.ActionBeforeClose,
                    //_staysOpen = growlInfo.StaysOpen,
                    ShowDateTime = true,
                    //ConfirmStr = growlInfo.ConfirmStr,
                    //CancelStr = growlInfo.CancelStr,
                    Type = InfoType.Success,
                    //_waitTime = Math.Max(growlInfo.WaitTime, 2)
                };
                UnsafeOp(growl, "_showCloseButton", true);
                UnsafeOp(growl, "_waitTime", 2);
                panel.Children.Insert(0, growl);
            });
        }

        private static void UnsafeOp(Growl growl, String fieldName, Object value)
        {
            FieldInfo field = growl.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
            field.SetValue(growl, value);
        }
    }
}
