<%@ Page Title="" Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="Index.aspx.vb" Inherits="Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div role="main" class="ui-content  section-first" >
        <div class="main-section-title" style="text-align:center;">
            SELECT WORKSTATION
        </div>
    </div>
    <div role="main" class="ui-content">
        <div class="ui-grid-a" id="wsList" runat="server">

        </div>
    </div>
</asp:Content>

