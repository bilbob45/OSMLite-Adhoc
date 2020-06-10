<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="report-test.aspx.cs" Inherits="Adhocs.report_test" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="assets/script/jquery-3.4.0.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-row">
            <div class="form-group col-md-12">
                <div class="alert alert-warning alert-dismissible" role="alert" visible="false" runat="server" id="divAlert">
                    <asp:Label ID="lblErrorMsg" runat="server"> </asp:Label>
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
            </div>
        </div>
        <div>
            <iframe runat="server" id="iframereport" style="width:100%; min-height:400px; height:1000px" frameborder="0"></iframe>
        </div>
    </form>
</body>
</html>
