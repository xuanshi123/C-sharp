<%@ Page Title="" Language="C#" MasterPageFile="~/Views/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%: Html.ActionLink("登陆", "Login","Manage")%>
    <%: Html.ActionLink("首页", "Default","Home")%>
</asp:Content>
