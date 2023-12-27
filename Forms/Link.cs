using DevExpress.XtraEditors;
using System;
using System.Net.Http;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Nhap_Hoc_TSV.Forms
{
    public partial class Link : DevExpress.XtraEditors.XtraForm
    {
        public static string code;
        public static string title;

        // get code from Upload.cs
        public static void GetCode(string code)
        {
            Link.code = code;
        }

        public static void GetTitle(string title)
        {
            Link.title = title;
        }

        public Link(string code, string title)
        {
            InitializeComponent();
            GetCode(code);
            GetTitle(title);
            labelControl1.Text = title;
        }

        public Link()
        {
            InitializeComponent();
        }

        private async void Upload(string link)
        {
            string apiUrl = "http://localhost:5001/api/SinhVien/hoso/" + Program.id;

            var client = new HttpClient();

            var content = new StringContent(
                $"{{\"maHoSo\": \"{code}\", \"soCCCD\": \"{Program.id}\", \"duongDan\": \"{link}\"}}",
                System.Text.Encoding.UTF8,
                "application/json"
            );

            try
            {
                var response = await client.PostAsync(apiUrl, content);
                var responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Upload thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    int tmp = int.Parse(code);
                    Program.mustUpload[tmp] = false;
                    Close();
                }
                else
                {
                    MessageBox.Show("Upload thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {            
            Upload(LinkHolder.Text.Trim());
        }
    }
}