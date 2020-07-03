using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace TruyenTranh_ManagermentPage
{
    public partial class ManagermentPage : System.Web.UI.MasterPage
    {
        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Managerment_Page;Persist Security Info=True;User ID=sa;Password=123456");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }

        }
        void LoadData()
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                string username = Session["username"].ToString();
                Managerment_PageEntities db = new Managerment_PageEntities();
                Account obj = db.Accounts.FirstOrDefault(x => x.username == username);
                int idAccount = obj.idAccount;
                Account_Detail obj2 = db.Account_Detail.FirstOrDefault(y => y.idAccount == idAccount);
                Username.Text = obj2.fullname;
                string queryimg = "select imgAccount from Account_Detail where idAccount='" + idAccount + "'";
                SqlCommand cmd2 = new SqlCommand(queryimg, conn);
                conn.Open();
                img.ImageUrl = "img/account/" + cmd2.ExecuteScalar().ToString();
                conn.Close();
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Response.Redirect("login.aspx");
        }

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            string username = Session["username"].ToString();
            Managerment_PageEntities db = new Managerment_PageEntities();
            Account obj = db.Accounts.FirstOrDefault(x => x.username == username);
            int idAccount = obj.idAccount;
            string url = "Profile.aspx?idAccount=" + idAccount;
            Response.Redirect(url);
        }
    }
}