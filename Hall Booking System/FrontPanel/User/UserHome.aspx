<%@ Page Title="" Language="C#" MasterPageFile="~/Content/FrontPanel/FrontPanel.master" AutoEventWireup="true" CodeFile="UserHome.aspx.cs" Inherits="FrontPanel_User_UserHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageTitle" runat="Server">
    <h1 class="header-title">User</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNavigation" runat="Server">
    <li class="breadcrumb-item active">UserProfile</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <div class="row">
        <div class="col-12">
            <div class="card">
                <div class="card-header">
                    <div class="row">
                        <div class="col-md-4">
                            <h5 class="card-title mb-0">User Profile</h5>
                        </div>
                        <div class="col-md-8">
                            <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger" EnableViewState="false" />
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-4 custom-align-userImg">
                            <asp:Image ID="imgUserPhoto" runat="server" CssClass="rounded-circle img-responsive" Width="176" Height="176" AlternateText="User Image" />
                            <div class="mt-2">
                                <span class="btn btn-primary" data-toggle="modal" data-target="#staticBackdrop"><i class="fas fa-upload"></i>&nbsp;Edit</span>
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="row">
                                <div class="col-md-12 pb-2">
                                    <h1 class="h1-phone-view">
                                        <asp:Label ID="lblUsername" runat="server"></asp:Label></h1>
                                </div>
                                <div class=" col-md-12 ml-2 mr-2 dropdown-divider"></div>
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <span class="font-weight-normal float-left">Details</span>
                                            <asp:LinkButton ID="libtnEdit" runat="server" CssClass="font-weight-normal float-right" OnClick="btnEdit_Click"><i class="fa fa-edit"></i>Edit</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 ml-2 mr-2 dropdown-divider"></div>
                                <div class="col-md-12 pb-3">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="row custom-font-size">
                                                <div class="col-md-4 custom-font-color">Display Name</div>
                                                <div class="col-md-4">
                                                    <asp:Label ID="lblDisplayName" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 pb-3">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="row custom-font-size">
                                                <div class="col-md-4 custom-font-color">Phone No</div>
                                                <div class="col-md-4">
                                                    <asp:Label ID="lblPhoneNo" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 pb-3">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="row custom-font-size">
                                                <div class="col-md-4 custom-font-color">Email</div>
                                                <div class="col-md-4">
                                                    <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 pb-3">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="row custom-font-size">
                                                <div class="col-md-4 custom-font-color">BirthDate</div>
                                                <div class="col-md-4">
                                                    <asp:Label ID="lblBirthDate" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 pb-3">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="row custom-font-size">
                                                <div class="col-md-4 custom-font-color">Gender</div>
                                                <div class="col-md-4">
                                                    <asp:Label ID="lblGender" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Button trigger modal -->
        <div class="modal fade" id="staticBackdrop" data-backdrop="static" tabindex="-1" role="dialog" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="staticBackdropLabel">Update Photo</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group row">
                            <label class="col-md-3">Upload Photo</label>
                            <div class="col-md-9">
                                <asp:FileUpload ID="fuUserPhoto" runat="server" />
                                <asp:RequiredFieldValidator ID="rfvUserPhoto" runat="server"
                                    ErrorMessage="Select One Photo" CssClass="text-danger"
                                    ControlToValidate="fuUserPhoto" SetFocusOnError="True"
                                    Display="Dynamic" ValidationGroup="Upload" />
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                        <asp:Button ID="btnUpload" runat="server" CssClass="btn btn-primary" ValidationGroup="Upload" Text="Save changes" OnClick="btnUpload_Click"></asp:Button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScript" runat="Server">
</asp:Content>

