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

namespace Nhap_Hoc_TSV.Forms
{
    public partial class Info : DevExpress.XtraEditors.XtraForm
    {
        public Info()
        {
            InitializeComponent();
            selfImage.Image = Image.FromFile(@"C:\Users\HP\Downloads\Documents\test.jpg");
            selfImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
        }

        // change in checkEdit1 event
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
    }
}