<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="ibook.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div>
        <div class="flex fl-betwen">
            <div>
                <!--   <a class="p-2 clxamtim bg-xam" href="">Xem Thêm</a> -->
            </div>
        </div>
        <br>
        <div class="row">
            <asp:Repeater ID="rptBook" runat="server" >
                <ItemTemplate>
                    <div class="col-md-3">
                        <a href="">
                            <img id="img" width="150px" class="pic" src="<%# string.Format("img/comic/"+Eval("imgComic")) %>" alt="">
                            <div id="namecomic" class="fwb sitka black"><%# Eval("nameComic") %></div>
                        </a>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="js" runat="server">
</asp:Content>
