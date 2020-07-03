using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
namespace TruyenTranh_ManagermentPage
{

    public partial class DS_TaiKhoan : System.Web.UI.Page
    {

        void LoadData()
        {
            Managerment_PageEntities db = new Managerment_PageEntities();
            List<Account_Detail> data = db.Account_Detail.ToList<Account_Detail>();
            dgvTaiKhoan.DataSource = data;
            dgvTaiKhoan.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        public string getUsername(object idAccount)
        {
            try
            {
                Managerment_PageEntities db = new Managerment_PageEntities();
                Account obj = db.Accounts.FirstOrDefault(x => x.idAccount.ToString() == idAccount.ToString());
                return obj.username;
            }
            catch
            {
                return "Đã xóa";
            }
        }
        protected void BtnResetPassword(object sender, EventArgs e)
        {

        }

        protected void BtnDisableAccount(object sender, EventArgs e)
        {

        }

        protected void btnXoa_Command(object sender, CommandEventArgs e)
        {
            int idAccount = int.Parse(e.CommandArgument.ToString());
            Managerment_PageEntities db = new Managerment_PageEntities();
            Account_Detail obj = db.Account_Detail.FirstOrDefault(x => x.idAccount == idAccount);
            db.Account_Detail.Remove(obj);
            db.SaveChanges();
            Account objAcc = db.Accounts.FirstOrDefault(x => x.idAccount == idAccount);
            db.Accounts.Remove(objAcc);
            db.SaveChanges();
            LoadData();
        }

        protected void btnUpdateStatus_Command(object sender, CommandEventArgs e)
        {
            int idAccount = int.Parse(e.CommandArgument.ToString());
            Managerment_PageEntities db = new Managerment_PageEntities();
            Account_Detail acc_detail = db.Account_Detail.FirstOrDefault(x => x.idAccount == idAccount);
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
            Account acc = db.Accounts.FirstOrDefault(x => x.idAccount == idAccount);
            acc.password = password;
            db.SaveChanges();
            LoadData();
        }

        protected void CreateAccount_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text;
            string password = getMd5Hash(txtpassword.Text);
            string fullname = txtFullname.Text;
            string DOB = txtDOB.Text;
            string Address = txtAddress.Text;
            string Email = txtEmail.Text;
            Managerment_PageEntities db = new Managerment_PageEntities();
            Account newAccount = new Account();
            newAccount.username = username;
            newAccount.password = password;
            db.Accounts.Add(newAccount);
            db.SaveChanges();
            Account acc = db.Accounts.FirstOrDefault(x => x.username == username);
            int idAccount = acc.idAccount;
            Account_Detail newaccount_Detail = new Account_Detail();
            newaccount_Detail.idAccount = idAccount;
            newaccount_Detail.fullname = fullname;
            newaccount_Detail.DOB = Convert.ToDateTime(DOB);
            newaccount_Detail.Address = Address;
            newaccount_Detail.Email = Email;
            newaccount_Detail.status = false;
            newaccount_Detail.imgAccount = "default-avatar.jpg";
            db.Account_Detail.Add(newaccount_Detail);
            db.SaveChanges();
            LoadData();
            DeleteForm();
        }
        void DeleteForm()
        {
            txtusername.Text = "";
            txtpassword.Text = "";
            txtFullname.Text = "";
            txtDOB.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
        }
        protected void btnSua_Command(object sender, CommandEventArgs e)
        {
            int idAccount = int.Parse(e.CommandArgument.ToString());
            string url = "EditAccount.aspx?idAccount=" + idAccount;
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