<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Twitter_Project.Profile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    
    <div class="container">

<div class="row py-5 px-4">
    <div class="col-xl-4 col-md-6 col-sm-10 mx-auto margin-left" style="background:#1A2226; color:whitesmoke; height:250px;" >

        <!-- Profile widget -->
        <div class="bg-white shadow rounded">
            <div class="px-4 pt-0 pb-4 bg-dark">
                <div class="media align-items-end profile-header">
                    <div class="profile mr-3"><img runat="server" ID="profilePicture"  alt="..." width="130" class="rounded mb-2 img-thumbnail">
                       <asp:Button runat="server" CssClass="btn btn-outline-primary profile-buttons" ID="followButton" OnClick="FollowUnfollow" Text="Follow"/>
                       <asp:Button runat="server" CssClass="btn btn-outline-primary profile-buttons" ID="messageButton" Text="Message"/>
                    </div>
                     
                    <div class="media-body mb-5 text-white">       
                        <asp:Label runat="server" CssClass="mt-0 mb-0" style="font-size:18px;" ID="nameLabel"></asp:Label>
                        <br />
                        <asp:Label runat="server" CssClass="small mb-4" ID="emailLabel"></asp:Label>
                    </div>
                </div>
            </div>

            <div class="bg-light p-4 d-flex justify-content-end text-center">
                <ul class="list-inline mb-0">
                    <li class="list-inline-item">
                        
                        
                        <asp:Label runat="server" CssClass="font-weight-bold mb-0 d-block" ID="totalPosts" style="font-size:16px;"></asp:Label>
                        <br />
                        <small class="text-muted"> <i class="fa fa-picture-o mr-1"></i>Photos</small>
                    </li>
                    <li class="list-inline-item">
                        <asp:Label runat="server" CssClass="font-weight-bold mb-0 d-block" ID="totalFollowers" style="font-size:16px;"></asp:Label>
                        <br />
                        <small class="text-muted"> <i class="fa fa-user-circle-o mr-1"></i>Followers</small>
                    </li>
                </ul>
            </div>
            </div>
        </div>
    </div>
        <br />
        <br />
        <div style="align-items: center">
            <asp:Label runat="server" CssClass="margin-left" ID="postNameLabel" style=" font-size:36px; color:whitesmoke;"></asp:Label>
        </div>
        
        <div class="row" style="margin-top:30px">
            <asp:Repeater ID="postRepeater" runat="server" OnItemDataBound="PostRepeaterItemDataBound" OnItemCommand="PostRepeaterItemCommand">
                <ItemTemplate>             
                    <div class="col-lg-6 col-md-8 login-box margin-left" style="align-items: flex-start">
                        <div>
                            <asp:Label runat="server" ID="postIdLabel" class="form-control-label" Style="visibility:hidden" Text='<%#Eval("post.postId") %>'><</asp:Label>
                            <asp:Label runat="server" ID="userIdLabel" class="form-control-label" Style="visibility:hidden" Text='<%#Eval("userId") %>'><</asp:Label>
                            <img src='File/<%#Eval("profilePicture")%>' class="avatar">
                             <asp:LinkButton runat="server" CommandName="Profile" CssClass="form-control-label nameLink"><%#Eval("userName") %></asp:LinkButton>
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
                                    <h3 class="pull-left" style="margin-left: 10px">New Comment</h3>
                                    <div class="col-lg-6 login-btm login-button">
                                        <asp:TextBox ID="CommentBox"  runat="server" TextMode="MultiLine" class="form-control" Style="background-color: #1A2226; color: whitesmoke; border-color: #0DB8DE; margin-left: 5px"></asp:TextBox>
                                        <asp:Button ID="CommentButton" runat="server" CommandName="Comment" Text="Submit" class="btn btn-outline-primary" Style="line-height: 0" />
                                    </div>
                                    <div class="row">
                                        <div class="form-group col-xs-12 col-sm-9 col-lg-10">
                                        </div>
                                    </div>
                                <asp:Label style="font-size:24px; color:whitesmoke; width:10ch;" ID="commentCountLabel" runat="server"></asp:Label>

                                <asp:Repeater runat="server" ID="commentRepeater" OnItemCommand="CommentRepeaterItemCommand" OnItemDataBound="CommentRepeaterItemDataBound">
                                    <ItemTemplate>


                                        <!-- COMMENT START -->
                                        <div class="media" style="color: whitesmoke; margin-left:10px">
                                            <a class="pull-left" href="#">
                                                <asp:Label runat="server" ID="commentUserIdLabel" class="form-control-label" Style="visibility:hidden" Text='<%#Eval("commentUserId") %>'><</asp:Label>
                                                 <asp:Label runat="server" ID="commentIdLabel" class="form-control-label" Style="visibility:hidden" Text='<%#Eval("comment.commentId") %>'><</asp:Label>
                                                <img class="avatar" style="margin-top: 0px" src='File/<%#Eval("commentProfilePicture") %>' alt=""></a>
                                            <div class="media-body">
                                                <asp:LinkButton runat="server" CommandName="ProfileFromComment" CssClass="media-heading commentNameLink"><%#Eval("commentUserName") %></asp:LinkButton>
                                                <br />
                                                <br />
                                                <div>
                                                    <p style="float:left"><%#Eval("comment.comment1") %></p>
                                                </div>                 
                                                <br />
                                                <ul class="list-unstyled list-inline media-detail pull-left">
                                                    <li><i class="fa fa-calendar"></i><%#Eval("comment.Date").ToString()%></li>
                                                </ul>
                                                <ul class="list-unstyled list-inline media-detail pull-right">
                                                    <li id="commentLikeCount<%#Eval("comment.commentId")%>"><%#Eval("comment.likeCount")%> likes</li>
                                                    <br />
                                                    <li><div class="heart" id="heart-comment<%#Eval("comment.commentId") %>" onclick="commentLikes('<%#Eval("comment.commentId") %>')"></li>
                                                    <li><asp:LinkButton runat="server" CommandName="DeleteComment" style="color:#0DB8DE" ID="deleteButton" Text="Delete"></asp:LinkButton></li>
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

        function likes(postID) {
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
                contentType: 'application/json; charset=utf-8',
                dataType: "json", 
                crossDomain: true,
                success: function (data) {
                    $('#divSum2').html(data.d);
                },

            });
        }

        function commentLikes(commentId) {
            $('#heart-comment' + commentId).toggleClass("is-active");
            var commentLikes = $("#commentLikeCount" + commentId).html();
            commentLikeCount = commentLikes.split(" ");
            var commentHeartDiv = document.getElementById('heart-comment' + commentId);
            var isContainActive = commentHeartDiv.classList.contains("is-active");
            var url = "";
            if (isContainActive) {
                commentLikeCount[0]++;
                document.getElementById("commentLikeCount" + commentId).innerHTML = commentLikeCount[0] + " likes";
                url = 'WebService1.asmx/IncrementCommentLikes';
            }
            else {
                commentLikeCount[0]--;
                document.getElementById("commentLikeCount" + commentId).innerHTML = commentLikeCount[0] + " likes";
            }
            $.ajax({
                type: 'POST',
                url: url,
                data: '{commentId:' + commentId + '}',
                contentType: 'application/json; charset=utf-8',
                dataType: "json",
                crossDomain: true,
                success: function (data) {
                    $('#divSum2').html(data.d);
                },

            });

        }
    </script>
</asp:Content>
