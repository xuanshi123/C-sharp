<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Manage/ManageSite.Master"
    Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        分类列表</h2>
    <ol>
        <%System.Data.DataTable dt = ViewData["CatalogList"] as System.Data.DataTable; %>
        <%foreach (System.Data.DataRow dr in dt.Rows)
          {
        %>
        <li>
            <%:Html.ActionLink(dr["CatalogName"].ToString(), "CatalogEdit/" + dr["ID"].ToString(), "Manage") %>
        </li>
        <%}%>
    </ol>
</asp:Content>
