<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pswdpolsettings.aspx.cs" Inherits="Adhocs.SysManagement.pswdpolsettings" %>

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

    <script type="text/javascript">
        // Restricts input for the set of matched elements to the given inputFilter function.
        (function ($) {
            $.fn.inputFilter = function (inputFilter) {
                return this.on("input keydown keyup mousedown mouseup select contextmenu drop", function () {
                    if (inputFilter(this.value)) {
                        this.oldValue = this.value;
                        this.oldSelectionStart = this.selectionStart;
                        this.oldSelectionEnd = this.selectionEnd;
                    } else if (this.hasOwnProperty("oldValue")) {
                        this.value = this.oldValue;
                        this.setSelectionRange(this.oldSelectionStart, this.oldSelectionEnd);
                    } else {
                        this.value = "";
                    }
                });
            };
        }(jQuery));

        $(document).ready(function () {
            $("#txtMinimumLimitsAccepted").inputFilter(function (value) {
                return /^\d*$/.test(value);
            });
            $("#txtFailedPenaltyValue").inputFilter(function (value) {
                return /^\d*$/.test(value);
            });
        });

        //Select 2 initializer
        $(document).ready(function (e) {
            $('#cmbRequiredDigit').select2();
            $('#cmbAlphaNumRequired').select2();
            $('#cmbUppercaseRequired').select2();
        });

        function openModalPwPolicy() {
            $('#exampleModalCenter').modal('show');
         }
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
    <form runat="server" id="frmPasswordPolicy">
        <asp:HiddenField ID="hdRs" runat="server" Value="0" />
        <div class="divnpenalty" runat="server" id="divnpenalty" style="margin: 10px">
            <div class="form-row">
                <div class="form-group col-md-12">
                    <div class="alert alert-danger alert-dismissible" role="alert" visible="false" runat="server" id="divAlert">
                        <asp:Label ID="lblFrmError" runat="server" Text=""> </asp:Label>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                </div>
            </div>

            <div class="form-row mb-4">
                <label class="h4">All Password Policy Settings</label>
            </div>
            <div class="form-row" id="divGrids" runat="server">
                <div class="form-group col-md-12" style="overflow:scroll; max-height:400px">
                    <div>
                        <asp:GridView ID="gridViewPasswordPolicy"
                            runat="server"
                            HeaderStyle-Wrap="false"
                            RowStyle-Wrap="false"
                            EmptyDataText="There is no report(s) to display for the selected department"
                            AutoGenerateColumns="true"
                            ViewStateMode="Enabled"
                            CssClass="table table-striped table-bordered table-hover table-header-fixed"
                            AutoGenerateSelectButton="True" OnSelectedIndexChanged="gridViewPasswordPolicy_SelectedIndexChanged" 
                            OnRowDataBound="gridViewPasswordPolicy_RowDataBound">
                            <EditRowStyle BackColor="#000FFF" />
                            <SelectedRowStyle BackColor="#999999" ForeColor="white" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>

        <!-- Modal Work Collection tabindex="-1"-->
        <div class="modal fade" id="exampleModalCenter" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLongTitle">Work Collection</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body" style="overflow: hidden;">
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <div class="alert alert-danger alert-dismissible" role="alert" style="display: none" id="divAlertInPopup">
                                    <asp:Label runat="server" ID="lblErrorMsgInPopup" Text=""></asp:Label>
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <label class="h4">Add-Update Ploicy Settings</label>
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="form-group col-md-3">
                                <label for="txtMinLenght">Minimum Lenght Required
                                    <label style="color: red">*</label>
                                </label>
                                <input type="text" id="txtMinLenght" runat="server" required="required" placeholder="Minimum Password Lenght" class="form-control" />
                            </div>
                            <div class="form-group col-md-3">
                                <label for="cmbRequiredDigit">Require Digit
                                    <label style="color: red">*</label>
                                </label>
                                <asp:DropDownList CssClass="form-control" ID="cmbRequiredDigit" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbPenaltyType_SelectedIndexChanged">
                                    <asp:ListItem Text="--Choose one--" Value="00" Enabled="false"> </asp:ListItem>
                                    <asp:ListItem Text="Yes" Value="1" Enabled="false"> </asp:ListItem>
                                    <asp:ListItem Text="No" Value="0" Enabled="false"> </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group col-md-3">
                                <label for="cmbRequiredDigit">Alphanumeric Required
                                    <label style="color: red">*</label>
                                </label>
                                <asp:DropDownList CssClass="form-control" ID="cmbAlphaNumRequired" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbPenaltyType_SelectedIndexChanged">
                                    <asp:ListItem Text="--Choose one--" Value="00" Enabled="false"> </asp:ListItem>
                                    <asp:ListItem Text="Yes" Value="1" Enabled="false"> </asp:ListItem>
                                    <asp:ListItem Text="No" Value="0" Enabled="false"> </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group col-md-3">
                                <label for="cmbUppercaseRequired">Uppercase Required
                                    <label style="color: red">*</label>
                                </label>
                                <asp:DropDownList CssClass="form-control" ID="cmbUppercaseRequired" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbPenaltyType_SelectedIndexChanged">
                                    <asp:ListItem Text="--Choose one--" Value="00" Enabled="false"> </asp:ListItem>
                                    <asp:ListItem Text="Yes" Value="1" Enabled="false"> </asp:ListItem>
                                    <asp:ListItem Text="No" Value="0" Enabled="false"> </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="form-group col-md-3">
                                <label for="cmbRequiredDigit">Lowercase Required
                                    <label style="color: red">*</label>
                                </label>
                                <asp:DropDownList CssClass="form-control" ID="DropDownList5" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbPenaltyType_SelectedIndexChanged">
                                    <asp:ListItem Text="--Choose one--" Value="00" Enabled="false"> </asp:ListItem>
                                    <asp:ListItem Text="Yes" Value="1" Enabled="false"> </asp:ListItem>
                                    <asp:ListItem Text="No" Value="0" Enabled="false"> </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group col-md-3">
                                <label for="cmbRequiredDigit">Unique Character
                                    <label style="color: red">*</label>
                                </label>
                                <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbPenaltyType_SelectedIndexChanged">
                                    <asp:ListItem Text="--Choose one--" Value="00" Enabled="false"> </asp:ListItem>
                                    <asp:ListItem Text="Yes" Value="1" Enabled="false"> </asp:ListItem>
                                    <asp:ListItem Text="No" Value="0" Enabled="false"> </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            
                            <div class="form-group col-md-3">
                                <label for="txtPasswordHistory">Enforce Password History
                                    <label style="color: red">*</label>
                                </label>
                                <input type="text" id="txtPasswordHistory" runat="server" required="required" placeholder="Enforce Password History" class="form-control" />
                            </div>

                            <div class="form-group col-md-3">
                                <label for="cmbRequiredDigit">Uppercase Required
                                    <label style="color: red">*</label>
                                </label>
                                <asp:DropDownList CssClass="form-control" ID="DropDownList4" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbPenaltyType_SelectedIndexChanged">
                                    <asp:ListItem Text="--Choose one--" Value="00" Enabled="false"> </asp:ListItem>
                                    <asp:ListItem Text="Yes" Value="1" Enabled="false"> </asp:ListItem>
                                    <asp:ListItem Text="No" Value="0" Enabled="false"> </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <div class="float-right">
                                    <asp:Button runat="server" ID="Button1" Text="Save Policy Settings" CssClass="btn btn-primary" OnClick="btnSavePenalty_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" id="btnSave" runat="server" class="btn btn-primary" onserverclick="btnSave_ServerClick">Save Policy Settings</button>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Modal -->

    </form>

    <script type="text/javascript">
        function ClosePopUp() {
            $("#btnCancel").click(function () {
                $("#exampleModalCenter").modal('hide');
            });
        }
    </script>

</body>
</html>

