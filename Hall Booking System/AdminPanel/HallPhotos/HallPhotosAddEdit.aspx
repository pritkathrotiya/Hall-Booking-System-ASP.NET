<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel/AdminPanel.master" AutoEventWireup="true" CodeFile="HallPhotosAddEdit.aspx.cs" Inherits="AdminPanel_HallPhotos_HallPhotosAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageTitle" runat="Server">
    <h1 class="header-title">Hall</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNavigation" runat="Server">
    <li class="breadcrumb-item"><a href='<%=ResolveClientUrl("~/AdminPanel/Dashboard/Dashboard.aspx") %>'>Dashboard</a></li>
    <li class="breadcrumb-item"><a href='<%=ResolveClientUrl("~/AdminPanel/HallPhotos/HallPhotosList.aspx") %>'>HallPhotos</a></li>
    <li class="breadcrumb-item active">HallPhotosEdit</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <div class="row">
        <div class="col-12">
            <div class="card">
                <div class="card-header">
                    <div class="row">
                        <div class="col-md-4">
                            <h5 class="card-title mb-0">Hall Photo Edit</h5>
                        </div>
                        <div class="col-md-8">
                            <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger" EnableViewState="false" />
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <div class="row mb-4">
                        <div class="col-md-4 m-b-4" data-toggle="modal" data-target="#exampleModalCenter" onclick="onclick1()">
                            <asp:Image ID="imgPhoto1" runat="server" CssClass="img-fluid hover-shadow hover-shadow--hover" />
                        </div>
                        <div class="col-md-4 m-b-4" data-toggle="modal" data-target="#exampleModalCenter" onclick="onclick2()">
                            <asp:Image ID="imgPhoto2" runat="server" CssClass="img-fluid hover-shadow hover-shadow--hover" />
                        </div>
                        <div class="col-md-4" data-toggle="modal" data-target="#exampleModalCenter" onclick="onclick3()">
                            <asp:Image ID="imgPhoto3" runat="server" CssClass="img-fluid hover-shadow hover-shadow--hover" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4 m-b-4" data-toggle="modal" data-target="#exampleModalCenter" onclick="onclick4()">
                            <asp:Image ID="imgPhoto4" runat="server" CssClass="img-fluid hover-shadow hover-shadow--hover" />
                        </div>
                        <div class="col-md-4 m-b-4" data-toggle="modal" data-target="#exampleModalCenter" onclick="onclick5()">
                            <asp:Image ID="imgPhoto5" runat="server" CssClass="img-fluid hover-shadow hover-shadow--hover" />
                        </div>
                        <div class="col-md-4" data-toggle="modal" data-target="#exampleModalCenter" onclick="onclick6()">
                            <asp:Image ID="imgPhoto6" runat="server" CssClass="img-fluid hover-shadow hover-shadow--hover" />
                        </div>
                    </div>

                    <!-- Modal Image -->
                    <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                        <div class="modal-dialog modal-dialog-centered" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="exampleModalCenterTitle">
                                        <asp:Label ID="lblImgID" runat="server"></asp:Label>
                                        <asp:HiddenField ID="hfPhotoID" runat="server"></asp:HiddenField>
                                    </h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body text-center">
                                    <asp:Image ID="imgPhoto" CssClass="img-fluid" runat="server" />
                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="btnDefaultPhoto" runat="server" Text="Set Default" CssClass="btn btn-secondary" OnClick="btnDefaultPhoto_Click" />
                                    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#staticBackdrop">Update Photo</button>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- Button trigger modal -->
                    <div class="modal fade bd-example-modal-sm" id="staticBackdrop" data-backdrop="static" tabindex="-1" role="dialog" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                        <div class="modal-dialog modal-sm modal-dialog-centered" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="staticBackdropLabel">Update Photo</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <div class="form-group row">
                                        <div class="col-md-12">
                                            <asp:FileUpload ID="fuHallPhoto" runat="server" />
                                            <asp:RequiredFieldValidator ID="rfvHallPhoto" runat="server"
                                                ErrorMessage="Select One Photo" CssClass="text-danger"
                                                ControlToValidate="fuHallPhoto" SetFocusOnError="True"
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
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScript" runat="Server">
    <script>
        function onclick1() {
            var imgURL = document.getElementById("<%=imgPhoto1.ClientID%>").getAttribute("src");
            document.getElementById("<%=imgPhoto.ClientID%>").setAttribute("src", imgURL);
            document.getElementById("<%=lblImgID.ClientID%>").innerHTML = "Photo1";
            document.getElementById("<%=hfPhotoID.ClientID%>").value = "Photo1";
        }
        function onclick2() {
            var imgURL = document.getElementById("<%=imgPhoto2.ClientID%>").getAttribute("src");
            document.getElementById("<%=imgPhoto.ClientID%>").setAttribute("src", imgURL);
            document.getElementById("<%=lblImgID.ClientID%>").innerHTML = "Photo2";
            document.getElementById("<%=hfPhotoID.ClientID%>").value = "Photo2";
        }
        function onclick3() {
            var imgURL = document.getElementById("<%=imgPhoto3.ClientID%>").getAttribute("src");
            document.getElementById("<%=imgPhoto.ClientID%>").setAttribute("src", imgURL);
            document.getElementById("<%=lblImgID.ClientID%>").innerHTML = "Photo3";
            document.getElementById("<%=hfPhotoID.ClientID%>").value = "Photo3";
        }
        function onclick4() {
            var imgURL = document.getElementById("<%=imgPhoto4.ClientID%>").getAttribute("src");
            document.getElementById("<%=imgPhoto.ClientID%>").setAttribute("src", imgURL);
            document.getElementById("<%=lblImgID.ClientID%>").innerHTML = "Photo4";
            document.getElementById("<%=hfPhotoID.ClientID%>").value = "Photo4";
        }
        function onclick5() {
            var imgURL = document.getElementById("<%=imgPhoto5.ClientID%>").getAttribute("src");
            document.getElementById("<%=imgPhoto.ClientID%>").setAttribute("src", imgURL);
            document.getElementById("<%=lblImgID.ClientID%>").innerHTML = "Photo5";
            document.getElementById("<%=hfPhotoID.ClientID%>").value = "Photo5";
        }
        function onclick6() {
            var imgURL = document.getElementById("<%=imgPhoto6.ClientID%>").getAttribute("src");
            document.getElementById("<%=imgPhoto.ClientID%>").setAttribute("src", imgURL);
            document.getElementById("<%=lblImgID.ClientID%>").innerHTML = "Photo6";
            document.getElementById("<%=hfPhotoID.ClientID%>").value = "Photo6";
        }
    </script>
</asp:Content>

