<%@ Page Title="" Language="C#" MasterPageFile="~/ManagermentPage.Master" AutoEventWireup="true" CodeBehind="EditChuong.aspx.cs" Inherits="TruyenTranh_ManagermentPage.EditChuong" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Chỉnh sửa Chương - Admin</title>
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
        <div class="row">
            <div class="col-sm-12 text-center" style="margin: 0 auto;">
                <h2>Chi Tiết Nội Dung Chương</h2>
                <asp:Label runat="server" ForeColor="Red" ID="Status"></asp:Label>
                <hr class="d-sm-none">
            </div>
            <div class="col-sm-12" style="margin-top: 100px">
                <div class="modal-body">
                    <table class="table">
                        <tr>
                            <td class="cantrai">
                                <h1 class="h3 mb-0 text-gray-800">Tên Chương:</h1>
                            </td>
                            <td>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtTenChuong" Enabled="true"></asp:TextBox></td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="container-fluid">
            <!-- Page Heading -->
            <div class="d-sm-flex align-items-center justify-content-between mb-4">
                <h1 class="h3 mb-0 text-gray-800">Nội Dung:</h1>
            </div>
            <asp:TextBox ID="txtContent" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="10"></asp:TextBox>
            <!-- Modal footer -->
            <div class="modal-footer">
                <asp:Button ID="btnSaveContent" runat="server" CommandArgument='<%# Eval("idChuong") %>' OnClick="btnSaveContent_Click" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" Text="Upload" />
                <asp:Button ID="btnResetContent" runat="server" OnClick="btnResetContent_Click" CssClass="d-none d-sm-inline-block btn btn-sm btn-secondary shadow-sm" Text="Reset" />
            </div>

        </div>
</asp:Content>
