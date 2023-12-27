using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Nhap_Hoc_TSV.Forms
{
    public partial class Main : DevExpress.XtraEditors.XtraForm
    {
        private int[] values = { 0, 0, 0, 0, 0 };

        public class DongPhuc
        {
            public string maDongPhuc { get; set; }
            public string tenDongPhuc { get; set; }
            public double donGia { get; set; }
        }

        public Main()
        {
            InitializeComponent();

            FormClosing += new FormClosingEventHandler(Main_FormClosing);

            Fee_Load();
            IsPaid();

            if (values[3] == 0) CnD_Load();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ask user if they want to the application
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private async void CnD_Load()
        {
            string api = "http://localhost:5001/api/DongPhuc/danhsachdongphuc";
            var client = new System.Net.Http.HttpClient();

            var response = await client.GetAsync(api);

            var responseContent = await response.Content.ReadAsStringAsync();

            List<DongPhuc> dongPhucs = JsonConvert.DeserializeObject<List<DongPhuc>>(responseContent);

            for (int i = 0; i < dongPhucs.Count; i++)
            {
                Program.arr_cnd[i] = (int)dongPhucs[i].donGia;
            }
        }

        private async void IsPaid()
        {
            string api = "http://localhost:5001/api/HocPhi/getlink/" + Program.id;
            var client = new System.Net.Http.HttpClient();

            var response = await client.GetAsync(api);

            var responseContent = await response.Content.ReadAsStringAsync();

            if (responseContent == "Sinh viên đã thanh toán học phí online!")
            {
                values[3] = values[4] = 1;
            }
        }

        private async void Fee_Load()
        {
            // API CALL
            string api = "http://localhost:5001/api/HocPhi/chitiethp/" + Program.id;
            var client = new System.Net.Http.HttpClient();

            var response = await client.GetAsync(api);

            var responseContent = await response.Content.ReadAsStringAsync();
            var data = Newtonsoft.Json.Linq.JObject.Parse(responseContent);

            Program.arr[0] = int.Parse(data["hocPhi"].ToString());
            Program.arr[1] = int.Parse(data["kinhPhiNhapHoc"].ToString());
            Program.arr[2] = int.Parse(data["phiBHYT"].ToString());
            Program.arr[3] = int.Parse(data["phiBHTN"].ToString());
            Program.arr[4] = int.Parse(data["phiKTX"].ToString());
            Program.arr[5] = int.Parse(data["phiDongPhuc"].ToString());
            Program.arr[6] = int.Parse(data["phiCLC"].ToString());
            Program.arr[7] = Program.arr[0] + Program.arr[1] + Program.arr[2] + Program.arr[3] + Program.arr[4] + Program.arr[5] + Program.arr[6];
        }
        public async Task<string> MakeRequest()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://example.com");
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
        }

        private void labelControl26_MouseEnter(object sender, EventArgs e)
        {
            // CHANGE CURSOR TO HAND WHEN MOUSE ENTER
            labelControl26.Cursor = Cursors.Hand;
        }

        // parameter: devExpress panel, color
        private void changeColor(DevExpress.XtraEditors.PanelControl panel, Color color)
        {
            foreach (Control c in panel.Controls)
            {
                if (c is DevExpress.XtraEditors.LabelControl)
                {
                    c.ForeColor = color;
                }
            }
        }

        private void panelEnter(DevExpress.XtraEditors.PanelControl panel)
        {
            panel.Cursor = Cursors.Hand;
            changeColor(panel, Color.Red);
        }
       
        private void panelLeave(DevExpress.XtraEditors.PanelControl panel)
        {
            panel.Cursor = Cursors.Default;
            changeColor(panel, Color.RoyalBlue);
        }

        private void panelControl3_MouseEnter(object sender, EventArgs e)
        {
            panelEnter(panelControl3);
        }

        private void panelControl3_MouseLeave(object sender, EventArgs e)
        {
            panelLeave(panelControl3);
        }

        private void panelControl4_MouseEnter(object sender, EventArgs e)
        {
            panelEnter(panelControl4);
        }

        private void panelControl4_MouseLeave(object sender, EventArgs e)
        {
            panelLeave(panelControl4);
        }

        private void panelControl5_MouseEnter(object sender, EventArgs e)
        {
            panelEnter(panelControl5);
        }

        private void panelControl5_MouseLeave(object sender, EventArgs e)
        {
            panelLeave(panelControl5);
        }

        private void panelControl6_MouseEnter(object sender, EventArgs e)
        {
            panelEnter(panelControl6);
        }

        private void panelControl6_MouseLeave(object sender, EventArgs e)
        {
            panelLeave(panelControl6);
        }

        private void panelControl7_MouseEnter(object sender, EventArgs e)
        {
            panelEnter(panelControl7);
        }

        private void panelControl7_MouseLeave(object sender, EventArgs e)
        {
            panelLeave(panelControl7);
        }

        private void panelControl8_MouseEnter(object sender, EventArgs e)
        {
            panelEnter(panelControl8);
        }

        private void panelControl8_MouseLeave(object sender, EventArgs e)
        {
            panelLeave(panelControl8);
        }

        private void openForm(Form form)
        {
            form.Show();

            this.Hide();

            form.FormClosed += (s, args) => this.Show();
        }

        private void panelControl3_Click(object sender, EventArgs e)
        {
            InfoUpdate info = new Forms.InfoUpdate();
            openForm(info);

            values[0] = 1;
        }

        private void panelControl4_Click(object sender, EventArgs e)
        {
            Upload upload = new Upload();
            openForm(upload);

            values[1] = 1;
        }

        private void panelControl5_Click(object sender, EventArgs e)
        {
            Bank bank = new Forms.Bank();
            openForm(bank);

            values[2] = 1;
        }

        private void panelControl6_Click(object sender, EventArgs e)
        {
            if (values[3] == 1)
            {
                MessageBox.Show("Đã thanh toán học phí online, không thể tiến hành mua đồng phục!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            CnD cnd = new Forms.CnD();
            openForm(cnd);

            values[3] = 1;
        }

        private void panelControl7_Click(object sender, EventArgs e)
        {
            if (values[4] == 1)
            {
                MessageBox.Show("Đã thanh toán học phí!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (values[3] == 0)
            {
                MessageBox.Show("Bắt buộc phải thực hiện bước 4 để tiến hành thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            Fee fee = new Forms.Fee();
            openForm(fee);

            values[4] = 1;
        }

        private void panelControl8_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == 0)
                {
                    string s = (i+1).ToString();
                    MessageBox.Show("Bạn chưa hoàn thành bước " + s, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            MessageBox.Show("Bạn đã hoàn thành tất cả các bước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }
    }
}