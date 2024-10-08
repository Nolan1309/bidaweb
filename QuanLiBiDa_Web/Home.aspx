<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="QuanLiBiDa_Web.Home" MaintainScrollPositionOnPostBack="true" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      <main id="main">
                <!-- Hero area of the page -->
                <section class="hero-area text-center" style="background-image:url('/Content/assets/images/home.png'); " data-scroll-index="0">
                    <div class="container">
                        <div class="row">
                            <header class="heading-holder col-xs-12 col-sm-10 col-sm-offset-1 col-md-8 col-md-offset-2 col-lg-6 col-lg-offset-3">
                              <h1>Trải nghiệm Bida đỉnh cao ngay hôm nay!</h1>
                            <p>Thư giãn và tận hưởng những phút giây giải trí tại quán bida của chúng tôi. Với không gian hiện đại, phục vụ tận tình, và các bàn bida đạt chuẩn, chúng tôi mang đến cho bạn trải nghiệm giải trí đỉnh cao.</p>

                            </header>
                        </div>
                        <div class="aligncenter">
                            <img src="/Content/assets/images/cyber.png" alt="image description" class="img-responsive">
                        </div>
                    </div>
                </section>
                <!-- Features area of the page -->
                   <section class="features-area container" data-scroll-index="1">
                    <div class="row">
                        <header class="col-xs-12 heading-wrap col-sm-6 col-sm-offset-3 text-center">
                            <h2>Trải nghiệm dịch vụ <br>tốt nhất tại quán <span class="text-bright">Bida của chúng tôi!</span></h2>
                        </header>
                    </div>
                    <ul class="features-list">
                        <li>
                            <div class="icon-holder">
                                <img src="/Content/assets/images/id-card.svg" width="54" height="52" alt="icon id-card" class="img-responsive">
                            </div>
                            <h3><a href="#">Thành viên ưu đãi</a></h3>
                            <p>Tham gia câu lạc bộ thành viên để nhận được nhiều ưu đãi hấp dẫn và giảm giá đặc biệt.</p>
                        </li>
                        <li>
                            <div class="icon-holder">
                                <img src="/Content/assets/images/clock.svg" width="56" height="50" alt="icon clock" class="img-responsive">
                            </div>
                            <h3><a href="#">Mở cửa 24/7</a></h3>
                            <p>Chúng tôi luôn sẵn sàng phục vụ bạn bất kể ngày hay đêm, mọi lúc bạn cần một nơi để thư giãn.</p>
                        </li>
                        <li>
                            <div class="icon-holder">
                                <img src="/Content/assets/images/notes.svg" width="51" height="45" alt="icon notes" class="img-responsive">
                            </div>
                            <h3><a href="#">Sân chơi đa dạng</a></h3>
                            <p>Hệ thống bàn bida đạt chuẩn với các loại bàn chơi khác nhau, phù hợp cho mọi trình độ.</p>
                        </li>
                        <li>
                            <div class="icon-holder">
                                <img src="/Content/assets/images/calculator.svg" width="52" height="60" alt="icon calculator" class="img-responsive">
                            </div>
                            <h3><a href="#">Giá cả hợp lý</a></h3>
                            <p>Chúng tôi cung cấp dịch vụ với giá cả cạnh tranh, phù hợp với tất cả khách hàng.</p>
                        </li>
                        <li>
                            <div class="icon-holder">
                                <img src="/Content/assets/images/cleaning.png" width="37" height="51" alt="icon cleaning" class="img-responsive">
                            </div>
                            <h3><a href="#">Không gian sạch sẽ</a></h3>
                            <p>Không gian luôn được vệ sinh sạch sẽ, đảm bảo sự thoải mái và an toàn cho khách hàng.</p>
                        </li>
                        <li>
                            <div class="icon-holder">
                                <img src="/Content/assets/images/calendar.svg" width="49" height="51" alt="icon calendar" class="img-responsive">
                            </div>
                            <h3><a href="#">Sự kiện và giải đấu</a></h3>
                            <p>Thường xuyên tổ chức các giải đấu và sự kiện thú vị, tạo cơ hội giao lưu và thể hiện tài năng.</p>
                        </li>
                    </ul>
                </section>

                <!-- Product Features of the page -->
                <section class="container product-features" data-scroll-index="2">
                    <div class="row sameheight-container">
                        <div class="col-xs-12 col-sm-6 descr sameheight">
                            <div class="align">
                                <h2>Thời gian mở cửa</h2>
                                <p>Quán bida của chúng tôi luôn sẵn sàng chào đón bạn suốt 24/7. Bạn có thể đến thư giãn và chơi bida vào bất kỳ thời điểm nào trong ngày, dù là sáng sớm hay tối muộn. Chúng tôi cam kết mang đến cho bạn trải nghiệm giải trí tuyệt vời nhất mọi lúc.</p>
                                <ul class="facts-list">
                                    <li>
                                        <h3><span class="counter">24</span><span class="text-block">Giờ mở cửa mỗi ngày</span></h3>
                                    </li>
                                    <li>
                                        <h3>7<span class="text-block">Ngày trong tuần</span></h3>
                                    </li>
                                    <li>
                                        <h3>365<span class="text-block">Ngày mỗi năm</span></h3>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div class="img-holder sameheight col-xs-12 col-sm-6">
                            <img src="/Content/assets/images/open.jpg" alt="Quán mở cửa 24/7" class="img-responsive">
                        </div>
                    </div>
                </section>

               
                <!-- Price offers of the page -->
                 <section class="container price-offers" data-scroll-index="4">
                    <div class="row">
                        <header class="col-xs-12 heading-wrap col-sm-6 col-sm-offset-3 text-center">
                            <h2>Chọn khu vực chơi <span class="text-bright">phù hợp với bạn</span>, <br>với giá cả hợp lý.</h2>
                        </header>
                    </div>
                    <div class="cols-holder">
                        <div class="price-col text-center col-xs-12 col-sm-6 col-md-4">
                            <strong class="title">Khu A</strong>
                            <div class="offer-heading">
                                <h3>80,000<span class="text-light"> VND/giờ</span><span class="subtitle">Không gian rộng rãi, thoải mái</span></h3>
                            </div>
                            <ul>
                                <li class="check"><span>Loại bàn lỗ</span></li>
                                <li class="check"><span>Bàn chuẩn quốc tế</span></li>
                                <li class="check"><span>Phục vụ tại chỗ</span></li>
                                <li class="un-check"><span>Khu vực riêng biệt</span></li>
                                <li class="check"><span>Wifi miễn phí</span></li>
                            </ul>
                            <a href="#" class="btn btn-info">Đặt bàn ngay</a>
                        </div>
                        <div class="price-col text-center col-xs-12 col-sm-6 col-md-4">
                            <strong class="title">Khu B</strong>
                            <div class="offer-heading">
                                <h3>100,000<span class="text-light"> VND/giờ</span><span class="subtitle">Không gian tiêu chuẩn, điều hòa</span></h3>
                            </div>
                            <ul>
                                <li class="check"><span>Loại bàn lỗ</span></li>
                                <li class="check"><span>Bàn bida chất lượng cao</span></li>
                                <li class="check"><span>Phục vụ tại chỗ</span></li>
                                <li class="check"><span>Khu vực riêng biệt</span></li>
                                <li class="check"><span>Wifi miễn phí</span></li>
                            </ul>
                            <a href="#" class="btn btn-info">Đặt bàn ngay</a>
                        </div>
                        <div class="price-col text-center col-xs-12 col-sm-6 col-md-4">
                            <strong class="title">Khu C</strong>
                            <div class="offer-heading">
                                <h3>120,000<span class="text-light"> VND/giờ</span><span class="subtitle">Không gian tiêu chuẩn, điều hòa</span></h3>
                            </div>
                            <ul>
                                <li class="check"><span>Loại bàn không lỗ</span></li>
                                <li class="check"><span>Bàn bida phổ thông</span></li>
                                <li class="check"><span>Phục vụ tại chỗ</span></li>
                                <li class="check"><span>Khu vực riêng biệt</span></li>
                                <li class="check"><span>Wifi miễn phí</span></li>
                            </ul>
                            <a href="#" class="btn btn-info">Đặt bàn ngay</a>
                        </div>
                    </div>
                </section>

                <!-- Trial block of the page -->
                <section class="trial-block container" data-scroll-index="5">
                    <div class="row">
                        <div class="col-xs-12 col-sm-6">
                            <img src="/Content/assets/images/order.jpg" alt="image description" class="img-responsive">
                        </div>
                        <div class="col-xs-12 col-sm-6 descr">
                            <div class="align">
                                <header class="heading-wrap">
                                    <h2>Đặt bàn ngay</h2>
                                </header>
                        

                                <div class="form-group">
                                    <label for="khuVuc">Chọn khu vực:</label>
                                    <asp:DropDownList ID="khuVuc" runat="server" CssClass="form-control select-khuvuc" AutoPostBack="True" OnSelectedIndexChanged="khuVuc_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="ban">Chọn bàn:</label>
                                    <asp:DropDownList ID="ban" runat="server" CssClass="form-control select-khuvuc">
                                        <asp:ListItem Text="-- Chọn bàn --" Value="" />
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="thoiGianDatBan">Chọn ngày và giờ đặt bàn:</label>
                                    <input type="datetime-local" id="thoiGianDatBan" name="thoiGianDatBan" class="form-control select-khuvuc" >
                                </div>


                                <asp:Button ID="btnSubmit" runat="server" Text="Đặt bàn" CssClass="btn btn-info" OnClick="btnSubmit_Click" />

                            </div>
                        </div>
                    </div>
                </section>

                <!-- Brands area of the page -->
              
            </main>
                 <%--<script type="text/javascript">
                     document.addEventListener("DOMContentLoaded", function () {
                         var khuVucDropdown = document.getElementById("<%= khuVuc.ClientID %>");
                         var banDropdown = document.getElementById("<%= ban.ClientID %>");
                         var hiddenBanField = document.getElementById("<%= selectedBan.ClientID %>");

                         khuVucDropdown.addEventListener("change", function () {
                             var selectedKhuVuc = khuVucDropdown.value;

                             // Xóa tất cả các tùy chọn hiện có trong dropdown bàn
                             while (banDropdown.options.length > 1) {
                                 banDropdown.remove(1);
                             }

                             // Lọc danh sách bàn theo khu vực được chọn
                             if (selectedKhuVuc && banData) {
                                 var filteredBans = banData.filter(function (ban) {
                                     return ban.MaKV === selectedKhuVuc;
                                 });

                                 // Thêm các tùy chọn bàn phù hợp vào dropdown bàn
                                 filteredBans.forEach(function (ban) {
                                     var option = document.createElement("option");
                                     option.value = ban.MaBan;
                                     option.text = ban.TenBan;
                                     banDropdown.add(option);
                                 });
                             }
                         });

                         banDropdown.addEventListener("change", function () {
                             hiddenBanField.value = banDropdown.value;  // Lưu giá trị bàn vào HiddenField
                         });
                     });




                </script>--%>

    </asp:Content>


