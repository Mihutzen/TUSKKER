<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendATask.aspx.cs" Inherits="TuskKer.SendATask" %>

<!DOCTYPE html>
<html>

<head>
    <title>Send a Task</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no">
    
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i">
    <link rel="stylesheet" href="assets/fonts/fontawesome-all.min.css">
    <link rel="stylesheet" href="assets/fonts/font-awesome.min.css">
    <link rel="stylesheet" href="assets/fonts/fontawesome5-overrides.min.css">
    <style type="text/css">
        .auto-style2 {
            width: 1027px;
        }
        .auto-style7 {
            width: 142px;
        }
        .auto-style8 {
            width: 141px;
        }
        .auto-style9 {
            width: 743px;
        }
        .auto-style10 {
            width: 1975px;
        }
    </style>

<style type="text/css">
        .ddl
        {
            border:2px solid #4E73DF;
            border-radius:5px;
            padding:3px;
            -webkit-appearance: none; 
            
            background-position:88px;
            background-repeat:no-repeat;
            text-indent: 3.01px;/*In Firefox*/
            text-overflow: '';/*In Firefox*/
        }
</style>
</head>

<body id="page-top">
    <form id="form4" runat="server">
    <div id="wrapper">
        <nav class="navbar navbar-dark align-items-start sidebar sidebar-dark accordion bg-gradient-primary p-0">
            <div class="container-fluid d-flex flex-column p-0">
                <a class="navbar-brand d-flex justify-content-center align-items-center sidebar-brand m-0" href="#">
                    <div class="sidebar-brand-icon rotate-n-15"><i class="fas fa-laugh-wink"></i></div>
                    <div class="sidebar-brand-text mx-3"><span>Tuskker</span></div>
                </a>
                <hr class="sidebar-divider my-0">
                <ul class="nav navbar-nav text-light" id="accordionSidebar">
                    <li class="nav-item" role="presentation"><a class="nav-link" href="ViewTasks.aspx"><i class="fas fa-tachometer-alt"></i><span>View Tasks</span></a></li>
                    <li class="nav-item" role="presentation"><a class="nav-link active" href="SendATask.aspx"><i class="fas fa-table"></i><span>Send a task<br></span></a></li>
                    <li class="nav-item" role="presentation"><a class="nav-link" href="UnassignedTasks.aspx"><i class="fa fa-tasks"></i><span>All Tasks<br></span></a></li>
                   
                    <asp:DropDownList ID="DropDownList12" CssClass="ddl" AutoPostBack="true" OnClick="VerificareSelectare" placeholder="Active Users" runat="server" BackColor="#4E73DF" ForeColor="White" Width="224px">
                        <asp:ListItem>Active Users</asp:ListItem>
                        </asp:DropDownList>
                </ul>
            </div>
        </nav>
        <div class="d-flex flex-column" id="content-wrapper">
            <div id="content">
                <nav class="navbar navbar-light navbar-expand bg-white shadow mb-4 topbar static-top">
                    <div>
                        <br />
                          <asp:Button ID="Button2" runat="server" OnClick="Button1_Click" style="float:right" Text="Logout" BackColor="#4E73DF" BorderColor="#4E73DF" Font-Bold="True" Font-Size="Large" Font-Strikeout="False" ForeColor="White"/>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </div>
                    <div class="container-fluid"><button class="btn btn-link d-md-none rounded-circle mr-3" id="sidebarToggleTop" type="button"><i class="fas fa-bars"></i></button></div>
                </nav>
                <div class="container-fluid">
                    <h3 class="text-dark mb-4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Send a task<br></h3>
                </div>

                <table class="auto-style2">
            <tr>
                <td class="auto-style9"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; GroupID</strong></td>
                <td class="auto-style10">
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="390px">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Task Name</strong></td>
                <td class="auto-style10">
                    <asp:TextBox ID="TextBox2" runat="server" Font-Names="Verdana" Font-Size="Medium" Width="390px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9"><strong><span class="auto-style7">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>Task Description</strong></td>
                <td class="auto-style10">
                    <asp:TextBox ID="TextBox3" runat="server" Font-Names="Verdana" Font-Size="Medium" Height="200px" TextMode="MultiLine" Width="500px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9"><span class="auto-style7"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Priority</strong></span><strong> Level</strong></td>
                <td class="auto-style10">
                    <asp:DropDownList ID="DropDownList2" runat="server" Width="296px">
                    </asp:DropDownList><asp:Label ID="Label2" runat="server" Font-Italic="True" Font-Names="Verdana" Font-Size="10pt" Text="(How early do you want the task to be done)"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9"><span class="auto-style7"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Estimated Time</strong></span></td>
                <td class="auto-style10">
                    <asp:DropDownList ID="DropDownList10" runat="server" Width="148px">
                    </asp:DropDownList>
                    <asp:DropDownList ID="DropDownList11" runat="server" Width="148px">
                    </asp:DropDownList>
                    <asp:Label ID="Label4" runat="server" Font-Italic="True" Font-Names="Verdana" Font-Size="10pt" Text="(How long will take the task to be done)"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9"><span class="auto-style7"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Difficulty</strong></span><strong> Level</strong></td>
                <td class="auto-style10">
                    <asp:DropDownList ID="DropDownList3" runat="server" Width="148px">
                    </asp:DropDownList><asp:Label ID="Label1" runat="server" Font-Italic="True" Font-Names="Verdana" Font-Size="10pt" Text="(1 - High, 5 - Low)"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9">&nbsp; <strong>&nbsp;&nbsp;&nbsp; Skill/s </strong><span class="auto-style7"><strong>Required</strong></span></td>
                <td class="auto-style10">
                    <asp:DropDownList ID="DropDownList7" runat="server" Width="148px">
                    </asp:DropDownList><asp:DropDownList ID="DropDownList8" runat="server" Width="148px">
                    </asp:DropDownList><asp:DropDownList ID="DropDownList9" runat="server" Width="148px">
                    </asp:DropDownList><asp:Label ID="Label3" runat="server" Font-Italic="True" Font-Names="Verdana" Font-Size="10pt" Text="(You need to choose at least one skill)"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Level of the skill/s</strong></td>
                <td class="auto-style10">
                    <asp:DropDownList ID="DropDownList4" runat="server" Width="148px">
                    </asp:DropDownList><asp:DropDownList ID="DropDownList5" runat="server" Width="148px">
                    </asp:DropDownList><asp:DropDownList ID="DropDownList6" runat="server" Width="148px">
                    </asp:DropDownList></td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style10">
                    <asp:Button ID="Button1" runat="server" CssClass="auto-style8" Font-Bold="True" Height="54px" Text="Send" Width="137px" OnClick="Button1_Click1"/>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style10">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
            </div>
        </div><a class="border rounded d-inline scroll-to-top" href="#page-top"><i class="fas fa-angle-up"></i></a></div>
        </form>
    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/bootstrap/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-easing/1.4.1/jquery.easing.js"></script>
    <script src="assets/js/theme.js"></script>
</body>

</html>
