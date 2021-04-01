<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TuskKer.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style type="text/css">
        #cf {
                position:relative;
                height:281px;
                width:450px;
                margin:0 auto;
                z-index: -1;
            }

            #cf img {
                position: absolute;
                left: 0;
                -webkit-transition: opacity 1s ease-in-out;
                -moz-transition: opacity 1s ease-in-out;
                -o-transition: opacity 1s ease-in-out;
                transition: opacity 1s ease-in-out;
                z-index: -1;
            }

        #cf img.top:hover {
                                opacity: 0;
                                z-index: -1;
                          }

        .auto-style4 {
            font-size: medium;
            -webkit-border-radius: 50px;
            -moz-border-radius: 50px;
            border-radius: 50px;
            width: 150px;
            
        }

        .auto-style5 {
            height: 54px;
            width: 391px;
            text-align: center;
        }

        .auto-style6 {
            height: 80px;
            width: 390px;
            text-align: center;
        }
        .auto-style7 {
            -moz-border-radius: 20px;
            -webkit-border-radius: 20px;
            border-radius: 20px;
                }
        .auto-style7 {
            font-size: x-large;
        }

        .buttom {
            float: left;
            left: 0;
            top: 0px;
            width: 1520px;
            height: 738px;
        }
        .auto-style9 {
            width: 377px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="auto-style9">
        <div id="cf">
            <img class="buttom" src="images/Fade/a12xm-n6wrn.jpg" />
            <img class="top" src="images/Fade/a2d81-x3rpx.jpg" style="left: 0; top: 0px; height: 738px; width: 1519px" />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />

        <div class="auto-style5">
            <asp:TextBox ID="TextBox1" placeholder="Username" runat="server" Height="35px" Width="339px" CssClass="auto-style4" style="text-align:center;" Rows="1"></asp:TextBox>
        </div>

        <div class="auto-style5">
            <asp:TextBox ID="TextBox2" type="password" placeholder="Password" runat="server" Height="35px" Width="339px" CssClass="auto-style4" style="text-align:center;" Rows="1" TextMode="Password"></asp:TextBox>
        </div>

        <br />
        <div class="auto-style6">
            <asp:Button ID="Button1" runat="server" CssClass="auto-style7" Font-Bold="True" Text="Login" Height="50px" Width="183px" Font-Names="Verdana" OnClick="Button1_Click" ForeColor="#999999" />
  
        </div>


        </div>
    </form>
</body>
</html>
