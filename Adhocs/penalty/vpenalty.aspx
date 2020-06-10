<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vpenalty.aspx.cs" Inherits="Adhocs.penalty.vpenalty" %>

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
            $("#DropDownList1").select2();
        });

        function openModalViewPenalty() {
             $('#exampleModalCenter').modal('show');
         }
    </script>
    <style type="text/css" lang="en">
        * {
            font-size: 11px;
            line-height: 2;
        }
    </style>
</head>
<body>
    <form runat="server" id="frmPenalty">
        <div class="" style="width: auto; margin:5px;">
            <div class="form-row">
                <div class="form-group col-md-12">
                    <div class="alert alert-danger alert-dismissible" role="alert" visible="false" runat="server" id="divAlert">
                        <asp:Label ID="lblReportName" runat="server"> </asp:Label>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                </div>
            </div>

            <div class="form-row">
                <div class="form-group col-md-5">
                    <input type="text" placeholder="Filter penalty - enter penalty description" autocomplete="off" id="txtSearchReports" class="form-control" />
                </div>
                <div class="form-group col-md-3">
                    <div class="dropdown">
                        <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButtonQuery" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Choose Action</button>
                        <div class="dropdown-menu" aria-labelledby="dropdownMenuButtonQuery">
                            <a class="dropdown-item" runat="server" id="lblAddNewPenalty" href="#" onserverclick="lblAddNewPenalty_ServerClick">Add New Penalty</a>
                            <a class="dropdown-item" runat="server" id="lblEditPenalty" href="#" onserverclick="lblEditPenalty_ServerClick">View Penalty Details</a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="form-row" id="divGrids" runat="server">
                <div class="form-group col-md-12" style="overflow:scroll; max-height:400px">
                    <label for="gridViewPenalties" runat="server" id="lblTableName300" class="font-weight-bold"></label>
                    <div>
                        <asp:GridView ID="gridViewPenalties"
                            runat="server"
                            HeaderStyle-Wrap="false"
                            RowStyle-Wrap="false"
                            EmptyDataText="There is no report(s) to display for the selected department"
                            AutoGenerateColumns="true"
                            ViewStateMode="Enabled"
                            CssClass="table table-striped table-bordered table-hover table-header-fixed"
                            AutoGenerateSelectButton="True" OnSelectedIndexChanged="gridViewPenalties_SelectedIndexChanged" OnRowDataBound="gridViewPenalties_RowDataBound">
                            <EditRowStyle BackColor="#000FFF" />
                            <SelectedRowStyle BackColor="#999999" ForeColor="white" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>

        <!--modal to view penalty details-->
            <div class="modal fade" id="exampleModalCenter" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLongTitle">Penalty</h5>
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
                            <div class="form-group col-md-12">
                                <label class="h4">Penalty Details</label>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label>Penalty Code: </label>
                                <label id="lblPenaltyCode" runat="server" class="font-weight-bold form-control-plaintext"></label>
                            </div>
                            <div class="form-group col-md-6">
                                <label>Penalty Description: </label>
                                <label id="lblPenaltyDescription" runat="server" class="font-weight-bold"></label>
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label>RI Type: </label>
                                <label id="lblRiType" runat="server" class="font-weight-bold"></label>
                            </div>
                            <div class="form-group col-md-6">
                                <label>Penalty Type: </label>
                                <label id="lblPenaltyType" runat="server" class="font-weight-bold"></label>
                            </div>
                        </div>
                        
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label>Penalty Frequency: </label>
                                <label id="lblPenaltyFrequency" runat="server" class="font-weight-bold"></label>
                            </div>
                            <div class="form-group col-md-6">
                                <label>Penalty Frequency Unit: </label>
                                <label id="lblPenaltyFrequencyUnit" runat="server" class="font-weight-bold"></label>
                            </div>
                        </div>
                        
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label>Delivery Deadline Day: </label>
                                <label id="lblDeliveryDay" runat="server" class="font-weight-bold"></label>
                            </div>
                            <div class="form-group col-md-6">
                                <label>Delivery Deadline Hour: </label>
                                <label id="lblDeliveryHour" runat="server" class="font-weight-bold"></label>
                            </div>
                        </div>
                        
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label>Delivery Deadline Minutes: </label>
                                <label id="lblDeliveryMinute" runat="server" class="font-weight-bold"></label>
                            </div>
                            <div class="form-group col-md-6">
                                <label>Penalty Limit: </label>
                                <label id="lblPenaltyLimit" runat="server" class="font-weight-bold"></label>
                            </div>
                        </div>
                        
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label>Penalty Value: </label>
                                <label id="lblPenaltyvalue" runat="server" class="font-weight-bold"></label>
                            </div>
                            <div class="form-group col-md-6">
                                <label>Start Validity Date: </label>
                                <label id="lblValidityStart" runat="server" class="font-weight-bold"></label>
                            </div>
                        </div>
                        
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label>End Validity Date: </label>
                                <label id="lblValidityEnd" runat="server" class="font-weight-bold"></label>
                            </div>
                            <div class="form-group col-md-6">
                                <label>Created By: </label>
                                <label id="lblCreatedBy" runat="server" class="font-weight-bold"></label>
                            </div>
                        </div>
                        
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label>Created Date: </label>
                                <label id="lblCreatedDate" runat="server" class="font-weight-bold"></label>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" id="btnCancel" runat="server" onclick="ClosePopUp()" class="btn btn-primary">Close</button>
                    </div>
                </div>
            </div>
        </div>
        <!--end modal to view penalty details-->
    </form>

    <script type="text/javascript">
        //filtering function
        function filterGrid(columnIndex, id) {
            var filterText = $("#" + id).val().toLowerCase();

            var cellText = "";
            var cellTextSampleToCompare = "";

            $("#<%=gridViewPenalties.ClientID%> tr:has(td)").each(function () {
                cellText = $(this).find("td:eq(" + columnIndex + ")").text().toLowerCase();
                cellText = $.trim(cellText);
                cellTextSampleToCompare = cellText.includes(filterText); //.substring(0, filterText.length);

                if (cellTextSampleToCompare == false) {
                    $(this).css('display', 'none');
                }
                else {
                    $(this).css('display', '');
                }
            });
        }
        
        //Filter the gridview content by the search string
        $(document).ready(function () {
            $("#txtSearchReports").on("keyup", function () {
                filterGrid(2, "txtSearchReports");
            });
        });

        function ClosePopUp() {
            $("#btnCancel").click(function () {
                $("#exampleModalCenter").modal('hide');
            });
        }
    </script>

</body>
</html>
