<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Manage/ViewMasterPageEdit.Master"
    Inherits="System.Web.Mvc.ViewPage<MvcWebPhoto.Models.Entities.Article>" ValidateRequest="false" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% SelectList Categories = ViewData["Categories"] as SelectList; %>
    <h2>
        文章维护</h2>
    <p>
        标题：<%: Html.TextBox("Title", ViewData["Title"], new { @class = "text_title" })%>
        <div class="red">
            <%:Html.ValidationMessage("validationTitle")%></div>
    </p>
    <p>
        分类：<%:Html.DropDownList("CatalogID",Categories,ViewData["CatalogID"])%>
        <div class="red">
            <%:Html.ValidationMessage("validationCatalog")%></div>
    </p>
    <iframe src="/Manage/ActicleImage" id="iframe1" frameborder="0" scrolling="no" style="width: 600px;
        height: 60px;"></iframe>
    <p>
        内容：<%: Html.Hidden("Content", ViewData["Content"].ToString())%>
        <div class="red">
            <%:Html.ValidationMessage("validationContent")%></div>
        <iframe id="eWebEditor1" src="../../eWebEditor/ewebeditor.htm?id=Content&style=coolblue"
            frameborder="0" scrolling="no" width="600" height="350"></iframe>
    </p>
    <p>
        创建时间：<%: Html.Label(ViewData["CreateDate"].ToString()) %>
    </p>
</asp:Content>
