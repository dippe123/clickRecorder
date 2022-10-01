using helpers;
using System.IO;
using System.Net;
using System.Drawing;
using System.Threading;
using Console = Colorful.Console;

using static helpers.ConsoleHelper;
using static MouseHookLib.SetMouseHook;

namespace clickRecorder {
    internal class clickRecorder {
        static Mutex mamt = new Mutex( false , "recorder" );
        private static void Main( string [ ] args ) {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            if ( !mamt.WaitOne( 0 , false ) )
                return;
            Console.CursorVisible = false;
            DisableSelection( );
            Console.Title = "";
            Console.Clear( );
            Console.ForegroundColor = Color.FromArgb( 199 , 199 , 74 );
            if ( !File.Exists( "clicks.txt" ) ) File.Create( "clicks.txt" );
            printCustom( "instance" , "waiting minecraft window..." );
            while ( true ) {
                if ( !MinecraftWindow.GetMinecraftWindow( ) ) continue;
                Console.Clear( );
                Console.ForegroundColor = Color.FromArgb( 160 , 160 , 160 );
                printCustom( "instance" , MinecraftWindow.GetName( ) );
                break;
            }
            printCustom( "hook" , "mouse hooked, now you can start clicking ( only instance clicks will be saved )" );
            SetHook( );
        }
    }
}
