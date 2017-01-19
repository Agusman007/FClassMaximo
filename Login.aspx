<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login | VisualArt</title>
    
    <!-- Styles -->
    <link href="assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/fontawesome/css/font-awesome.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/toastr/toastr.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/modern.min.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
        /* Notification */
        function showMessageWarning(msg) {
            toastr.warning(msg);
        }

        function showMessageDanger(msg) {
            toastr.error(msg);
        }
    </script>

</head>
<body class="page-login">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true" EnableScriptGlobalization="True">
        </asp:ScriptManager>
        <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
            <Scripts>
                <asp:ScriptReference Path="~/assets/plugins/jquery/jquery-2.1.4.min.js" />
                <asp:ScriptReference Path="~/assets/plugins/jquery-ui/jquery-ui.min.js" />
                <asp:ScriptReference Path="~/assets/bootstrap/js/bootstrap.min.js" />
                <asp:ScriptReference Path="~/assets/plugins/waves/waves.min.js" />
                <asp:ScriptReference Path="~/assets/plugins/toastr/toastr.min.js" />
                <asp:ScriptReference Path="~/assets/js/modern.js" />
            </Scripts>
        </asp:ScriptManagerProxy>

        <main class="page-content">
            <div class="page-inner">
                <div id="main-wrapper">
                    <div class="row">
                        <div class="col-md-3 center">
                            <div class="login-box">
                                <a href="#" class="logo-name text-lg text-center">VISUALART</a>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" data-ajax="false">
                                <ContentTemplate>
                                    <p class="text-center m-t-md"> <asp:Label ID="lblLogin" runat="server" Text="Please login into your account."></asp:Label></p>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Username" autofocus="true"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:DropDownList ID="ddRole" runat="server" AutoPostBack="False" CssClass="form-control" Visible="false">
                                        </asp:DropDownList>
                                    </div>
                                    <div id="errorContainer" runat="server" class="alert alert-danger alert-dismissible" role="alert" style="display:none;">
                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">×</span></button>
                                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                                    </div>                                  
                                    <asp:Button ID="btnSubmit" runat="server" Text="Login" CssClass="btn btn-success btn-block"></asp:Button>
                                    <asp:Button ID="bntLogin" runat="server" Text="Login" CssClass="btn btn-success btn-block" Visible="false"></asp:Button>
                                </ContentTemplate>
                                </asp:UpdatePanel>
                                
                                <p class="text-center m-t-xs text-sm">2016 © Protech.</p>
                            </div>
                        </div>
                    </div><!-- Row -->
                </div><!-- Main Wrapper -->
            </div><!-- Page Inner -->
        </main>
    <!-- Page Content -->
    </form>
    
</body>
</html>
