<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="audit.aspx.cs" Inherits="Adhocs.audit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </div>
        <div>
            <button runat="server" id="btnClickMe" value="Make Request" onserverclick="btnClickMe_ServerClick">Make Request</button>
        </div>
    </form>
</body>
</html>
