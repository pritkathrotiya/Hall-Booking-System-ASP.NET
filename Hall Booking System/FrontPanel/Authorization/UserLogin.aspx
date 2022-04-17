<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserLogin.aspx.cs" Inherits="FrontPanel_Login_UserLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <title>User Login</title>

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
                            <h1 class="h2">Welcome back, User</h1>
                            <p class="lead">
                                Sign in to your account to continue
                            </p>
                        </div>

                        <div class="card">
                            <div class="card-body">
                                <div class="m-sm-4">
                                    <form id="form1" runat="server">
                                        <div class="form-group">
                                            <label><i class="fa fa-user"></i>&nbsp;Username</label>
                                            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control form-control-lg" placeholder="Enter Username"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvUsername" runat="server"
                                                ErrorMessage="Enter Username"
                                                CssClass="text-danger" SetFocusOnError="true" Display="Dynamic"
                                                ControlToValidate="txtUsername" ValidationGroup="Login">
                                            </asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <label><i class="fa fa-lock"></i>&nbsp;Password</label>
                                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control form-control-lg" TextMode="Password" placeholder="Enter Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server"
                                                ErrorMessage="Enter Password"
                                                CssClass="text-danger" SetFocusOnError="true" Display="Dynamic"
                                                ControlToValidate="txtPassword" ValidationGroup="Login">
                                            </asp:RequiredFieldValidator>
                                            <small class="float-right">
                                                <a href='<%=ResolveClientUrl("~/FrontPanel/Authorization/UserResetPassword.aspx") %>'>Forgot password?</a>
                                            </small>
                                        </div>
                                        <div>
                                            <div class="custom-control custom-checkbox align-items-center">
                                                <input id="customControlInline" type="checkbox" class="custom-control-input" value="remember-me"
                                                    name="remember-me" checked>
                                                <label class="custom-control-label text-small" for="customControlInline">Remember me next time</label>
                                            </div>
                                        </div>
                                        <div class="text-center mt-3">
                                            <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-lg btn-primary" Text="Sign in" ValidationGroup="Login" OnClick="btnLogin_Click"/>
                                        </div>
                                        <div class="text-center mt-2">
                                            <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger"></asp:Label>
                                        </div>
                                        <div class="text-center mt-2">
                                            Don't have an account?&nbsp;<a href='<%=ResolveClientUrl("~/FrontPanel/Authorization/UserRegistration.aspx") %>'>Sign Up </a>
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
