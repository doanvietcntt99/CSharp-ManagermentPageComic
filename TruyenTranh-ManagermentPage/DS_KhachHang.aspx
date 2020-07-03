<%@ Page Title="" Language="C#" MasterPageFile="~/ManagermentPage.Master" AutoEventWireup="true" CodeBehind="DS_KhachHang.aspx.cs" Inherits="TruyenTranh_ManagermentPage.DS_KhachHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>Quản Lý Khách hàng - Admin</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
     <div class="container-fluid">
        <!-- Page Heading -->
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Danh Sách Tài Khoản</h1>
            <asp:LinkButton runat="server" ID="btnThem" data-toggle="modal" data-target="#myModal" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i class="fas fa-download fa-sm text-white-50"></i>Tạo Mới Tài Khoản</asp:LinkButton>
            
        </div>
        <asp:GridView AutoGenerateColumns="false" runat="server" ID="dgvUser" CssClass="table table-hover">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="idAccount" />
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label runat="server">Username</asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# getusernameUser(Eval("idAccount")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Họ và Tên" DataField="fullname" />
                <asp:BoundField HeaderText="Ngày Sinh" DataField="DOB" DataFormatString="{0:MM/dd/yyyy}" />
                <asp:BoundField HeaderText="Địa Chỉ" DataField="Address" />
                <asp:BoundField HeaderText="Email" DataField="Email" />
                <asp:BoundField HeaderText="Trạng Thái" DataField="status" />
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:DataList ID="DataList1" runat="server"></asp:DataList>
                        <asp:Label runat="server">Chức năng</asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" CommandArgument='<%# Eval("idAccount") %>' OnCommand="btnSua_Command" ID="btnSua" Text="<i class='fas fa-user-edit'></i>" CssClass="btn btn-warning"></asp:LinkButton>
                        <asp:LinkButton runat="server" ID="btnXoa" Text="<i class='fas fa-trash-alt'></i>" CssClass="btn btn-danger" CommandArgument='<%# Eval("idAccount") %>' OnClientClick="return checkDelete()" OnCommand="btnXoa_Command"></asp:LinkButton>
                        <asp:LinkButton runat="server" ID="btnUpdateStatus" Text="<i class='far fa-bell-slash'></i>" CssClass="btn btn-secondary" CommandArgument='<%# Eval("idAccount") %>' OnClientClick="return checkStatus()" OnCommand="btnUpdateStatus_Command"></asp:LinkButton>
                        <asp:LinkButton runat="server" ID="btnResetPassword" Text="<i class='fas fa-sync-alt'></i>" CssClass="btn btn-success" CommandArgument='<%# Eval("idAccount") %>' OnClientClick="return checkPassword" OnCommand="btnResetPassword_Command"></asp:LinkButton>
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
                    <h4 class="modal-title">Tạo Tài Khoản</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <!-- Modal body -->
                <div class="modal-body">
                    <table class="table">
                        <tr>
                            <td class="cantrai">Tài Khoản: </td>
                            <td style="float: right;">
                                <asp:TextBox runat="server" ID="txtusername" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="cantrai">Mật Khẩu: </td>
                            <td style="float: right;">
                                <asp:TextBox runat="server" ID="txtpassword" TextMode="Password" CssClass="form-control"></asp:TextBox></td>

                        </tr>
                        <tr>
                            <td class="cantrai">Họ và Tên :</td>
                            <td style="float: right;">
                                <asp:TextBox runat="server" ID="txtFullname" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="cantrai">Ngày Sinh:</td>
                            <td style="float: right;">
                                <asp:TextBox runat="server" ID="txtDOB" TextMode="Date"  CssClass="form-control"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="cantrai">Địa Chỉ</td>
                            <td style="float: right;">
                                <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="cantrai">Email</td>
                            <td style="float: right;">
                                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                    </table>
                </div>

                <!-- Modal footer -->
                <div class="modal-footer">
                    <asp:Button ID="CreateUser" runat="server" OnClick="CreateUser_Click" Text="Create" CssClass="btn btn-success"></asp:Button>
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>

                </div>

            </div>
        </div>
    </div>


</asp:Content>
