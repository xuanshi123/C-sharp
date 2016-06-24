<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Manage/ManageSite.Master"
    Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        欢迎进入<%:ViewData["WebTitle"].ToString() %>--后台管理系统</h2>
        请点击左侧导航进行相关内容维护
</asp:Content>
