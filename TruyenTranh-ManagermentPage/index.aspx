<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ibook.index1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
            
            <div>
                <div class="flex fl-betwen">
                    <div class="fs25 fwb mt--15 ">Hot</div>
                    <div>
                        <!--   <a class="p-2 clxamtim bg-xam" href="">Xem Thêm</a> -->
                    </div>
                </div>
                <br>
                <div class="row">
                    <asp:Repeater ID="rptBook" runat="server" DataSourceID="dtsBook">
                        <ItemTemplate>
                            <div class="col-md-3">
                                <a href="<%# string.Format("Detail.aspx?idComic="+ Eval("idComic")) %>" >
                                    <img width="150px" class="pic" src="<%# string.Format("img/comic/"+Eval("imgComic")) %>" alt="">
                                    <div class="fwb sitka black"><%# Eval("nameComic") %></div>
                                </a>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:SqlDataSource ID="dtsBook" runat="server" ConnectionString="<%$ ConnectionStrings:Managerment_PageConnectionString %>" SelectCommand="SELECT * FROM [Comic]"></asp:SqlDataSource>
                </div>
            </div>
            <!-- <br>
            <br>
            <div>
                <div class="flex fl-betwen">
                    <div class="fs25 fwb mt--15 ">
                        Best Seller
                    <div>
                        <a class="p-2 clxamtim bg-xam" href="">Xem Thêm</a>
                    </div>
                    </div>
                    <br>
                    <div class="row">
                        <div class="col-md-3">
                            <a href="">
                                <img width="150px" class="pic" src="./img/Intersection 2.png" alt="">
                                <div class="fwb sitka black">Khi người ta tư duy</div>
                            </a>
                        </div>
                        <div class="col-md-3">
                            <a href="">
                                <img width="150px" class="pic" src="./img/Intersection 2.png" alt="">
                                <div class="fwb sitka black">Khi người ta tư duy</div>
                            </a>
                        </div>
                        <div class="col-md-3">
                            <a href="">
                                <img width="150px" class="pic" src="./img/Intersection 2.png" alt="">
                                <div class="fwb sitka black">Khi người ta tư duy</div>
                            </a>
                        </div>
                        <div class="col-md-3">
                            <a href="">
                                <img width="150px" class="pic" src="./img/Intersection 2.png" alt="">
                                <div class="fwb sitka black">Khi người ta tư duy</div>
                            </a>
                        </div>

                    </div>
                </div>
                <br>
                <br>
                <div>
                    <div class="flex fl-betwen">
                        <div class="fs25 fwb mt--15 ">New</div>
                        <div>
                            <a class="p-2 clxamtim bg-xam" href="">Xem Thêm</a>
                        </div>
                    </div>
                    <br>
                    <div class="row">
                        <div class="col-md-3">
                            <a href="">
                                <img width="150px" class="pic" src="./img/Intersection 2.png" alt="">
                                <div class="fwb sitka black">Khi người ta tư duy</div>
                            </a>
                        </div>
                        <div class="col-md-3">
                            <a href="">
                                <img width="150px" class="pic" src="./img/Intersection 2.png" alt="">
                                <div class="fwb sitka black">Khi người ta tư duy</div>
                            </a>
                        </div>
                        <div class="col-md-3">
                            <a href="">
                                <img width="150px" class="pic" src="./img/Intersection 2.png" alt="">
                                <div class="fwb sitka black">Khi người ta tư duy</div>
                            </a>
                        </div>
                        <div class="col-md-3">
                            <a href="">
                                <img width="150px" class="pic" src="./img/Intersection 2.png" alt="">
                                <div class="fwb sitka black">Khi người ta tư duy</div>
                            </a>
                        </div>

                    </div>
                </div> -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="js" runat="server">
</asp:Content>
