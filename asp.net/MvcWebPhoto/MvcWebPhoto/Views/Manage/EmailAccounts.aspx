<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Manage/ViewMasterPageEdit.Master"
    Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        邮箱设置
    </h2>
    <table cellpadding="3" cellspacing="3">
        <tr>
            <td align="right">
                发送邮箱地址：
            </td>
            <td>
                <%: Html.TextBox("SendAddress", ViewData["SendAddress"])%>
                <div class="red">
                    <%:Html.ValidationMessage("validationSendAddress")%></div>
            </td>
        </tr>
        <tr>
            <td align="right">
                发送邮箱端口：
            </td>
            <td>
                <%: Html.TextBox("Port", ViewData["Port"])%>
                <div class="red">
                    <%:Html.ValidationMessage("validationSendPort")%></div>
            </td>
        </tr>
        <tr>
            <td align="right">
                发送邮箱帐号：
            </td>
            <td>
                <%: Html.TextBox("SendAccounts", ViewData["SendAccounts"])%>
                <div class="red">
                    <%:Html.ValidationMessage("validationSendAccounts")%></div>
            </td>
        </tr>
        <tr>
            <td align="right">
                用户名：
            </td>
            <td>
                <%: Html.TextBox("SendUser", ViewData["SendUser"])%>
                <div class="red">
                    <%:Html.ValidationMessage("validationSendUser")%></div>
            </td>
        </tr>
        <tr>
            <td align="right">
                用户密码：
            </td>
            <td>
                <%: Html.TextBox("SendPassword", ViewData["SendPassword"])%>
                <div class="red">
                    <%:Html.ValidationMessage("validationSendPassword")%></div>
            </td>
        </tr>
        <tr>
            <td align="right">
                接收邮箱帐号：
            </td>
            <td>
                <%: Html.TextBox("ReceiveAccounts", ViewData["ReceiveAccounts"])%>
                <div class="red">
                    <%:Html.ValidationMessage("validationReceiveAccounts")%></div>
        </tr>
    </table>
</asp:Content>
