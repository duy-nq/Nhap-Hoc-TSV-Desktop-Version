using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Nhap_Hoc_TSV.Forms;
using System.Net.Http;

namespace Nhap_Hoc_TSV.Forms
{
    public partial class CnD : DevExpress.XtraEditors.XtraForm
    {
        public CnD()
        {
            InitializeComponent();
            // Add fake data for gridview1
            DataTable dt = new DataTable(); 
            dt.Columns.Add("Tên", typeof(string));
            dt.Columns.Add("Đơn giá", typeof(int));
            
            dt.Rows.Add("Áo sơ mi", Program.arr_cnd[1]);
            dt.Rows.Add("Áo thể dục", Program.arr_cnd[2]);
            dt.Rows.Add("Quần thể dục", Program.arr_cnd[3]);
            dt.Rows.Add("Áo khoác", Program.arr_cnd[0]);

            gridControl1.DataSource = dt;
        }

        private void addOnInfo(string path, string des)
        {
            string imagePath = path;

            Form imageForm = new Form();
            PictureBox pictureBox = new PictureBox();

            pictureBox.Image = Image.FromFile(imagePath);
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

            imageForm.Controls.Add(pictureBox);
            imageForm.AutoSize = true;
            imageForm.Text = des;
            imageForm.ShowDialog();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            checkEdit2.Checked = !checkEdit1.Checked;
            KTXControl.Height = 157;

            checkEdit2.Enabled = true;
            checkEdit1.Enabled = false;
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            checkEdit1.Checked = !checkEdit2.Checked;
            KTXControl.Height = 87;

            checkEdit1.Enabled = true;
            checkEdit2.Enabled = false;
        }

        private void sizeBtn_Click(object sender, EventArgs e)
        {
            string imagePath = "C:/Users/HP/Desktop/MyWork/banner-template.png";
            string description = "Bảng tra cứu size đồng phục";
            addOnInfo(imagePath, description);
        }

        private async void saveCnD(string cid, string size, int quantity)
        {
            string apiUrl = "http://localhost:5001/api/DongPhuc/muadongphuc/" + Program.id;

            var client = new HttpClient();

            var content = new StringContent(
                $"{{\"soCCCD\": \"{Program.id}\", \"maDongPhuc\": \"{cid}\", \"kichCo\": \"{size}\", \"soLuong\": \"{quantity}\"}}",
                System.Text.Encoding.UTF8,
                "application/json"
            );

            Console.WriteLine(content);

            try
            {
                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {

                }
                else
                {
                    XtraMessageBox.Show("Thao tác thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                XtraMessageBox.Show("Lỗi kết nối!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox4.Text == "" || comboBox5.Text == "")
            {
                MessageBox.Show("Vui lòng chọn size đồng phục", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBox3.Text == "" && checkEdit1.Checked)
            {
                // Message Box for not choosing type of dorm
                MessageBox.Show("Vui lòng chọn loại ký túc xá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            saveCnD("dp001", comboBox1.Text, (int)cltBtn1.Value);
            
            if ((int)cltBtn2.Value > 0) saveCnD("dp004", comboBox1.Text, (int)cltBtn2.Value);
            
            saveCnD("dp002", comboBox2.Text, (int)cltBtn3.Value);
            
            if ((int)cltBtn4.Value > 0) saveCnD("dp003", comboBox4.Text, (int)cltBtn4.Value);


            MessageBox.Show("Đã lưu thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }
    }
}