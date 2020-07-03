using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Threading;

namespace TruyenTranh_ManagermentPage
{
    public partial class EditChuong : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
            }
        }
        void GetData()
        {
            int idChuong = Convert.ToInt32(Request.Params["idChuong"].ToString());
            Managerment_PageEntities db = new Managerment_PageEntities();
            Chuong obj = db.Chuongs.FirstOrDefault(x => x.idChuong == idChuong);
            txtTenChuong.Text = obj.tenChuong.ToString();
            txtContent.Text = obj.content.ToString();
        }

        protected void btnSaveContent_Click(object sender, EventArgs e)
        {
            int idChuong = Convert.ToInt32(Request.Params["idChuong"]);
            string txtContentUpdate = txtContent.Text;
            string txttenChuong = txtTenChuong.Text;
            Managerment_PageEntities db = new Managerment_PageEntities();
            Chuong obj = db.Chuongs.FirstOrDefault(x => x.idChuong == idChuong);
            obj.tenChuong = txttenChuong;
            obj.content = txtContentUpdate;
            db.SaveChanges();
            Status.Text = "Cập nhật thành công!";
            /*Thread.Sleep(2000);
            Response.Redirect("DS_Truyen.aspx");*/
        }

        protected void btnResetContent_Click(object sender, EventArgs e)
        {
            string idChuong = Request.Params["idChuong"].ToString();
            Managerment_PageEntities db = new Managerment_PageEntities();
            Chuong obj = db.Chuongs.FirstOrDefault(x => x.idChuong.ToString() == idChuong.ToString());
            txtTenChuong.Text = obj.tenChuong.ToString();
            txtContent.Text = obj.content.ToString();
        }
    }
}