<%@ Page Title="" Language="VB" MasterPageFile="~/MainAdmin.master" AutoEventWireup="false" CodeFile="6kolom.aspx.vb" Inherits="FClass_Maximo_Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../../assets/plugins/datatables/css/jquery.datatables.min.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="page-title">
        <h3>
            <asp:Label ID="lblPageName" runat="server">Failur Class Maximo 6 Kolom</asp:Label></h3>
        <%--<div class="page-breadcrumb">
            <ol class="breadcrumb">
                <li>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Admin/MasterData/Category/Index.aspx">F Class</asp:HyperLink></li>
                <li class="active">
                    <asp:Label ID="lblPageName2" runat="server">Data Category</asp:Label></li>
            </ol>
        </div>--%>
    </div>

    <div id="main-wrapper">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="row">
                    <!-- Accordion -->

                    <div class="col-md-12">
                        <div class="panel panel-white">
                            <div class="panel-body">

                                <div class="row">
                                    <div class="col-md-12">

                                        <table id="DataTable" class="display table" style="width: 100%; cellspacing: 0;">
                                            <thead>
                                                <tr>
                                                    <th>No.</th>
                                                    <th>Class</th>
                                                    <th>D Class</th>
                                                    <th>Code</th>
                                                    <th>D Code</th>
                                                    <th>Cause</th>
                                                    <th>D Cause</th>
                                                </tr>
                                            </thead>
                                            <tbody runat="server" id="tblFClass_Maximo">
                                                <%--Data list category--%>
                                            </tbody>
                                        </table>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <script type="text/javascript" src="../../../assets/plugins/datatables/js/jquery.datatables.min.js"></script>
    <script type="text/javascript">
        /* On UpdatePanel Refresh */
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        if (prm != null) {
            prm.add_endRequest(function (sender, e) {
                if (sender._postBackSettings.panelsToUpdate != null) {
                    showDatatable();
                }
            });
        };

        /* Data Tables */
        function showDatatable() {
            $('#DataTable').DataTable( {
                stateSave: true
            } );
        }
        $(document).ready(function () {
            showDatatable();
        });

    </script>
</asp:Content>

