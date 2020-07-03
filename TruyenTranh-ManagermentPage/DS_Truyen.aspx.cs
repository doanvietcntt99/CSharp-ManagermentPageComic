using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Security.Policy;

namespace TruyenTranh_ManagermentPage
{
    public partial class DS_Truyen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();

            }
        }
        void LoadData()
        {
            Managerment_PageEntities db = new Managerment_PageEntities();
            List<Comic> data = db.Comics.ToList<Comic>();
            dgvComic.DataSource = data;
            dgvComic.DataBind();
            getNameTypeComic();
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
        public string getStatus(object idComic)
        {
            try
            {
                Managerment_PageEntities db = new Managerment_PageEntities();
                Comic obj = db.Comics.FirstOrDefault(x => x.idComic.ToString() == idComic.ToString());
                if (obj.status == true)
                {
                    return "Đang kích hoạt!";
                }
                else
                {
                    return "Vô hiệu hóa!";
                }
            }
            catch
            {
                return "Không có!";
            }
            }


        protected void btnUpdateStatus_Command(object sender, CommandEventArgs e)
        {
            int idComic = int.Parse(e.CommandArgument.ToString());
            Managerment_PageEntities db = new Managerment_PageEntities();
            Comic comic = db.Comics.FirstOrDefault(x => x.idComic == idComic);
            Boolean status = Convert.ToBoolean(comic.status.ToString());
            Boolean statusafterupdate = true;
            if (status == true)
            {
                statusafterupdate = false;
            }
            else
            {
                statusafterupdate = true;
            }
            comic.status = statusafterupdate;
            db.SaveChanges();
            LoadData();
        }

        protected void btnDeleteComic_Command(object sender, CommandEventArgs e)
        {
            int idComic = int.Parse(e.CommandArgument.ToString());
            Managerment_PageEntities db = new Managerment_PageEntities();
            Comic obj = db.Comics.FirstOrDefault(x => x.idComic == idComic);
            db.Comics.Remove(obj);
            db.SaveChanges();
            LoadData();
        }

        protected void CreateAccount_Click(object sender, EventArgs e)
        {
            string nameComic = txtNameComic.Text;
            string typeofComic = cmbNameType.SelectedValue;
            string decription = txtDecription.Text;
            string author = txtAuthor.Text;
            string username = Session["username"].ToString();
            Managerment_PageEntities db = new Managerment_PageEntities();
            Account obj = db.Accounts.FirstOrDefault(x => x.username == username);
            int idAccount = obj.idAccount;
            Comic newComic = new Comic();
            newComic.nameComic = nameComic;
            newComic.idTypeComic = Convert.ToInt32(typeofComic);
            newComic.imgComic = "avatar.jpg";
            newComic.decription = decription;
            newComic.author = author;
            newComic.idAccount = idAccount;
            newComic.status = false;
            db.Comics.Add(newComic);
            db.SaveChanges();
            LoadData();
        }

        protected void btnChiTiet_Command(object sender, CommandEventArgs e)
        {
            int idComic = int.Parse(e.CommandArgument.ToString());
            string url = "EditDetailComic.aspx?idComic=" + idComic;
            Response.Redirect(url);
        }
        public void getNameTypeComic()
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
    }
}