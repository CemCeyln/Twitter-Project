<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Twitter_Project.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <asp:Repeater ID="postRepeater" runat="server">
                <ItemTemplate>
                    <div class="col-lg-6 col-md-8 login-box">
                 <asp:Label runat="server" class="form-control-label" style="font-size:20px; display:flex" Text='<%#Eval("userName") %>'><</asp:Label>
                <div class="col-lg-3 col-md-2" style="height:300px; align-items:center">
                    <image src='File/<%#Eval("post.filePath") %>' style="max-height:290px !important"></image>
                </div>
            </div>
                </ItemTemplate>               
            </asp:Repeater>
            <!--- 
            <div class="col-lg-6 col-md-8 login-box">
                 <asp:Label runat="server" id="PostOwnerLabel" class="form-control-label" style="font-size:20px; display:flex">Post Owner</asp:Label>
                <div class="col-lg-3 col-md-2" style="height:300px; align-items:center">
                    <image src="File/windows-xp.jpg" style="max-height:290px !important"></image>
                </div>
            </div>
                -->
        </div> 
                
</div>
</asp:Content>
