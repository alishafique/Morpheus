<%@ Page Title="" Language="C#" MasterPageFile="~/defualt.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Morpheus.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <link rel="stylesheet" type="text/css" href="css/style.min.css" />
<link rel="stylesheet" type="text/css" href="icons/entypo.css" />
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
        <section class="hero_area">
          

            <%--This is the slider--%>
  <div class='o-sliderContainer hasShadow' id="pbSliderWrap3">
    <div class='o-slider' id='pbSlider3'>
      <div class="o-slider--item" data-image="img/hero.jpg">
        <div class="o-slider-textWrap">
          <h2 class="o-slider-title">Dynamic Innovation in</h2>
          <span class="a-divider"></span>
          <h2 class="o-slider-subTitle">Occupational Health & Safety</h2>
        </div>
      </div>
      <div class="o-slider--item" data-image="img/Main.jpg">
        <div class="o-slider-textWrap">
          <h1 class="o-slider-title">712,000 workers employed</h1>
          <span class="a-divider"></span>
          <h2 class="o-slider-subTitle">in the construction industry in 2013 – Safework Australia</h2>
        </div>
      </div>
      <div class="o-slider--item" data-image="img/3.jpg">
        <div class="o-slider-textWrap">
          <h1 class="o-slider-title">This is a title</h1>
          <span class="a-divider"></span>
          <h2 class="o-slider-subTitle">This is a sub title</h2>
        </div>
      </div>
      <div class="o-slider--item" data-image="img/4.jpg">
        <div class="o-slider-textWrap">
          <h1 class="o-slider-title">This is a title</h1>
          <span class="a-divider"></span>
          <h2 class="o-slider-subTitle">This is a sub title</h2>
        </div>
      </div>
      <div class="o-slider--item" data-image="img/5.jpg">
        <div class="o-slider-textWrap">
          <h1 class="o-slider-title">This is a title</h1>
          <span class="a-divider"></span>
          <h2 class="o-slider-subTitle">This is a sub title</h2>
        </div>
      </div>
      <div class="o-slider--item" data-image="img/6.jpg">
        <div class="o-slider-textWrap">
          <h1 class="o-slider-title">This is a title</h1>
          <span class="a-divider"></span>
          <h2 class="o-slider-subTitle">This is a sub title</h2>
        </div>
      </div>
    </div>
  </div>
     
                </section>
         
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
                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin id pulvinar magna. Aenean accumsan iaculis lorem, nec sodales lectus auctor tempor.</p>
                            <i class="fa fa-exclamation-triangle"></i>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="box">
                            <h3>OMS/GU Press Release and add to Latest
                                 <br />
                                News</h3>
                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin id pulvinar magna. Aenean accumsan iaculis lorem, nec sodales lectus auctor tempor.</p>
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
                                <h4 class="media-heading">FIRST SERVICE TITLE</h4>
                                <p>Lorem ipsum dolor amet,consectetur adipiscing elit. Proin id pulvinar magna. Aenean accumsan iaculis lorem, nec sodales lectus auctor tempor.</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                        <div class="media">
                            <div class="media-left media-middle">
                                <i class="fa fa-user-md"></i>
                            </div>
                            <div class="media-body">
                                <h4 class="media-heading">SECOND SERVICE TITLE</h4>
                                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin id pulvinar magna. Aenean accumsan iaculis lorem, nec sodales lectus auctor tempor.</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                        <div class="media">
                            <div class="media-left media-middle">
                                <i class="fa fa-stethoscope"></i>
                            </div>
                            <div class="media-body">
                                <h4 class="media-heading">THIRD SERVICE TITLE</h4>
                                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin id pulvinar magna. Aenean accumsan iaculis lorem, nec sodales lectus auctor tempor.</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                        <div class="media">
                            <div class="media-left media-middle">
                                <i class="fa fa-graduation-cap"></i>
                            </div>
                            <div class="media-body">
                                <h4 class="media-heading">FOURTH SERVICE TITLE</h4>
                                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin id pulvinar magna. Aenean accumsan iaculis lorem, nec sodales lectus auctor tempor.</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                        <div class="media">
                            <div class="media-left media-middle">
                                <i class="fa fa-file-text-o"></i>
                            </div>
                            <div class="media-body">
                                <h4 class="media-heading">FIFTH SERVICE TITLE</h4>
                                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin id pulvinar magna. Aenean accumsan iaculis lorem, nec sodales lectus auctor tempor.</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                        <div class="media">
                            <div class="media-left media-middle">
                                <i class="fa fa-heartbeat"></i>
                            </div>
                            <div class="media-body">
                                <h4 class="media-heading">SIXTH SERVICE TITLE</h4>
                                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin id pulvinar magna. Aenean accumsan iaculis lorem, nec sodales lectus auctor tempor.</p>
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
                                    <div class="thumbnail">
                                        <img src="img/h1.jpeg" alt="Post">
                                        <div class="caption">
                                            <h3><a href="#">Post Title</a></h3>
                                            <p>Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus.</p>
                                            <a href="#" class="btn btn-link" role="button">More</a>
                                        </div>
                                    </div>                                        
                                </li>
                                <li class="col-md-3 col-sm-6 col-xs-12">
                                    <div class="thumbnail">
                                        <img src="img/h2.jpg" class="img-responsive" alt="Post">
                                        <div class="caption">
                                            <h3><a href="#">Post Title</a></h3>
                                            <p>Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus.</p>
                                            <a href="#" class="btn btn-link" role="button">More</a>
                                        </div>
                                    </div>                                        
                                </li>
                                <li class="col-md-3 col-sm-6 col-xs-12">
                                    <div class="thumbnail">
                                        <img src="img/h3.jpeg" class="img-responsive" alt="Post">
                                        <div class="caption">
                                            <h3><a href="#">Post Title</a></h3>
                                            <p>Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus.</p>
                                            <a href="#" class="btn btn-link" role="button">More</a>
                                        </div>
                                    </div>                                        
                                </li>
                                <li class="col-md-3 col-sm-6 col-xs-12">
                                    <div class="thumbnail">
                                        <img src="img/h4.jpeg" class="img-responsive" alt="Post">
                                        <div class="caption">
                                            <h3><a href="#">Post Title</a></h3>
                                            <p>Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus.</p>
                                            <a href="#" class="btn btn-link" role="button">More</a>
                                        </div>
                                    </div>                                        
                                </li>                                    
                            </ul>
                        </div>
                        
                        <div class="col-sm-9 home_bottom">
                            <h2 class="sub_title">REFERENCES</h2>
                            <div class="clearfix"></div>
                            <div class="row">
                                <div class="carousel slide" data-ride="carousel" data-type="multi" data-interval="6000" id="myCarousel">
                                    <div class="carousel-inner">
                                        <div class="item active">
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
<script src="js/jquery-3.2.0.min.js" type="text/javascript"></script>
<script src='js/hammer.min.js' type="text/javascript"></script>
<script src='js/slider.js' type="text/javascript"></script>
<script src='js/owl.carousel.js' type="text/javascript"></script>
    <script type="text/javascript">
       
        $('#pbSlider3').owlCarousel({
            loop: true,
            margin: 10,
            nav: true,
            responsive: {
                0: {
                    items: 1
                },
                600: {
                    items: 3
                },
                1000: {
                    items: 5
                }
            }
        });

        //    .pbTouchSlider({
        //    slider_Wrap: '#pbSliderWrap3',
        //    slider_Item_Width: 80,
        //    slider_Threshold: 50,
        //    slider_Speed: 400,
        //    slider_Ease: 'linear',
        //    slider_Breakpoints: {
        //        default: {
        //            height: 475
        //        },
        //        tablet: {
        //            height: 300,
        //            media: 1024
        //        },
        //        smartphone: {
        //            height: 200,
        //            media: 768
        //        }
        //    }
        //} );
       
       
       
    </script>
   
</asp:Content>
