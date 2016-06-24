<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Manage/ManageSite.Master"
    Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        文章管理</h2>
    <%System.Data.DataTable dt = ViewData["ArticleList"] as System.Data.DataTable; %>
    <ol>
        <%foreach (System.Data.DataRow dr in dt.Rows)
          { %>
        <li>
            <%:Html.ActionLink(dr["Title"].ToString(), "ArticleEdit/"+dr["ID"].ToString(), "Manage") %>
        </li>
        <%}%>
    </ol>
</asp:Content>
