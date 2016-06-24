<%@ Page Title="" Language="C#" MasterPageFile="~/Views/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>"
    ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    联系我们--<%:ViewData["WebTitle"] %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ContactUs">
        <%using (Html.BeginForm("ContactUs", "Home"))
          { %>
        <table>
            <tr>
                <td>
                    CONTACT US联系我们
                </td>
            </tr>
            <tr>
                <td>
                    感谢您关注Babyisart摄影，请提交以下信息，我们会尽快与您取得联系。
                </td>
            </tr>
            <tr>
                <td>
                    姓名Name：<br />
                    <%:Html.TextBox("Name", "", new { @class="text"})%><%:Html.ValidationMessage("validationName") %>
                </td>
            </tr>
            <tr>
                <td>
                    邮箱Email：<br />
                    <%:Html.TextBox("Email", "", new { @class = "text" })%><%:Html.ValidationMessage("validationEmail") %>
                </td>
            </tr>
            <tr>
                <td>
                    手机Mobile：<br />
                    <%:Html.TextBox("Mobile", "", new { @class = "text" })%><%:Html.ValidationMessage("validationMobile") %>
                </td>
            </tr>
            <tr>
                <td>
                    您的信息Your Message：<br />
                    <%:Html.TextArea("Content","",8,50,"") %><%:Html.ValidationMessage("validationContent", new { @class = "validation" })%>
                </td>
            </tr>
            <tr>
                <td>
                    <input type="submit" value="提交" />
                </td>
            </tr>
        </table>
        <%} %>
    </div>
</asp:Content>
