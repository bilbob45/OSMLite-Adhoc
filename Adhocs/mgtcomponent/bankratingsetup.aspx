<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bankratingsetup.aspx.cs" Inherits="Adhocs.mgtcomponent.bankratingsetup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../assets/style/bootstrap.min.css" rel="stylesheet" />
    <script src="../assets/script/jquery-2.2.4.min.js"></script>
    <script src="../assets/script/bootstrap.bundle.min.js"></script>

    <!--Select2 Plugin-->
    <script src="../assets/select2/js/select2.full.min.js"></script>
    <link href="../assets/select2/css/select2.min.css" rel="stylesheet" />

    <!--Material Design Icon-->
    <link href="../assets/md/css/materialdesignicons.min.css" media="all" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        //Select 2 initializer
        $(document).ready(function (e) {
            $('#cmbRiType').select2();
            $("#txtComponentWeight").inputFilter(function (value) {
                return /^\d*$/.test(value);
            });
        });
    </script>

    <style type="text/css" lang="en">
        * {
            font-size: 11px;
            line-height: 2;
        }
        .select2 {
            width:100%!important;
         }
    </style>
</head>
<body>
    <form id="frmBankRating" runat="server">
        <div class="form-row">
                <div class="form-group col-md-12">
                    <div class="alert alert-danger alert-dismissible" role="alert" visible="false" runat="server" id="divAlert">
                        <asp:Label ID="lblError" runat="server"> </asp:Label>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                </div>
            </div>
        <div class="form-row mb-4">
            <div class="col-md-6">
                <span class="h4">Bank Rating Setup</span>
            </div>
        </div>
        <div class="form-row">
                <div class="form-group col-md-4">
                    <label for="txtBankRatingCode">Bank Rating Code</label>
                    <input type="text" id="txtBankRatingCode" runat="server" onserverchange="txtBankRatingCode_ServerChange" required="required" placeholder="Bank rating code" class="form-control" />
                </div>
                <div class="form-group col-md-4">
                    <label for="cmbRiType">RI Type</label>
                    <asp:DropDownList CssClass="form-control" ID="cmbRiType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbRiType_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="form-group col-md-4">
                    <label for="txtParam">Parameter</label>
                    <input type="text" id="txtParam" runat="server" required="required" placeholder="Parameter" class="form-control" />
                </div>
            </div>
        <div class="form-row">
                    <div class="form-group col-md-4">
                        <label for="txtComponentWeight">Component Weight</label>
                        <input type="text" id="txtComponentWeight" runat="server" required="required" placeholder="Component weight" class="form-control" />
                    </div>
                    <div class="form-group col-md-4">
                        <label for="txtStartValidityDate">Start Validity Date</label>
                        <asp:TextBox ID="txtStartValidityDate" OnTextChanged="txtStartValidityDate_TextChanged" CssClass="form-control form-control-inline input-medium date-picker" runat="server" TextMode="Date"></asp:TextBox>
                    </div>
            <div class="form-group col-md-4">
                    <label for="txtDescription">Component</label> <!--formally Description-->
                    <input type="text" id="txtDescription" runat="server" placeholder="Component" class="form-control" />
                </div>
                    <div class="form-group col-md-4" style="display:none">
                        <label for="txtEndValidityDate">End Validity Date</label>
                        <asp:TextBox ID="txtEndValidityDate" OnTextChanged="txtEndValidityDate_TextChanged" CssClass="form-control form-control-inline input-medium" runat="server" TextMode="Date" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
        <div class="form-row">
                    <div class="form-group col-md-12">
                        <div class="float-right ml-3">
                            <asp:Button runat="server" ID="btnSave" Text="Save Bank Rating Setup" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                        </div>
                        <div class="float-right">
                            <%--<asp:Button runat="server" ID="btnGoBack" Text="Go Back" CssClass="btn btn-primary" OnClick="btnGoBack_Click" />--%>
                            <input type="button" runat="server" id="btnGoBacks" value="Go Back" class="btn btn-primary" onserverclick="btnGoBack_Click" />
                        </div>
                    </div>
                </div>
    </form>
</body>
</html>
