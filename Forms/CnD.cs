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
            
            dt.Rows.Add("Áo sơ mi", "130000");
            dt.Rows.Add("Đồng phục thể dục", "200000");

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

        private void checkEdit3_CheckedChanged(object sender, EventArgs e)
        {
            checkEdit4.Checked = !checkEdit3.Checked;
            cltBtn1.Enabled = cltBtn2.Enabled = false;

            checkEdit4.Enabled = true;
            checkEdit3.Enabled = false;
        }

        private void checkEdit4_CheckedChanged(object sender, EventArgs e)
        {
            checkEdit3.Checked = !checkEdit4.Checked;
            cltBtn1.Enabled = cltBtn2.Enabled = true;
            cltBtn1.Value = cltBtn2.Value = 1;

            checkEdit3.Enabled = true;
            checkEdit4.Enabled = false;
        }

        private void sizeBtn_Click(object sender, EventArgs e)
        {
            string imagePath = "C:/Users/HP/Desktop/MyWork/banner-template.png";
            string description = "Bảng tra cứu size đồng phục";
            addOnInfo(imagePath, description);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || comboBox2.Text == "")
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

            // Send data to database via API
            MessageBox.Show("Đã lưu thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}