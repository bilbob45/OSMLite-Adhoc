<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="radjustments.aspx.cs" Inherits="Adhocs.rules.radjustments" %>

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
            $('#cmbFrequency').select2();
            $('#cmbColmnList').select2({
                dropdownParent: $("#exampleModalCenterValue")
            });
            $("#cmbColumnListComplex").select2();
            $('#cmbColmnValue').select2();
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
    <form runat="server" id="frmRulesAdjustment">
        <asp:HiddenField ID="hfColumnList" runat="server" Value="0" />
        <input type="hidden" runat="server" id="hndSchedule" name="hndSchedule" value="" />
        <input type="hidden" runat="server" id="hndType" name="hndType" value="" />
        <div class="" style="margin:5px">
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
                    <span class="h4">Rule Adjustment</span>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-3">
                    <label for="txtDate">RI Type</label>
                    <asp:DropDownList CssClass="form-control" ID="cmbRiType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbRiType_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="form-group col-md-3">
                    <label for="cmbReportingInstitution">Reporting Institution</label>
                    <asp:DropDownList CssClass="form-control" ID="cmbReportingInstitution" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbReportingInstitution_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="form-group col-md-3">
                    <label for="cmbFrequency">Frequency</label>
                    <asp:DropDownList CssClass="form-control" ID="cmbFrequency" runat="server" AutoPostBack="True"></asp:DropDownList>
                </div>
                <div class="form-group col-md-3">
                    <div id="datetimepickerWc" class="input-append date">
                        <label for="txtDate">Work Collection Date</label>
                        <asp:TextBox ID="txtWorkcollectionDate" CssClass="form-control form-control-inline input-medium date-picker" runat="server" TextMode="Date"></asp:TextBox>
                        <span class="add-on">
                            <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
                        </span>
                    </div>
                </div>
            </div>
            <div class="form-row">  
                <div class="form-group col-md-3">
                    <label for="txtDate"></label>
                    <div class="dropdown">
                        <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButtonQuery" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Choose Action</button>
                        <div class="dropdown-menu" aria-labelledby="dropdownMenuButtonQuery">
                            <a class="dropdown-item" runat="server" id="lblViewCompRule" href="#" onserverclick="lblViewCompRule_ServerClick">View Computation Rule</a>
                        </div>
                    </div>
                </div>
            </div>

            <div id="divGrids" runat="server" style="display: none">
                <div class="form-row">
                    <div class="form-group col-md-4">
                        <input type="text" name="txtSearchCompRule" id="txtSearchCompRule" value="" class="form-control" placeholder="Search computation rule" />
                    </div>
                    <div class="form-group col-md-2">
                        <div class="dropdown">
                            <button class="btn btn-secondary dropdown-toggle" type="button" id="bb" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                Filter</button>
                            <div class="dropdown-menu" aria-labelledby="dropdownMenuButtonQuery">
                                <a class="dropdown-item" runat="server" id="A1" href="#" onclick="toggleColumnIndex(2)">Rule Name</a>
                                <a class="dropdown-item" runat="server" id="A2" href="#" onclick="toggleColumnIndex(3)">Rule Description</a>
                                <a class="dropdown-item" runat="server" id="A4" href="#" onclick="toggleColumnIndex(5)">Rule Type</a>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="form-row">
                    <div class="form-group col-md-6" style="height: 350px; left: 4px;">
                        <div onscroll="$(scroll.Y).val(this.scrollTop);">
                            <asp:GridView ID="gridViewRules"
                                runat="server"
                                HeaderStyle-Wrap="false"
                                RowStyle-Wrap="false"
                                EmptyDataText="There is no work collection available for the selected date"
                                AutoGenerateColumns="true"
                                AutoGenerateSelectButton="true"
                                ViewStateMode="Enabled"
                                CssClass="table table-striped table-bordered table-hover pre-scrollable table-responsive" OnSelectedIndexChanged="gridViewRules_SelectedIndexChanged" OnRowDataBound="gridViewListReport_RowDataBound">
                                <EditRowStyle BackColor="#000FFF" />
                                <SelectedRowStyle BackColor="#999999" ForeColor="white" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="form-group col-md-6" style="height: 350px; left: 4px;">
                         <div class="overflow-auto" style="height:auto">
                            <div>
                            <asp:GridView ID="gridViewCompValue"
                                runat="server"
                                HeaderStyle-Wrap="true"
                                RowStyle-Wrap="false"
                                EmptyDataText="There is no rule values to display for the selected rule name"
                                AutoGenerateColumns="true"
                                AutoGenerateSelectButton="true"
                                ViewStateMode="Enabled" OnSelectedIndexChanged="gridViewCompValue_SelectedIndexChanged" 
                                CssClass="table table-striped table-bordered table-hover pre-scrollable table-responsive" OnRowDataBound="gridViewListReport_RowDataBound">
                                <EditRowStyle BackColor="#000FFF" />
                                <SelectedRowStyle BackColor="#999999" ForeColor="white" />
                            </asp:GridView>
                        </div>
                        </div>
                    </div>
                </div>
                <div class="form-row">
                    <div class="col-md-2">
                        <button type="button" id="btnSaveAdjustment" value="Save" runat="server" class="btn btn-primary" onserverclick="btnSaveAdjustment_ServerClick">Save Changes</button>
                    </div>
                    <div class="col-md-2">
                        <button type="button" style="display:none" id="btnCancelAdjustment" value="Calcel" runat="server" class="btn btn-primary" onserverclick="btnCancelAdjustment_ServerClick">Cancel</button>
                    </div>
                </div>
            </div>
        </div>

         <!-- Modal Modify -->
            <div class="modal fade" id="exampleModalCenterValue" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Adjust Computation Value</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>

                    <div class="modal-body modal-lg" style="overflow:hidden;">
                        <div class="form-row">
                            <div class="form-group col-md-12 mb-2">
                                <div class="alert alert-danger alert-dismissible" runat="server" id="divModalChanges" role="alert" style="display:none">
                                    <asp:Label runat="server" ID="lblErrorChangeValue" Text=""></asp:Label>
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                            </div>
                        </div>

                        <!--simple rule adjustment form-->
                        
                        <div class="simple-rule-adjusment-form" id="divSimpleRuleAdjustment" runat="server" visible="false">
                            <div class="form-row">
                                <div class="col-md-12">
                                    <label runat="server" id="lblRuleTypeSimple" class="font-weight-bold"></label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-12 mb-0">
                                    <label runat="server" id="lblOldRowIdSimple" class="font-weight-bold"></label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-12 mb-0">
                                    <label runat="server" id="lblOldValueSimple" class="font-weight-bold"></label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-12 mb-0">
                                    <label runat="server" id="lblOldCommentSimple" class="font-weight-bold"></label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-12 mb-0">
                                    <label runat="server" id="lblNewValueSimple" class="font-weight-bold"></label>
                                </div>
                            </div>
                            <hr />
                            <div class="form-row">
                                <div class="form-group col-md-12 mb-3">
                                    <label for="txtNewValue">New Value</label>
                                    <input type="text" name="txtNewValueSimple" id="txtNewValueSimple" required="required" class="form-control" runat="server" placeholder="1000000000000" value="" />
                                </div>
                            </div>
                        </div>

                        <!--compound rule adjustment form-->
                        <div class="complex-rule-adjusment-form" id="divCompoundRuleAdjustment" runat="server" visible="false">
                            <div class="form-row">
                                <div class="col-md-12">
                                    <label runat="server" id="lblRuleTypeCompound" class="font-weight-bold"></label>
                                </div>
                            </div>
                             <div class="form-row">
                                <div class="form-group col-md-12 mb-0">
                                    <label runat="server" id="lblOldRowIdComplex" class="font-weight-bold"></label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-12 mb-0">
                                    <label runat="server" id="lblRowCodeComplex" class="font-weight-bold"></label>
                                </div>
                            </div>
                             <div class="form-row">
                                <div class="form-group col-md-12 mb-0">
                                    <label runat="server" id="lblSummaryComplex" class="font-weight-bold"></label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-12 mb-0">
                                    <label runat="server" id="lblAdhicComplex" class="font-weight-bold"></label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-12 mb-0">
                                    <label runat="server" id="lblNewValueComplex" class="font-weight-bold"></label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-12">
                                    <label runat="server" id="lblColumnName" class="font-weight-bold"></label>
                                </div>
                            </div>
                            <hr />                            
                            <div class="form-row"> 
                                <div class="col-md-12">
                                    <label for="txtNewValue">Column Header</label>
                                    <asp:DropDownList runat="server" ID="cmbColumnListComplex" CssClass="form-control" OnSelectedIndexChanged="cmbColumnListComplex_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Selected="True" Enabled="false" Value="00">--Choose header--</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-row" id="divDynamicHolder" runat="server">
                                <div class="form-group col-md-12 mb-0">
                                    <label for="txtNewValue">New Value</label>
                                    <input type="text" name="txtNewValueComplex" id="txtNewValueComplex" required="required" class="form-control" runat="server" placeholder="1000000" value="" />
                                </div>
                            </div>
                        </div>

                        <!--comment-->
                        <div class="form-row">
                            <h5 class="h3"></h5>
                            <div class="form-group col-md-12">
                                <label for="txtAreaAnalystComment" id="lblAreaAnalystComment" runat="server">Comment</label>
                                <textarea runat="server" id="txtAreaAnalystComment" required="required" class="form-control"></textarea>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" id="btnCancelValue" runat="server" onclick="ClosePopUp()" class="btn btn-primary">Cancel</button>
                        <button type="button" id="btnUpdate" runat="server" class="btn btn-primary" onserverclick="btnUpdate_ServerClick">Update</button>
                        <button type="button" id="btnChangeValue" runat="server" class="btn btn-primary" onserverclick="btnUpdateValueProceed_ServerClick">Update value & proceed</button>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Modal -->
    </form>
    <script type="text/javascript">
        var global = "";
        $('#txtNewValueSimple').keyup(function () {
            $("#lblNewValueSimple").text("New Rule Value: " + $("#txtNewValueSimple").val());
            //Clear the control content
            //$("#txtNewValueSimple").val('');
        });

        $('#txtNewValueComplex').keyup(function () {
            $("#lblNewValueComplex").text("New Rule Value: " + $("#txtNewValueComplex").val());
            //Clear the control content
            //$("#txtNewValueSimple").val('');
        });

        //handle dynamic adding of control to the modal box
        $("[id*=gridViewCompValue] tr").click(function () {            
            var totalcount = $("[id*=gridViewCompValue] tr").length;
            //var totalcountMinusHeader = $("[id*=gridViewCompValue] td").closest("tr").length;
            //var columnCount = $("[id*=gridViewCompValue]").find("tr")[0].cells.length;
            

            //var row = $(this).closest("tr");
            //var headerrow = $("[id*=gridViewCompValue] tr");
            //global = headerrow;
            //row.css("background-color", "red");
            //var message = "";
            //$("#cmbColumnListComplex").empty().append("");
            //alert(message);
        });

        $("#cmbColumnListComplex").change(function () {
            //alert("welcome");
        });

        //Control validator for value changes
        $('#btnChangeValue').click(function (e) {
            const RULE_TYPES_SIMPLE = "Simple";
            const RULE_TYPES_COMPOUND = "Compound";

            //Simple rule validation control
            var ruletype = $("#hndType").val();
            //alert(ruletype);
            if (ruletype == RULE_TYPES_SIMPLE) {
                $("#divCompoundRuleAdjustment").css('display', 'none');
                var newvaluesimple = $("#txtNewValueSimple").val();
                if(newvaluesimple.length < 1 || newvaluesimple == null){
                    //$('#divModalChanges').css('display', 'table');
                    $('#lblErrorChangeValue').text("The new value for the simple rule modification is required");
                    $('#exampleModalCenterValue').modal('show');
                } else {
                    $('#divModalChanges').css('display', 'none');
                    return;
                }
            }
            else if (ruletype == RULE_TYPES_COMPOUND) {
                $("#divSimpleRuleAdjustment").css('display', 'none');
                var newvaluecompound = $("#txtNewValueComplex").val();
                if (newvaluecompound.length < 1 || newvaluecompound == null) {
                    //$('#divModalChanges').css('display', 'table');
                    $('#lblErrorChangeValue').text("The new value for the compound rule modification is required");                    
                    $('#exampleModalCenterValue').modal('show');
                } else {
                    $('#divModalChanges').css('display', 'none');
                    return;
                }
            }
        });

        $('#cmbColmnList').on('change', function () {
            if ($('#cmbColmnList').find('option:selected').text() !== 'value') {
                $('#divModalChanges').css('display', 'flex');
                $('#lblErrorChangeValue').text("Only fields in the value column list can me modified");
            }
            else {
                $('#divModalChanges').css('display', 'none');
                return;
            }
        });

        //control validator for Analyst comment
        $('#btnSave').click(function (e) {
            e.preventDefault();
            if ($('#txtAreaComment').val().length < 1){
                $('.divmodalcomment').css('display', 'flex');
                $('#lblModalError').text("Analyst comment is required");

                //Open the modal box again if validation failed
                openModal();
                return;
            }
            else {
                $('.divmodalcomment').css('display', 'none');
            }
        });

        //filtering function
        function filterGrid(columnIndex, id) {
            var filterText = $("#" + id).val().toLowerCase();

            var cellText = "";
            var cellTextSampleToCompare = "";

            $("#<%=gridViewRules.ClientID%> tr:has(td)").each(function () {
                cellText = $(this).find("td:eq(" + columnIndex + ")").text().toLowerCase();
                cellText = $.trim(cellText);
                cellTextSampleToCompare = cellText.includes(filterText);

                if (cellTextSampleToCompare == false) {
                    $(this).css('display', 'none');
                }
                else {
                    $(this).css('display', '');
                }
            });
        }

        $("#btnCancelPopup").click(function () {
            $("#exampleModalCenter").modal('hide');
        });
        
        var indexSelection = 0;
        function toggleColumnIndex(index)
        {
            indexSelection = index;
            console.log(index + "- selection =" + indexSelection);
            $('#txtSearchCompRule').focus();
        }
        //Filter the gridview content by the search string
        $(document).ready(function () {
            $("#txtSearchCompRule").on("keyup", function () {
                if (indexSelection == 0)
                    return;
                else
                {
                    filterGrid(indexSelection, "txtSearchCompRule");
                }
            });
        });
    </script>
</body>
</html>