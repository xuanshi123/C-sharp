<%@ Page Title="" Language="C#" MasterPageFile="~/Views/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    分类-<%:ViewData["WebTitle"] %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%System.Data.DataTable dt = ViewData["Article_Category"] as System.Data.DataTable; %>
    <div class="Default">
        <ul>
            <%foreach (System.Data.DataRow dr in dt.Rows)
              { %>
            <li>
                <%:dr["Title"].ToString() %>
            </li>
            <li>
                <%:dr["Content"].ToString()%></li>
            <%} %>
        </ul>
    </div>
</asp:Content>
