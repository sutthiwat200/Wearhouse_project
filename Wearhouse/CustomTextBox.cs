using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Wearhouse
{
    public class CustomTextBox : TextBox
    {
        private string _placeholder = "";
        [Category("Appearance")]
        public string Placeholder
        {
            get { return _placeholder; }
            set { _placeholder = value; UpdatePlaceholder(); }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            UpdatePlaceholder();
        }

        private void UpdatePlaceholder()
        {
            if (this.IsHandleCreated && _placeholder != null)
            {
                SendMessage(this.Handle, 0x1501, (IntPtr)1, _placeholder);
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, string lp);
    }
}
