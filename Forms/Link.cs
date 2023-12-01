using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace Nhap_Hoc_TSV.Forms
{
    public partial class Link : DevExpress.XtraEditors.XtraForm
    {
        public static string code;

        // get code from Upload.cs
        public static void getCode(string code)
        {
            Link.code = code;
        }

        public Link(string code)
        {
            InitializeComponent();
            getCode(code);
        }

        public Link()
        {
            InitializeComponent();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {            
            if (LinkHolder.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đường dẫn đến file!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }   
            
            // TODO: Call API to upload link to server using txtLink.Text
            MessageBox.Show("Upload thành công "+code, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
    }
}