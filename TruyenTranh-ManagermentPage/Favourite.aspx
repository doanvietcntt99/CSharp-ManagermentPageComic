<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Favourite.aspx.cs" Inherits="TruyenTranh_ManagermentPage.Favourite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <p class="fs20 font-weight-bold robo"> Danh sách Yêu thích </p>
    <asp:GridView AutoGenerateColumns="false" runat="server" ID="dgvFavouriteComic" CssClass="table table-hover">
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
            <asp:BoundField HeaderText="Mô Tả" DataField="imgComic" />
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label runat="server">Ảnh Bìa</asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Image runat="server" ImageUrl='<%# getURLAvatar(Eval("idComic")) %>' Width="150px" Height= "150px" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Tác Giả" DataField="author" />
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label runat="server">Chức Năng</asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="btnDeleteFavouriteComic" Text="<i class='fas fa-trash-alt'></i>" CssClass="btn btn-danger" CommandArgument='<%# Eval("idComic") %>' OnCommand="btnDeleteFavouriteComic_Command"></asp:LinkButton>
                    <asp:LinkButton runat="server" ID="btnChiTiet" Text="<i class='fas fa-info-circle'></i>" CssClass="btn btn-primary" CommandArgument='<%# Eval("idComic") %>' OnCommand="btnChiTiet_Command"></asp:LinkButton>
                </ItemTemplate>

            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="js" runat="server">
</asp:Content>
