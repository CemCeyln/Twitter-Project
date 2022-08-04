<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Twitter_Project.HomePage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">      
            <asp:Repeater ID="postRepeater" runat="server">
                <ItemTemplate>
                    <asp:HiddenField runat="server" Value="<%#Eval("post.postId") %>" ID="postId"/>
                    <div class="col-lg-6 col-md-8 login-box" style="align-items: flex-start">
                        <div>
                            <img src='File/<%#Eval("profilePicture")%>' class="avatar">
                            <asp:Label runat="server" ID="userName" class="form-control-label" Style="font-size: 20px; float: left; padding-left: 5px; padding-top: 20px" Text='<%#Eval("userName") %>'><</asp:Label>
                        </div>
                        <br />
                        <div class="col-lg-12 col-md-12" style="max-height: 150px; text-align: left; background-color: #1A2226; color: whitesmoke; margin-top: 10px">
                            <p><%#Eval("post.description") %></p>
                        </div>
                        <br />
                        <div class="col-lg-12 col-md-12" style="height: 300px; align-items: center">
                            <image src='File/<%#Eval("post.filePath") %>' style="max-height: 290px !important"></image>
                        </div>
                        <div class="col-lg-6 col-md-8 login-box" style="color: whitesmoke; margin-top: 3px !important; box-shadow:none;">
                            <div class="heart" id="heart">
                                <p id="Likecount"><%#Eval("post.likes")%> likes</p>
                            </div>
                        </div>
                        <div class="row">
            <div class="col-lg-12 col-md-12 row" style="box-shadow: 0 3px 6px rgba(0, 0, 0, 0.16), 0 3px 6px rgba(0, 0, 0, 0.23); color:whitesmoke">   
                <form>
                	<h3 class="pull-left" style="margin-left:10px">New Comment</h3>
                    <div class="col-lg-6 login-btm login-button">
                         <asp:TextBox ID="CommentBox" runat="server" TextMode="MultiLine" class="form-control" style="background-color:#1A2226; color:whitesmoke; border-color:#0DB8DE; margin-left:5px"></asp:TextBox>
                        <asp:Button runat="server" id="CommentButton" text="Submit" class="btn btn-outline-primary" style="line-height:0"/>
                    </div>
                        <div class="row">
                            <div class="form-group col-xs-12 col-sm-9 col-lg-10">
                                 
                            </div>
                        </div>  	
                </form>
                
                <h3 style="color:whitesmoke">1 Comment</h3>
                
                <asp:Repeater runat="server" ID="commentRepeater">
                      <!-- COMMENT START -->
                <div class="media" style="color:whitesmoke">
                    <a class="pull-left" href="#"><img class="avatar" style="margin-top:0px" src="https://bootdey.com/img/Content/avatar/avatar1.png" alt=""></a>
                    <div class="media-body">
                        <h4 class="media-heading" style="float:left; margin-top:10px; text-decoration:underline">John Doe</h4>
                        <br />
                        <br />
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                        <ul class="list-unstyled list-inline media-detail pull-left">
                            <li><i class="fa fa-calendar"></i>27/02/2014</li>
                            <li><i class="fa fa-thumbs-up"></i>13</li>
                        </ul>
                        <ul class="list-unstyled list-inline media-detail pull-right">
                            <li class=""><a href="">Like</a></li>
                            <li class=""><a href="">Reply</a></li>
                        </ul>
                    </div>
                </div>
                <!-- COMMENT END -->  
                </asp:Repeater>
                     
            </div>
        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <script>
        $(function () {
            $(".heart").on("click", function () {
                $(this).toggleClass("is-active");
                var likes = $("#Likecount").html();
                likeCount = likes.split(" ");
                var heartDiv = document.getElementById("heart");
                var isContain = heartDiv.classList.contains("is-active");
                var url = "";
                if (isContain) {
                    likeCount[0]++;
                    document.getElementById("Likecount").innerHTML = likeCount[0] + " likes";
                    url = '/WebService1.asmx/IncrementLikes';
                }
                else {

                    likeCount[0]--;
                    document.getElementById("Likecount").innerHTML = likeCount[0] + " likes";
                    url = '/WebService1.asmx/DecrementLikes';
                }
                var postId = $("#postId").html();
                var userName = $("#userName").html();
                var likeNumber = $("#Likecount").html();
                $.ajax({
                    type: 'POST',
                    url: url,
                    data: '{postId:' + postId + '}',
                    contentType: 'application/json; charset=utf-8',// What I am ing
                    dataType: "json", // What I am expecting
                    crossDomain: true,
                    success: function (data) {
                        $('#divSum2').html(data.d);
                    },
                    error(dataer) { alert(dataer.d); }
                });
            });
        });
    </script>

</asp:Content>
