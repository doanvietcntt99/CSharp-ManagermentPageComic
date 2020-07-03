using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TruyenTranh_ManagermentPage;

namespace ibook
{
    public partial class index : System.Web.UI.MasterPage
    {
        Managerment_PageEntities db = new Managerment_PageEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idKhachHang"] == null)
            {
                AvatarKhachHang.ImageUrl = "./img/mèo bó chịu.jpg";
                NameKhachHang.Text = "Đụt Team";
            }
            else
            {
                int idKhachHang = Convert.ToInt32(Session["idKhachHang"]);
                Managerment_PageEntities db = new Managerment_PageEntities();
                User_Detail user = db.User_Detail.FirstOrDefault(x => x.idAccount == idKhachHang);
                AvatarKhachHang.ImageUrl = "./img/customer/" + user.imgAccount;
                NameKhachHang.Text = user.fullname;
            }
        }

        protected void rptTypeComic_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
           
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            var result = db.Comics.Where(x => x.nameComic.Contains(tbSearch.Text));
            searchbook.DataSource = result.ToList();
            searchbook.DataBind();
        }
    }
}