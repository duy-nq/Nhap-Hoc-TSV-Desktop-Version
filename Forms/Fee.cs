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
    public partial class Fee : DevExpress.XtraEditors.XtraForm
    {
        public Fee()
        {
            InitializeComponent();
            
            // Add fake data to grid view
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("STT", typeof(int));
            dataTable.Columns.Add("Khoản thu", typeof(string));
            dataTable.Columns.Add("Số tiền", typeof(string));

            dataTable.Rows.Add(1, "Học phí", "10.250.000");
            dataTable.Rows.Add(2, "Phí nhập học", "250.000");
            dataTable.Rows.Add(3, "Đồng phục", "350.000");
            dataTable.Rows.Add(4, "Phụ thu", "500.000");
            dataTable.Rows.Add(5, "Tổng cộng", "11.350.000");

            gridControl1.DataSource = dataTable;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // open web browser: google.com
            System.Diagnostics.Process.Start("https://www.google.com");

            // if the browser closed, show message box to inform user
            XtraMessageBox.Show("Đang tiến hành thanh toán...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            // message box to inform user that they will come to school to pay fee
            XtraMessageBox.Show("Thanh toán tại phòng ... từ ngày 21/08 đến 21/09", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}