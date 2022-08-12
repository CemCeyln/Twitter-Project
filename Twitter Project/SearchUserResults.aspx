<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="SearchUserResults.aspx.cs" EnableEventValidation="false" Inherits="Twitter_Project.SearchUserResults" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <asp:Repeater runat="server" ID="profileRepeater" OnItemCommand="ProfileRepeaterItemCommand" OnItemDataBound="ProfileRepeaterItemDataBound">
            <ItemTemplate>
                <div class="row py-5 px-4" style="margin-top:40px; margin-bottom:25px">
                    <div class="col-xl-4 col-md-6 col-sm-10 mx-auto" style="background: #1A2226; color: whitesmoke; margin-left: 57px; height: 250px;">
                        <div class="bg-white shadow rounded">
                            <div class="px-4 pt-0 pb-4 bg-dark">
                                <div class="media align-items-end profile-header">
                                    <div class="profile mr-3">
                                        <img id="profilePicture" src='File/<%#Eval("profilePicture")%>' alt="..." width="130" class="rounded mb-2 img-thumbnail">
                                        <asp:Button runat="server" CssClass="btn btn-outline-primary profile-buttons" ID="followButton" CommandName="Follow" Text="Follow" />
                                        <asp:Button runat="server" CssClass="btn btn-outline-primary profile-buttons" ID="messageButton" Text="Message" />
                                    </div>
                                    <div class="media-body mb-5 text-white">
                                        <asp:LinkButton runat="server" CommandName="Profile" CssClass="mt-0 mb-0 searchNameLink"><%#Eval("Name") %></asp:LinkButton>
                                        <br />
                                        <asp:Label runat="server" CssClass="small mb-4" ID="emailLabel" Text='<%#Eval("Email") %>'></asp:Label>
                                        <asp:Label runat="server" Style="visibility: hidden" ID="profileIdLabel" Text='<%#Eval("UserId") %>'></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="bg-light p-4 d-flex justify-content-end text-center">
                                <ul class="list-inline mb-0">
                                    <li class="list-inline-item">


                                        <asp:Label runat="server" CssClass="font-weight-bold mb-0 d-block" ID="totalPosts" Style="font-size: 16px;" Text='<%#Eval("TotalPost") %>'></asp:Label>
                                        <br />
                                        <small class="text-muted"><i class="fa fa-picture-o mr-1"></i>Photos</small>
                                    </li>
                                    <li class="list-inline-item">
                                        <asp:Label runat="server" CssClass="font-weight-bold mb-0 d-block" ID="totalFollowers" Style="font-size: 16px;" Text='<%#Eval("TotalFollowers") %>'></asp:Label>
                                        <br />
                                        <small class="text-muted"><i class="fa fa-user-circle-o mr-1"></i>Followers</small>
                                    </li>
                                </ul>
                            </div>
                        </div>

                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
