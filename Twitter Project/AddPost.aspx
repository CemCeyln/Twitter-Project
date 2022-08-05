<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AddPost.aspx.cs" Inherits="Twitter_Project.AddPost" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <script>
        function showPreview(event) {
            if (event.target.files.length > 0) {
                var src = URL.createObjectURL(event.target.files[0]);
                document.getElementById("<%=PostPicture.ClientID %>").setAttribute('src', src);
            }
        }
        </script>
    <div class="container">
        <div class="row">
            <div class="col-lg-3 col-md-2"></div>
            <div class="col-lg-6 col-md-8 login-box">
                <div class="col-lg-12 login-title">
                    <asp:Label runat="server" ID="RegisterLabel" class="form-control-label" Style="font-size: 40px"></asp:Label>
                </div>

                <div class="col-lg-12 login-form">
                    <div class="col-lg-12 login-form">
                        <div class="form-group">
                            <asp:Label runat="server" ID="DescriptionLabel" Text="Description" class="form-control-label"></asp:Label>
                            <asp:TextBox ID="DescriptionTextBox" runat="server" TextMode="SingleLine" CssClass="form-control"></asp:TextBox>
                            <div class="form-group">
                                <asp:Label runat="server" ID="ProfilePictureLabel" class="form-control-label"></asp:Label>
                                <asp:FileUpload ID="ProfilePictureUpload" runat="server" Style="color: #0DB8DE" onChange="showPreview(event)"></asp:FileUpload>
                                <asp:Image ID="PostPicture" runat="server" Style="max-height: 300px" />
                            </div>
                            <div class="col-lg-12 loginbttm">
                                <div class="col-lg-6 login-btm login-text">
                                    <asp:Label runat="server" ID="ErrorMessageLabel" ForeColor="Red" class="form-control-label"></asp:Label>
                                </div>
                                <div class="col-lg-6 login-btm login-button">
                                    <asp:Button runat="server" ID="ShareButton" Text="Share" OnClick="ShareButton_Click" class="btn btn-outline-primary" Style="line-height: 0" />
                                </div>
                                <br />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
