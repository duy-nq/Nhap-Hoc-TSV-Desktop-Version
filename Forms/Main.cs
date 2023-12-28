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
        public int[] values = { 0, 0, 0, 0, 0 };

        public class DongPhuc
        {
            public string maDongPhuc { get; set; }
            public string tenDongPhuc { get; set; }
            public double donGia { get; set; }
        }

        public class KTX
        {
            public string tenPhong { get; set; }
            public string gioiTinh { get; set; }
            public int soNguoi { get; set; }
            public double donGia { get; set; }
            public string giuongNam { get; set; }
            public string wc { get; set; }
            public string dichVuDiKem { get; set; }
        }

        public Main()
        {
            InitializeComponent();

            FormClosing += new FormClosingEventHandler(Main_FormClosing);

            Program.Fee_Load();
            IsPaid();

            if (Program.arr[5] != 0) values[3] = 1;
            if (values[4] == 0) CnD_Load();
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
            if (Program.offline != true)
            {
                if (values[4] == 1)
                {
                    MessageBox.Show("Đã thanh toán học phí, không thể tiến hành mua đồng phục!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            CnD cnd = new Forms.CnD();
            openForm(cnd);

            Program.Fee_Load();
            if (Program.arr[5] == 0)
            {
                MessageBox.Show("Hoàn tất bước này trước khi thực hiện thanh toán!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else values[3] = 1;
        }

        private void panelControl7_Click(object sender, EventArgs e)
        {
            if (values[4] == 1 && Program.offline == false)
            {
                MessageBox.Show("Đã thanh toán học phí!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (values[3] == 0)
            {
                MessageBox.Show("Bạn chưa hoàn thành bước 4", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Fee fee = new Forms.Fee();
            openForm(fee);

            IsPaid();
            if (Program.offline == true)
            {
                values[4] = 1;
            }
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