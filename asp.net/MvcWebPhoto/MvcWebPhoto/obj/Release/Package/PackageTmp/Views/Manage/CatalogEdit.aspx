<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Manage/ViewMasterPageEdit.Master"
    Inherits="System.Web.Mvc.ViewPage<MvcWebPhoto.Models.Entities.Catalog>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        分类维护</h2>
    <div class="red">
        <%:Html.ValidationMessage("validationDelError") %></div>
    <p>
        标题：<%: Html.TextBox("CatalogName", ViewData["CatalogName"])%>
        <div class="red">
            <%:Html.ValidationMessage("validationCatalogName")%></div>
    </p>
    <p>
        创建时间：<%: Html.Label(ViewData["CreateDate"].ToString()) %>
    </p>
</asp:Content>
