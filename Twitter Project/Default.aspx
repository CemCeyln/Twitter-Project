<%@ Page Title="Login" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Twitter_Project._Default" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Log in</title>
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/custom.css" rel="stylesheet" />
    <script src="Scripts/boostrap.bundle.min.js"></script>
 </head>
    <body>
  <div class="container">
        <div class="row">
            <div class="col-lg-3 col-md-2"></div>
            <div class="col-lg-6 col-md-8 login-box">
                <div class="col-lg-12 login-key">
                    <i class="fa fa-key" aria-hidden="true"></i>
                </div>
                <div class="col-lg-12 login-title">
                    <asp:Label runat="server" id="WelcomeLabel" class="form-control-label" style="font-size:40px"></asp:Label>
                </div>

                <div class="col-lg-12 login-form">
                    <div class="col-lg-12 login-form">
                        <form runat="server">
                            <div class="form-group">
                            <asp:Label runat="server" id="LanguageLabel"  class="form-control-label"></asp:Label>
                              <asp:DropDownList ID="LanguageDropDownList" runat="server" Width="100px" Height="30px" onselectedindexchanged="SelectedIndexChanged" AutoPostback="True" class="dropdown-list-outline-primary " placeholder="Email"> </asp:DropDownList>
                             </div>
                            <div class="form-group">
                                <asp:Label runat="server" id="EmailLabel" Text="Email" class="form-control-label"></asp:Label>
                                <asp:TextBox ID="Email" runat="server" TextMode="SingleLine" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                 <asp:Label runat="server" id="PasswordLabel" class="form-control-label"></asp:Label>
                                <asp:TextBox ID="Password" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
                            </div>

                            <div class="col-lg-12 loginbttm">
                                <div class="col-lg-6 login-btm login-text">
                                    <asp:Label runat="server" id="ErrorMessageLabel" ForeColor="Red" class="form-control-label"></asp:Label>
                                </div>
                                <div class="col-lg-6 login-btm login-button">
                                    <asp:Button runat="server" id="LoginButton"  OnClick="LoginButton_Click"  class="btn btn-outline-primary"/>
                                </div>
                                <br />
                                <div class="col-lg-12 login-title">
                                    <asp:Label runat="server" id="OrLabel" class="form-control-label"></asp:Label>
                                      <br />
                                <div style="margin-bottom:15px">
                                   <asp:Button runat="server" id="RegisterButton"  OnClick="RegisterButton_Click" CssClass="btn btn-outline-primary"/> 
                                </div>
                                </div>                                                                    
                            </div>
                        </form>
                    </div>
                </div>
                <div class="col-lg-3 col-md-2"></div>
            </div>
        </div> 
</div>
    </body>
  
</html>