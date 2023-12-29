using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Windows.Forms;
using static Nhap_Hoc_TSV.Forms.Main;

namespace Nhap_Hoc_TSV.Forms
{
    public partial class Fee : DevExpress.XtraEditors.XtraForm
    {
        private bool isPaid = false;
        
        public Fee()
        {
            InitializeComponent();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("STT", typeof(int));
            dataTable.Columns.Add("Khoản thu", typeof(string));
            dataTable.Columns.Add("Số tiền", typeof(int));       

            dataTable.Rows.Add(1, "Học phí", Program.arr[0]);
            dataTable.Rows.Add(2, "Kinh phí nhập học", Program.arr[1]);
            dataTable.Rows.Add(3, "Phí BHYT", Program.arr[2]);
            dataTable.Rows.Add(4, "Phí BHTN", Program.arr[3]);
            dataTable.Rows.Add(5, "Phí KTX", Program.arr[4]);
            dataTable.Rows.Add(6, "Phí đồng phục", Program.arr[5]);
            dataTable.Rows.Add(7, "Phí CLC", Program.arr[6]);
            dataTable.Rows.Add(8, "Tổng cộng", Program.arr[7]);

            gridControl1.DataSource = dataTable;
        }

        private async void LinkToPay()
        {
            string api = "http://localhost:5001/api/HocPhi/getlink/" + Program.id;
            var client = new System.Net.Http.HttpClient();

            var response = await client.GetAsync(api);

            var responseContent = await response.Content.ReadAsStringAsync();

            if (responseContent == "Sinh viên đã thanh toán học phí online!")
            {
                return;
            }
            else
            {
                System.Diagnostics.Process.Start(responseContent);
            }

            values[4] = 1;
        }

        private async void CheckBill()
        {
            string api = "http://localhost:5001/api/HocPhi/hoadon/" + Program.id;
            var client = new System.Net.Http.HttpClient();

            var response = await client.GetAsync(api);

            var responseContent = await response.Content.ReadAsStringAsync();

            try
            {
                isPaid = true;

                var data = Newtonsoft.Json.Linq.JObject.Parse(responseContent);

                string message = "Mã hóa đơn: " + data["maHD"].ToString() + " - Số tiền: " + data["soTien"].ToString() + " - Thời gian: " + data["thoiDiem"].ToString() + " - Nội dung thanh toán: " + data["noiDung"].ToString();

                XtraMessageBox.Show(message, "Xác nhận đã thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch
            {
                XtraMessageBox.Show("Thanh toán chưa hoàn tất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            CheckBill();
            
            if (isPaid) return;
            else LinkToPay();       
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Thanh toán tại phòng ... từ ngày 21/08 đến 21/09", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Program.offline = true;
            Close();
        }
    }
}