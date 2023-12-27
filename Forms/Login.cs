using DevExpress.XtraEditors;
using Newtonsoft.Json.Linq;
using Nhap_Hoc_TSV.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhap_Hoc_TSV
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Title_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void memoEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_MouseHover(object sender, EventArgs e)
        {
            // Inform user default password is dd/mm/yyyy
            txtPassword.ToolTip = "Mật khẩu mặc định là ngày sinh của bạn (ddmmyyyy)";
        }

        private void txtUsername_MouseHover(object sender, EventArgs e)
        {
            // Inform user default username is your student ID
            txtUsername.ToolTip = "Tên đăng nhập mặc định là mã số sinh viên của bạn";
        }

        private void fPassword_MouseEnter(object sender, EventArgs e)
        {
            // cursor change to hand when mouse enter
            fPassword.Cursor = Cursors.Hand;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string apiUrl = "http://localhost:5001/api/Login"; // Replace with your API endpoint

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            var client = new HttpClient();

            // Prepare the content to be sent in the request body (assuming it's JSON)
            var content = new StringContent(
                $"{{\"soCCCD\": \"{username}\", \"matKhau\": \"{password}\"}}", 
                System.Text.Encoding.UTF8,
                "application/json"
            );

            try
            {
                // Send POST request to the API
                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    // Read response content
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var json = JObject.Parse(responseContent);

                    if (json["success"].ToString() == "False")
                    {
                        XtraMessageBox.Show("Đăng nhập thất bại. Vui lòng kiểm tra lại thông tin đăng nhập.", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Save user ID and token
                    Program.id = username;
                    Program.token = json["data"].ToString();

                    Console.WriteLine("ID: " + Program.id);
                    Console.WriteLine("Token: " + Program.token);

                    // Open main form
                    Main main = new Main();
                    main.Show();

                    // Hide login form
                    this.Hide();
                }
                else
                {
                    // Handle error or unsuccessful login
                    Console.WriteLine("Login failed. Status code: " + response.StatusCode);
                    XtraMessageBox.Show("Đăng nhập thất bại. Vui lòng kiểm tra lại thông tin đăng nhập.", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (HttpRequestException err)
            {
                // Handle exception
                Console.WriteLine("Error: " + err.Message);
            }
            finally
            {
                client.Dispose();
            }
        }
    }
}