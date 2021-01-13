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

        .error{
            color: red;
        }
    </style>
</head>
<body>
    <form runat="server" id="frmPenalty">
        <asp:HiddenField ID="hdRs" runat="server"/>
        <div class="divnpenalty" runat="server" id="divnpenalty" style="margin:10px">
                <div class="form-row">
                    <div class="form-group col-md-12">
                        <div class="alert alert-danger alert-dismissible" role="alert" runat="server" id="divAlert">
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
                    <label for="cmbRiType">Institution Type <label style="color:red">*</label> </label>
                    <asp:DropDownList CssClass="form-control" ID="cmbRiType" runat="server" AutoPostBack="False" 
                        OnSelectedIndexChanged="cmbRiType_SelectedIndexChanged" SelectMethod="GetRITypes" DataValueField="ri_type_id" DataTextField="description"></asp:DropDownList>
                </div>
                     <div class="form-group col-md-3">
                    <label for="cmbPenaltyType">Penalty Type <label style="color:red">*</label> </label>
                    <asp:DropDownList CssClass="form-control" ID="cmbPenaltyType" runat="server" 
                        AutoPostBack="False" OnSelectedIndexChanged="cmbPenaltyType_SelectedIndexChanged" SelectMethod="GetPenaltyType" 
                        DataTextField="description" DataValueField="penalty_type">
                        
                    </asp:DropDownList>
                </div>
            </div>

                <div class="form-row">
                <div class="form-group col-md-3">
                    <label for="txtPenaltyFreq">Penalty Frequency <label style="color:red">*</label> </label>                    
                    <asp:DropDownList CssClass="form-control" ID="cmbPenaltyFrequency" runat="server" 
                        AutoPostBack="False" SelectMethod="GetPenaltyFreq" DataTextField="freq_desc" DataValueField="freq_unit">
                    </asp:DropDownList>
                </div>
                <div class="form-group col-md-3">
                    <label for="txtPenaltyFreqUnit">Penalty Frequency Unit <label style="color:red">*</label> </label>
                    <input type="number" id="txtPenaltyFreqUnit" runat="server" required="required" placeholder="Penalty Frequency Unit" class="form-control" />
                </div>
                    <div class="form-group col-md-3">
                    <label for="txtMinimumLimitsAccepted">Min. Accepted Limits</label>
                    <input type="text" id="txtMinimumLimitsAccepted" runat="server" placeholder="Min accepted limits" class="form-control numeric" />
                </div>
                <div class="form-group col-md-3">
                    <label for="txtMaximumLimitsAccepted">Max. Accepted Limits</label>
                    <input type="text" id="txtMaximumLimitsAccepted" runat="server" placeholder="Max accepted limits" class="form-control numeric" />
                </div>
            </div>

            <div class="form-row">
                <div class="form-group col-md-3">
                    <label for="txtPenaltyDeadlineDay">Delivery Deadline Day</label>
                    <input type="number" id="txtPenaltyDeadlineDay" runat="server" placeholder="Deadline unit" class="form-control" />
                </div>
                <div class="form-group col-md-3">
                    <label for="txtPenaltyDeadlineHour">Delivery Deadline Hour</label>
                    <input type="number" id="txtPenaltyDeadlineHour" runat="server" placeholder="Deadline hour" class="form-control" />
                </div>
                <div class="form-group col-md-3">
                    <label for="txtPenaltyDeadlineMinute">Delivery Deadline Minute</label>
                    <input type="number" id="txtPenaltyDeadlineMinute" runat="server" placeholder="Deadline minute" class="form-control" />
                </div>
                <div class="form-group col-md-3">
                    <label for="cmbPenaltyPerUnit">Penalty Per Unit</label><label style="color:red">*</label>
                    <asp:DropDownList CssClass="form-control" ID="cmbPenaltyPerUnit" runat="server" AutoPostBack="False">
                        <asp:ListItem Text="0" Value="0" Enabled="true" Selected="True"> </asp:ListItem>
                        <asp:ListItem Text="1" Value="1" Enabled="true"> </asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="form-row">
                <div class="form-group col-md-3">
                    <label for="txtFailedPenaltyValue">Failed Penalty Value</label>
                    <input type="text" id="txtFailedPenaltyValue" runat="server" placeholder="Failed penalty value" class="form-control numeric" />
                </div>
                <div class="form-group col-md-3">
                    <label for="txtPenaltyValue">Penalty Value
                        <label style="color: red">*</label></label>
                    <input type="text" id="txtPenaltyValue" runat="server" required="required" placeholder="Penalty Value" class="form-control" />
                </div>
                <div class="form-group col-md-3">
                    <label for="txtStartValDate">Start Validity Date
                        <label style="color: red">*</label></label>
                    <div id="datetimepickerStart" class="input-append date">
                        <input type="date" required="required" name="txtStartValDate" id="txtStartValDate" class="form-control form-control-inline input-medium date-picker" value="" />
                        <span class="add-on">
                            <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
                        </span>
                    </div>
                </div>
                <div class="form-group col-md-3">
                    <label for="cmbFrequency">Frequency<label style="color: red">*</label>
                    </label>
                    <asp:DropDownList CssClass="form-control" ID="cmbFrequency" runat="server" AutoPostBack="False" SelectMethod="GetFrequencies" DataValueField="freq_unit" DataTextField="freq_desc"></asp:DropDownList>
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
                            <asp:Button runat="server" ID="btnSave" Text="Save Penalty" CssClass="btn btn-primary btn-lg" />
                        </div>
                    </div>
                </div>
            </div>

         <!-- Modal Work Collection tabindex="-1"-->
            <div class="modal fade" id="exampleModalCenter" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog" role="document">
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
                                <label id="lblPenaltyId" runat="server" class="font-weight-bold"></label>
                            </div>
                        </div>
                        
                        <div class="form-row">
                            <div class="form-group col-md-12" style="width:100%!important">
                                <label for="cmbWorkCollection">Work Collection <label style="color:red">*</label> </label>
                                <asp:ListBox ID="cmbWorkCollection" runat="server" SelectionMode="Multiple" 
                                    OnSelectedIndexChanged="cmbWorkCollection_SelectedIndexChanged" 
                                    data-placeholder="Work Collection" SelectMethod="GetWorkCollection" DataTextField="work_collection_code"
                                    DataValueField="work_collection_id" CssClass="form-control select2"></asp:ListBox>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <%--<button type="button" id="btnCancel" runat="server" onclick="ClosePopUp()" class="btn btn-primary">Cancel</button>--%>
                        <button type="button" id="btnAddWC" runat="server" class="btn btn-primary">Add Work Collection</button>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Modal -->

    </form>

    <script src="../assets/jquery.validate.min.js"></script>

    <script type="text/javascript">
        function ClosePopUp() {
            $("#btnCancel").click(function () {
                $("#exampleModalCenter").modal('hide');
            });
        }

        function getUrlVars() {
            var vars = [], hash;
            var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            for (var i = 0; i < hashes.length; i++) {
                hash = hashes[i].split('=');
                vars.push(hash[0]);
                vars[hash[0]] = hash[1];
            }
            return vars;
        }

        var selected = [];
        function savePenalty() {

            var penaltyWCModel = {
                penaltyWCModel :  selected
            };

            var pinfo = {

                penalty_code: $("#txtPenaltyCode").val(),
                penalty_desc: $("#txtPenaltyDescription").val(),
                ri_type_id: $("#cmbRiType option:selected").val(),
                penalty_type: $("#cmbPenaltyType option:selected").val(),
                penalty_freq: $("#cmbPenaltyFrequency option:selected").val(),
                penalty_freq_unit: $("#txtPenaltyFreqUnit").val(),
                delivery_deadline_day: $("#txtPenaltyDeadlineDay").val(),
                delivery_deadline_hr: $("#txtPenaltyDeadlineHour").val(),
                delivery_deadline_min: $("#txtPenaltyDeadlineMinute").val(),
                min_limit_accepted: $("#txtMinimumLimitsAccepted").val(),
                max_limit_accepted: $("#txtMaximumLimitsAccepted").val(),
                penalty_per_unit: ($("#cmbPenaltyPerUnit option:selected").val().trim() == '0' ? false : true),
                failed_penalty_value: $("#txtFailedPenaltyValue").val(),
                penalty_value: $("#txtPenaltyValue").val(),
                start_validity_date: $("#txtStartValDate").val(),
                frequncy: $("#cmbFrequency option:selected").val(),
                created_date: "<%: DateTime.Now%>",
                created_by: getUrlVars()["uname"]
            };

            var data = {
                pinfo: pinfo,
                penaltyWCModel: penaltyWCModel
            }

            //make the ajax call
            $.ajax({
                type: "POST",
                url: "npenalty.aspx/SavePenalty",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(data),
                beforeSend: function () {
                    $("#btnSave").attr('disabled', true);
                },
                complete: function () {
                    $("#btnSave").attr('disabled', false);
                },
                success: function (response) {

                    var responseData = (response.d !== null || response.d !== undefined) ? response.d : response;

                    if (responseData.Status == "0") {

                        $("#divAlert").addClass("alert alert-danger alert-dismissible fade show").slideDown("slow");
                        $("#lblFrmError").html(responseData.Message);
                        return;
                    }
                    else if (responseData.Status == "1") {

                        $("#divAlert").removeClass("alert alert-danger alert-dismissible fade show");
                        $("#divAlert").addClass("alert alert-success alert-dismissible fade show").slideDown("slow");
                        $("#lblFrmError").html(responseData.Message);
                        //window.location.href = window.location.href;
                    }
                    else
                        return;
                },
                error: function (data) {
                    alert(data);
                }
            });
        }

        var penaltyTypeConst = {
            RS: 'RS',
            CV: 'CV'
        };

        $(function () {

            //hide div alert when document is ready
            $("#divAlert").hide();

            //$("#hdRs").val('');

            //pre-validate the form
            var validator = $("#frmPenalty").validate();

            $("#btnAddWC").click(function () {

                var selectedWcText = $("#cmbWorkCollection option:selected").val();
                if (selectedWcText == "0") {

                    $("#divAlertInPopup").addClass('alert alert-danger alert-dismissible').slideDown('slow');
                    $("#lblFrmError").html("Please choose a valid work collection");
                    return;
                }
                else {

                    $("#cmbWorkCollection").children("option:selected").each(function () {

                        selected.push($(this).val());
                        console.log($(this).val());
                    });

                    $('#divAlertInPopup').attr('class', 'alert alert-success alert-dismissible').css('display', 'flex').slideDown('slow');
                    $('#<%=lblErrorMsgInPopup.ClientID%>').html('Work collection added to penalty successfuly');

                }
            });

            //handle penalty type selection to determine if the selected
            //penalty type is RS (resubmission penalty) or CV (conventional penalty)
            $("#cmbPenaltyType").change(function (e) {
                
                var penaltyTypeValue = $("#cmbPenaltyType option:selected").val();
                var penaltyCode = $("#txtPenaltyCode").val();

                if (penaltyCode == '' || penaltyCode == undefined) {
                    $("#divAlert").addClass('alert alert-danger alert-dismissible').toggle().slideDown('slow');
                    $("#lblFrmError").html("Penalty code is required, please choose a penalty type to proceed");
                    return;
                }
                else {
                    $("#divAlert").addClass('alert alert-danger alert-dismissible').slideUp('slow');
                }

                console.log(penaltyTypeValue);
                console.log(penaltyCode);

                if (penaltyTypeValue.trim().toLowerCase() != "rs") {
                    return;
                }
                else {

                    console.log('RS selected');
                    $("#hdRs").val('RS');
                    $("#lblPenaltyId").html(penaltyCode);
                    openModalWC();
                }

                if ($("#hdRs").val().toLowerCase() == 'rs' && penaltyTypeValue == '') {

                    $("#divAlert").addClass('alert alert-danger alert-dismissible').toggle().slideDown('slow');
                    $("#lblFrmError").html("Penalty code is required, please choose a penalty type to proceed");
                    return;
                }
            });

            //handle the form submission
            $("#frmPenalty").on('submit', function (event) {

                if ($(this).valid()) {

                    //save penalty value using ajax

                    savePenalty();

                } else {

                    //display an error message
                    $("#divAlert").addClass('alert alert-danger alert-dismissible').slideDown('slow');
                    $("#lblFrmError").html("Please fill out the required field(s)");
                    return;
                }
                event.preventDefault();
            });
        });
    </script>

</body>
</html>
