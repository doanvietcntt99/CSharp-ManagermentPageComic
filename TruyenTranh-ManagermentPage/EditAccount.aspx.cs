using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TruyenTranh_ManagermentPage
{
    public partial class EditAccount : System.Web.UI.Page
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
            int idAccount = Convert.ToInt32(Request.Params["idAccount"].ToString());
            Managerment_PageEntities db = new Managerment_PageEntities();
            Account acc = db.Accounts.FirstOrDefault(x => x.idAccount == idAccount);
            Account_Detail acc_detail = db.Account_Detail.FirstOrDefault(x => x.idAccount == idAccount);
            txtusername.Text = acc.username;
            txtFullname.Text = acc_detail.fullname;
            DateTime date = Convert.ToDateTime(acc_detail.DOB);
            string formatted = date.ToString("yyyy-MM-dd");
            txtDOB.Text = formatted;
            txtAddress.Text = acc_detail.Address;
            txtEmail.Text = acc_detail.Email;
            img.ImageUrl = "img/account/" + acc_detail.imgAccount;
            List<Comic> listComic = db.Comics.Where(x => x.idAccount == idAccount).ToList();
            dgvComic.DataSource = listComic;
            dgvComic.DataBind();
        }
        protected void btnEditAccount_Click(object sender, EventArgs e)
        {
            int idAccount = Convert.ToInt32(Request.Params["idAccount"].ToString());
            string fullname = txtFullname.Text;
            string DOB = txtDOB.Text;
            string Address = txtAddress.Text;
            string Email = txtEmail.Text;
            Managerment_PageEntities db = new Managerment_PageEntities();
            Account_Detail acc_detail = db.Account_Detail.FirstOrDefault(x => x.idAccount == idAccount);
            acc_detail.fullname = fullname;
            acc_detail.DOB = Convert.ToDateTime(DOB);
            acc_detail.Address = Address;
            acc_detail.Email = Email;
            db.SaveChanges();
            lblNotice.Text = "Đã Cập nhật thông tin thành công!";
            GetData();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            Managerment_PageEntities db = new Managerment_PageEntities();
            string sTenFile;
            int idAccount = Convert.ToInt32(Request.Params["idAccount"].ToString());
            Account_Detail getOldNameImg = db.Account_Detail.FirstOrDefault(x => x.idAccount == idAccount);
            string imgAccountOld = getOldNameImg.imgAccount.ToString();
            if (imgAccountOld.Equals("default-avatar.jpg") == false)
            {
                string filePath = MapPath("~/img/account/" + imgAccountOld);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            //Tách lấy tên tập tin
            sTenFile = FileUpload1.FileName;
            //Thực hiện chép tập tin lên thư mục Upload
            FileUpload1.SaveAs(MapPath("~/img/account/" + sTenFile));
            lblNotice.Text = "Đã upload thành công";

            Account_Detail acc_detail = db.Account_Detail.FirstOrDefault(x => x.idAccount == idAccount);
            acc_detail.imgAccount = sTenFile;
            db.SaveChanges();
            GetData();
        }


    }
}