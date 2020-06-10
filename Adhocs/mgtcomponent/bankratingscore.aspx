<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bankratingscore.aspx.cs" Inherits="Adhocs.mgtcomponent.bankratingscore" %>

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
    <form id="frmBankRatingScore" runat="server">
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
                <span class="h4">Bank Rating Score</span>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-4">
                <label for="cmbRiType">RI Type</label>
                <asp:DropDownList CssClass="form-control" ID="cmbRiType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbRiType_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="form-group col-md-4">
                <label for="cmbReportingInstitution">Reporting Institution</label>
                <asp:DropDownList CssClass="form-control" ID="cmbReportingInstitution" runat="server" AutoPostBack="True">
                </asp:DropDownList>
            </div>
            <div class="form-group col-md-4">
                <div id="datetimepickerWc" class="input-append date">
                    <label for="txtDate">Date</label>
                    <asp:TextBox ID="txtWorkcollectionDate" CssClass="form-control form-control-inline input-medium date-picker" runat="server" TextMode="Date"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-12">
                <div class="dropdown">
                    <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButtonQuery" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        Choose Action</button>
                    <div class="dropdown-menu" aria-labelledby="dropdownMenuButtonQuery">
                        <a class="dropdown-item" runat="server" id="btnGetRatingDetails" onserverclick="btnGetRatingDetails_ServerClick" href="#">Get Rating Details</a>
                        <a class="dropdown-item" runat="server" id="btnSaveChanges" onserverclick="btnSaveChanges_ServerClick" href="#">Save Changes</a>
                        <hr />
                        <a class="dropdown-item" runat="server" id="btnGoBack" onserverclick="btnGoBack_Click" href="#">Go Back</a>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-row" id="divGridResult" runat="server" visible="false">
            <div class="form-group col-md-12" style="top: -2px; left: 4px;">
                <div class="overflow-auto" style="height: auto; width: 100%">
                    <asp:GridView ID="gridviewRatingSetup"
                        runat="server"
                        HeaderStyle-Wrap="false"
                        RowStyle-Wrap="true"
                        EmptyDataText="There is no record(s) to display for the TI Type & selected date"
                        AutoGenerateColumns="true"
                        ViewStateMode="Enabled" OnSelectedIndexChanged="gridviewRatingSetup_SelectedIndexChanged"
                        CssClass="table table-striped table-bordered table-hover table-header-fixed pre-scrollable" AutoGenerateSelectButton="True">
                        <EditRowStyle BackColor="#000FFF" />
                        <SelectedRowStyle BackColor="#999999" ForeColor="White" />
                    </asp:GridView>
                </div>
            </div>
        </div>

         <!-- Modal 3-->
            <div class="modal fade" id="exampleModalCenter3" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLongTitle3">Add Rating Score</h5>
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
                                <label for="txtRatingScore">Rating Score</label>
                                <input type="text" id="txtRatingScore" runat="server" placeholder="Rating Score" class="form-control" />
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <input id="btnUpdateScore" class="form-control btn btn-primary" type="button" value="Update Score" onserverclick="btnUpdateScore_ServerClick" runat="server" />
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
