using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.IO;


namespace TruyenTranh_ManagermentPage
{
    public partial class Profile : System.Web.UI.Page
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
            int idAccount = Convert.ToInt32(Request.Params["idAccount"].ToString());
            Managerment_PageEntities db = new Managerment_PageEntities();
            Account acc = db.Accounts.FirstOrDefault(x => x.idAccount == idAccount);
            Account_Detail acc_detail = db.Account_Detail.FirstOrDefault(x => x.idAccount == idAccount);
            txtusername.Text = acc.username;
            txtusernamemodel.Text = acc.username;
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
            getNameListTypeComic();
            

        }

        protected void btnSubmitUpdatePassword_Click(object sender, EventArgs e)
        {
            string taikhoan = txtusernamemodel.Text;
            string matkhaucu = getMd5Hash(txtoldpasswordmodel.Text);
            string matkhaumoi = txtnewpasswordmodel.Text;
            string rematkhaumoi = txtrenewpasswordmodel.Text;
            Managerment_PageEntities db = new Managerment_PageEntities();
            Account acc = db.Accounts.FirstOrDefault(x => x.username == taikhoan);
            if (matkhaucu.Equals(acc.password.ToString()))
            {
                if (matkhaumoi.Equals(rematkhaumoi))
                {
                    acc.password = getMd5Hash(matkhaumoi);
                    db.SaveChanges();
                    lbError.Text = "Đổi mật khẩu thành công!";
                    XoaThongTinModel();
                }
                else
                {
                    lbError.Text = "Mật khẩu mới không khớp nhau!";
                    XoaThongTinModel();
                }
            }
            else
            {
                lbError.Text = "Mật khẩu cũ không đúng!"; 
                XoaThongTinModel();
            }
        }
        void XoaThongTinModel()
        {
            txtoldpasswordmodel.Text = "";
            txtnewpasswordmodel.Text = "";
            txtrenewpasswordmodel.Text = "";
        }
        static string getMd5Hash(string input)
        { // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create(); // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            // Create a new Stringbuilder to collect the bytes // and create a string.
            StringBuilder sBuilder = new StringBuilder(); // Loop through each byte of the hashed data // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
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
                lbError.Text = "Cập nhật thành công!";
                LoadData();
            }
            catch
            {
                lbError.Text = "Cập nhật thất bại!";
            }
        }


        protected void CreateComic_Click(object sender, EventArgs e)
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
        public void getNameListTypeComic()
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

        protected void btnDetailComic_Command(object sender, CommandEventArgs e)
        {
            int idComic = int.Parse(e.CommandArgument.ToString());
            string url = "EditDetailComic.aspx?idComic=" + idComic;
            Response.Redirect(url);
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
        public string getStatus (object idComic)
        {
            try
            {
                Managerment_PageEntities db = new Managerment_PageEntities();
                Comic obj = db.Comics.FirstOrDefault(x => x.idComic.ToString() == idComic.ToString());
                if (obj.status == true)
                {
                    return "Kích Hoạt";
                }
                else
                {
                    return "Vô Hiệu Hóa";
                }
            }
            catch
            {
                return "";
            }
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
            LoadData();
        }
    }
}