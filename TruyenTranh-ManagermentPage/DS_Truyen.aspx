<%@ Page Title="" Language="C#" MasterPageFile="~/ManagermentPage.Master" AutoEventWireup="true" CodeBehind="DS_Truyen.aspx.cs" Inherits="TruyenTranh_ManagermentPage.DS_Truyen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Danh sách Truyện - Admin</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <div class="container-fluid">
        <!-- Page Heading -->
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Danh Sách Truyện</h1>
            <asp:LinkButton runat="server" ID="btnThem" data-toggle="modal" data-target="#myModal" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i class="fas fa-download fa-sm text-white-50"></i>Thêm Mới Truyện</asp:LinkButton>
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
                <asp:BoundField HeaderText="Mô Tả" DataField="decription" />
                <asp:BoundField HeaderText="Tác Giả" DataField="author" />
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label runat="server">Trạng Thái</asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# getStatus(Eval("idComic")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label runat="server">Chức Năng</asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="btnUpdateStatus" Text="<i class='far fa-bell-slash'></i>" CssClass="btn btn-secondary" CommandArgument='<%# Eval("idComic") %>' OnCommand="btnUpdateStatus_Command"></asp:LinkButton>
                        <asp:LinkButton runat="server" ID="btnDeleteComic" Text="<i class='fas fa-trash-alt'></i>" CssClass="btn btn-danger" CommandArgument='<%# Eval("idComic") %>' OnCommand="btnDeleteComic_Command"></asp:LinkButton>
                        <asp:LinkButton runat="server" ID="btnChiTiet" Text="<i class='fas fa-info-circle'></i>" CssClass="btn btn-primary" CommandArgument='<%# Eval("idComic") %>' OnCommand="btnChiTiet_Command"></asp:LinkButton>
                    </ItemTemplate>

                </asp:TemplateField>

            </Columns>
        </asp:GridView>
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
                        <asp:Button ID="CreateAccount" runat="server" OnClick="CreateAccount_Click" Text="Tạo Mới" CssClass="btn btn-success"></asp:Button>
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Đóng</button>

                    </div>

                </div>
            </div>
        </div>
</asp:Content>
