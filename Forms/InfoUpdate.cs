using DevExpress.XtraEditors;
using Newtonsoft.Json;
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
using static Nhap_Hoc_TSV.Forms.InfoUpdate;
using static System.Windows.Forms.LinkLabel;

namespace Nhap_Hoc_TSV.Forms
{
    public partial class InfoUpdate : DevExpress.XtraEditors.XtraForm
    {
        public class Person
        {
            public string soCCCD { get; set; }
            public string hoTen { get; set; }
            public string quocTich { get; set; }
            public string gioiTinh { get; set; }
            public string ngaySinh { get; set; }
            public string thuongTru { get; set; }
            public string tamTru { get; set; }

            public string sdt { get; set; }
            public string email { get; set; }
            public string avatarPath { get; set; }
            public Relative nguoiThan1 { get; set; }
            public Relative nguoiThan2 { get; set; }

            public Person()
            {
                soCCCD = "";
                hoTen = "";
                quocTich = "";
                gioiTinh = "";
                ngaySinh = "";
                thuongTru = "";
                sdt = "";
                email = "";
                avatarPath = "";
                nguoiThan1 = new Relative();
                nguoiThan2 = new Relative();
            }

            public Person(string soCCCD, string hoTen, string quocTich, string gioiTinh, string ngaySinh, string thuongTru, string tamTru, string sdt, string email, string avatarPath, Relative nguoiThan1, Relative nguoiThan2)
            {
                this.soCCCD = soCCCD;
                this.hoTen = hoTen;
                this.quocTich = quocTich;
                this.gioiTinh = gioiTinh;
                this.ngaySinh = ngaySinh;
                this.thuongTru = thuongTru;
                this.tamTru = tamTru;
                this.sdt = sdt;
                this.email = email;
                this.avatarPath = avatarPath;
                this.nguoiThan1 = nguoiThan1;
                this.nguoiThan2 = nguoiThan2;
            }
        }

        public class Relative
        {
            public string hoTen { get; set; }
            public string namSinh { get; set; }
            public string quocTich { get; set; }
            public string danToc { get; set; }
            public string ngheNghiep { get; set; }
            public string sdt { get; set; }
            public string diaChi { get; set; }

            public Relative()
            {
                hoTen = "";
                namSinh = "";
                quocTich = "";
                danToc = "";
                ngheNghiep = "";
                sdt = "";
                diaChi = "";
            }

            public Relative(string hoTen, string namSinh, string quocTich, string danToc, string ngheNghiep, string sdt, string diaChi)
            {
                this.hoTen = hoTen;
                this.namSinh = namSinh;
                this.quocTich = quocTich;
                this.danToc = danToc;
                this.ngheNghiep = ngheNghiep;
                this.sdt = sdt;
                this.diaChi = diaChi;
            }
        }

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
            txtTmp.Text = data["tamTru"].ToString();

            try
            {
                txtHoTenR1.Text = data["nguoiThan1"]["hoTen"].ToString();
                txtNamSinhR1.Text = data["nguoiThan1"]["namSinh"].ToString();
                txtQuocTichR1.Text = data["nguoiThan1"]["quocTich"].ToString();
                txtDanTocR1.Text = data["nguoiThan1"]["danToc"].ToString();
                txtCongViecR1.Text = data["nguoiThan1"]["ngheNghiep"].ToString();
                txtPhoneR1.Text = data["nguoiThan1"]["sdt"].ToString();
                txtAddressR1.Text = data["nguoiThan1"]["diaChi"].ToString();

                txtHoTenR2.Text = data["nguoiThan2"]["hoTen"].ToString();
                txtNamSinhR2.Text = data["nguoiThan2"]["namSinh"].ToString();
                txtQuocTichR2.Text = data["nguoiThan2"]["quocTich"].ToString();
                txtDanTocR2.Text = data["nguoiThan2"]["danToc"].ToString();
                txtCongViecR2.Text = data["nguoiThan2"]["ngheNghiep"].ToString();
                txtPhoneR2.Text = data["nguoiThan2"]["sdt"].ToString();
                txtAddressR2.Text = data["nguoiThan2"]["diaChi"].ToString();
            }
            catch
            {

            }
            
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

        private bool checkInfo()
        {
            if (txtPhone.Text == "" || txtAddress.Text == "") return false;

            if (txtDanTocR1.Text == "" || txtDanTocR2.Text == "" || txtQuocTichR1.Text == "" || txtQuocTichR2.Text == "") return false;

            if (txtHoTenR1.Text == "" || txtHoTenR2.Text == "" || txtNamSinhR1.Text == "" || txtNamSinhR2.Text == "") return false;

            if (txtCongViecR1.Text == "" || txtCongViecR2.Text == "" || txtPhoneR1.Text == "" || txtPhoneR2.Text == "") return false;   

            if (txtAddressR1.Text == "" || txtAddressR2.Text == "") return false;

            if (checkEdit1.Checked == true && txtTmp.Text == "") return false;

            return true;
        } 

        private async void SaveInfo()
        {
            Relative relative1 = new Relative(
                txtHoTenR1.Text.Normalize(),
                txtNamSinhR1.Text.Normalize(),
                txtQuocTichR1.Text.Normalize(),
                txtDanTocR1.Text.Normalize(),
                txtCongViecR1.Text.Normalize(),
                txtPhoneR1.Text.Normalize(),
                txtAddressR1.Text.Normalize()
            );

            Relative relative2 = new Relative(
                txtHoTenR2.Text.Normalize(),
                txtNamSinhR2.Text.Normalize(),
                txtQuocTichR2.Text.Normalize(),
                txtDanTocR2.Text.Normalize(),
                txtCongViecR2.Text.Normalize(),
                txtPhoneR2.Text.Normalize(),
                txtAddressR2.Text.Normalize()
            );

            Person person = new Person(
                Program.id,
                txtName.Text.Normalize(),
                "Vietnamese",
                txtGender.Text.Normalize(),
                Program.formatDate(txtDate.Text),
                txtAddress.Text.Normalize(),
                txtTmp.Text.Normalize(),
                txtPhone.Text.Normalize(),
                "",
                "",
                relative1,
                relative2
            );

            if (checkInfo() == false)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            var json = JsonConvert.SerializeObject(person);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            string apiUrl = "http://localhost:5001/api/SinhVien/updateSV/" + Program.id;

            var client = new HttpClient();

            Program.address = txtAddress.Text;

            try
            {
                HttpResponseMessage response = await client.PutAsync(apiUrl, data);
                Console.WriteLine(response);
                response.EnsureSuccessStatusCode();

                MessageBox.Show("Cập nhật thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Cập nhật thông tin thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // API CALL
            SaveInfo();
        }
    }
}