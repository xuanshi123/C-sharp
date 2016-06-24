<%@ Page Title="" Language="C#" MasterPageFile="~/Views/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    FAQ-<%:ViewData["WebTitle"] %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="FAQ">
        <%System.Data.DataTable dt = ViewData["FAQList"] as System.Data.DataTable; %>
        <%foreach (System.Data.DataRow dr in dt.Rows)
          {%>
        <div class="title">
            <%: dr["Title"].ToString() %></div>
        <div class="content">
            <%=dr["Content"].ToString() %></div>
        <%} %>
        </ul>
    </div>
</asp:Content>
