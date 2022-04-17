<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminResetPassword.aspx.cs" Inherits="AdminPanel_Authorization_AdminResetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <title>Admin Reset Password</title>

    <!-- Main CSS File -->
    <style>
        body {
            opacity: 0;
        }
    </style>
    <link rel="stylesheet" href="<%=ResolveClientUrl("~/Content/FrontPanel/Assets/css/modern.css") %>" />
    <link rel="stylesheet" href="<%=ResolveClientUrl("~/Content/FrontPanel/Assets/css/custom.css") %>" />
</head>
<body class="theme-blue">
    <div class="splash active">
        <div class="splash-icon"></div>
    </div>

    <main class="main h-100 w-100">
        <div class="container h-100">
            <div class="row h-100">
                <div class="col-sm-10 col-md-8 col-lg-6 mx-auto d-table h-100">
                    <div class="d-table-cell align-middle">

                        <div class="text-center mt-4">
                            <h1 class="h2">Reset password</h1>
                            <p class="lead">
                                Enter your email to reset your password.
                            </p>
                        </div>

                        <div class="card">
                            <div class="card-body">
                                <div class="m-sm-4">
                                    <form id="form1" runat="server">
                                        <div class="form-group">
                                            <label><i class="fa fa-envelope"></i>&nbsp;Email<span class="text-danger">&nbsp;*</span></label>
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control form-control-lg" placeholder="Enter Email"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
                                                ErrorMessage="Enter Email"
                                                CssClass="text-danger font-weight-400" SetFocusOnError="true" Display="Dynamic"
                                                ControlToValidate="txtEmail" ValidationGroup="Login" />
                                            <asp:RegularExpressionValidator ID="revEmail" runat="server"
                                                ErrorMessage="Enter Proper Email"
                                                CssClass="text-danger font-weight-400" SetFocusOnError="True" Display="Dynamic"
                                                ControlToValidate="txtEmail" ValidationGroup="Login"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                        </div>
                                        <div class="text-center mt-3">
                                            <asp:Button ID="btnResetPassword" runat="server" ValidationGroup="Login" Text="Reset Password" CssClass="btn btn-lg btn-primary" OnClick="btnResetPassword_Click" />
                                        </div>
                                        <div class="text-center mt-2">
                                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                        </div>
                                        <div class="text-center mt-2">
                                            Go to&nbsp;<a href='<%=ResolveClientUrl("~/AdminPanel/Authorization/AdminLogin.aspx") %>'>SignIn</a>&nbsp;Page
                                        </div>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>

    <svg width="0" height="0" style="position: absolute">
        <defs>
            <symbol viewBox="0 0 512 512" id="ion-ios-pulse-strong">
                <path
                    d="M448 273.001c-21.27 0-39.296 13.999-45.596 32.999h-38.857l-28.361-85.417a15.999 15.999 0 0 0-15.183-10.956c-.112 0-.224 0-.335.004a15.997 15.997 0 0 0-15.049 11.588l-44.484 155.262-52.353-314.108C206.535 54.893 200.333 48 192 48s-13.693 5.776-15.525 13.135L115.496 306H16v31.999h112c7.348 0 13.75-5.003 15.525-12.134l45.368-182.177 51.324 307.94c1.229 7.377 7.397 11.92 14.864 12.344.308.018.614.028.919.028 7.097 0 13.406-3.701 15.381-10.594l49.744-173.617 15.689 47.252A16.001 16.001 0 0 0 352 337.999h51.108C409.973 355.999 427.477 369 448 369c26.511 0 48-22.492 48-49 0-26.509-21.489-46.999-48-46.999z">
                </path>
            </symbol>
        </defs>
    </svg>
    <!-- Main JS File -->
    <script src="<%=ResolveClientUrl("~/Content/FrontPanel/Assets/js/app.js") %>"></script>
    <script src="<%=ResolveClientUrl("~/Content/FrontPanel/Assets/js/custom.js") %>"></script>
</body>
</html>
