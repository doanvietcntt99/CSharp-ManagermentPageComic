<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="ibook.Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="robo mt-3">
        <div class="row">
            <asp:Repeater ID="rptBook" runat="server">
                <ItemTemplate>
                    <div class="col-md-6 text-right">
                        <img src="<%# string.Format("img/comic/"+Eval("imgComic")) %>" class="pic" width="250rem" alt="">
                    </div>
                    <div class="col-md-6 text-left">
                        <p class="fs20 font-weight-bold"><%# Eval("nameComic") %></p>
                        <p>
                            <asp:LinkButton runat="server" ID="btnYeuThich" Text="Yêu Thích" CssClass="btn btn-secondary" OnCommand="btnYeuThich_Command1"></asp:LinkButton>
                            <asp:Label runat="server" ID="txtThongBao" Text="" ForeColor="Red"></asp:Label>
                        </p>
                        <p>Tác giả: <%# Eval("author") %></p>
                        <div>
                            <%# Eval("decription") %>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <br />
        <br />
        <div class="text-left">
            <div class="fs20 font-weight-bold">Danh sách chương</div>
            <div>
                <table class="table">
                    <thead>
                        <tr>
                            <th scope="col">Lời tựa</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptchuong" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <a href="<%# string.Format("Chuong.aspx?idChuong="+ Eval("idChuong")) %>">
                                            <%# Eval("tenChuong") %>
                                        </a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="js" runat="server">
</asp:Content>
