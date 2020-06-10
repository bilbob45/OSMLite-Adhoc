<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="radjustment.aspx.cs" Inherits="Adhocs.returns.radjustment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> </title>
    <!--bootstrap css-->
    <link href="../assets/style/bootstrap.min.css" rel="stylesheet" />
    <!--select 2 css-->
    <link href="../assets/select2/css/select2.min.css" rel="stylesheet" />
    <!--jquery js-->
    <script src="../assets/script/jquery-2.2.4.min.js"></script>
    <script src="../assets/script/bootstrap.bundle.min.js"></script>
    <!--bootstrap datetime picker js-->
    <script src="Scripts/bootstrap-datetimepicker.min.js"></script>
    <!--select 2 js-->
    <script src="../assets/select2/js/select2.full.min.js"></script>

    <script type="text/javascript">
        //Select 2 initializer
        $(document).ready(function (e) {
            $('#cmbInstitutionType').select2();
            $('#cmbReportingInstitution').select2();
        });

        //Show the exampleModalCenter modal
        function openModal() {
            $('#exampleModalCenter').modal('show');
        }

        //Show the exampleModalCenter2 modal
        function openModal2() {
            $('#exampleModalCenter2').modal('show');
        }

        //Show the exampleModalCenter3 modal
        function openModal3() {
            $('#exampleModalCenter3').modal('show');
        }

        //Close all the modal boxes
        function ClosePopUp() {
            $('#exampleModalCenter').modal('hide'); //.toggle();
            $('#exampleModalCenter2').modal('hide');//toggle();
            $('#exampleModalCenter3').modal('hide');//toggle();
        }

        //
        $(function () {
            $('#txtWorkcollectionDate').on('Textchange', function () {
                alert($('#txtWorkcollectionDate').val());
            });
        });
    </script>

    <style type="text/css">
        * {
           font-size: 11px;
           line-height: 2;
        }
    </style>
