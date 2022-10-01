using System;
using System.Diagnostics;
using static MouseHookLib.Delegates;
using static MouseHookLib.Imports;


namespace MouseHookLib {
    internal class Native {
        public const int WH_MOUSE_LL = 14;
        public static IntPtr SetHook( LowLevelMouseProc proc ) {
            using ( Process curProcess = Process.GetCurrentProcess( ) )
            using ( ProcessModule curModule = curProcess.MainModule ) {
                return SetWindowsHookEx( WH_MOUSE_LL , proc , GetModuleHandle( curModule.ModuleName ) , 0 );
            }
        }
    }
}
