using System;
using System.Runtime.InteropServices;

namespace MouseHookLib {
    internal class Imports {
        [DllImport( "user32.dll" , CharSet = CharSet.Auto , SetLastError = true )] public static extern IntPtr SetWindowsHookEx( int idHook , Delegates.LowLevelMouseProc lpfn , IntPtr hMod , uint dwThreadId );
        [DllImport( "user32.dll" , CharSet = CharSet.Auto , SetLastError = true )]  [return: MarshalAs( UnmanagedType.Bool )] public static extern bool UnhookWindowsHookEx( IntPtr hhk );
        [DllImport( "user32.dll" , CharSet = CharSet.Auto , SetLastError = true )] public static extern IntPtr CallNextHookEx( IntPtr hhk , int nCode , IntPtr wParam , IntPtr lParam );
        [DllImport( "kernel32.dll" , CharSet = CharSet.Auto , SetLastError = true )] public static extern IntPtr GetModuleHandle( string lpModuleName );
    }
}
