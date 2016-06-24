<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Manage/ViewMasterPageEdit.Master"
    Inherits="System.Web.Mvc.ViewPage<MvcWebPhoto.Models.Entities.FAQ>" ValidateRequest="false" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        FAQ维护</h2>
    <p>
        标题：<%: Html.TextBox("title", ViewData["title"], new { @class = "text_title" })%>
        <div class="red">
            <%:Html.ValidationMessage("validationTitle")%></div>
    </p>
    <p>
        内容：<%: Html.Hidden("content",ViewData["content"].ToString()) %>
        <iframe id="eWebEditor1" src="../../eWebEditor/ewebeditor.htm?id=content&style=coolblue"
            frameborder="0" scrolling="no" width="600" height="350"></iframe>
        <div class="red">
            <%:Html.ValidationMessage("validationContent")%></div>
    </p>
    <p>
        创建时间：<%: Html.Label(ViewData["CreateDate"].ToString()) %>
    </p>
</asp:Content>
