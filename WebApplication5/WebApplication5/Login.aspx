<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication5.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login To Mobile Shop Management System</title>
    <link rel="stylesheet" href="style.css" />
</head>
<body>
    <div class="Loginbox" >
        <img src="Master Page layout/dist/img/icon.png" alt="Alternate Text" class="user" />
        <h2>Log In Here</h2>
        <form runat="server">
            <asp:Label Text="Email" CssClass="lblemail" runat="server" />
            <asp:TextBox ID="textbox1" runat="server" CssClass="txtemail" placeholder="Enter Email" AutoCompleteType="Disabled" />
            <asp:Label Text="Password" CssClass="lblpass" runat="server" />
            <asp:TextBox ID="textbox2" runat="server" type="password" CssClass="txtpass" placeholder="********" />

            <asp:Button runat="server" CssClass="btnsubmit" Text="Sign In" OnClick="Unnamed5_Click" />
            <asp:LinkButton runat="server" CssClass="btnforget" Text="Forget Password" />
            <br /><br />
            <asp:Label Text="" id="lblinvalid" CssClass="lblinvalid" runat="server" style="color: red; font-weight: bold; text-align: center; font-size: 17px; text-align: center;"/>

        </form>
    </div>
</body>
</html>
