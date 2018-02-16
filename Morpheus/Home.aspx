<%@ Page Title="" Language="C#" MasterPageFile="~/defualt.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Morpheus.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/jquery-3.2.0.min.js" type="text/javascript"></script>
<script src='js/hammer.min.js' type="text/javascript"></script>
<script src='js/slider.js' type="text/javascript"></script>
<script src='js/owl.carousel.js' type="text/javascript"></script>
 <link rel="stylesheet" type="text/css" href="css/style.min.css" />
    <link rel="stylesheet" type="text/css" href="css/owl.carousel.min.css" />
    <link rel="stylesheet" type="text/css" href="css/owl.theme.default.min.css" />
<link rel="stylesheet" type="text/css" href="icons/entypo.css" />
    <style type="text/css">
                 /*.sizing {
                    width: 100%;
                    height: 400px;
                    overflow: hidden;
                 }
                 .heading1 {
                    top: 240px;
                    left: 70px;
                    right: 0;
                    position: absolute;
                    padding: 0;
                    color:azure;
                 }

                .heading2 {
                    top: 280px;
                    left: 70px;
                    right: 0;
                    position: absolute;
                    padding: 0;
                     color:azure;
                }
                .sizing img
                {
                   /*height:100%;
                     }
                 */
               
            </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
        <main class="site-main">
            
     <%--   <section class="hero_area">
            <div class="hero_content">
                <div class="container">
                    <div class="row">
                        <div class="col-sm-12" style="margin:-45px;margin-left: 15px;">
                          
                            <h2>Dynamic Innovation in</h2>
                            <h2>Occupational Health & Safety</h2>
                        </div>
                    </div>
                </div>
            </div>
        </section>--%>
        <div class="container">
          
            
            <%--This is the slider--%>
  <div id="pbSliderWrap4">
    <div class='owl-carousel owl-theme' id='pbSlider4'>
         <div class="item sizing">
          <img src="img/5.jpg" />
        <div class="o-slidr-textWrap">
          <h1 class="heading1" style="color:black;">Dynamic Innovation in</h1>
          <span class="a-dvider"></span>
          <h2 class="heading2" style="color:black;">Occupational Health & Safety</h2>
        </div>
      </div>
      <div class="item sizing" >
          <img src="img/safety-helmet.jpg" />
        <div class="o-slier-textWrap">
          <h2 class="heading1"  style="color:black;" >Dynamic Innovation</h2>
          <span class="a-diider" ></span>
          <h2 class="heading2"  style="color:black;">in Occupational Health & Safety</h2>
        </div>
      </div>
      <div class="item sizing" >
          <img src="img/Main.jpg" />
      <%--  <div class="o-slidr-textWrap">
          <h1 class="heading1" style="color:black;">712,000 workers employed</h1>
          <span class="a-dvider"></span>
          <h2 class="heading2" style="color:black;">in the construction industry in 2013 – Safework Australia</h2>
        </div>--%>
      </div>
      <div class="item sizing" >
          <img src="img/3.jpg" />
        <div class="o-slier-textWrap">
          <h1 class="heading1"  style="color:black;">This is a title</h1>
          <span class="a-dvider"></span>
          <h2 class="heading2"  style="color:black;">This is a sub title</h2>
        </div>
      </div>
      <div class="item sizing" >
          <img src="img/4.jpg" />
        <div class="o-slier-textWrap">
          <h1 class="heading1" style="color:black;">This is a title</h1>
          <span class="a-ivider"></span>
          <h2 class="heading2" style="color:black;">This is a sub title</h2>
        </div>
      </div>
     
      <div class="item sizing" >
          <img src="img/6.jpg" />
        <div class="o-slidr-textWrap">
          <h1 class="heading1" style="color:black;">This is a title</h1>
          <span class="a-diider"></span>
          <h2 class="heading2" style="color:black;">This is a sub title</h2>
        </div>
      </div>
    </div>
  </div>
     
               </div>
         
        <section class="boxes_area">
            <div class="container">
                <div class="row">
                    <div class="col-sm-4">
                        <div class="box">
                            <h3>Why Do I Need an OHS System?</h3>
                            <p>Health and safety laws have evolved as result of oversight, or failure to provide safe working conditions for workers.  Whilst majority of employers genuinely care for their employees, they aren’t always able, or often overlook the necessary requirements for safety in their day to day operations.</p>
                            <i class="fa fa-cogs"></i>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="box">
                            <h3>Legal Minefield - Your Obligations – Employer/Employee</h3>
                            <p>With flexible workforce arrangements becoming increasingly common, it’s vital you understand your obligations to employees.With flexible workforce arrangements becoming increasingly common, it’s vital you understand your obligations to employees<a href="#" data-toggle="modal" data-target="#LegalMinefield" style="color:#005FA6;">   More..</a></p>
                            <div class="modal fade" id="LegalMinefield" tabindex="-1" role="dialog" aria-labelledby="myModalLabel1" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="myModalLabel1">Legal Minefield - Your Obligations – Employer/Employee</h4>
                                        </div>
                                        <div class="modal-body">
                                           <p>With flexible workforce arrangements becoming increasingly common, it’s vital you understand your obligations to employees.</p>
                                            <p>Deciding whether workers are employees or contractors can be a legal minefield for which businesses are unprepared until a dispute arises, or an ATO auditor or Fair Work inspector pays a visit.</p>
                                            <p>Unfortunately, ignorance of the law is no defence, and getting it wrong can leave you heavily out of pocket.</p>
                                            <p>Unfortunately, ignorance of the law is no defence, and getting it wrong can leave you heavily out of pocket.</p>
                                            <h2>Don’t assume</h2>
                                            <p>The ATO recently warned small businesses not to be fooled by the myth that simply calling a worker a contractor releases businesses from super and tax payments. The ATO recently warned small businesses not to be fooled by the myth that simply calling a worker a contractor releases businesses from super and tax payments.</p>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                        </div>
                                    </div>
                                    <!-- /.modal-content -->
                                </div>
                                <!-- /.modal-dialog -->
                            </div>
                            <i class="fa fa-exclamation-triangle"></i>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="box">
                            <h3>OMS/GU Press Release and add to Latest
                                 <br />
                                News</h3>
                            <p>Under construction.</p>
                            <i class="fa fa-clipboard"></i>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <section class="services">
            <h2 class="section-title">SERVICES</h2>
            <%--<p class="desc">Praesent faucibus ipsum at sodales blandit</p>--%>
            <div class="container">
                <div class="row">
                    <div class="col-md-4 col-sm-6 col-xs-12">
                        <div class="media">
                            <div class="media-left media-middle">
                                <i class="fa fa-cogs"></i>
                            </div>
                            <div class="media-body">
                                <h4 class="media-heading">INCIDENT REPORTING</h4>
                                <p>An easier way to report incident to your company. On one click you can export it to PDF/Excel file.</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                        <div class="media">
                            <div class="media-left media-middle">
                                <i class="fa fa-male"></i>
                            </div>
                            <div class="media-body">
                                <h4 class="media-heading">MANAGE EMPLOYEES</h4>
                                <p>Add/Update/Delete your employee's account. Interactive dashboard to manage your employees.</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                        <div class="media">
                            <div class="media-left media-middle">
                                <i class="fa fa-user fa-fw"></i>
                            </div>
                            <div class="media-body">
                                <h4 class="media-heading">MANAGE SUB-CONTRACTORS</h4>
                                <p>Add/update/Delete your Sub-Contractor's Account. A simple way to manage your staff in one place.</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                        <div class="media">
                            <div class="media-left media-middle">
                                <i class="fa fa-graduation-cap"></i>
                            </div>
                            <div class="media-body">
                                <h4 class="media-heading">ASSIGN JOBS TO EMPLOYEES</h4>
                                <p>Create/Update jobs and Assign it to your employees. An easy Way to keep track of jobs and employees.</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                        <div class="media">
                            <div class="media-left media-middle">
                                <i class="fa fa-file-text-o"></i>
                            </div>
                            <div class="media-body">
                                <h4 class="media-heading">EXPORT INCIDENT REPORTS</h4>
                                <p>Upon few clicks you can easily download your incident report in PDF and Excel formate.</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                        <div class="media">
                            <div class="media-left media-middle">
                                <i class="fa fa-database"></i>
                            </div>
                            <div class="media-body">
                                <h4 class="media-heading">FULL DATABASE RECORDS OF EMPLOYEES</h4>
                                <p>Our application keep full records of your employees. An easy way of managing the Employees.</p>
                            </div>
                        </div>
                    </div>                     
                </div>
            </div>
        </section>
        <section class="home-area">
            <div class="home_content">
                <div class="container">
                    <div class="row">
                        <div class="col-sm-12"><h2 class="sub_title">LATEST NEWS</h2></div>
                        <div class="home_list">
                            <ul>
                                <li class="col-md-3 col-sm-6 col-xs-12">
                                    <div class="thumbnail" id="NewsDiv1" runat="server">
                                        <img id="imgNews1" class="img-responsive" alt="Post" runat="server" />
                                        <div class="caption" >
                                            <h3><a href="#"><asp:Label ID="lblNews1PostTitle" runat="server" Text=""></asp:Label></a></h3>
                                            <p><asp:Label ID="lblNews1Detail" runat="server" Text=""></asp:Label></p>
                                            <a href="#" class="btn btn-link" data-toggle="modal" data-target="#News1Detail" role="button">More</a>
                                            <div class="modal fade" id="News1Detail" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="myModalLabel">Detail Of news</h4>
                                        </div>
                                        <div class="modal-body">
                                            <asp:Label ID="lblNewsDetail1" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                        </div>
                                    </div>
                                    <!-- /.modal-content -->
                                </div>
                                <!-- /.modal-dialog -->
                            </div>
                                        </div>
                                    </div>                                        
                                </li>
                                <li class="col-md-3 col-sm-6 col-xs-12">
                                    <div class="thumbnail">
                                        <img id="imgNews2" class="img-responsive" alt="Post" runat="server" />
                                        <div class="caption">
                                            <h3><a href="#"><asp:Label ID="lblNews2PostTitle" runat="server" Text=""></asp:Label></a></h3>
                                            <p><asp:Label ID="lblNews2Detail" runat="server" Text=""></asp:Label></p>
                                            <a href="#" class="btn btn-link" role="button" data-toggle="modal" data-target="#News2Detail">More</a>
                                             <div class="modal fade" id="News2Detail" tabindex="-1" role="dialog" aria-labelledby="myModalLabel2" aria-hidden="true">
                                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="myModalLabel2">Detail Of news</h4>
                                        </div>
                                        <div class="modal-body">
                                            <asp:Label ID="lblNewsDetail2" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                        </div>
                                    </div>
                                    <!-- /.modal-content -->
                                </div>
                                <!-- /.modal-dialog -->
                                                </div>
                                        </div>
                                    </div>                                        
                                </li>
                                <li class="col-md-3 col-sm-6 col-xs-12">
                                    <div class="thumbnail">
                                        <img id="imgNews3" class="img-responsive" alt="Post" runat="server" />
                                        <div class="caption">
                                            <h3><a href="#"><asp:Label ID="lblNews3PostTitle" runat="server" Text=""></asp:Label></a></h3>
                                            <p><asp:Label ID="lblNews3Detail" runat="server" Text=""></asp:Label></p>
                                            <a href="#" class="btn btn-link" role="button" data-toggle="modal" data-target="#News3Detail">More</a>
                                             <div class="modal fade" id="News3Detail" tabindex="-1" role="dialog" aria-labelledby="myModalLabel3" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="myModalLabel3">Detail Of news</h4>
                                        </div>
                                        <div class="modal-body">
                                            <asp:Label ID="lblNewsDetail3" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                        </div>
                                    </div>
                                    <!-- /.modal-content -->
                                </div>
                                <!-- /.modal-dialog -->
                            </div>
                                        </div>
                                    </div>                                        
                                </li>
                                <li class="col-md-3 col-sm-6 col-xs-12">
                                    <div class="thumbnail">
                                        <img id="imgNews4" class="img-responsive" alt="Post" runat="server">
                                        <div class="caption">
                                            <h3><a href="#"><asp:Label ID="lblNews4PostTitle" runat="server" Text=""></asp:Label></a></h3>
                                            <p><asp:Label ID="lblNews4Detail" runat="server" Text=""></asp:Label></p>
                                            <a href="#" class="btn btn-link" role="button" data-toggle="modal" data-target="#News4Detail">More</a>
                                             <div class="modal fade" id="News4Detail" tabindex="-1" role="dialog" aria-labelledby="myModalLabel4" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="myModalLabel4">Detail Of news</h4>
                                        </div>
                                        <div class="modal-body">
                                            <asp:Label ID="lblNewsDetail4" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                        </div>
                                    </div>
                                    <!-- /.modal-content -->
                                </div>
                                <!-- /.modal-dialog -->
                            </div>
                                        </div>
                                    </div>                                        
                                </li>                                    
                            </ul>
                        </div>
                        
                        <div class="col-sm-9 home_bottom">
                            <h2 class="sub_title">PARTNERS</h2>
                            <div class="clearfix"></div>
                            <div class="row">
                                <div class="carousel slide" data-ride="carousel" data-type="multi" data-interval="6000" id="myCarousel">
                                    <div class="carousel-inner">
                                        <div class="item active">
                                            <div class="col-md-2 col-sm-6 col-xs-12 p10">
                                                <a href="#"><img src="img/l1.jpg" class="img-responsive" alt="Reference" /></a>
                                            </div>
                                        </div>
                                        <div class="item">
                                            <div class="col-md-2 col-sm-6 col-xs-12 p10">
                                                <a href="#"><img src="img/l2.jpg" class="img-responsive" alt="Reference"></a>
                                            </div>
                                        </div>
                                        <div class="item">
                                            <div class="col-md-2 col-sm-6 col-xs-12">
                                                <a href="#"><img src="img/l3.jpg" class="img-responsive" alt="Reference"></a>
                                            </div>
                                        </div>
                                        <div class="item">
                                            <div class="col-md-2 col-sm-6 col-xs-12">
                                                <a href="#"><img src="img/l4.jpg" class="img-responsive" alt="Reference"></a>
                                            </div>
                                        </div>
                                        <div class="item">
                                            <div class="col-md-2 col-sm-6 col-xs-12">
                                                <a href="#"><img src="img/l5.jpg" class="img-responsive" alt="Reference"></a>
                                            </div>
                                        </div>
                                        <div class="item">
                                            <div class="col-md-2 col-sm-6 col-xs-12">
                                                <a href="#"><img src="img/l6.jpg" class="img-responsive" alt="Reference"></a>
                                            </div>
                                        </div>
                                        <div class="item">
                                            <div class="col-md-2 col-sm-6 col-xs-12">
                                                <a href="#"><img src="img/l7.jpg" class="img-responsive" alt="Reference"></a>
                                            </div>
                                        </div>
                                        <div class="item">
                                            <div class="col-md-2 col-sm-6 col-xs-12">
                                                <a href="#"><img src="img/l8.jpg" class="img-responsive" alt="Reference"></a>
                                            </div>
                                        </div>
                                        <div class="item">
                                            <div class="col-md-2 col-sm-6 col-xs-12 p10">
                                                <a href="#"><img src="img/l1.jpg" class="img-responsive" alt="Reference"></a>
                                            </div>
                                        </div>
                                        <div class="item">
                                            <div class="col-md-2 col-sm-6 col-xs-12 p10">
                                                <a href="#"><img src="img/l2.jpg" class="img-responsive" alt="Reference"></a>
                                            </div>
                                        </div>
                                        <div class="item">
                                            <div class="col-md-2 col-sm-6 col-xs-12">
                                                <a href="#"><img src="img/l3.jpg" class="img-responsive" alt="Reference"></a>
                                            </div>
                                        </div>
                                        <div class="item">
                                            <div class="col-md-2 col-sm-6 col-xs-12">
                                                <a href="#"><img src="img/l4.jpg" class="img-responsive" alt="Reference"></a>
                                            </div>
                                        </div>
                                        <div class="item">
                                            <div class="col-md-2 col-sm-6 col-xs-12">
                                                <a href="#"><img src="img/l5.jpg" class="img-responsive" alt="Reference"></a>
                                            </div>
                                        </div>
                                        <div class="item">
                                            <div class="col-md-2 col-sm-6 col-xs-12">
                                                <a href="#"><img src="img/l6.jpg" class="img-responsive" alt="Reference"></a>
                                            </div>
                                        </div>
                                        <div class="item">
                                            <div class="col-md-2 col-sm-6 col-xs-12">
                                                <a href="#"><img src="img/l7.jpg" class="img-responsive" alt="Reference"></a>
                                            </div>
                                        </div>
                                        <div class="item">
                                            <div class="col-md-2 col-sm-6 col-xs-12">
                                                <a href="#"><img src="img/l8.jpg" class="img-responsive" alt="Reference"></a>
                                            </div>
                                        </div>                                        
                                    </div>
                                    <a class="left carousel-control" href="#myCarousel" data-slide="prev"><i class="glyphicon glyphicon-chevron-left"></i></a>
                                    <a class="right carousel-control" href="#myCarousel" data-slide="next"><i class="glyphicon glyphicon-chevron-right"></i></a>
                                </div>
                            </div>                            
                        </div>
                        <div class="col-sm-3">
                            <h2 class="sub_title w10">CALL YOU</h2>
                            <div class="clearfix"></div>
                            <div class="login-form-1">
                                <form id="login-form" class="text-left">
                                    <div class="login-form-main-message"></div>
                                    <div class="main-login-form">
                                        <div class="login-group">
                                            <div class="form-group">
                                                <label for="ad" class="sr-only">Name</label>
                                                <input type="text" class="form-control" id="ad" name="ad" placeholder="Name">
                                            </div>
                                            <div class="form-group">
                                                <label for="tel" class="sr-only">Phone Number</label>
                                                <input type="text" class="form-control" id="tel" name="tel" placeholder="Phone Number">
                                            </div>
                                        </div>
                                        <button type="submit" class="login-button"><i class="fa fa-chevron-right"></i></button>
                                    </div>
                                </form>
                            </div>                            
                        </div>
                    </div>
                </div>
            </div>
        </section>
                
    </main>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#pbSlider4').owlCarousel({
                loop: true,
                nav: true,
                margin: 10,
               items: 1,
                autoplay: true,
                autoplayTimeout: 3000,
                autoplayHoverPause: true,
                responsiveClass: true
              
            });
        });
        
     
    </script>
   
</asp:Content>
