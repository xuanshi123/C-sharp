<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Manage/ViewMasterPageEdit.Master"
    Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        网站Logo管理</h2>
    <table>
        <tr>
            <td>
                说明：只能上传gif图片，网站不限定图片大小,请上传合适大小的图片，如果图片大小过大，会造成网站变形等问题。
            </td>
        </tr>
        <tr>
            <td>
                Logo：<input name="uploadpic" type="file" size="80" />
                <input type="submit" value="保存" name="action" />
                <div class="red">
                    <%:Html.ValidationMessage("validationLogoError")%></div>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <h2>
        网站幻灯片管理</h2>
    <table>
        <tr>
            <td>
                说明：只能上传gif图片，推荐大小为1000pxX350px，如果原图不是该大小，网站会自动将图片拉伸为该大小，可能会造成图片变形等问题。
            </td>
        </tr>
        <tr>
            <td>
                幻灯片一：<input name="uploadpic1" type="file" size="80" />
                <input type="submit" value="保存1" name="action" />
                <div class="red">
                    <%:Html.ValidationMessage("validationLogoError1")%></div>
            </td>
        </tr>
        <tr>
            <td>
                幻灯片二：<input name="uploadpic2" type="file" size="80" />
                <input type="submit" value="保存2" name="action" />
                <div class="red">
                    <%:Html.ValidationMessage("validationLogoError2")%></div>
            </td>
        </tr>
        <tr>
            <td>
                幻灯片三：<input name="uploadpic3" type="file" size="80" />
                <input type="submit" value="保存3" name="action" />
                <div class="red">
                    <%:Html.ValidationMessage("validationLogoError3")%></div>
            </td>
        </tr>
        <tr>
            <td>
                幻灯片四：<input name="uploadpic4" type="file" size="80" />
                <input type="submit" value="保存4" name="action" />
                <div class="red">
                    <%:Html.ValidationMessage("validationLogoError4")%></div>
            </td>
        </tr>
    </table>
</asp:Content>

