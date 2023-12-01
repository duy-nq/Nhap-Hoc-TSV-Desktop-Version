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
    public partial class Bank : DevExpress.XtraEditors.XtraForm
    {
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

        }
    }
}