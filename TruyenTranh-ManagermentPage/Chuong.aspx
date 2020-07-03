<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Chuong.aspx.cs" Inherits="ibook.Chuong1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="robo mt-3">
        <asp:Repeater ID="rptBook" runat="server">
            <ItemTemplate>
                <div class="text-center">
                    <p><%# Eval("tenChuong") %></p>

                </div>
                <hr>
                <div>
                    <%# Eval("content") %>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="js" runat="server">
</asp:Content>
