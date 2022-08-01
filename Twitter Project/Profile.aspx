<%@ Page Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Twitter_Project.Profile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<script>
ProfilePictureUpload.onchange = evt => {
    const [file] = ProfilePictureUpload.files
    console.log("a");
    if (file) {
        preview.src = URL.createObjectURL(file)
    }
}
</script>
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
                        <asp:Label runat="server" id="NameLabel" Text="Name Surname" class="form-control-label"></asp:Label>
                        <asp:TextBox ID="Name" runat="server" TextMode="SingleLine" CssClass="form-control"></asp:TextBox> 
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" id="EmailLabel" Text="E-mail"  class="form-control-label"></asp:Label>
                        <asp:TextBox ID="Email" runat="server" TextMode="SingleLine" CssClass="form-control"></asp:TextBox> 
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" id="ProfilePictureLabel" class="form-control-label"></asp:Label>
                        <asp:FileUpload id="ProfilePictureUpload" runat="server" style="color:#0DB8DE"></asp:FileUpload>
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
</asp:Content>
