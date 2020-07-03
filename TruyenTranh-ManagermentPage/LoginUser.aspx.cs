using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Threading;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace TruyenTranh_ManagermentPage
{
    public partial class LoginUser : System.Web.UI.Page
    {
        protected override void InitializeCulture()
        {
            string ui = Request.QueryString["lancode"];
            if (string.IsNullOrEmpty(ui))
                ui = "vi";
            string culture = ui == "en" ? "en-us" : ui + "-" + "VN";
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
            base.InitializeCulture();
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }
        Managerment_PageEntities db = new Managerment_PageEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            lbThongBao.Enabled = false;
        }
        protected void imbLogin_Click(object sender, ImageClickEventArgs e)
        {
            if (txtName.Text != "" && txtPass.Text != "")
            {
                string taikhoan = txtName.Text;
                string matkhau = getMd5Hash(txtPass.Text);
                Managerment_PageEntities db = new Managerment_PageEntities();
                int check = db.Users.Count(x => x.username == taikhoan && x.password == matkhau);

                if (check == 1)
                {
                    User acc = db.Users.FirstOrDefault(x => x.username == taikhoan);
                    int idAccount = Convert.ToInt32(acc.idAccount.ToString());
                    User_Detail acc_detail = db.User_Detail.FirstOrDefault(x => x.idAccount == idAccount);
                    Boolean checkStatus = Convert.ToBoolean(acc_detail.status.ToString());
                    if (checkStatus == true)
                    {
                        Session["idKhachHang"] = idAccount;
                        Response.Redirect("index.aspx");
                    }
                    else
                    {
                        txtError.Text = "Tài khoản của bạn đã bị Vô hiệu hóa!";
                    }
                }
                else
                {
                    txtError.Text = "Tài khoản và mật khẩu sai!";
                }
            }
            else
            {
                lbThongBao.Text = "Tên đăng nhập hoặc mật khẩu trống!";
            }
        }
        static string getMd5Hash(string input)
        { // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create(); // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            // Create a new Stringbuilder to collect the bytes // and create a string.
            StringBuilder sBuilder = new StringBuilder(); // Loop through each byte of the hashed data // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}