using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TruyenTranh_ManagermentPage
{
    public partial class Favourite : System.Web.UI.Page
    {
        Managerment_PageEntities db = new Managerment_PageEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idKhachHang"] == null)
            {
                Response.Redirect("index.aspx");
            }
            else
            {
                LoadData();
            }
        }
        void LoadData()
        {
            int idKhachHang = Convert.ToInt32(Session["idKhachHang"]);

            List<ListFavourite> listFavourite = db.ListFavourites.Where(x => x.idAccount == idKhachHang).ToList();
            List<Comic> lsComic = new List<Comic>();
            foreach (ListFavourite ls in listFavourite)
            {
                Comic comic = db.Comics.FirstOrDefault(x => x.idComic == ls.idComic);
                lsComic.Add(comic);
            }
            dgvFavouriteComic.DataSource = lsComic;
            dgvFavouriteComic.DataBind();
        }
        public string getnameTypeComic(object idTypeComic)
        {
            try
            {
                Managerment_PageEntities db = new Managerment_PageEntities();
                Type_Comic obj = db.Type_Comic.FirstOrDefault(x => x.idTypeComic.ToString() == idTypeComic.ToString());
                return obj.nameTypeComic;
            }
            catch
            {
                return "Đã xóa";
            }
        }
        public string getURLAvatar(object idComic)
        {
            try
            {
                Managerment_PageEntities db = new Managerment_PageEntities();
                Comic obj = db.Comics.FirstOrDefault(x => x.idComic.ToString() == idComic.ToString());
                return "./img/comic/" + obj.imgComic;
            }
            catch
            {
                return "./img/comic/default-avatar.jpg";
            }
        }
        protected void btnDeleteFavouriteComic_Command(object sender, CommandEventArgs e)
        {
            int idComic = int.Parse(e.CommandArgument.ToString());
            int idAccount = Convert.ToInt32(Session["idKhachHang"].ToString());
            ListFavourite lf = db.ListFavourites.FirstOrDefault(x => x.idComic == idComic && x.idAccount == idAccount);
            db.ListFavourites.Remove(lf);
            db.SaveChanges();
            LoadData();
        }

        protected void btnChiTiet_Command(object sender, CommandEventArgs e)
        {
            int idComic = int.Parse(e.CommandArgument.ToString());
            string url = "Detail.aspx?idComic=" + idComic;
            Response.Redirect(url);
        }
    }
}