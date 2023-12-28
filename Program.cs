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
        public static bool offline = false;
        public static int[] arr = new int[8];
        public static int[] arr_cnd = new int[4];
        public static bool[] mustUpload = { true, true, true, false, true, false, true, false, false, true, false };

        public static async void Fee_Load()
        {
            // API CALL
            string api = "http://localhost:5001/api/HocPhi/chitiethp/" + Program.id;
            var client = new System.Net.Http.HttpClient();

            var response = await client.GetAsync(api);

            var responseContent = await response.Content.ReadAsStringAsync();
            var data = Newtonsoft.Json.Linq.JObject.Parse(responseContent);

            Program.arr[0] = int.Parse(data["hocPhi"].ToString());
            Program.arr[1] = int.Parse(data["kinhPhiNhapHoc"].ToString());
            Program.arr[2] = int.Parse(data["phiBHYT"].ToString());
            Program.arr[3] = int.Parse(data["phiBHTN"].ToString());
            Program.arr[4] = int.Parse(data["phiKTX"].ToString());
            Program.arr[5] = int.Parse(data["phiDongPhuc"].ToString());
            Program.arr[6] = int.Parse(data["phiCLC"].ToString());
            Program.arr[7] = Program.arr[0] + Program.arr[1] + Program.arr[2] + Program.arr[3] + Program.arr[4] + Program.arr[5] + Program.arr[6];
        }
        public static string formatDate(string txt)
        {
            string tmp = txt.Split(' ')[0];

            string[] date = tmp.Split('/');
            return date[2] + "-" + date[1] + "-" + date[0];
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
