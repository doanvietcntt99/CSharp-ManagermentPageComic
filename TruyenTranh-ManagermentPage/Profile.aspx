<%@ Page Title="" Language="C#" MasterPageFile="~/ManagermentPage.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="TruyenTranh_ManagermentPage.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Profile - Managerment Page
    </title>
    <style>
        .fakeimg {
            margin: 0 auto;
            width: 300px;
            height: 300px;
            max-width: 100%;
            max-height: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="container" style="margin-top: 30px">
        <center><asp:Label ID="lbError" runat="server"></asp:Label></center>
        <div class="row">
            <div class="col-sm-4">
                <h2>Profile</h2>
                <h5>Photos</h5>
                <div class="fakeimg text-center">
                    <asp:Image ID="img" runat="server" CssClass="fakeimg pic rounded-circle" ImageUrl="img/account/65421830_2311443385780433_5468278071217881088_n.jpg" />
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
                                <asp:TextBox runat="server" ID="txtDOB" TextMode="Date" CssClass="form-control"></asp:TextBox></td>
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
                <div class="modal-footer">
                    <asp:LinkButton ID="btnUpdatePassword" runat="server" Text="Đổi Mật Khẩu" CssClass="btn btn-success" data-toggle="modal" data-target="#ModelUpdatePassword"></asp:LinkButton>
                    <asp:Button ID="btnUpdate" runat="server" Text="Cập Nhật" OnClick="btnUpdate_Click" CssClass="btn btn-success"></asp:Button>
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
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label runat="server">Thể Loại Truyện</asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# getnameTypeComic(Eval("idTypeComic")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Mô Tả Truyện" DataField="decription" />
                        <asp:BoundField HeaderText="Tác Giả Truyện" DataField="author" />
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label runat="server">Trạng Thái</asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# getStatus(Eval("idComic")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>Chức Năng</HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="btnDetailComic" Text="<i class='fas fa-user-edit'></i>" CssClass="btn btn-primary" CommandArgument='<%# Eval("idComic") %>' OnCommand="btnDetailComic_Command">
                                </asp:LinkButton>
                                <asp:LinkButton runat="server" ID="btnUpdateStatus" Text="<i class='far fa-bell-slash'></i>" CssClass="btn btn-secondary" CommandArgument='<%# Eval("idComic") %>' OnCommand="btnUpdateStatus_Command">

                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <!-- The Modal Create -->
    <div class="modal fade" id="ModelUpdatePassword">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Đổi Mật Khẩu</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <!-- Modal body -->
                <div class="modal-body">
                    <table class="table">
                        <tr>
                            <td class="cantrai">Tài Khoản: </td>
                            <td style="float: right;">
                                <asp:TextBox runat="server" ID="txtusernamemodel" CssClass="form-control" Enabled="false"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="cantrai">Mật Khẩu cũ: </td>
                            <td style="float: right;">
                                <asp:TextBox runat="server" ID="txtoldpasswordmodel" TextMode="Password" CssClass="form-control"></asp:TextBox></td>

                        </tr>
                        <tr>
                            <td class="cantrai">Mật Khẩu mới: </td>
                            <td style="float: right;">
                                <asp:TextBox runat="server" ID="txtnewpasswordmodel" TextMode="Password" CssClass="form-control"></asp:TextBox></td>

                        </tr>
                        <tr>
                            <td class="cantrai">Nhập lại Mật Khẩu mới: </td>
                            <td style="float: right;">
                                <asp:TextBox runat="server" ID="txtrenewpasswordmodel" TextMode="Password" CssClass="form-control"></asp:TextBox></td>
                        </tr>


                    </table>
                </div>

                <!-- Modal footer -->
                <div class="modal-footer">
                    <asp:Button ID="btnSubmitUpdatePassword" runat="server" OnClick="btnSubmitUpdatePassword_Click" Text="Update" CssClass="btn btn-success"></asp:Button>
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>

                </div>

            </div>
        </div>
    </div>
    <!-- The Modal Create -->
    <div class="modal fade" id="myModal">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Tạo Mới Truyện</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <!-- Modal body -->
                <div class="modal-body">
                    <table class="table">
                        <tr>
                            <td class="cantrai">Tên Truyện: </td>
                            <td style="float: right;">
                                <asp:TextBox runat="server" ID="txtNameComic" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="cantrai">Loại Truyện:</td>
                            <td>
                                <asp:DropDownList runat="server" ID="cmbNameType" CssClass="form-control"></asp:DropDownList>
                        </tr>
                        <tr>
                            <td class="cantrai">Mô Tả:</td>
                            <td style="float: right;">
                                <asp:TextBox runat="server" ID="txtDecription" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="cantrai">Tác Giả:</td>
                            <td style="float: right;">
                                <asp:TextBox runat="server" ID="txtAuthor" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                    </table>
                </div>

                <!-- Modal footer -->
                <div class="modal-footer">
                    <asp:Button ID="CreateComic" runat="server" OnClick="CreateComic_Click" Text="Tạo Mới" CssClass="btn btn-success"></asp:Button>
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Đóng</button>

                </div>

            </div>
        </div>
    </div>
</asp:Content>
