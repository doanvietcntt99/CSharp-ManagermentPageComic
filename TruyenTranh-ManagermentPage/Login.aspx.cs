using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Configuration;
using System.Security.Cryptography;
namespace TruyenTranh_ManagermentPage
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string taikhoan = txtusername.Text;
            string matkhau = getMd5Hash(txtpassword.Text);
            if (taikhoan.Length == 0 && matkhau.Length == 0)
            {
                txtError.Text = "Vui lòng nhập tài khoản và mật khẩu!";
            }
            else if (taikhoan.Length == 0)
            {
                txtError.Text = "Vui lòng nhập tài khoản!";
            }
            else if (matkhau.Length == 0)
            {
                txtError.Text = "Vui lòng nhập mật khẩu!";
            }
            else
            {
                Managerment_PageEntities db = new Managerment_PageEntities();
                int check = db.Accounts.Count(x => x.username == taikhoan && x.password == matkhau);
                Account acc = db.Accounts.FirstOrDefault(x => x.username == taikhoan);
                int idAccount = Convert.ToInt32(acc.idAccount.ToString());
                Account_Detail acc_detail = db.Account_Detail.FirstOrDefault(x => x.idAccount == idAccount);
                Boolean checkStatus = Convert.ToBoolean(acc_detail.status.ToString());

                if (check == 1)
                {
                    if (checkStatus == true)
                    {
                        Session["username"] = taikhoan;
                        Response.Redirect("Index_ManagermentPage.aspx");
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