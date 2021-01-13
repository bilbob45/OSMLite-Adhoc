<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vpenalty.aspx.cs" ClientIDMode="Static" Inherits="Adhocs.penalty.vpenalty" %>

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

    <link href="../assets/style/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="../assets/style/jquery.mCustomScrollbar.min.css" rel="stylesheet" />

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
    <style type="text/css">
        .styled-table {
            border-collapse: collapse;
            margin: 25px 0;
            font-size: 0.9em;
            font-family: sans-serif;
            width: inherit;
            min-width: 400px;
            box-shadow: 0 0 20px rgba(0, 0, 0, 0.15);
        }

            .styled-table thead tr {
                background-color: #009879;
                color: #ffffff;
                text-align: left;
            }

            .styled-table th, .styled-table td {
                padding: 12px 15px;
            }

            .styled-table tbody tr {
                border-bottom: thin #dddddd;
            }

                .styled-table tbody tr:nth-of-type(even) {
                    background-color: #f3f3f3;
                }

                .styled-table tbody tr:last-of-type {
                    border-bottom: 2px solid #009879;
                }

                .styled-table tbody tr.active-row {
                    font-weight: bold;
                    color: #009879;
                }

    </style>
</head>
<body>
    <form runat="server" id="frmPenalty">
        <div class="" style="width: auto; margin:5px;">
            <div class="form-row">
                <div class="form-group col-md-12">
                    <div class="alert alert-danger alert-dismissible" role="alert" runat="server" id="divAlert">
                        <asp:Label ID="lblReportName" runat="server"> </asp:Label>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                </div>
            </div>

            <div class="form-row">
                <%--<div class="form-group col-md-5">
                    <input type="text" placeholder="Filter penalty - enter penalty description" autocomplete="off" id="txtSearchReports" class="form-control" />
                </div>--%>
                <div class="form-group col-md-3">
                    <div class="dropdown">
                        <button class="btn btn-secondary btn-sm dropdown-toggle" type="button" id="dropdownMenuButtonQuery" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Choose Action</button>
                        <div class="dropdown-menu" aria-labelledby="dropdownMenuButtonQuery">
                            <a class="dropdown-item" runat="server" id="lblAddNewPenalty" href="#" onserverclick="lblAddNewPenalty_ServerClick">Add New Penalty</a>
                            <a class="dropdown-item" runat="server" id="lblEditPenalty" href="#">View Penalty Details</a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="form-group col-md-12">
                    <asp:GridView ID="gridViewPenalties"
                            runat="server" SelectMethod="gridViewPenalties_GetData"
                            HeaderStyle-Wrap="false"
                            RowStyle-Wrap="true"
                            EmptyDataText="There is no report(s) to display for the selected department"
                            AutoGenerateColumns="true"
                            ViewStateMode="Enabled"
                            CssClass="table table-bordered table-hover table-header-fixed"
                            AutoGenerateSelectButton="False" OnRowDataBound="gridViewPenalties_RowDataBound">
                            <EditRowStyle BackColor="#000FFF" />
                            <SelectedRowStyle BackColor="#999999" ForeColor="white" />
                        <%--<Columns>
                        <asp:TemplateField AccessibleHeaderText="Action">
                            <HeaderTemplate>
                                <span></span>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="col-12 col-md-auto d-flex justify-content-between align-items-center">
                                    <button type="button" class="btn btn-sm btn-soft-warning btn-icon rounded-pill" runat="server" id="btnView">View Details</button>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>--%>
                        </asp:GridView>
                </div>
        </div>

        <!--modal to view penalty details-->
            <div class="modal fade" id="exampleModalCenter" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title ml-2" style="font-weight:200" id="exampleModalLongTitle">Penalty Details</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body" style="display:none">
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
                                
                            </div>
                            <div class="form-group col-md-6">
                                <label>Penalty Description: </label>
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label>RI Type: </label>
                                
                            </div>
                            <div class="form-group col-md-6">
                                <label>Penalty Type: </label>
                                
                            </div>
                        </div>
                        
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label>Penalty Frequency: </label>
                                
                            </div>
                            <div class="form-group col-md-6">
                                <label>Penalty Frequency Unit: </label>
                                
                            </div>
                        </div>
                        
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label>Delivery Deadline Day: </label>
                                
                            </div>
                            <div class="form-group col-md-6">
                                <label>Delivery Deadline Hour: </label>
                                
                            </div>
                        </div>
                        
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label>Delivery Deadline Minutes: </label>

                            </div>
                            <div class="form-group col-md-6">
                                <label>Penalty Limit: </label>
                                
                            </div>
                        </div>
                        
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label>Penalty Value: </label>
                                
                            </div>
                            <div class="form-group col-md-6">
                                <label>Start Validity Date: </label>
                                
                            </div>
                        </div>
                        
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label>End Validity Date: </label>
                            </div>
                        </div>
                    </div>

                    <div class="modal-body">
                        <table class="table dt-head-nowrap" id="tblPv1">
                            <thead>
                                <tr>
                                    <th scope="col" class="nowrap">Code</th>
                                    <th scope="col" class="nowrap">Description</th>
                                    <th scope="col" class="nowrap">RI Type</th>
                                    <th scope="col" class="nowrap">Penalty Type</th>
                                    <th scope="col" class="nowrap">Frequency</th>
                                    <th scope="col" class="nowrap">Freq. Unit</th>
                                    <%--<th scope="col" class="nowrap">Deadline Day</th>
                                    <th scope="col" class="nowrap">Deadline Hour</th>
                                    <th scope="col" class="nowrap">Deadline Minutes</th>
                                    <th scope="col" class="nowrap">Penalty Limits</th>
                                    <th scope="col" class="nowrap">Penalty Value</th>--%>
                                    <th scope="col" class="nowrap">Val. Date</th>
                                    <%--<th scope="col" class="nowrap">End Val. Date</th>--%>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        <label id="lblPenaltyCode" runat="server" class="font-weight-bold form-control-plaintext"></label>
                                    </td>
                                    <td>
                                        <label id="lblPenaltyDescription" runat="server" class="font-weight-bold"></label>
                                    </td>
                                    <td>
                                        <label id="lblRiType" runat="server" class="font-weight-bold"></label>
                                    </td>
                                    <td>
                                        <label id="lblPenaltyType" runat="server" class="font-weight-bold"></label>
                                    </td>
                                    <td>
                                        <label id="lblPenaltyFrequency" runat="server" class="font-weight-bold"></label>
                                    </td>
                                    <td>
                                        <label id="lblPenaltyFrequencyUnit" runat="server" class="font-weight-bold"></label>
                                    </td>
                                    <%--<td>
                                        <label id="lblDeliveryDay" runat="server" class="font-weight-bold"></label>
                                    </td>
                                    <td>
                                        <label id="lblDeliveryHour" runat="server" class="font-weight-bold"></label>
                                    </td>
                                    <td>
                                        <label id="lblDeliveryMinute" runat="server" class="font-weight-bold"></label>
                                    </td>--%>
                                    <%--<td>
                                        <label id="lblPenaltyLimit" runat="server" class="font-weight-bold"></label>
                                    </td>
                                    <td>
                                        <label id="lblPenaltyvalue" runat="server" class="font-weight-bold"></label>
                                    </td>
                                    <td>
                                        <label id="lblValidityStart" runat="server" class="font-weight-bold"></label>
                                    </td>--%>
                                    <%--<td>
                                        <label id="lblValidityEnd" runat="server" class="font-weight-bold"></label>
                                    </td>--%>
                                </tr>
                            </tbody>
                        </table>
                    </div>

                    <div class="modal-footer">
                        <button type="button" id="btnCancel" runat="server" onclick="ClosePopUp()" class="btn btn-primary">Close</button>
                    </div>
                </div>
            </div>
        </div>
        <!--end modal to view penalty details-->
    </form>

    <!-- javascript plugins-->
    <script src="../assets/jquery.dataTables.min.js"></script>
    <script src="../assets/jquery.validate.min.js"></script>


    <script type="text/javascript">

        var responseData = "";

        function ClosePopUp() {
            $("#btnCancel").click(function () {
                $("#exampleModalCenter").modal('hide');
            });
        }

        function getDT(pcode) {
           
        }
        
        //Filter the gridview content by the search string
        $(document).ready(function () {

            $('#divAlert').hide();

            var table = $('#gridViewPenalties').DataTable();
            $(document).on('click', '#<%= gridViewPenalties.ClientID %> tr', function (e) {

                var pcode = table.row(this).data()[0];

                if (pcode == undefined)
                    return;

                //alert(pcode);

                var data = {
                    pcode : pcode
                };

                $.ajax({
                    type: 'POST',
                    url: 'vpenalty.aspx/GetPenaltyDetails',
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(data),
                    success: function (response) {

                        responseData = (response.d !== null || response.d !== undefined) ? response.d : response

                        console.log(responseData);

                        $("#lblPenaltyCode").empty().html(responseData.pcode);
                        $("#lblPenaltyDescription").empty().html(responseData.pdescription);
                        $("#lblRiType").empty().html(responseData.ritypedesc);
                        $("#lblPenaltyType").empty().html(responseData.type);
                        $("#lblPenaltyFrequency").empty().html(responseData.freq);
                        $("#lblPenaltyFrequencyUnit").empty().html(responseData.frequnit);
                        //$("#lblDeliveryDay").html(responseData.dday);
                        //$("#lblDeliveryHour").html(responseData.dhour);
                        //$("#lblDeliveryMinute").html(responseData.dmin);
                        //$("#lblPenaltyLimit").html(responseData.plimit);
                        //$("#lblPenaltyvalue").html(responseData.pvalue);
                        $("#lblValidityStart").empty().html(new Date(responseData.pstartval).toString());
                        //$("#lblValidityEnd").html(responseData.pendtval);

                        $('#exampleModalCenter').modal('show');
                    
                    },
                    error: function (data) {
                        console.log(data);
                    }
                });
            });
            
            //table.find("tbody").on('click', 'tr', function (e) {

            //    alert(this.rowIndex - 1);

            //    //Make an ajax callt to get the details of the selected row 
            //    //or display a modal pop-up choosing it's data from the gridview
            //    var data = {
            //        nok: nok
            //    };

            //    var responseData = "";
            //    $.ajax({
            //        type: "POST",
            //        url: "vpenalty.aspx/Save",
            //        dataType: "json",
            //        contentType: "application/json; charset=utf-8",
            //        data: JSON.stringify(data),
            //        success: function (response) {

            //            responseData = (response.d !== null || response.d !== undefined) ? response.d : response;

            //            //Error occured
            //            if (responseData.Status == "0") {

            //                $("#divAlert").addClass("alert alert-danger alert-dismissible fade show").slideDown("slow");
            //                $("#lblErrorText").html(responseData.Message);
            //                return;
            //            }
            //            //Ajax suceeds
            //            else if (responseData.Status == "1") {

            //                $("#divAlert").removeClass("alert alert-danger alert-dismissible fade show");
            //                $("#divAlert").addClass("alert alert-success alert-dismissible fade show").slideDown("slow");
            //                $("#lblErrorText").html(responseData.Message);
            //                location.reload(true);
            //            }
            //            else
            //                return;
            //        },
            //        error: function (data) {
            //            $("#divAlert").addClass("alert alert-danger alert-dismissible fade show").slideDown("slow");
            //            $("#lblErrorText").html(responseData.Message);
            //        }
            //    });

            //    e.preventDefault();

            //});

        });
    </script>
</body>
</html>
