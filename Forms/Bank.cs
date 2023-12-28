using DevExpress.XtraEditors;
using Newtonsoft.Json;
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
using static Nhap_Hoc_TSV.Forms.InfoUpdate;

namespace Nhap_Hoc_TSV.Forms
{
    public partial class Bank : DevExpress.XtraEditors.XtraForm
    {
        public class Banking
        {
            public string soCCCD { get; set; }
            public string hoTenInTrenThe { get; set; }
            public string ngayCap { get; set; }
            public string sdt { get; set; }
            public string dichVu { get; set; }

            public Banking()
            {
                soCCCD = "";
                hoTenInTrenThe = "";
                ngayCap = "";
                sdt = "";
                dichVu = "";
            }

            public Banking(string soCCCD, string hoTenInTrenThe, string ngayCap, string sdt, string dichVu)
            {
                this.soCCCD = soCCCD;
                this.hoTenInTrenThe = hoTenInTrenThe;
                this.ngayCap = ngayCap;
                this.sdt = sdt;
                this.dichVu = dichVu;
            }
    }
        
        public Bank()
        {
            InitializeComponent();
            pictureEdit1.Image = Image.FromFile(@"C:\Users\HP\source\repos\Nhap-Hoc-TSV\Resources\Image\Agribank_logo.png");
            // resize picture without losing aspect ratio
            pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
        }

        private void idBtn_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(idBtn, "Sử dụng thông tin CCCD đã cung cấp");
        }

        private void addressBtn_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(addressBtn, "Sử dụng địa chỉ thường trú đã cung cấp");
        }

        private void idBtn_Click(object sender, EventArgs e)
        {
            txtCCCD.Text = Program.id;
        }

        private string GetService()
        {
            string service;

            if (checkEdit1.Checked == true && checkEdit2.Checked == true)
            {
                service = "All";
            }
            else if (checkEdit1.Checked == true && checkEdit2.Checked == false)
            {
                service = "SMS Banking";
            }
            else if (checkEdit1.Checked == false && checkEdit2.Checked == true)
            {
                service = "Giao dịch Internet (E-Commerce)";
            }
            else
            {
                service = "None";
            }

            return service;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Banking banking = new Banking(txtCCCD.Text, txtName.Text, Program.formatDate(dateEdit1.Text), txtPhone.Text, GetService());

            var json = JsonConvert.SerializeObject(banking);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            string apiUrl = "http://localhost:5001/api/SinhVien/banking/" + Program.id;

            var client = new HttpClient();

            Console.WriteLine(json);

            try
            {
                HttpResponseMessage response = client.PostAsync(apiUrl, data).Result;

                Console.WriteLine(response);

                response.EnsureSuccessStatusCode();

                MessageBox.Show("Đăng ký dịch vụ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}