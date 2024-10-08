<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="QuanLiBiDa_Web.Account" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

       <main id="main">
                <!-- Hero area of the page -->
                <section class="hero-area text-center" >
               <div class="container">
        <div class="section-bg-color">
            <div class="row">
                <div class="col-lg-12">
                    <!-- My Account Page Start -->
                    <div class="myaccount-page-wrapper">
                        <!-- My Account Tab Menu Start -->
                        <div class="row">
                            <div class="col-lg-3 col-md-4">
                                <div class="myaccount-tab-menu nav" role="tablist">
                                    <a href="#account-info" data-toggle="tab" class="show active">
                                        <i class="fa fa-user"></i> Account
                                        Thông tin cá nhân
                                    </a>
                                    <a href="#orders" data-toggle="tab" class="show">
                                        <i class="fa fa-cart-arrow-down"></i>
                                        Quản lí đặt bàn
                                    </a>

                                    
                                    <a href="Logout.aspx"><i class="fa fa-sign-out"></i>Logout</a>
                                </div>
                            </div>
                            <!-- My Account Tab Menu End -->
                            <!-- My Account Tab Content Start -->
                            <div class="col-lg-9 col-md-8">
                                <div class="tab-content" id="myaccountContent">
                                    <!-- Single Tab Content Start -->
                                   
                                    <!-- Single Tab Content End -->
                                    <!-- Single Tab Content Start -->
                                    <div class="tab-pane fade" id="orders" role="tabpanel">
                                        <div class="myaccount-content" style="min-height: 381px;">
                                            <h3>Orders</h3>
                                            <div class="myaccount-table table-responsive text-center">
                                                 <asp:DataList ID="dlLichSuDatBan" runat="server" RepeatColumns="1">
                            <HeaderTemplate>
                                <div class="table-responsive">
                                    <table class="table table-striped">
                                        <thead class="thead-light">
                                            <tr>
                                                <th>Mã bàn</th>
                                                <th>Tên bàn</th>
                                                <th>Mã khu vực</th>
                                                <th>Trạng thái</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                            </HeaderTemplate>

                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("MaBan") %></td>
                                    <td><%# Eval("TenBan") %></td>
                                    <td><%# Eval("MaKV") %></td>
                                    <td><%# Eval("TrangThai") %></td>
                                </tr>
                            </ItemTemplate>

                            <FooterTemplate>
                                        </tbody>
                                    </table>
                                </div>
                            </FooterTemplate>
                        </asp:DataList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="tab-pane fade active show" id="account-info" role="tabpanel">
                                        <div class="myaccount-content">                                     
                                            <div class="account-details-form" style="height:690px">
                                                <h3>Thông tin cá nhân</h3>
                                                <asp:Label runat="server" ID="lblMessage" ForeColor="Red" />
                                                <div class="form-group">
                                                    <label for="inputTenKH">Tên khách hàng:</label>
                                                    <asp:TextBox ID="inputTenKH" runat="server" CssClass="form-control" />
                                                </div>
                                                <div class="form-group">
                                                    <label for="inputSDT">Số điện thoại:</label>
                                                    <asp:TextBox ID="inputSDT" runat="server" CssClass="form-control" TextMode="Phone" />
                                                </div>
                                                <div class="form-group">
                                                    <label for="inputMatKhau">Mật khẩu:</label>
                                                    <asp:TextBox ID="inputMatKhau" runat="server" CssClass="form-control" TextMode="Password" />
                                                </div>
                                                <asp:Button ID="btnCapNhat" runat="server" CssClass="btn btn-primary" Text="Cập nhật thông tin" OnClick="btnCapNhat_Click" />
                                            </div>
                                        </div>
                                    </div> <!-- Single Tab Content End -->
                                </div>
                            </div> <!-- My Account Tab Content End -->
                        </div>
                    </div> <!-- My Account Page End -->
                </div>
            </div>
        </div>
    </div>
                </section>
           </main>
    
</asp:Content>

