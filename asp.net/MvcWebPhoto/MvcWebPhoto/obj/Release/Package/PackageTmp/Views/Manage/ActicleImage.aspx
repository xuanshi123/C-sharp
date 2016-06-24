<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
</head>
<body>
    <%using (Html.BeginForm("ActicleImage", "Manage", FormMethod.Post, new { name = "submit", enctype = "multipart/form-data" }))
      { %>
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td>
                上传本地图片：
            </td>
            <td>
                <input name="uploadpic" type="file" size="40" />
            </td>
            <td>
                <input type="submit" value="上传" name="action" />
            </td>
        </tr>
        <tr>
            <td>
                图片地址：
            </td>
            <td colspan="2">
                <input type="text" disabled="disabled" value='<%=ViewData["ImageUrl"] == null ? "" : ViewData["ImageUrl"].ToString() %>'
                    size="55" />
            </td>
        </tr>
    </table>
    <%} %>
</body>
</html>
