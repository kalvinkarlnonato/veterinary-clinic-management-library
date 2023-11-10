using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Text.RegularExpressions;

namespace VCMS.Library
{
    public class Config
    {
        public static bool IsDark { get; set; }

        //Drag Form
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        private static extern bool ReleaseCapture();

        public Config() { IsDark = false; }
        
        public static void MoveForm(IntPtr handle)
        {
            ReleaseCapture();
            SendMessage(handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        public static string FormatPhoneNumber(string phone)
        {
            Regex regex = new Regex(@"[^\d]");
            phone = regex.Replace(phone, "");
            phone = Regex.Replace(phone, @"(\d{4})(\d{3})(\d{4})", "$1-$2-$3");
            return phone;
        }
    }
}
