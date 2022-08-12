<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Settings.aspx.cs" Inherits="Twitter_Project.Settings" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script>
        function showPreview(event) {
            if (event.target.files.length > 0) {
                var src = URL.createObjectURL(event.target.files[0]);
                document.getElementById("<%=ProfilePicture.ClientID %>").setAttribute('src', src);
                //$('.avatar').attr("src", URL.createObjectURL(src));
            }
        }
    </script>
    <div class="container">
        <div class="row">
            <div class="col-lg-3 col-md-2"></div>
            <div class="col-lg-6 col-md-8 login-box">
                <div class="col-lg-12 login-title">
                </div>
                <div class="col-lg-12 login-form">
                    <div class="col-lg-12 login-form">
                        <form>
                            <div class="form-group">
                                <asp:Label runat="server" ID="NameLabel" Text="Name Surname" class="form-control-label"></asp:Label>
                                <asp:TextBox ID="Name" runat="server" TextMode="SingleLine" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" ID="EmailLabel" Text="E-mail" class="form-control-label"></asp:Label>
                                <asp:TextBox ID="Email" runat="server" TextMode="SingleLine" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" ID="ProfilePictureLabel" class="form-control-label"></asp:Label>
                                <asp:FileUpload ID="ProfilePictureUpload" runat="server" Style="color: #0DB8DE" onChange="showPreview(event)"></asp:FileUpload>
                                <asp:Image ID="ProfilePicture" runat="server" class="avatar" />
                            </div>
                            <div class="col-lg-12 loginbttm">
                                <div class="col-lg-6 login-btm login-text">
                                    <asp:Label runat="server" ID="ErrorMessageLabel" ForeColor="Red" class="form-control-label"></asp:Label>
                                </div>
                                <div class="col-lg-6 login-btm login-button">
                                    <asp:Button runat="server" ID="UpdateButton" Text="Update" OnClick="UpdateButton_Click" class="btn btn-outline-primary" Style="line-height: 0" />
                                </div>
                                <br />
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
