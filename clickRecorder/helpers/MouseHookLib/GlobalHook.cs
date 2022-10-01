using System;
using static MouseHookLib.Imports;
using static MouseHookLib.Messages;
using static MouseHookLib.SetMouseHook;
using static helpers.ClickRecorder;

namespace MouseHookLib {
    internal class GlobalHook {
        private static int counter;
        private static DateTime firstClick = DateTime.Now, secondClick = DateTime.Now;
        public static IntPtr HookCallback( int nCode , IntPtr wParam , IntPtr lParam ) {
            if ( nCode >= 0 && MouseMessages.WM_LBUTTONDOWN == ( MouseMessages ) wParam ) {
                firstClick = DateTime.Now;
                MouseDown_del( firstClick , secondClick , counter++ );
            }
            if ( nCode >= 0 && MouseMessages.WM_LBUTTONUP == ( MouseMessages ) wParam ) {
                secondClick = DateTime.Now;
                MouseUp_del( firstClick , secondClick , counter++ );
            }
            return CallNextHookEx( _hookID , nCode , wParam , lParam );
        }
    }
}
