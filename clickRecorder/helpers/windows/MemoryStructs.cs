using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace helpers {
    class MemoryStructs {
        [DllImport( "kernel32.dll" , SetLastError = true )] public static extern IntPtr OpenProcess( ProcessAccessFlags processAccess , bool bInheritHandle , int processId );
        [DllImport( "kernel32.dll" , SetLastError = true )] public static extern bool ReadProcessMemory( IntPtr hProcess , IntPtr lpBaseAddress , byte [ ] lpBuffer , Int32 nSize , out IntPtr lpNumberOfBytesRead );
        [DllImport( "kernel32.dll" , SetLastError = true )] public static extern bool WriteProcessMemory( IntPtr hProcess , IntPtr lpBaseAddress , [MarshalAs( UnmanagedType.AsAny )] object lpBuffer , Int32 nSize , out IntPtr lpNumberOfBytesWritten );
        [DllImport( "kernel32.dll" )] public static extern bool VirtualProtect( IntPtr lpAddress , int dwSize , uint flNewProtect , out uint lpflOldProtect );
        [DllImport( "msvcrt.dll" , CallingConvention = CallingConvention.Cdecl )] public static extern int memcmp( byte [ ] b1 , byte [ ] b2 , long count );
        [DllImport( "kernel32.dll" )] public static extern bool Process32First( IntPtr hSnapshot , ref PROCESSENTRY32 lppe );
        [DllImport( "kernel32.dll" )] public static extern bool Process32Next( IntPtr hSnapshot , ref PROCESSENTRY32 lppe );
        [DllImport( "kernel32.dll" )] public static extern bool Module32First( IntPtr hSnapshot , ref MODULEENTRY32 lpme );
        [DllImport( "kernel32.dll" )] public static extern bool Module32Next( IntPtr hSnapshot , ref MODULEENTRY32 lpme );
        [DllImport( "kernel32.dll" , SetLastError = true )] public static extern bool CloseHandle( IntPtr hHandle );
        [DllImport( "kernel32.dll" , CharSet = CharSet.Auto , SetLastError = true )] public static extern IntPtr GetModuleHandle( string moduleName );
        [DllImport( "kernel32.dll" , SetLastError = true )] private static extern IntPtr CreateToolhelp32Snapshot( SnapshotFlags dwFlags , int th32ProcessID );
        [DllImport( "kernel32" , CharSet = CharSet.Ansi , ExactSpelling = true , SetLastError = true )] public static extern IntPtr GetProcAddress( IntPtr hModule , string procName );
        [DllImport( "kernel32.dll" )] private static extern IntPtr CreateRemoteThread( IntPtr hProcess , IntPtr lpThreadAttributes , uint dwStackSize , IntPtr lpStartAddress , IntPtr lpParameter , uint dwCreationFlags , out IntPtr lpThreadId );
        [DllImport( "kernel32.dll" , SetLastError = true , ExactSpelling = true )] private static extern IntPtr VirtualAllocEx( IntPtr hProcess , IntPtr lpAddress , uint dwSize , AllocationType flAllocationType , MemoryProtection flProtect );
       
        [Flags]
        public enum ProcessAccessFlags:uint {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VirtualMemoryOperation = 0x00000008,
            VirtualMemoryRead = 0x00000010,
            VirtualMemoryWrite = 0x00000020,
            DuplicateHandle = 0x00000040,
            CreateProcess = 0x000000080,
            SetQuota = 0x00000100,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            QueryLimitedInformation = 0x00001000,
            Synchronize = 0x00100000
        }

        [Flags]
        private enum SnapshotFlags:uint {
            HeapList = 0x00000001,
            Process = 0x00000002,
            Thread = 0x00000004,
            Module = 0x00000008,
            Module32 = 0x00000010,
            Inherit = 0x80000000,
            All = 0x0000001F,
            NoHeaps = 0x40000000
        }


        [StructLayout( LayoutKind.Sequential )]
        public struct PROCESSENTRY32 {
            public uint dwSize;
            public uint cntUsage;
            public uint th32ProcessID;
            public IntPtr th32DefaultHeapID;
            public uint th32ModuleID;
            public uint cntThreads;
            public uint th32ParentProcessID;
            public int pcPriClassBase;
            public uint dwFlags;
            [MarshalAs( UnmanagedType.ByValTStr , SizeConst = 260 )] public string szExeFile;
        };

        [StructLayout( LayoutKind.Sequential , CharSet = System.Runtime.InteropServices.CharSet.Ansi )]
        public struct MODULEENTRY32 {
            internal uint dwSize;
            internal uint th32ModuleID;
            internal uint th32ProcessID;
            internal uint GlblcntUsage;
            internal uint ProccntUsage;
            internal IntPtr modBaseAddr;
            internal uint modBaseSize;
            internal IntPtr hModule;

            [MarshalAs( UnmanagedType.ByValTStr , SizeConst = 256 )]
            internal string szModule;

            [MarshalAs( UnmanagedType.ByValTStr , SizeConst = 260 )]
            internal string szExePath;
        }

        [Flags]
        public enum AllocationType {
            Commit = 0x1000,
            Reserve = 0x2000,
            Decommit = 0x4000,
            Release = 0x8000,
            Reset = 0x80000,
            Physical = 0x400000,
            TopDown = 0x100000,
            WriteWatch = 0x200000,
            LargePages = 0x20000000
        }

        [Flags]
        public enum MemoryProtection {
            Execute = 0x10,
            ExecuteRead = 0x20,
            ExecuteReadWrite = 0x40,
            ExecuteWriteCopy = 0x80,
            NoAccess = 0x01,
            ReadOnly = 0x02,
            ReadWrite = 0x04,
            WriteCopy = 0x08,
            GuardModifierflag = 0x100,
            NoCacheModifierflag = 0x200,
            WriteCombineModifierflag = 0x400
        }
        [System.Runtime.InteropServices.StructLayout( System.Runtime.InteropServices.LayoutKind.Sequential )]
        public struct SystemKernelDebuggerInformation {
            [System.Runtime.InteropServices.MarshalAs( System.Runtime.InteropServices.UnmanagedType.U1 )]
            public static bool KernelDebuggerEnabled;

            [System.Runtime.InteropServices.MarshalAs( System.Runtime.InteropServices.UnmanagedType.U1 )]
            public static bool KernelDebuggerNotPresent;
        }
    }
}
