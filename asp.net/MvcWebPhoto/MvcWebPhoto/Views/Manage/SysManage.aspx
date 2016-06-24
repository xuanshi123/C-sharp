<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Manage/ViewMasterPageEdit.Master"
    Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%:Html.Label(ViewData["ExPlain"].ToString()) %></h2>
    <p>
        内容：<%: Html.Hidden("Content", ViewData["Content"])%>
        <iframe id="eWebEditor1" src="../../eWebEditor/ewebeditor.htm?id=Content&style=coolblue"
            frameborder="0" scrolling="no" width="600" height="350"></iframe>
        <div class="red">
            <%:Html.ValidationMessage("validationContent")%></div>
    </p>
</asp:Content>
