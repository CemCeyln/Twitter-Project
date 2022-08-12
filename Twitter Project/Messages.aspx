<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Messages.aspx.cs" Inherits="Twitter_Project.Messages" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin: 60px auto;
  background: #fff;
  padding: 0;
  border-radius: 7px;">
	<div class="row no-gutters">
	  <div class="col-md-4 border-right">
		<div class="settings-tray">
		  <img class="profile-image" src="File" runat="server" ID="profileImage" alt="Profile img">
			<asp:Label runat="server" ID="nameLabel"></asp:Label>
		</div>
		<div class="search-box">
		  <div class="input-wrapper">
			<i class="material-icons">search</i>
			<input class="messages-input" placeholder="Search here" type="text">
		  </div>
		</div>
		  <asp:Repeater runat="server" ID="chatRepeater">
			  <ItemTemplate>
				  <div class="friend-drawer friend-drawer--onhover">
		  <img class="profile-image" src="https://www.clarity-enhanced.net/wp-content/uploads/2020/06/robocop.jpg" alt="">
		  <div class="text">
			<h6>Robo Cop</h6>
			<p class="text-muted">Hey, you're arrested!</p>
		  </div>
		  <span class="time text-muted small">13:21</span>
		</div>
			  </ItemTemplate>			  
		  </asp:Repeater>
		
		<hr>
	  <div class="col-md-8">
		<div class="settings-tray">
			<div class="friend-drawer no-gutters friend-drawer--grey">
			<img class="profile-image" src="https://www.clarity-enhanced.net/wp-content/uploads/2020/06/robocop.jpg" alt="">
			<div class="text">
			  <h6>Robo Cop</h6>
			  <p class="text-muted">Layin' down the law since like before Christ...</p>
			</div>
		  </div>
		</div>
		<div class="chat-panel">
		  <div class="row no-gutters">
			<div class="col-md-3">
			  <div class="chat-bubble chat-bubble--left">
				Hello dude!
			  </div>
			</div>
		  </div>
		  <div class="row no-gutters">
			<div class="col-md-3 offset-md-9 my-message">
			  <div class="chat-bubble chat-bubble--right color-my-message">
				Hello dude!
			  </div>
			</div>
		  </div>
		  <div class="row no-gutters">
			<div class="col-md-3 offset-md-9 my-message">
			  <div class="chat-bubble chat-bubble--right color-my-message">
				Hello dude!
			  </div>
			</div>
		  </div>
		  <div class="row no-gutters">
			<div class="col-md-3">
			  <div class="chat-bubble chat-bubble--left">
				Hello dude!
			  </div>
			</div>
		  </div>
		  <div class="row no-gutters">
			<div class="col-md-3">
			  <div class="chat-bubble chat-bubble--left">
				Hello dude!
			  </div>
			</div>
		  </div>
		  <div class="row no-gutters">
			<div class="col-md-3">
			  <div class="chat-bubble chat-bubble--left">
				Hello dude!
			  </div>
			</div>
		  </div>
		  <div class="row no-gutters">
			<div class="col-md-3 offset-md-9 my-message">
			  <div class="chat-bubble chat-bubble--right color-my-message">
				Hello dude!
			  </div>
			</div>
		  </div>
		  <div class="row">
			<div class="col-12">
			  <div class="chat-box-tray">
				<i class="material-icons">sentiment_very_satisfied</i>
				<input class="messages-input" style="margin: 0 10px;
    padding: 6px 2px;" type="text" placeholder="Type your message here...">
				<i class="material-icons" style="color: grey;
    font-size: 30px;
    vertical-align: middle;">mic</i>
				<i class="material-icons"
    style="font-size: 30px;
    vertical-align: middle;">send</i>
			  </div>
			</div>
		  </div>
		</div>
	  </div>
	</div>
  </div>
		</div>

	<script>
        $('.friend-drawer--onhover').on('click', function () {

            $('.chat-bubble').hide('slow').show('slow');
        });

    </script>
	    </asp:Content>
