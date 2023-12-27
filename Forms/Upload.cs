using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Nhap_Hoc_TSV.Forms;

namespace Nhap_Hoc_TSV
{    
    public partial class Upload : DevExpress.XtraEditors.XtraForm
    {
        public Upload()
        {
            InitializeComponent();
            FormClosing += new FormClosingEventHandler(Upload_FormClosing);
        }

        private void Upload_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ask user if they want to exit
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        // add-on infomation for section
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

        private bool uploading()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                // TODO: Call API to upload image to server using imagePath


                MessageBox.Show("Upload thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            return false;
        }

        private bool PostLink(string code, string title)
        {
            // open LinkForm
            Link linkForm = new Link(code, title);
            linkForm.ShowDialog();

            return true;
        }

        private void labelControl7_Click(object sender, EventArgs e)
        {
            string imagePath = "C:/Users/HP/Desktop/MyWork/banner-template.png";
            string description = "Danh sách đối tượng ưu tiên";
            addOnInfo(imagePath, description);
        }

        private void labelControl7_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void labelControl7_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void labelControl18_Click(object sender, EventArgs e)
        {
            string imagePath = "C:/Users/HP/Desktop/MyWork/banner-template.png";
            string description = "Danh sách chứng chỉ";
            addOnInfo(imagePath, description);
        }

        private void labelControl18_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void labelControl18_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void uploadBtn01_Click(object sender, EventArgs e)
        {
            PostLink("1", "1. Học bạ THPT (*)");
        }

        private void uploadBtn02_Click(object sender, EventArgs e)
        {
            PostLink("2", "2. Giấy xác nhận tốt nghiệp THPT tạm thời (*)");
        }

        private void uploadBtn03_Click(object sender, EventArgs e)
        {
            PostLink("3", "3. Giấy khai sinh (*)");
        }

        private void uploadBtn04_Click(object sender, EventArgs e)
        {
            PostLink("4", "4. Đối tượng ưu tiên");
        }

        private void uploadBtn05_Click(object sender, EventArgs e)
        {
            PostLink("5", "5. Giấy báo trúng tuyển (*)");
        }

        private void uploadBtn06_Click(object sender, EventArgs e)
        {
            PostLink("6", "6. Giấy chứng nhận");
        }

        private void uploadBtn07_Click(object sender, EventArgs e)
        {
            PostLink("7", "7. Hồ sơ sinh viên (*)");
        }

        private void uploadBtn08_Click(object sender, EventArgs e)
        {
            PostLink("8", "8. Giấy chuyển sinh hoạt Đoàn (Đảng)");
        }

        private void uploadBtn09_Click(object sender, EventArgs e)
        {
            PostLink("9", "9. Giấy chuyển NVQS (với nam giới)");
        }

        private void uploadBtn10_Click(object sender, EventArgs e)
        {
            PostLink("10", "10. Thẻ BHYT (*)");
        }

        private void uploadBtn11_Click(object sender, EventArgs e)
        {
            PostLink("11", "11. Chứng chỉ Anh Văn hoặc QPAN");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void labelControl14_Click(object sender, EventArgs e)
        {

        }
    }
}
