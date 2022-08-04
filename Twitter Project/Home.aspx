<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Twitter_Project.Home" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="postIdBox" runat="server" style="visibility:hidden"></asp:TextBox>
    <div class="container">
        <div class="row">
            <asp:Repeater ID="postRepeater" runat="server" OnItemDataBound="PostRepeaterItemDataBound">
                <ItemTemplate>             
                    <div class="col-lg-6 col-md-8 login-box margin-left" style="align-items: flex-start">
                        <div>
                            <asp:Label runat="server" ID="postId" class="form-control-label" Style="visibility:hidden" Text='<%#Eval("post.postId") %>'><</asp:Label>
                            <img src='File/<%#Eval("profilePicture")%>' class="avatar">
                            <asp:Label runat="server" ID="userName" class="form-control-label" Style="font-size: 20px; float: left; padding-left: 5px; padding-top: 20px" Text='<%#Eval("userName") %>'><</asp:Label>
                            <p style="float:right; color:whitesmoke"><%#Eval("post.createdDate").ToString() %></p>
                        </div>
                        <br />
                        <div class="col-lg-12 col-md-12" style="max-height: 150px; text-align: left; background-color: #1A2226; color: whitesmoke; margin-top: 10px">
                            <p><%#Eval("post.description") %></p>
                        </div>
                        <br />
                        <div class="col-lg-12 col-md-12" style="height: 300px; align-items: center">
                            <image src='File/<%#Eval("post.filePath") %>' style="max-height: 290px !important"></image>
                        </div>
                        <div class="col-lg-6 col-md-8 login-box" style="color: whitesmoke; margin-top: 3px !important; box-shadow: none;">
                            <div class="heart" id="heart<%#Eval("post.postId") %>" onclick="likes('<%#Eval("post.postId") %>')">
                                <p id="Likecount<%#Eval("post.postId")%>"><%#Eval("post.likes")%> likes</p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12 col-md-12 row" style="box-shadow: 0 3px 6px rgba(0, 0, 0, 0.16), 0 3px 6px rgba(0, 0, 0, 0.23); color: whitesmoke">
                                <form>
                                    <h3 class="pull-left" style="margin-left: 10px">New Comment</h3>
                                    <div class="col-lg-6 login-btm login-button">
                                        <asp:TextBox ID="CommentBox" runat="server" TextMode="MultiLine" class="form-control" Style="background-color: #1A2226; color: whitesmoke; border-color: #0DB8DE; margin-left: 5px"></asp:TextBox>
                                        <asp:Button ID="CommentButton" runat="server" Text="Submit" class="btn btn-outline-primary commentButtonClass" Style="line-height: 0" postIdTutucu='<%#Eval("post.postId") %>' OnClick="RegisterButton_Click" />
                                    </div>
                                    <div class="row">
                                        <div class="form-group col-xs-12 col-sm-9 col-lg-10">
                                        </div>
                                    </div>
                                </form>
                                <asp:Label style="font-size:24px; color:whitesmoke; width:10ch;" ID="commentCountLabel" runat="server"></asp:Label>

                                <asp:Repeater runat="server" ID="commentRepeater">
                                    <ItemTemplate>


                                        <!-- COMMENT START -->
                                        <div class="media" style="color: whitesmoke">
                                            <a class="pull-left" href="#">
                                                <img class="avatar" style="margin-top: 0px" src='File/<%#Eval("commentProfilePicture") %>' alt=""></a>
                                            <div class="media-body">
                                                <h4 class="media-heading" style="float: left; margin-top: 10px; text-decoration: underline"><%#Eval("commentUserName") %></h4>
                                                <br />
                                                <br />
                                                <p style="float:left"><%#Eval("comment.comment1") %></p>
                                                <br />
                                                <ul class="list-unstyled list-inline media-detail pull-left">
                                                    <li><i class="fa fa-calendar"></i><%#Eval("comment.Date").ToString()%></li>
                                                </ul>
                                                <ul class="list-unstyled list-inline media-detail pull-right">
                                                    <li class=""><a href="">Like</a></li>
                                                    <li class=""><a href="">Reply</a></li>
                                                </ul>
                                            </div>
                                        </div>
                                        <!-- COMMENT END -->
                                    </ItemTemplate>
                                </asp:Repeater>

                            </div>
                        </div>
                    </div>
                </ItemTemplate>


            </asp:Repeater>
        </div>
    </div>
    <script>

            function likes(postID)
            {
                $('#heart' + postID).toggleClass("is-active");
                var likes = $("#Likecount" + postID).html();
                likeCount = likes.split(" ");
                var heartDiv = document.getElementById('heart' + postID);
                var isContain = heartDiv.classList.contains("is-active");
                var url = "";
                if (isContain) {
                    likeCount[0]++;
                    document.getElementById("Likecount" + postID).innerHTML = likeCount[0] + " likes";
                    url = '/WebService1.asmx/IncrementLikes';
                }
                else {

                    likeCount[0]--;
                    document.getElementById("Likecount" + postID).innerHTML = likeCount[0] + " likes";
                    url = '/WebService1.asmx/DecrementLikes';
                }
                $.ajax({
                    type: 'POST',
                    url: url,
                    data: '{postId:' + postID + '}',
                    contentType: 'application/json; charset=utf-8',// What I am ing
                    dataType: "json", // What I am expecting
                    crossDomain: true,
                    success: function (data) {
                        $('#divSum2').html(data.d);
                    },

                });
            }

        $(document).ready(function () {

            $(".commentButtonClass").click(function () {
                document.getElementById('<%=postIdBox.ClientID %>').value = $(this).attr("postIdTutucu");

            });
        });


    </script>

</asp:Content>
