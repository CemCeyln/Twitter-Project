<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Twitter_Project.Main" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent>
     <div class="container">
        <div class="row">      
            <asp:Repeater runat="server" ID="postRepeater">
                <ItemTemplate>
                    <asp:HiddenField runat="server" ID="postId" />
                    <asp:Label runat="server" ID="descriptionLabel"></asp:Label>
                </ItemTemplate>
            </asp:Repeater>
         </div>    
         <asp:Label runat="server" ID="userName"></asp:Label>
     </div>   
</asp:Content>