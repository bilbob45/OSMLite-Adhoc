<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="liquiditystresstest.aspx.cs" Inherits="Adhocs.mgtcomponent.liquiditystresstest" %>

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
            $('#cmbReportingInstitution').select2();
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
            width: 100% !important;
        }
    </style>
</head>
<body>
    <form id="frmliquiditystresstest" runat="server">
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
                <span class="h4">Liquidity Stress Test</span>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-3">
                <label for="cmbRiType">RI Type</label>
                <asp:DropDownList CssClass="form-control" ID="cmbRiType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbRiType_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="form-group col-md-3">
                <label for="cmbRiType">Reporting Institution</label>
                <asp:DropDownList CssClass="form-control" ID="cmbReportingInstitution" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbReportingInstitution_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="form-group col-md-6">
                        <label for="txtEndValidityDate">Valuation Date</label>
                        <asp:TextBox ID="txtEndValidityDate" CssClass="form-control form-control-inline input-medium CC" runat="server" OnTextChanged="txtEndValidityDate_TextChanged" TextMode="Date"></asp:TextBox>
                    </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-12">
                <div class="float-right ml-3">
                    <asp:Button runat="server" ID="btnSave" Text="Proceed" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                </div>
            </div>
        </div>

          <!-- Modal 3-->
            <div class="modal fade" id="exampleModalCenter3" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLongTitle3">Add Score</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>

                    <div class="modal-body">
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <div class="alert alert-danger alert-dismissible" role="alert" style="display:none" id="divAlertInPopup3">
                                    <asp:Label runat="server" ID="lblErrorMsgPopUp3" Text=""></asp:Label>
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <label for="txtAmount">Amount</label>
                                <input type="text" id="txtAmount" runat="server" placeholder="Amount" class="form-control" />
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <input id="btnUpdateScore" class="form-control btn btn-primary" type="button" onserverclick="btnUpdateScore_ServerClick" value="Save" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Modal -->
    </form>
</body>
</html>
