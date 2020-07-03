<%@ Page Title="" Language="C#" MasterPageFile="~/ManagermentPage.Master" AutoEventWireup="true" CodeBehind="EditAccount.aspx.cs" Inherits="TruyenTranh_ManagermentPage.EditAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Chỉnh sửa Tài Khoản - Admin</title>
    <style>
        .fakeimg {
            width: 250px;
            height: 300px;
            max-width: 100%;
            max-height: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <div class="container" style="margin-top: 30px">
        <div class="row">
            <div class="col-sm-4">
                <h2>Profile</h2>
                <h5>Photos</h5>
                <div class="fakeimg text-center">
                    <asp:Image ID="img" runat="server" CssClass="fakeimg" ImageUrl="img/account/65421830_2311443385780433_5468278071217881088_n.jpg" />
                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control-file" />
                    <asp:Button ID="btnUpload" CssClass="btn btn-success" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                    <asp:Label ID="lblNotice" runat="server" Text=""></asp:Label>
                </div>

                <hr class="d-sm-none">
            </div>
            <div class="col-sm-8" style="margin-top: 80px;">
                <div class="modal-body">
                    <table class="table">
                        <tr>
                            <td class="cantrai">Username: </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtusername" Enabled="false" CssClass="form-control"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td class="cantrai">Họ và Tên :</td>
                            <td>
                                <asp:TextBox runat="server" ID="txtFullname" CssClass="form-control"></asp:TextBox></td>
                            
                        </tr>
                        <tr>
                            <td class="cantrai">Ngày Sinh:</td>
                            <td>
                                <asp:TextBox runat="server" TextMode="Date" ID="txtDOB" CssClass="form-control" ></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="cantrai">Địa Chỉ</td>
                            <td>
                                <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="cantrai">Email</td>
                            <td>
                                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                    </table>
                </div>

                <!-- Modal footer -->
                <div class="modal-footer">
                    <asp:Button ID="btnEditAccount" runat="server" OnClick="btnEditAccount_Click" Text="Cập Nhật" CssClass="btn btn-success"></asp:Button>
                </div>
            </div>
            <div class="container-fluid">
                <!-- Page Heading -->
                <div class="d-sm-flex align-items-center justify-content-between mb-4">
                    <h1 class="h3 mb-0 text-gray-800">Danh Sách Chương Đã Đăng</h1>
                    <asp:LinkButton runat="server" ID="btnThem" data-toggle="modal" data-target="#myModal" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i class="fas fa-download fa-sm text-white-50"></i>Tạo Mới Chương</asp:LinkButton>
                </div>
                <asp:GridView AutoGenerateColumns="false" runat="server" ID="dgvComic" CssClass="table table-hover">
                    <Columns>
                        <asp:BoundField HeaderText="ID Truyện" DataField="idComic" />
                        <asp:BoundField HeaderText="Tên Truyện" DataField="nameComic" />
                        <asp:BoundField HeaderText="Thể Loại Truyện" DataField="idTypeComic" />
                        <asp:BoundField HeaderText="Mô Tả Truyện" DataField="decription" />
                        <asp:BoundField HeaderText="Tác Giả Truyện" DataField="author" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
