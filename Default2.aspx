<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td>账号：</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>密码：</td>
                <td>
                    <asp:TextBox ID="txtPwd" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>角色</td>
                <td>
                    <asp:RadioButtonList ID="rdlRole" runat="server" RepeatDirection="Horizontal">
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="注册" />
                    <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="修改" />
                    <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="删除" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