</head>
<body>
    <form runat="server" id="frmRAdjustment">
        <asp:HiddenField ID="hdnValues" runat="server"/>
        <div style="width: auto; margin:2px" runat="server" id="container">
            <div class="form-row">                
                <div class="form-group col-md-12">
                    <div class="alert alert-danger alert-dismissible" role="alert" runat="server" visible="false" id="divAlert">
                        <asp:Label runat="server" ID="lblErrorMsg" Text=""></asp:Label>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                </div>
            </div>       
            
            <div class="form-row mb-4">
                <div class="col-md-6">
                    <span class="h4">Return Adjustment</span>
                </div>
            </div>

            <div class="form-row">
                <div class="form-group col-md-4">
                    <label for="cmbInstitutionType">Institution Type</label>
                    <asp:DropDownList CssClass="form-control" ID="cmbInstitutionType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbInstitutionType_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="form-group col-md-4">
                    <label for="cmbReportingInstitution">Reporting Institution</label>
                    <asp:DropDownList CssClass="form-control" ID="cmbReportingInstitution" runat="server" AutoPostBack="True"></asp:DropDownList>
                </div>
                <div class="form-group col-md-4">
                    <div id="datetimepicker" class="input-append date">
                        <label for="txtDate">Work Collection Date</label>
                        <asp:TextBox ID="txtWorkcollectionDate" CssClass="form-control form-control-inline input-medium date-picker" runat="server" TextMode="Date"></asp:TextBox>
                        <span class="add-on">
                            <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
                        </span>
                    </div>
                </div>
            </div>

            <div class="form-row">
                <div class="form-group col-md-12">
                    <div class="dropdown">
                        <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButtonQuery" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Choose Action</button>
                        <div class="dropdown-menu" aria-labelledby="dropdownMenuButtonQuery">
                            <a class="dropdown-item" runat="server" id="A1" onserverclick="btnAdjustReturn_ServerClick" href="#">View return</a>
                            <a class="dropdown-item" runat="server" id="lblAdjustReturn" onserverclick="lblAdjustReturn_ServerClick" href="#">Adjust selected return</a>
                            <a class="dropdown-item" runat="server" id="A2" onserverclick="btnAddAnalystComment_ServerClick" href="#">Save all changes</a>
                        </div>
                    </div>
             </div>            
            </div>
            
            <div runat="server" id="divGridResult" visible="false">
                <div class="form-row" id="divGrids" runat="server">
                        <div class="form-group col-md-6" style="top: -2px; left: 4px; ">
                            <label for="gridviewLeft300" runat="server" id="lblTableName300"  class="font-weight-bold"></label>
                            <div class="overflow-auto" style="height:auto">
                                        <asp:GridView ID="gridviewLeft300"
                                        runat="server" 
                                        HeaderStyle-Wrap="false"
                                        RowStyle-Wrap="true"
                                        EmptyDataText="There is no record(s) to display for the selected date"
                                        AutoGenerateColumns="true"
                                        ViewStateMode="Enabled"                                
                                        CssClass="table table-striped table-bordered table-hover table-header-fixed pre-scrollable table-responsive" 
                                            OnSelectedIndexChanged="gridviewLeft300_SelectedIndexChanged" AutoGenerateSelectButton="True" OnPageIndexChanging="gridviewLeftRight_PageIndexChanging" OnRowDataBound="griviewReturnAdjusted_RowDataBound">
                                        <EditRowStyle BackColor="#000FFF" />
                                        <SelectedRowStyle BackColor="#999999" ForeColor="White" />
                                    </asp:GridView>
                                    </div>
                        </div>
                    <div class="form-group col-md-6" style="border-left: 0px dashed #333; border-color:deepskyblue">
                        <label for="gridviewRight1000" class="font-weight-bold" runat="server" id="lblTableName1000"></label>
                        <div class="overflow-auto" style="height:auto">
                                <asp:GridView ID="gridviewRight1000"
                                runat="server" 
                                HeaderStyle-Wrap="false"
                                     RowStyle-Wrap="true"
                                EmptyDataText="There is no record(s) to display for the selected date"
                                AutoGenerateColumns="true" 
                                ViewStateMode="Enabled"                            
                                        CssClass="table table-striped table-bordered table-hover table-header-fixed pre-scrollable table-responsive"  
                                    AutoGenerateSelectButton="True" OnPageIndexChanging="gridviewLeftRight_PageIndexChanging" OnSelectedIndexChanged="gridviewRight1000_SelectedIndexChanged"  OnRowDataBound="gridviewRight1000_RowDataBound">
                                <EditRowStyle BackColor="#000FFF" />
                                <SelectedRowStyle BackColor="#999999" ForeColor="White" />
                            </asp:GridView>
                              </div>
                    </div>
                </div>
        </div>
        </div>

        <!-- Modal 1-->
            <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLongTitle"> <%=this.lblTableName300.InnerText%> </h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>

                    <div class="modal-body">
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
                            <div class="form-group col-md-6 mb-0">
                                <label runat="server" id="lblItemCode" class="font-weight-bold"></label>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-12 mb-0">
                                <label runat="server" id="lblDescriptionToModify" class="font-weight-bold"></label>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-12 mb-0">
                                <label runat="server" id="lblLocalCurrencyToModify" class="font-weight-bold"></label>
                            </div>
                        </div>
                        <div class="form-row" runat="server" visible="true" style="display:none" id="div300Mdhr3">
                            <div class="form-group col-md-12 mb-0">
                                <label runat="server" id="lblLocalCurrencyToModify2nd" class="font-weight-bold"></label>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-12 mb-0">
                                <label runat="server" id="lblAdjReason" class="font-weight-bold"></label>
                            </div>
                        </div>
                         <div class="form-row">
                            <div class="form-group col-md-12 mb-0">
                                <hr />
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6" runat="server" id="div300Mdhr1">
                                <label for="txtNewCurrencyValue">Amount</label>
                                <input type="text" id="txtNewCurrencyValue" runat="server" required="required" placeholder="New Amount" class="form-control" />
                            </div>
                            <div class="form-group col-md-6" style="display:none" id="div300Mdhr2" runat="server">
                                <label for="txtNewCurrencyValue2">Amount</label>
                                <input type="text" id="txtNewCurrencyValue2" runat="server" required="required" placeholder="New Amount" class="form-control" />
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <label for="txtAreaModal1">Reason for Adjustment</label>
                                <textarea id="txtAreaModal1" cols="20" rows="5" runat="server" required="required" placeholder="Add your reason for adjustment" class="form-control"></textarea>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" id="btnCancelPopup" runat="server" onclick="ClosePopUp()" class="btn btn-primary">Cancel</button>
                        <button type="button" id="btnProceedToReturnAdjustment" onserverclick="btnProceedToReturnAdjustment_ServerClick" runat="server" class="btn btn-primary">Proceed</button>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Modal -->

        <!-- Modal 2-->
            <div class="modal fade" id="exampleModalCenter2" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLongTitle2"><%=this.lblTableName1000.InnerText%></h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>

                    <div class="modal-body">
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <div class="alert alert-danger alert-dismissible" role="alert" style="display:none" id="divAlertInPopup2">
                                    <asp:Label runat="server" ID="lblErrorMsgInPopup2" Text=""></asp:Label>
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6 mb-0">
                                <label runat="server" id="lblItemCode2" class="font-weight-bold"></label>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-12 mb-0">
                                <label runat="server" id="lblDescriptionToModify2" class="font-weight-bold"></label>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-12 mb-0">
                                <label runat="server" id="lblLocalCurrencyToModify2" class="font-weight-bold"></label>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-12 mb-0">
                                <label runat="server" id="lblLocalCurrencyToModify3" class="font-weight-bold"></label>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-12 mb-0">
                                <label runat="server" id="lblAdjReason2" class="font-weight-bold"></label>
                            </div>
                        </div>
                         <div class="form-row">
                            <div class="form-group col-md-12 mb-0">
                                <hr />
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label for="txtNewLastMonthCurrencyValue">Amount (Last Month)</label>
                                <input type="text" id="txtNewLastMonthCurrencyValue" runat="server" required="required" placeholder="Amount last month currency" class="form-control" />
                            </div>
                            <div class="form-group col-md-6">
                                <label for="txtNewYearToDateCurrencyValue">Amount (Year to Date)</label>
                                <input type="text" id="txtNewYearToDateCurrencyValue" runat="server" required="required" placeholder="New year to date currency" class="form-control" />
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <label for="txtAreaModal2">Reason for Adjustment</label>
                                <textarea id="txtAreaModal2" cols="20" rows="5" runat="server" required="required" placeholder="Add your reason for adjustment" class="form-control"></textarea>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" id="btnCancelPopup2" runat="server" onclick="ClosePopUp()" class="btn btn-primary">Cancel</button>
                        <button type="button" id="btnProceedToReturnAdjustment2" onserverclick="btnProceedToReturnAdjustment_ServerClick" runat="server" class="btn btn-primary">Proceed</button>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Modal -->

        <!-- Modal 3-->
            <div class="modal fade" id="exampleModalCenter3" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLongTitle3">Add Comment(s)</h5>
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
                                <label for="txtNewLastMonthCurrencyValue">Analyst Comment</label>
                                <textarea id="txtAreaAnalystComment" cols="20" rows="5" runat="server" required="required" placeholder="Enter an overall analyst comments...." class="form-control"></textarea>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <input id="Button1" class="form-control btn btn-primary" type="button" value="Save" runat="server" onserverclick="btnSaveAllChanges_ServerClick" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Modal -->

        
        
        <!--Registered script block-->
        <script type="text/javascript">
            
        </script>
    </form>    

    <script type="text/javascript">
        $(function () {
            $("#txtDate").datepicker({
                dateFormat: "yy-dd-mm"
            });
        });

        jQuery(document).ready(function (e) {

            jQuery("#cmbReportingInstitution").on("change", function () {
                jQuery("#divGrids").css("display", "grid");
            });

            jQuery("#btnCancelPopup").click(function () {
                $('#exampleModalCenter').modal('hide');
            });
            jQuery("#btnCancelPopup2").click(function () {
                $('#exampleModalCenter2').modal('hide');
            });

            jQuery("#btnCancelPopup2").click(function () {
                $('#exampleModalCenter2').modal('hide');
            });
            
            jQuery("#btnProceedToReturnAdjustment").click(function (e) {
                e.preventDefault();
                var txtNewCurrencyValue = jQuery("#txtNewCurrencyValue").val();
                if(txtNewCurrencyValue == null || txtNewCurrencyValue.length < 1){
                    jQuery("#divAlertInPopup").toggle("slide");
                    jQuery("#lblErrorMsgInPopup").text("All fields are required");
                }
                else {
                    return;
                }
            });

            jQuery("#btnProceedToReturnAdjustment2").click(function (e) {
                e.preventDefault();
                var txtNewCurrencyValue = jQuery("#txtNewCurrencyValue").val();
                if(txtNewCurrencyValue == null || txtNewCurrencyValue.length < 1){
                    jQuery("#divAlertInPopup2").toggle("slide");
                    jQuery("#lblErrorMsgInPopup2").text("All fields are required");
                }
                else {
                    return;
                }
            });
        });
    </script>
</body>
</html>
