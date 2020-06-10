<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="npenalty.aspx.cs" Inherits="Adhocs.penalty.npenalty" %>

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
            $("#txtMaximumLimitsAccepted").inputFilter(function (value) {
                return /^\d*$/.test(value);
            });
            $("#txtPenaltyPerUnit").inputFilter(function (value) {
                return /^\d*$/.test(value);
            });
            $("#txtFailedPenaltyValue").inputFilter(function (value) {
                return /^\d*$/.test(value);
            });
        });

        //Select 2 initializer
        $(document).ready(function (e) {
            $('#cmbPenaltyType').select2();
            $('#cmbRiType').select2();
            $('#cmbPenaltyFrequency').select2();
            $('#cmbFrequency').select2();
            $('#cmbWorkCollection').select2();
        });

         function openModalWC() {
             $('#exampleModalCenter').modal('show');
             $('#divAlertInPopup').attr('class', 'alert alert-info alert-dismissible');
             $('#divAlertInPopup').css('display', 'flex');
             $('#<%=lblErrorMsgInPopup.ClientID%>').html('Return submission penalty type must be added to a work collection');
             //alert alert-info alert-dismissible
         }
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
    <form runat="server" id="frmPenalty">
        <asp:HiddenField ID="hdRs" runat="server" Value="0"/>
        <div class="divnpenalty" runat="server" id="divnpenalty" style="margin:10px">
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
                    <label class="h4">Add New Penalty</label>
                </div>

                <div class="form-row">
                <div class="form-group col-md-3">
                    <label for="txtPenaltyCode">Penalty Code <label style="color:red">*</label> </label>
                    <input type="text" id="txtPenaltyCode" runat="server" required="required" placeholder="Penalty Code" class="form-control" />
                </div>
                <div class="form-group col-md-3">
                    <label for="txtPenaltyDescription">Penalty Description <label style="color:red">*</label> </label>
                    <input type="text" id="txtPenaltyDescription" runat="server" required="required" placeholder="Penalty description" class="form-control" />
                </div>
                <div class="form-group col-md-3">
                    <label for="cmbPenaltyType">Institution Type <label style="color:red">*</label> </label>
                    <asp:DropDownList CssClass="form-control" ID="cmbRiType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbRiType_SelectedIndexChanged">
                        <%--<asp:ListItem Text="--Choose one--" Value="1" Enabled="true"> </asp:ListItem>--%>
                    </asp:DropDownList>
                </div>
                     <div class="form-group col-md-3">
                    <label for="cmbPenaltyType">Penalty Type <label style="color:red">*</label> </label>
                    <asp:DropDownList CssClass="form-control" ID="cmbPenaltyType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbPenaltyType_SelectedIndexChanged">
                        <%--<asp:ListItem Text="--Choose one--" Value="1" Enabled="true"> </asp:ListItem>--%>
                    </asp:DropDownList>
                </div>
            </div>

                <div class="form-row">
                <div class="form-group col-md-3">
                    <label for="txtPenaltyFreq">Penalty Frequency <label style="color:red">*</label> </label>                    
                    <asp:DropDownList CssClass="form-control" ID="cmbPenaltyFrequency" runat="server" AutoPostBack="True">
                        <%--<asp:ListItem Text="--Choose one--" Value="1" Enabled="true"> </asp:ListItem>--%>
                    </asp:DropDownList>
                </div>
                <div class="form-group col-md-3">
                    <label for="txtPenaltyFreqUnit">Penalty Frequency Unit <label style="color:red">*</label> </label>
                    <input type="text" id="txtPenaltyFreqUnit" runat="server" required="required" placeholder="Penalty Frequency Unit" class="form-control" />
                </div>
                <div class="form-group col-md-3">
                    <label for="txtPenaltyDeadlineDay">Delivery Deadline Day</label>
                    <input type="text" id="txtPenaltyDeadlineDay" runat="server" placeholder="Deadline unit" class="form-control" />
                </div>
                <div class="form-group col-md-3">
                    <label for="txtPenaltyDeadlineHour">Delivery Deadline Hour</label>
                    <input type="text" id="txtPenaltyDeadlineHour" runat="server" placeholder="Deadline hour" class="form-control" />
                </div>
            </div>

            <div class="form-row">
                <div class="form-group col-md-3">
                    <label for="txtMinimumLimitsAccepted">Min. Accepted Limits</label>
                    <input type="text" id="txtMinimumLimitsAccepted" runat="server" placeholder="Min accepted limits" class="form-control numeric" />
                </div>
                <div class="form-group col-md-3">
                    <label for="txtMaximumLimitsAccepted">Max. Accepted Limits</label>
                    <input type="text" id="txtMaximumLimitsAccepted" runat="server" placeholder="Max accepted limits" class="form-control numeric" />
                </div>
                <div class="form-group col-md-3">
                    <label for="cmbPenaltyPerUnit">Penalty Per Unit</label><label style="color:red">*</label>
                    <asp:DropDownList CssClass="form-control" ID="cmbPenaltyPerUnit" runat="server" AutoPostBack="True">
                        <asp:ListItem Text="0" Value="0" Enabled="true" Selected="True"> </asp:ListItem>
                        <asp:ListItem Text="1" Value="1" Enabled="true"> </asp:ListItem>
                    </asp:DropDownList>
                    <%--<input type="text" id="txtPenaltyPerUnit" title="Penalty per unit" runat="server" placeholder="Penalty per limit" class="form-control numeric" />--%>
                </div>
                <div class="form-group col-md-3">
                    <label for="txtFailedPenaltyValue">Failed Penalty Value</label>
                    <input type="text" id="txtFailedPenaltyValue" runat="server" placeholder="Failed penalty value" class="form-control numeric" />
                </div>
            </div>

                <div class="form-row">
                    <div class="form-group col-md-3">
                        <label for="txtPenaltyDeadlineMinute">Delivery Deadline Minute</label>
                        <input type="text" id="txtPenaltyDeadlineMinute" runat="server" placeholder="Deadline minute" class="form-control" />
                    </div>
                    <%--<div class="form-group col-md-3">
                        <label for="txtPenaltyLimit">Penalty Limit</label>
                        <input type="text" id="txtPenaltyLimit" runat="server" placeholder="Penalty Limit" class="form-control" />
                    </div>--%>
                    <div class="form-group col-md-3">
                        <label for="txtPenaltyValue">Penalty Value <label style="color:red">*</label></label>
                        <input type="text" id="txtPenaltyValue" runat="server" required="required" placeholder="Penalty Value" class="form-control" />
                    </div>
                    <div class="form-group col-md-3">
                        <label for="txtStartValDate">Start Validity Date <label style="color:red">*</label></label>
                        <div id="datetimepickerStart" class="input-append date">
                            <asp:TextBox ID="txtStartValDate" CssClass="form-control form-control-inline input-medium date-picker" runat="server" TextMode="Date"></asp:TextBox>
                            <span class="add-on">
                                <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
                            </span>
                        </div>
                    </div>
                    <div class="form-group col-md-3">
                    <label for="txtPenaltyFreqUnit">Frequency<label style="color:red">*</label> </label>
                    <asp:DropDownList CssClass="form-control" ID="cmbFrequency" runat="server" AutoPostBack="True">
                        <%--<asp:ListItem Text="0" Value="0" Enabled="true" Selected="True"> </asp:ListItem>
                        <asp:ListItem Text="1" Value="1" Enabled="true"> </asp:ListItem>--%>
                    </asp:DropDownList>
                </div>
                </div>

                <div class="form-row" style="display:none">
                    <div class="form-group col-md-3">
                        <label for="txtStartValDate">End Validity Date</label>
                        <div id="datetimepickerEnd" class="input-append date">
                            <asp:TextBox ID="txtEndValDate" CssClass="form-control form-control-inline input-medium date-picker" runat="server" TextMode="Date"></asp:TextBox>
                            <span class="add-on">
                                <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
                            </span>
                        </div>
                    </div>
                </div>

                <div class="form-row">
                    <div class="form-group col-md-12">
                        <div class="float-right">
                            <%--<input type="button" id="btnSavePenalties" value="Save Penalty" class="btn btn-primary" runat="server" onserverclick="btnSavePenalty_Click"/>--%>
                            <asp:Button runat="server" ID="btnSave" Text="Save Penalty" CssClass="btn btn-primary" OnClick="btnSavePenalty_Click" />
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
                    <div class="modal-body" style="overflow:hidden;">
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <div class="alert alert-danger alert-dismissible" role="alert" style="display:none" id="divAlertInPopup">
                                    <asp:Label runat="server" ID="lblErrorMsgInPopup" Text=""></asp:Label>
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <label class="h4">Add Work Collection To Penalty</label>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-12" style="width:100%!important">
                                <label>Penalty Code : </label>
                                <label id="lblPenaltyId" runat="server" class="font-weight-bold"><%=this.txtPenaltyCode.Value%></label>
                            </div>
                        </div>
                        
                        <div class="form-row">
                            <div class="form-group col-md-12" style="width:100%!important">
                                <label for="cmbWorkCollection">Work Collection <label style="color:red">*</label> </label>
                                <asp:ListBox ID="cmbWorkCollection" runat="server" SelectionMode="Multiple" OnSelectedIndexChanged="cmbWorkCollection_SelectedIndexChanged" data-placeholder="Work Collection" CssClass="form-control select2"></asp:ListBox>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" id="btnCancel" runat="server" onclick="ClosePopUp()" class="btn btn-primary">Cancel</button>
                        <button type="button" id="btnAddWC" runat="server" class="btn btn-primary" onserverclick="btnAddWC_ServerClick">Add Work Collection</button>
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
