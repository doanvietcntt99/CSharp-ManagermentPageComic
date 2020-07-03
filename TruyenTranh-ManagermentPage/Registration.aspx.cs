﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Threading;
using System.Globalization;

namespace TruyenTranh_ManagermentPage
{
    public partial class Registration : System.Web.UI.Page
    {
        protected override void InitializeCulture()
        {
            string ui = Request.QueryString["lancode"];
            if (string.IsNullOrEmpty(ui))
                ui = "vi";
            string culture = ui == "en" ? "en-us" : ui + "-" + "VN";
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
            base.InitializeCulture();
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lbThongBao.Visible = false;
        }
        protected void btDangKy_Click(object sender, EventArgs e)
        {
            string gioitinh = "";
            if (rbNam.Checked) gioitinh = "Nam";
            else gioitinh = "Nữ";
            
        }
    }
}