<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login</title>
    <link rel="stylesheet" href="StyleSheet1.css" type="text/css" />
</head>
<body>
    <div id="loginpage" class="login-page">
        <div class="form">

            <form id="form1" runat="server" class="login-form">
                            <asp:TextBox placeholder="User name" runat="server" ID="txbUsername"></asp:TextBox>
                            <asp:TextBox placeholder="Password" runat="server" ID="txbPassword" TextMode="Password"></asp:TextBox>
                            <asp:Button runat="server" ID="btnLogin" Text="Login" OnClick="btnLogin_Click" />
                <div>
                    <asp:Label runat="server" ID="lbMsg" ForeColor="Red"></asp:Label>
                </div>
            </form>
        </div>
    </div>
</body>
</html>
