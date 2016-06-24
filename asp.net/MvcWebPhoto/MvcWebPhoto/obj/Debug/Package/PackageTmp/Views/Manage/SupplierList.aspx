<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Manage/ManageSite.Master"
    Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        赞助商管理</h2>
    <%System.Data.DataTable dt = ViewData["SupplierList"] as System.Data.DataTable; %>
    <ol>
        <%foreach (System.Data.DataRow dr in dt.Rows)
          { %>
        <li>
            <%:Html.ActionLink(dr["SupplierName"].ToString(), "SupplierEdit/"+dr["ID"].ToString(), "Manage") %>
        </li>
        <%}%>
    </ol>
</asp:Content>
