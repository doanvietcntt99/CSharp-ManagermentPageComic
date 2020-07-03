using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TruyenTranh_ManagermentPage
{
    public partial class DS_KhachHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        public string getusernameUser(object idAccount)
        {
            try
            {
                Managerment_PageEntities db = new Managerment_PageEntities();
                User obj = db.Users.FirstOrDefault(x => x.idAccount.ToString() == idAccount.ToString());
                return obj.username;
            }
            catch
            {
                return "Đã xóa";
            }
        }
        void LoadData()
        {
            Managerment_PageEntities db = new Managerment_PageEntities();
            List<User_Detail> data = db.User_Detail.ToList<User_Detail>();
            dgvUser.DataSource = data;
            dgvUser.DataBind();
        }
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text;
            string password = getMd5Hash(txtpassword.Text);
            string fullname = txtFullname.Text;
            string DOB = txtDOB.Text;
            string Address = txtAddress.Text;
            string Email = txtEmail.Text;
            Managerment_PageEntities db = new Managerment_PageEntities();
            User newUser = new User();
            newUser.username = username;
            newUser.password = password;
            db.Users.Add(newUser);
            db.SaveChanges();
            User acc = db.Users.FirstOrDefault(x => x.username == username);
            int idAccount = acc.idAccount;
            User_Detail newuser_Detail = new User_Detail();
            newuser_Detail.idAccount = idAccount;
            newuser_Detail.fullname = fullname;
            newuser_Detail.DOB = Convert.ToDateTime(DOB);
            newuser_Detail.Address = Address;
            newuser_Detail.Email = Email;
            newuser_Detail.status = false;
            newuser_Detail.imgAccount = "default-avatar.jpg";
            db.User_Detail.Add(newuser_Detail);
            db.SaveChanges();
            LoadData();
        }

        protected void btnUpdateStatus_Command(object sender, CommandEventArgs e)
        {
            int idAccount = int.Parse(e.CommandArgument.ToString());
            Managerment_PageEntities db = new Managerment_PageEntities();
            User_Detail acc_detail = db.User_Detail.FirstOrDefault(x => x.idAccount == idAccount);
            Boolean status = Convert.ToBoolean(acc_detail.status.ToString());
            Boolean statusafterupdate = true;
            if (status == true)
            {
                statusafterupdate = false;
            }
            else
            {
                statusafterupdate = true;
            }
            acc_detail.status = statusafterupdate;
            db.SaveChanges();
            LoadData();
        }

        protected void btnResetPassword_Command(object sender, CommandEventArgs e)
        {
            string passwordmacdinh = "admin123";
            string password = getMd5Hash(passwordmacdinh);
            int idAccount = int.Parse(e.CommandArgument.ToString());
            Managerment_PageEntities db = new Managerment_PageEntities();
            User acc = db.Users.FirstOrDefault(x => x.idAccount == idAccount);
            acc.password = password;
            db.SaveChanges();
            LoadData();
        }

        protected void btnXoa_Command(object sender, CommandEventArgs e)
        {
            int idAccount = int.Parse(e.CommandArgument.ToString());
            Managerment_PageEntities db = new Managerment_PageEntities();
            User_Detail obj = db.User_Detail.FirstOrDefault(x => x.idAccount == idAccount);
            db.User_Detail.Remove(obj);
            db.SaveChanges();
            User objAcc = db.Users.FirstOrDefault(x => x.idAccount == idAccount);
            db.Users.Remove(objAcc);
            db.SaveChanges();
            LoadData();
        }

        protected void btnSua_Command(object sender, CommandEventArgs e)
        {
            int idAccount = int.Parse(e.CommandArgument.ToString());
            string url = "EditUser.aspx?idAccount=" + idAccount;
            Response.Redirect(url);
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