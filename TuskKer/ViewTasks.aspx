<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewTasks.aspx.cs" Inherits="TuskKer.ViewTasks" %>

<!DOCTYPE html>
<html>

<head>
    <title>Tasks</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no">
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i">
    <link rel="stylesheet" href="assets/fonts/fontawesome-all.min.css">
    <link rel="stylesheet" href="assets/fonts/font-awesome.min.css">
    <link rel="stylesheet" href="assets/fonts/fontawesome5-overrides.min.css">

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
    <form id="form1" runat="server">
    <div id="wrapper">
        <nav class="navbar navbar-dark align-items-start sidebar sidebar-dark accordion bg-gradient-primary p-0">
            <div class="container-fluid d-flex flex-column p-0">
                <a class="navbar-brand d-flex justify-content-center align-items-center sidebar-brand m-0" href="#">
                    <div class="sidebar-brand-icon rotate-n-15"><i class="fas fa-laugh-wink"></i></div>
                    <div class="sidebar-brand-text mx-3"><span>Tuskker</span></div>
                </a>
                <hr class="sidebar-divider my-0">
                <ul class="nav navbar-nav text-light" id="accordionSidebar">
                    <li class="nav-item" role="presentation"><a class="nav-link active" href="ViewTasks.aspx"><i class="fas fa-tachometer-alt"></i><span>View Tasks</span></a></li>
                    <li class="nav-item" role="presentation"><a class="nav-link" href="SendATask.aspx"><i class="fas fa-table"></i><span>Send a task<br></span></a></li>
                    <li class="nav-item" role="presentation"><a class="nav-link" href="UnassignedTasks.aspx"><i class="fa fa-tasks"></i><span>All Tasks<br></span></a></li>
 
                    <asp:DropDownList ID="DropDownList1" CssClass="ddl" AutoPostBack="true" OnClick="VerificareSelectare" placeholder="Active Users" runat="server" BackColor="#4E73DF" ForeColor="White" Width="224px">
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
                          <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="float:right" Text="Logout" BackColor="#4E73DF" BorderColor="#4E73DF" Font-Bold="True" Font-Size="Large" Font-Strikeout="False" ForeColor="White"/>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </div>
                    
                    <div class="container-fluid"><button class="btn btn-link d-md-none rounded-circle mr-3" id="sidebarToggleTop" type="button"><i class="fas fa-bars"></i></button>
                        
                    </div>
                </nav>
                
                <div class="container-fluid">
                    <div class="d-sm-flex justify-content-between align-items-center mb-4">

                        <h3 class="text-dark mb-0">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Tasks:<table class="w-100">
                            <tr>
                                <td>
                                    <br />
                                    <asp:Table ID="Table1" runat="server" Width="1250px" BorderColor="#999999" BorderStyle="Solid" GridLines="Horizontal" Height="40px">
                                        <asp:TableHeaderRow 
                                                runat="server" 
                                                ForeColor="Snow"
                                                BackColor="#6666ff"
                                                Font-Bold="false"
                                                font-size= "20px"

                                           >

                                            <asp:TableHeaderCell Width="150">Task Name</asp:TableHeaderCell>
                                            <asp:TableHeaderCell Width="150">Priority Level</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>Task Description</asp:TableHeaderCell>
                                            <asp:TableHeaderCell Width="100">Start</asp:TableHeaderCell>
                                            <asp:TableHeaderCell Width="100">Hold</asp:TableHeaderCell>
                                            <asp:TableHeaderCell Width="100">Stop</asp:TableHeaderCell>
                                            <asp:TableHeaderCell Width="150">Status</asp:TableHeaderCell>
                                            <asp:TableHeaderCell Width="150">Time Remaining</asp:TableHeaderCell>
                                            </asp:TableHeaderRow>


                                        <asp:TableRow runat="server" BackColor="#FF5050" BorderStyle="Solid">
                                        </asp:TableRow>
                                        <asp:TableRow runat="server">
                                        </asp:TableRow>
                                        <asp:TableRow runat="server">
                                        </asp:TableRow>


                                    </asp:Table>
                                </td>
                            </tr>
                            </table>
                        </h3>
                    </div>
                </div>
            </div>
        </div><a class="border rounded d-inline scroll-to-top" href="#page-top"><i class="fas fa-angle-up"></i></a></div>
    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/bootstrap/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-easing/1.4.1/jquery.easing.js"></script>
    <script src="assets/js/theme.js"></script>
    </form>
</body>

</html>
