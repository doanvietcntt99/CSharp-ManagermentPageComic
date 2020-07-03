using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TruyenTranh_ManagermentPage
{
    public partial class Index_ManagermentPage : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Managerment_Page;Persist Security Info=True;User ID=sa;Password=123456");
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();

        }
        void LoadData()
        {
            string query = "exec TinhTiLeTaiKhoan";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            string ketqua = cmd.ExecuteScalar().ToString();
            conn.Close();
            txtstatus.Text = ketqua + "%";
            Label1.Text = "";
            Label1.Text += "<div class='progress-bar bg-info' role='progressbar' runat='server' style='width:" + ketqua + "%; height: 100%;' aria-valuenow='" + ketqua + "' aria-valuemin='0' aria-valuemax='100'></div>";
            string queryTiLETrang = "exec TinhTiLeComicActive";
            SqlCommand cmd2 = new SqlCommand(queryTiLETrang, conn);
            conn.Open();
            float codeStatusTrang = float.Parse(cmd2.ExecuteScalar().ToString());
            conn.Close();
            Label2.Text = codeStatusTrang + "%";
            Label3.Text = "<div class='progress-bar bg-info' role='progressbar' runat='server' style='width:" + codeStatusTrang + "%; height: 100%;' aria-valuenow='" + codeStatusTrang + "' aria-valuemin='0' aria-valuemax='100'></div>";
            Managerment_PageEntities db = new Managerment_PageEntities();
            int countComic = db.Comics.Count();
            txtTotalComic.Text = countComic.ToString();
            int countChapter = db.Chuongs.Count();
            txtTotalChapter.Text = countChapter.ToString();
            int countAccount = db.Accounts.Count();
            txtTotalAccount.Text = countAccount.ToString();
            int countUser = db.Users.Count();
            txtTotalUser.Text = countUser.ToString();
            string queryChuong = "exec TinhTiLeChuongActive";
            SqlCommand cmd3 = new SqlCommand(queryChuong, conn);
            conn.Open();
            string ketquaChuong = cmd3.ExecuteScalar().ToString();
            conn.Close();
            txtStatusChuong.Text = ketquaChuong + "%";
            Label4.Text = "<div class='progress-bar bg-info' role='progressbar' runat='server' style='width:" + ketquaChuong + "%; height: 100%;' aria-valuenow='" + ketquaChuong + "' aria-valuemin='0' aria-valuemax='100'></div>";
            string queryUser = "exec TinhTiLeUserActive";
            SqlCommand cmd4 = new SqlCommand(queryUser, conn);
            conn.Open();
            string ketquaUser = cmd4.ExecuteScalar().ToString();
            conn.Close();
            lbPercentUser.Text = ketquaUser + "%";
            lbPercentUserBar.Text = "<div class='progress-bar bg-info' role='progressbar' runat='server' style='width:" + ketquaUser + "%; height: 100%;' aria-valuenow='" + ketquaUser + "' aria-valuemin='0' aria-valuemax='100'></div>";
        }

    }
}
