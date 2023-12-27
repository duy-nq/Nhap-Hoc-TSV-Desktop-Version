using DevExpress.XtraEditors;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhap_Hoc_TSV.Forms
{
    public partial class InfoUpdate : DevExpress.XtraEditors.XtraForm
    {
        public InfoUpdate()
        {
            InitializeComponent();
            selfImage.Image = Image.FromFile(@"C:\Users\HP\Downloads\Documents\test.jpg");
            selfImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;

            loadData();
        }

        private async void loadData()
        {
            string api = "http://localhost:5001/api/SinhVien/" + Program.id;
            var client = new HttpClient();

            var response = await client.GetAsync(api);

            var responseContent = await response.Content.ReadAsStringAsync();
            var data = JObject.Parse(responseContent);

            txtName.Text = data["hoTen"].ToString();
            txtDate.Text = data["ngaySinh"].ToString();
            txtGender.Text = data["gioiTinh"].ToString();

            txtPhone.Text = data["sdt"].ToString();
            txtAddress.Text = data["thuongTru"].ToString();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked == true)
            {
                txtTmp.Enabled = true;
            }
            else
            {
                txtTmp.Enabled = false;
                txtTmp.Text = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // API CALL

            // Close form, return to main form
            Close();
        }
    }
}