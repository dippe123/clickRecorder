using System;

namespace MouseHookLib {
    internal class Delegates {
        public delegate IntPtr LowLevelMouseProc( int nCode , IntPtr wParam , IntPtr lParam );
    }
}
