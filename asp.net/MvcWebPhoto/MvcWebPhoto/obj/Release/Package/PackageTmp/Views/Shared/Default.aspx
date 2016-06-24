<%@ Page Title="" Language="C#" MasterPageFile="~/Views/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    首页-<%:ViewData["WebTitle"] %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%System.Data.DataTable dt = ViewData["Article"] as System.Data.DataTable; %>
    <div class="Default">
        <%foreach (System.Data.DataRow dr in dt.Rows)
          { %>
        <div style="margin-top: 15px;">
            <%:Html.ActionLink(dr["Title"].ToString(), "ArticleDetail/" + dr["ID"].ToString(), "Home",null, new { target="blank"})%>
        </div>
        <div class="article_detail">
            <%=dr["Content"].ToString()%>
        </div>
        <!--分享来源网站http://www.passit.cn/index-->
        <script type="text/javascript" language="javascript">
            var passit_title;
            passit_title = '<%:dr["Title"].ToString() %>'; //自定义分享标题，删除和留空表示使用默认
            var passit_url = ""; //自定义分享网址，删除和留空表示使用默认
            var passit_content;
            passit_content = '<%:dr["Title"].ToString() %>'; //自定义分享内容，删除和留空表示使用默认Meta中的描述
            var passit_image = ""; //自定义分享图片，删除和留空表示不分享图片
            var sina_appkey = ""; //sina微博appkey,删除和留空表示使用默认
            var qq_appkey = ""; //腾讯微博appkey,删除和留空表示使用默认
        </script>
        <div class="passit_barDiv">
            <a class="passit_default" href="http://www.passit.cn/bookmark.html" target="_blank">
            </a>
        </div>
        <%} %>
    </div>
    <!--Passit BUTTON BEGIN-->
    <script type="text/javascript">
        bookmark_service_div = "qq,kxzt,qqxy,baiduHi,bookmark,baidu,douban,sohuweibo,163weibo,more";
        bookmark_service = "share,qqkj,sinaweibo,xnzt,more";</script>
    <script type="text/javascript" src="http://www.passit.cn/js/passit_bar_new.js?pub=0&simple=1"
        charset="UTF-8"></script>
    <!--Passit BUTTON END-->
</asp:Content>
