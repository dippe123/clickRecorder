using System;
using System.Runtime.InteropServices;
using System.Text;

namespace helpers {
    class MinecraftWindow {
        #region Imports
        [DllImport ( "user32" , CharSet = CharSet.Auto , SetLastError = true )] public static extern int GetWindowText ( IntPtr hWnd , StringBuilder lpString , int cch );
        #endregion
        public static bool GetMinecraftWindow ( ) {
            if ( GetName ( ).Contains ( "Lunar" ) || GetName ( ).Contains ( "Badlion" ) || GetName ( ).Contains ( "Minecraft" ) || GetName ( ).Contains ( "Cheatbreaker" ) )
                return true;
            else
                return false;
        }


        public static string GetName ( ) {
            StringBuilder stringBuilder = new StringBuilder ( 256 );
            GetWindowText ( WinAPI.GetForegroundWindow ( ) , stringBuilder , stringBuilder.Capacity );
            return stringBuilder.ToString ( );
        }
    }
}