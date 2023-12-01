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

        private bool PostLink(string code)
        {
            // open LinkForm
            Link linkForm = new Link(code);
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
            PostLink("1");
        }

        private void uploadBtn02_Click(object sender, EventArgs e)
        {
            PostLink("2");
        }

        private void uploadBtn03_Click(object sender, EventArgs e)
        {
            PostLink("3");
        }

        private void uploadBtn04_Click(object sender, EventArgs e)
        {
            PostLink("4");
        }

        private void uploadBtn05_Click(object sender, EventArgs e)
        {
            PostLink("5");
        }

        private void uploadBtn06_Click(object sender, EventArgs e)
        {
            PostLink("6");
        }

        private void uploadBtn07_Click(object sender, EventArgs e)
        {
            PostLink("7");
        }

        private void uploadBtn08_Click(object sender, EventArgs e)
        {
            PostLink("8");
        }

        private void uploadBtn09_Click(object sender, EventArgs e)
        {
            PostLink("9");
        }

        private void uploadBtn10_Click(object sender, EventArgs e)
        {
            PostLink("10");
        }

        private void uploadBtn11_Click(object sender, EventArgs e)
        {
            PostLink("11");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void labelControl14_Click(object sender, EventArgs e)
        {

        }
    }
}
