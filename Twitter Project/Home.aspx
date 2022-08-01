<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Twitter_Project.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">      
            <asp:Repeater ID="postRepeater" runat="server">
                <ItemTemplate>
                     <p style="visibility: hidden" id="postId"><%#Eval("post.postId") %></p>
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
                        <div class="col-lg-6 col-md-8 login-box" style="color: whitesmoke; margin-top: 3px !important">
                            <div class="heart" id="heart">
                                <p id="Likecount"><%#Eval("post.likes")%> likes</p>
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
