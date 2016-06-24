<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="af" Namespace="ActionlessForm" Assembly="ActionlessForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br />
        <asp:Button ID="Button1" runat="server" Text="跳转" OnClick="Button1_Click" /><br />
        注意：非aspx扩展名的要在iis里设置扩展名映射，否则会提示找不到网页<br />
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/microsoft.aspx">microsoft.aspx</asp:HyperLink><br />
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/microsoft.mspx">microsoft.mspx</asp:HyperLink><br />
        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/microsoft.html">microsoft.html</asp:HyperLink><br />
        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/microsoft.do">microsoft.do</asp:HyperLink><br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/microsoft/1.aspx">microsoft/1.aspx</asp:HyperLink><br />
        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/microsoft">microsoft</asp:HyperLink><br />
        <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/microsoft/">microsoft/</asp:HyperLink> 会出错，不要以/结尾<br />
        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/m/i/c/rosoft.aspx">m/i/c/rosoft.aspx</asp:HyperLink><br />
    </form>
</body>
</html>
<%--
		<af:Form id="Form1" runat="server"></af:Form>
		<form name="Form1" method="post" id="Form1">
		<form name="form1" method="post" action="default.aspx" id="form1">
--%>
