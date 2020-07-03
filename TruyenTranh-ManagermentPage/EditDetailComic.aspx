<%@ Page Title="" Language="C#" MasterPageFile="~/ManagermentPage.Master" AutoEventWireup="true" CodeBehind="EditDetailComic.aspx.cs" Inherits="TruyenTranh_ManagermentPage.EditDetailComic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Chỉnh sửa Truyện - Admin</title>
    <style>
        .fakeimg {
            width: 300px;
            height: 300px;
            max-width: 100%;
            max-height: 100%;
        }

        .content {
            width: 200px;
            height: 300px;
        }

        .pic {
            object-fit: cover;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="container" style="margin-top: 30px">
        <div class="row">
            <div class="col-sm-4">
                <h2>Chi Tiết Truyện</h2>
                <h5>Avatar</h5>
                <div class="fakeimg text-center">
                    <asp:Image ID="img" runat="server" CssClass="fakeimg pic rounded-circle" ImageUrl="" />
                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control-file" />
                    <asp:Button ID="btnUpload" CssClass="btn btn-success" runat="server" Text="Tải Lên" OnClick="btnUpload_Click" />
                    <asp:Label ID="lblNotice" runat="server" Text=""></asp:Label>
                </div>
                <hr class="d-sm-none">
            </div>
            <div class="col-sm-8" style="margin-top: 60px">
                <div class="modal-body">
                    <table class="table">
                        <tr>
                            <td class="cantrai">ID Truyện:</td>
                            <td>
                                <asp:TextBox runat="server" ID="txtIdComic" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td class="cantrai">Tên Truyện: </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtnameComic" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="cantrai">Thể Loại Truyện:</td>
                            <td>
                                <asp:DropDownList runat="server" ID="cmbNameType" CssClass="form-control"></asp:DropDownList>
                        </tr>
                        <tr>
                            <td class="cantrai">Mô Tả:</td>
                            <td>
                                <asp:TextBox runat="server" ID="txtDecription" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="cantrai">Tác Giả:</td>
                            <td>
                                <asp:TextBox runat="server" ID="txtAuthor" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="cantrai">Người Đăng:</td>
                            <td>
                                <asp:TextBox runat="server" ID="txtPoster" CssClass="form-control" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>

                    </table>
                    <div class="modal-footer">
                        <asp:Button runat="server" ID="btnUpdateComicDetail" Text="Cập Nhật" CssClass="btn btn-success" OnCommand="btnUpdateComicDetail_Command" />
                        <asp:Button runat="server" ID="btnResetForm" Text="Làm Mới" CssClass="btn btn-secondary" OnCommand="btnResetForm_Command" />
                    </div>
                </div>
            </div>
        </div>
        <div class="container-fluid">
            <!-- Page Heading -->
            <div class="d-sm-flex align-items-center justify-content-between mb-4">
                <h1 class="h3 mb-0 text-gray-800">Danh Sách Chương</h1>
                <asp:LinkButton runat="server" ID="btnThem" data-toggle="modal" data-target="#myModal" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i class="fas fa-download fa-sm text-white-50"></i>Tạo Mới Chương</asp:LinkButton>
            </div>
            <asp:GridView AutoGenerateColumns="false" runat="server" ID="dgvChuong" CssClass="table table-hover">
                <Columns>
                    <asp:BoundField HeaderText="ID Chương" DataField="idChuong" />
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label runat="server">Tên Truyện</asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# getnameComic(Eval("idComic")) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Tên Chương" DataField="tenChuong" />
                    <asp:BoundField HeaderText="Trạng Thái" DataField="status" />
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label runat="server">Chức Năng</asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnEdit" runat="server" Text="Chỉnh Sửa" CommandArgument='<%# Eval("idChuong") %>' CssClass="btn btn-warning" OnCommand="btnEdit_Click"></asp:LinkButton>
                            <asp:LinkButton ID="btnDelete" runat="server" Text="Xóa" CommandArgument='<%# Eval("idChuong") %>' CssClass="btn btn-danger" OnCommand="btnDelete_Command"></asp:LinkButton>
                            <asp:LinkButton runat="server" ID="btnUpdateStatus" Text="Disable" CssClass="btn btn-secondary" CommandArgument='<%# Eval("idComic") %>' OnCommand="btnUpdateStatus_Command"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <!-- The Modal Create -->
        <div class="modal fade" id="myModal">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <!-- Modal Header -->
                    <div class="modal-header">
                        <h4 class="modal-title">Create New Account</h4>
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <!-- Modal body -->
                    <div class="modal-body">
                        <table class="table">
                            <tr>
                                <td class="cantrai">Tên Chương: </td>
                                <td style="float: right;">
                                    <asp:TextBox runat="server" ID="txtTenChuong" CssClass="form-control"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="cantrai">Nội dung </td>
                                <td style="float: right;">
                                    <asp:TextBox runat="server" ID="txtContent" CssClass="form-control" Rows="3"></asp:TextBox></td>
                            </tr>

                        </table>
                    </div>

                    <!-- Modal footer -->
                    <div class="modal-footer">
                        <asp:Button ID="CreateChuong" runat="server" OnClick="CreateChuong_Click" Text="Create" CssClass="btn btn-success"></asp:Button>
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>

                    </div>

                </div>
            </div>
        </div>
</asp:Content>
