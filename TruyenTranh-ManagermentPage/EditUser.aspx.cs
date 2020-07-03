using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
namespace TruyenTranh_ManagermentPage
{
    public partial class EditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadData();
            }
        }
        void LoadData()
        {
            int idAccount = Convert.ToInt32(Request.Params["idAccount"].ToString());
            Managerment_PageEntities db = new Managerment_PageEntities();
            User acc = db.Users.FirstOrDefault(x => x.idAccount == idAccount);
            User_Detail acc_detail = db.User_Detail.FirstOrDefault(x => x.idAccount == idAccount);
            txtusername.Text = acc.username;
            txtFullname.Text = acc_detail.fullname;
            DateTime date = Convert.ToDateTime(acc_detail.DOB);
            string formatted = date.ToString("yyyy-MM-dd");
            txtDOB.Text = formatted;
            txtAddress.Text = acc_detail.Address;
            txtEmail.Text = acc_detail.Email;
            img.ImageUrl = "img/customer/" + acc_detail.imgAccount;
            List<ListFavourite> listidFavourties = db.ListFavourites.Where(x => x.idAccount == idAccount).ToList();
            List<Comic> viewList = new List<Comic>();
            foreach (ListFavourite items in listidFavourties)
            {
                int idComic = Convert.ToInt32(items.idComic.ToString());
                Comic comic = db.Comics.FirstOrDefault(x => x.idComic == idComic);
                viewList.Add(comic);
            }
            dgvListFavourite.DataSource = viewList;
            dgvListFavourite.DataBind();
        }
       
        protected void btnEditAccount_Click(object sender, EventArgs e)
        {
            try
            {
                int idAccount = Convert.ToInt32(Request.Params["idAccount"].ToString());
                string fullname = txtFullname.Text;
                string DOB = txtDOB.Text;
                string Address = txtAddress.Text;
                string Email = txtEmail.Text;
                Managerment_PageEntities db = new Managerment_PageEntities();
                User_Detail user_detail = db.User_Detail.FirstOrDefault(x => x.idAccount == idAccount);
                user_detail.fullname = fullname;
                user_detail.DOB = Convert.ToDateTime(DOB);
                user_detail.Address = Address;
                user_detail.Email = Email;
                db.SaveChanges();
                lblNotice.Text = "Đã Cập nhật thông tin thành công!";
                LoadData();
            }
            catch
            {
                lblNotice.Text = "Thất Bại!";
                LoadData();
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            Managerment_PageEntities db = new Managerment_PageEntities();
            string sTenFile;
            int idAccount = Convert.ToInt32(Request.Params["idAccount"].ToString());
            User_Detail getOldNameImg = db.User_Detail.FirstOrDefault(x => x.idAccount == idAccount);
            string imgAccountOld = getOldNameImg.imgAccount.ToString();
            if (imgAccountOld.Equals("default-avatar.jpg") == false)
            {
                string filePath = MapPath("~/img/customer/" + imgAccountOld);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            //Tách lấy tên tập tin
            sTenFile = FileUpload1.FileName;
            //Thực hiện chép tập tin lên thư mục Upload
            FileUpload1.SaveAs(MapPath("~/img/customer/" + sTenFile));
            lblNotice.Text = "Đã upload thành công";
            User_Detail acc_detail = db.User_Detail.FirstOrDefault(x => x.idAccount == idAccount);
            acc_detail.imgAccount = sTenFile;
            db.SaveChanges();
            LoadData();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

        }
    }
}