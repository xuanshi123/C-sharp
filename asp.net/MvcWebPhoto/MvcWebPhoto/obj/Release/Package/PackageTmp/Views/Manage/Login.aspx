<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<MvcWebPhoto.Models.Entities.User>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>后台登陆</title>
    <link href="/Content/ManageSite.css" rel="stylesheet" type="text/css" />
</head>
<body style="margin: 0 auto; padding-top: 100px; display: block; width: 300px;">
    <h2>
        后台登陆入口</h2>
    <div>
        <%using (Html.BeginForm("Login", "Manage", FormMethod.Post))
          { %>
        <fieldset>
            <legend>管理员信息</legend>
            <div class="red">
                <%:Html.ValidationMessage("validationLoginError") %></div>
            <div style="margin-bottom: 10px; margin-top: 10px;">
                用户名：<%:Html.TextBoxFor(m => m.UserID)%>
            </div>
            <div class="red">
                <%: Html.ValidationMessage("validationUserID") %></div>
            <div>
                密&nbsp;&nbsp;&nbsp;&nbsp;码：<%:Html.PasswordFor(m => m.PassWord)%>
            </div>
            <div class="red">
                <%:Html.ValidationMessage("validationPassword") %></div>
            <p>
                <input type="submit" value="登录" />
            </p>
        </fieldset>
        <%} %>
    </div>
</body>
</html>
