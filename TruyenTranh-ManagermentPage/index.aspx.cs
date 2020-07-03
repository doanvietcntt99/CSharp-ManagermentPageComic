using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TruyenTranh_ManagermentPage;

namespace ibook
{
    public partial class index1 : System.Web.UI.Page
    {
        Managerment_PageEntities m = new Managerment_PageEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            load();

        }
        void load()
        {
            /*List<Type_Comic> data = m.Type_Comic.ToList<Type_Comic>();
            .DataSource = data;
            dgvtype.DataBind();*/
            /*SqlDataSource dtsTypeComic = new SqlDataSource();
            var data = from f in m.Type_Comic select new { f.nameTypeComic };
            dtsTypeComic. = data.ToList();*/

        }


    }
}