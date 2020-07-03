using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TruyenTranh_ManagermentPage;

namespace ibook
{
    public partial class Detail : System.Web.UI.Page
    {
        Managerment_PageEntities db = new Managerment_PageEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            int idcomic = Convert.ToInt32(Request.Params["idComic"]);
            var c = from f in db.Comics where f.idComic == idcomic select f;
            var chuong = from f in db.Chuongs where f.idComic == idcomic select f;
            rptBook.DataSource = c.ToList();
            rptchuong.DataSource = chuong.ToList();
            rptBook.DataBind();
            rptchuong.DataBind();
        }



        protected void btnYeuThich_Command1(object sender, CommandEventArgs e)
        {
            int idcomic = Convert.ToInt32(Request.Params["idComic"]);
            if (Session["idKhachHang"] == null)
            {

            }
            else
            {
                int idAccount = Convert.ToInt32(Session["idKhachHang"].ToString());
                ListFavourite checkout = db.ListFavourites.FirstOrDefault(x => x.idAccount == idAccount && x.idComic == idcomic);
                if (checkout == null)
                {
                    ListFavourite newF = new ListFavourite();
                    newF.idAccount = idAccount;
                    newF.idComic = idcomic;
                    db.ListFavourites.Add(newF);
                    db.SaveChanges();
                }
                else
                {

                }
                
            }

        }
    }
}