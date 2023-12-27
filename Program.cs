using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using Nhap_Hoc_TSV.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Nhap_Hoc_TSV
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static string id = "";
        public static string token = "";
        public static string address = "";
        public static int[] arr = new int[8];
        public static int[] arr_cnd = new int[4];
        public static bool[] mustUpload = { true, true, true, false, true, false, true, false, false, true, false };

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
