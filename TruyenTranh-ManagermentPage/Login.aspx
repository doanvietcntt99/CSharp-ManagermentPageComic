<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TruyenTranh_ManagermentPage.Login1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form class="login100-form validate-form" runat="server">
        <span class="login100-form-title">LOGIN
        </span>

        <div class="wrap-input100 validate-input" data-validate="Mật khẩu có dạng: ex@abc.xyz">

            <asp:TextBox runat="server" CssClass="input100" ID="txtusername" placeholder="Tài Khoản"></asp:TextBox>
            <span class="focus-input100"></span>
            <span class="symbol-input100">
                <i class="fa fa-envelope" aria-hidden="true"></i>
            </span>
        </div>

        <div class="wrap-input100 validate-input" data-validate="Password is required">
            <asp:TextBox runat="server" CssClass="input100" ID="txtpassword" TextMode="Password" placeholder="Mật Khẩu"></asp:TextBox>
            <span class="focus-input100"></span>
            <span class="symbol-input100">
                <i class="fa fa-lock" aria-hidden="true"></i>
            </span>
        </div>

        <div class="container-login100-form-btn">
            <asp:Button runat="server" CssClass="login100-form-btn" ID="btnLogin" OnClick="btnLogin_Click" Text="ĐĂNG NHẬP" />
        </div>

        <div class="text-center p-t-12">
            <span class="txt1">Quên 
            </span>
            <a class="txt2" href="#">Tài Khoản / Mật Khẩu?
            </a>
        </div>
        <div class="text-center p-t-12">
        <asp:Label runat="server"  ID="txtError" ForeColor="Red" Text=""></asp:Label>
            </div>
        <div class="text-center p-t-136">
            <a class="txt2" href="#">Tạo Tài Khoản 
							<i class="fa fa-long-arrow-right m-l-5" aria-hidden="true"></i>
            </a>
        </div>
    </form>
</asp:Content>
