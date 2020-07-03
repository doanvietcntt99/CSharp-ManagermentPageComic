using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TruyenTranh_ManagermentPage;

namespace ibook
{
    public partial class Search : System.Web.UI.Page
    {
        Managerment_PageEntities db = new Managerment_PageEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            int typecomic = Convert.ToInt32(Request.Params["idTypeComic"]);
            var c = from f in db.Comics where f.idTypeComic == typecomic select f;
            rptBook.DataSource = c.ToList();
            rptBook.DataBind();
        }
    }
}