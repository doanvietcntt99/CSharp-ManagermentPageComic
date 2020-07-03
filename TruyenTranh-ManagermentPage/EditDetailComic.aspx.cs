using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace TruyenTranh_ManagermentPage
{
    public partial class EditDetailComic : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                getNameTypeComic();
            }
        }
        void LoadData()
        {
            int idComic =Convert.ToInt32( Request.Params["idComic"]);
            Managerment_PageEntities db = new Managerment_PageEntities();
            Comic obj = db.Comics.FirstOrDefault(x => x.idComic == idComic);
            txtIdComic.Text = obj.idComic.ToString();
            txtnameComic.Text = obj.nameComic.ToString();
            cmbNameType.SelectedValue = obj.idTypeComic.ToString();
            txtDecription.Text = obj.decription.ToString();
            txtAuthor.Text = obj.author.ToString();
            int idAccount = Convert.ToInt32(obj.idAccount.ToString());
            Account_Detail obj2 = db.Account_Detail.FirstOrDefault(x => x.idAccount == idAccount);
            txtPoster.Text = obj2.fullname.ToString();
            List<Chuong> data = db.Chuongs.Where(x => x.idComic == idComic).ToList();
            dgvChuong.DataSource = data;
            dgvChuong.DataBind();
            Comic obj3 = db.Comics.FirstOrDefault(x => x.idComic == idComic);
            img.ImageUrl = "img/Comic/" + obj3.imgComic.ToString();
        }
        public string getnameComic(object idComic)
        {
            try
            {
                Managerment_PageEntities db = new Managerment_PageEntities();
                Comic obj = db.Comics.FirstOrDefault(x => x.idComic.ToString() == idComic.ToString());
                return obj.nameComic;
            }
            catch
            {
                return "Đã xóa";
            }
        }
        public void getNameTypeComic ()
        {
            try
            {
                Managerment_PageEntities db = new Managerment_PageEntities();
                List<Type_Comic> dataTypeComic = db.Type_Comic.ToList();
                cmbNameType.DataSource = dataTypeComic;
                cmbNameType.DataTextField = "nameTypeComic";
                cmbNameType.DataValueField = "idTypeComic";
                cmbNameType.DataBind();
            }
            catch
            {
                
            }
        }

        protected void btnUpdateComicDetail_Command(object sender, CommandEventArgs e)
        {
            int idComic = Convert.ToInt32(Request.Params["idComic"]);
            string nameComic = txtnameComic.Text;
            int typeComic = Convert.ToInt32(cmbNameType.SelectedValue);
            string decription = txtDecription.Text;
            string author = txtAuthor.Text;
            Managerment_PageEntities db = new Managerment_PageEntities();
            Comic obj = db.Comics.FirstOrDefault(x => x.idComic == idComic);
            obj.nameComic = nameComic;
            obj.idTypeComic = typeComic;
            obj.decription = decription;
            obj.author = author;
            db.SaveChanges();
            LoadData();
        }

        protected void btnEdit_Click(object sender, CommandEventArgs e)
        {
            int idComic = Convert.ToInt32(Request.Params["idComic"]);
            int idChuong = Convert.ToInt32(e.CommandArgument.ToString());
            string url = "EditChuong.aspx?idChuong=" + idChuong;
            Response.Redirect(url);
        }

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {

            int idChuong = Convert.ToInt32(e.CommandArgument.ToString());
            Managerment_PageEntities db = new Managerment_PageEntities();
            Chuong obj = db.Chuongs.FirstOrDefault(x => x.idChuong == idChuong);
            db.Chuongs.Remove(obj);
            db.SaveChanges();
            LoadData();
            getNameTypeComic();
        }

        protected void btnResetForm_Command(object sender, CommandEventArgs e)
        {
            LoadData();
            getNameTypeComic();
        }

        protected void CreateChuong_Click(object sender, EventArgs e)
        {
            int idComic = Convert.ToInt32(Request.Params["idComic"]);
            string tenChuong = txtTenChuong.Text;
            string content = txtContent.Text;
            Managerment_PageEntities db = new Managerment_PageEntities();
            Chuong newChuong = new Chuong();
            newChuong.idComic = idComic;
            newChuong.tenChuong = tenChuong;
            newChuong.content = content;
            db.Chuongs.Add(newChuong);
            db.SaveChanges();
            LoadData();
            getNameTypeComic();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string sTenFile;
            int idComic = Convert.ToInt32(Request.Params["idComic"].ToString());
            sTenFile = FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath("~/img/Comic/" + sTenFile));
            lblNotice.Text = "Đã upload thành công";
            Managerment_PageEntities db = new Managerment_PageEntities();
            Comic obj = db.Comics.FirstOrDefault(x => x.idComic == idComic);
            obj.imgComic = sTenFile;
            db.SaveChanges();
            LoadData();
            getNameTypeComic();
        }

        protected void btnUpdateStatus_Command(object sender, CommandEventArgs e)
        {
            int idComic = int.Parse(e.CommandArgument.ToString());
            Managerment_PageEntities db = new Managerment_PageEntities();
            Chuong chuong = db.Chuongs.FirstOrDefault(x => x.idComic == idComic);
            Boolean status = Convert.ToBoolean(chuong.status.ToString());
            Boolean statusafterupdate = true;
            if (status == true)
            {
                statusafterupdate = false;
            }
            else
            {
                statusafterupdate = true;
            }
            chuong.status = statusafterupdate;
            db.SaveChanges();
            LoadData();
        }
    }
}