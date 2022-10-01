using System;
using System.IO;
using System.Drawing;
using Console = Colorful.Console;
using System.Runtime.InteropServices;
using static helpers.WinStructs;
using static helpers.WinAPI;

namespace helpers {
    internal class ClickRecorder {
        public static void MouseDown_del( DateTime firstClick , DateTime secondClick , int counter ) {
            var delays = firstClick - secondClick;
            if ( MinecraftWindow.GetMinecraftWindow( ) && !isCursorVisible( ) && ( int ) Math.Round( delays.TotalMilliseconds ) < 150 ) {
                logClick( ( int ) Math.Round( delays.TotalMilliseconds ) );

            }
        }
        public static void MouseUp_del( DateTime firstClick , DateTime secondClick , int counter ) {
            var delays = secondClick - firstClick;
            if ( MinecraftWindow.GetMinecraftWindow( ) && !isCursorVisible( ) && ( int ) Math.Round( delays.TotalMilliseconds ) < 150 ) {
                logClick( ( int ) Math.Round( delays.TotalMilliseconds ) );
                Console.SetCursorPosition( 0 , 2 );
                Console.ForegroundColor = Color.FromArgb( 160 , 160 , 160 );
                ConsoleHelper.printCustom( "counter" , $"total clicks: {counter}" );
            }
        }
        private static void logClick( double clicks ) {
            try {
                using ( StreamWriter sw = File.AppendText( "clicks.txt" ) ) {
                    sw.WriteLine( clicks );
                    sw.Close( );
                }
            } catch { }
        }
        private static bool isCursorVisible( ) {
            CURSORINFO cursorInfo = new CURSORINFO( );
            cursorInfo.cbSize = Marshal.SizeOf( cursorInfo );
            if ( GetCursorInfo( out cursorInfo ) ) {
                int mousehandle_int = ( int ) cursorInfo.hCursor;
                if ( mousehandle_int > 50000 & mousehandle_int < 100000 )
                    return true;
                else
                    return false;
            }
            return false;
        }
    }
}
