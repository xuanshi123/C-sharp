<%@ Page Title="" Language="C#" MasterPageFile="~/Views/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>"
    ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%:ViewData["Title"] %>--<%:ViewData["WebTitle"] %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="Default">
        <table>
            <tr>
                <td style="font-weight: bold; font-size: 18px; text-align: center; padding: 5px;">
                    <%:ViewData["Title"] %>
                </td>
            </tr>
            <tr>
                <td style="color: #666666; text-align: center; font-size: 12px;">
                    创建时间：<%:ViewData["CreateDate"] %>
                </td>
            </tr>
            <tr>
                <td class="article_detail">
                    <%=ViewData["Content"] %>
                </td>
            </tr>
            <tr>
                <td>
                    <!--分享来源网站http://www.passit.cn/index-->
                    <script type="text/javascript" language="javascript">
                        var passit_title;
                        passit_title = '<%:ViewData["Title"].ToString() %>'; //自定义分享标题，删除和留空表示使用默认
                        var passit_url = ""; //自定义分享网址，删除和留空表示使用默认
                        var passit_content;
                        passit_content = '<%:ViewData["Title"].ToString() %>'; //自定义分享内容，删除和留空表示使用默认Meta中的描述
                        var passit_image = ""; //自定义分享图片，删除和留空表示不分享图片
                        var sina_appkey = ""; //sina微博appkey,删除和留空表示使用默认
                        var qq_appkey = ""; //腾讯微博appkey,删除和留空表示使用默认
                    </script>
                    <div class="passit_barDiv">
                        <a class="passit_default" href="http://www.passit.cn/bookmark.html" target="_blank">
                        </a>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <%using (Html.BeginForm("ArticleDetail", "Home", FormMethod.Post))
      { %>
    <table style="width: 1000px">
        <tr>
            <td style="border-top: 1px dashed #cccccc; padding-top: 8px;">
                <b>最新评论：</b>
            </td>
        </tr>
        <tr>
            <td>
                <%System.Data.DataTable dt = ViewData["CommentData"] as System.Data.DataTable;  %>
                <table cellpadding="0" cellspacing="0">
                    <% if (dt.Rows.Count == 0)
                       { %>
                    <tr>
                        <td>
                            暂无任何评论，请留下您对本文章的看法，共同参入讨论！
                        </td>
                    </tr>
                    <%} %>
                    <%else
                        { %>
                    <%foreach (System.Data.DataRow dr in dt.Rows)
                      {%>
                    <tr>
                        <td>
                            ·&nbsp;<%=dr["Content"].ToString()%>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 15px; color: Gray; font-size: 12px;">
                            评论人：<%=dr["Creator"].ToString().ToString().Length == 0 ? "匿名" : dr["Creator"].ToString()%>&nbsp;&nbsp;论评时间：<%=dr["CreateDate"].ToString()%>
                        </td>
                    </tr>
                    <%}
                        } %>
                </table>
            </td>
        </tr>
        <tr>
            <td style="padding-top: 8px;">
                <b>发表评论：</b>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="2" cellspacing="2">
                    <tr>
                        <td align="right" width="50px">
                            留言人：
                        </td>
                        <td align="left">
                            <%:Html.TextBox("Creator")%>
                        </td>
                    </tr>
                    <tr>
                        <td valign="bottom" align="right" width="50px">
                            内&nbsp;&nbsp;容：
                        </td>
                        <td align="left">
                            <%:Html.TextArea("Content","",new{ rows="10",cols="60"}) %>
                            <span style="color: Red">
                                <%:Html.ValidationMessage("validationContent")%>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <input id="submit" type="submit" value="发表评论" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <%} %>
    <!--Passit BUTTON BEGIN-->
    <script type="text/javascript">
        bookmark_service_div = "qq,kxzt,qqxy,baiduHi,bookmark,baidu,douban,sohuweibo,163weibo,more";
        bookmark_service = "share,qqkj,sinaweibo,xnzt,more";</script>
    <script type="text/javascript" src="http://www.passit.cn/js/passit_bar_new.js?pub=0&simple=1"
        charset="UTF-8"></script>
    <!--Passit BUTTON END-->
</asp:Content>
