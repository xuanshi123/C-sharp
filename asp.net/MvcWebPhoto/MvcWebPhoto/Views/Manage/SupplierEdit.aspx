<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Manage/ViewMasterPageEdit.Master"
    Inherits="System.Web.Mvc.ViewPage<MvcWebPhoto.Models.Entities.Supplier>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        赞助商维护</h2>
    <p>
        赞助商名称：<%: Html.TextBox("SupplierName", ViewData["SupplierName"])%>
        <div class="red">
            <%:Html.ValidationMessage("validationSupplierName")%></div>
    </p>
    <p>
        赞助商地址：<%: Html.TextBox("SupplierUrl", ViewData["SupplierUrl"])%>
        <div class="red">
            <%:Html.ValidationMessage("validationSupplierUrl")%></div>
    </p>
    <p>
        创建时间：<%: Html.Label(ViewData["CreateDate"].ToString()) %>
    </p>
</asp:Content>
