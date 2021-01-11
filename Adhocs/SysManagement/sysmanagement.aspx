<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="sysmanagement.aspx.cs" Inherits="Adhocs.SysManagement.sysmanagement" %>

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
        //Show the exampleModalCenter2 modal
        function ConfirmDeactivation() {
            $('#DeactivateModal').modal('show');
        }
    </script>

    <style type="text/css" lang="en">
        * {
            font-size: 11px;
            line-height: 1;
        }

        .select2 {
            width: 100% !important;
        }
    </style>
</head>
<body>
    <form id="frmsysmanagement" runat="server">
        <div class="">
            <ul class="nav nav-tabs" id="myTab" role="tablist">
                <li class="nav-item">
                    <a class="nav-link active" id="home-tab" data-toggle="tab" href="#home" role="tab" aria-controls="home" aria-selected="true">User Settings</a>
                </li>
            </ul>

            <div class="tab-content">
                <div class="tab-pane active" id="home" role="tabpanel" aria-labelledby="home-tab">
                    <div class="" style="width: auto; margin: 5px">
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <div class="alert alert-success alert-dismissible" role="alert" visible="false" runat="server" id="divAlert">
                                    <asp:Label ID="lblError" runat="server"> </asp:Label>
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                            </div>
                        </div>
                        <div class="form-row mb-4">
                            <div class="col-md-6">
                                <span class="h4">Application Users</span>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <input type="text" placeholder="Search user - Enter username" autocomplete="off" id="txtSearchUser" class="form-control" />
                            </div>
                        </div>
                        <div class="form-row" id="divGrids" runat="server">
                            <div class="form-group col-md-12" style="overflow: scroll; max-height: 600px">
                                <label for="gridViewListUser" runat="server" id="lblTableName300" class="font-weight-bold"></label>
                                <div>
                                    <asp:GridView ID="gridViewListUser"
                                        runat="server"
                                        HeaderStyle-Wrap="false"
                                        RowStyle-Wrap="false"
                                        DataKeyNames="Application User ID"
                                        EmptyDataText="There is no report(s) to display for the selected department"
                                        AutoGenerateColumns="true"
                                        ViewStateMode="Enabled"
                                        CssClass="table table-striped table-bordered table-hover table-header-fixed"
                                        OnRowDataBound="gridViewListUser_RowDataBound"
                                        OnSelectedIndexChanged="gridViewListUser_SelectedIndexChanged" AutoGenerateSelectButton="false">
                                        <EditRowStyle BackColor="#000FFF" />
                                        <SelectedRowStyle BackColor="#999999" ForeColor="white" />
                                        <Columns>
                                            <%--<asp:ButtonField ControlStyle-CssClass="btn btn-primary" Text="Enable Token"/>--%>
                                            <asp:TemplateField HeaderText="Action" ShowHeader="true">
                                                <ItemTemplate>
                                                    <div class="dropdown">
                                                        <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButtonQuery" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                            Choose Action
                                                        </button>
                                                        <div class="dropdown-menu" aria-labelledby="dropdownMenuButtonQuery">
                                                            <asp:Button OnCommand="btnDissableToken_Command" CommandName="DisableToken" CommandArgument='<%#Eval("Application User ID")%>' Text="Two Factor Token" class="dropdown-item" runat="server" ID="btnDissableToken" href="#"></asp:Button>
                                                            <asp:Button OnCommand="btnDissableToken_Command" CommandName="DeactivateUser" CommandArgument='<%#Eval("Application User ID")%>' Text="(De)Activate User" class="dropdown-item" runat="server" ID="btnDeactivateUser" href="#" Visible="false"></asp:Button>
                                                            <asp:Button OnCommand="btnDissableToken_Command" CommandName="ConfirmMail" CommandArgument='<%#Eval("Application User ID")%>' Text="Email Confirmation" class="dropdown-item" runat="server" ID="btnConfirmMail" href="#"></asp:Button>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Modal 3-->
        <div class="modal fade" id="DeactivateModal" tabindex="-1" role="dialog" aria-labelledby="DeactivateModalTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="DeactivateModalTitle">Account Deactivation - Confirmation</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>

                    <div class="modal-body">
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <div class="alert alert-primary" role="alert" id="divAlertInPopup3">
                                    <h4 class="alert-heading">Caution</h4>
                                    <asp:Label runat="server" CssClass="h5" ID="lblErrorMsgConfirm" Text=""></asp:Label>
                                    <hr />
                                    <span class="mb-2">The operation you're about to perform will cause major data changes within the system, proceed with caution
                                    </span>
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <input id="btnProceed" class="form-control btn btn-primary" onserverclick="btnProceed_ServerClick" type="button" value="Proceed" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Modal -->
    </form>
    <script type="text/javascript">
        $(function () {
            $('#myTab li:last-child a').tab('show');
        })
        //filtering function
        function filterGrid(columnIndex, id) {
            var filterText = $("#" + id).val().toLowerCase();

            var cellText = "";
            var cellTextSampleToCompare = "";

            $("#<%=gridViewListUser.ClientID%> tr:has(td)").each(function () {
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
            $("#txtSearchUser").on("keyup", function () {
                filterGrid(1, "txtSearchUser");
            });
        });
    </script>
</body>
</html>
