using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TruyenTranh_ManagermentPage;

namespace ibook
{
    public partial class Chuong1 : System.Web.UI.Page
    {
        Managerment_PageEntities db = new Managerment_PageEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            int idchuong = Convert.ToInt32(Request.Params["idChuong"]);
            var chuong = from f in db.Chuongs where f.idChuong == idchuong select f;
            rptBook.DataSource = chuong.ToList();
            rptBook.DataBind();
        }
    }
}