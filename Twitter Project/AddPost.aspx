<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPost.aspx.cs" Inherits="Twitter_Project.AddPost" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Share a Post</title>
</head>
<body>
    <div class="container">
 <div class="row">
    <div class="col-lg-3 col-md-2"></div>
    <div class="col-lg-6 col-md-8 login-box">
        <div class="col-lg-12 login-title">
            <asp:Label runat="server" id="RegisterLabel" class="form-control-label" style="font-size:40px"></asp:Label>
        </div>

        <div class="col-lg-12 login-form">
            <div class="col-lg-12 login-form">
                <form>
                    <div class="form-group">
                        <asp:Label runat="server" id="DescriptionLabel" Text="Description" class="form-control-label"></asp:Label>
                        <asp:TextBox ID="Description" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox> 
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" id="PostPictureLabel" class="form-control-label"></asp:Label>
                        <asp:FileUpload id="PostsPictureUpload" runat="server" style="color:#0DB8DE"></asp:FileUpload>
                        <img id="preview" src="#"/>
                    </div>
                    <div class="col-lg-12 loginbttm">
                        <div class="col-lg-6 login-btm login-text">
                            <asp:Label runat="server" id="ErrorMessageLabel" ForeColor="Red" class="form-control-label"></asp:Label>
                        </div>
                        <div class="col-lg-6 login-btm login-button">
                            <asp:Button runat="server" id="UpdateButton" text="Update" OnClick="UpdateButton_Click" class="btn btn-outline-primary" style="line-height:0"/>
                        </div>
                        <br />                                                                   
                    </div>
                </form>
            </div>
        </div>
    </div>
</div>

</div>
</body>
</html>
