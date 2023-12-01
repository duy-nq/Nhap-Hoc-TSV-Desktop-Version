using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Http;
using System.Threading.Tasks;

namespace Nhap_Hoc_TSV.Forms
{
    public partial class Main : DevExpress.XtraEditors.XtraForm
    {
        private int[] values = { 0, 0, 0, 0, 0 };

        public Main()
        {
            InitializeComponent();
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
            Info info = new Forms.Info();
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
            CnD cnd = new Forms.CnD();
            openForm(cnd);

            values[3] = 1;
        }

        private void panelControl7_Click(object sender, EventArgs e)
        {
            if (values[3] == 0)
            {
                MessageBox.Show("Bạn chưa hoàn thành bước 4 để tiến hành thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    // i to string
                    string s = (i+1).ToString();
                    // message box inform that step i is not completed
                    MessageBox.Show("Bạn chưa hoàn thành bước " + s, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            MessageBox.Show("Bạn đã hoàn thành tất cả các bước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }
    }
}