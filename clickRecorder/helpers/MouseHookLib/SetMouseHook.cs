using System;
using System.Windows.Forms;
using static MouseHookLib.Delegates;
using static MouseHookLib.Imports;
using static MouseHookLib.GlobalHook;

namespace MouseHookLib {
    class SetMouseHook {
        public static LowLevelMouseProc _proc = HookCallback;
        public static IntPtr _hookID = IntPtr.Zero;
        public static void SetHook( ) {
            try {
                _hookID = Native.SetHook( _proc );
                Application.Run( );
                UnhookWindowsHookEx( _hookID );
            } catch { }
        }
    }
}

