using System;
using System.Runtime.InteropServices;

namespace AvrDudeFix
{
    public class ShieldButton : System.Windows.Forms.Button
    {
        public ShieldButton()
        { FlatStyle = System.Windows.Forms.FlatStyle.System; ShowShield = true; }
        private bool _mShowShield; public bool ShowShield { get { return _mShowShield; } set { _mShowShield = value; SendMessage(new HandleRef(this, Handle), BcmSetshield, IntPtr.Zero, new IntPtr(_mShowShield ? 1 : 0)); } }
        const uint BcmSetshield = 0x0000160C;
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern IntPtr SendMessage(HandleRef hWnd, UInt32 msg, IntPtr wParam, IntPtr lParam);
    }
}
