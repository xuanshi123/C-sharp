<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Manage/ManageSite.Master"
    Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        FAQ列表</h2>
    <% System.Data.DataTable dt = ViewData["FAQList"] as System.Data.DataTable; %>
    <div>
        <ol>
            <% foreach (System.Data.DataRow dr in dt.Rows)
               { 
            %>
            <li>
                <%:Html.ActionLink(dr["Title"].ToString(),"FAQEdit/"+dr["ID"].ToString(),"Manage") %></li>
            <%
                }%>
        </ol>
    </div>
</asp:Content>