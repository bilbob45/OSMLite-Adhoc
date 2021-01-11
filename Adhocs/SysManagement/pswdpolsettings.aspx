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
            $("#txtDefaultValue").inputFilter(function (value) {
                return /^\d*$/.test(value);
            });
            $("#txtPolicyValue").inputFilter(function (value) {
                return /^\d*$/.test(value);
            });

            //Select 2 initializer
            $('#cmbEnable').select2();
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

        .WrapText {  
            width: 100%;  
            word-break: break-all;  
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
                        <asp:Label ID="lblError" runat="server" Text=""> </asp:Label>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                </div>
            </div>

            <div class="form-row mb-4">
                <label class="h4">Password Policy Settings</label>
            </div>
            <div class="form-row">
                <div class="form-group col-md-2">
                    <div class="dropdown">
                        <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButtonQuery" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Choose Action</button>
                        <div class="dropdown-menu" aria-labelledby="dropdownMenuButtonQuery">
                            <a class="dropdown-item" runat="server" id="btnEditPolicy" href="#" onserverclick="btnEditPolicy_ServerClick">Edit Policy Entry</a>
                            <a class="dropdown-item" runat="server" id="btnSaveChanges" onserverclick="btnSave_ServerClick" href="#">Save all changes</a>
                        </div>
                    </div>
                </div>
                <div class="form-group col-md-10">
                    <input type="text" placeholder="Search password policy - enter policy name" autocomplete="off" id="txtSearchPolicy" class="form-control" />
                </div>
            </div>
            <div class="form-row" id="divGrids" runat="server">
                <div class="form-group col-md-12" style="overflow: scroll; max-height: 400px">
                    <div class="WrapText">
                        <asp:GridView ID="gridViewPasswordPolicy"
                            runat="server"
                            HeaderStyle-Wrap="false"
                            RowStyle-Wrap="false"
                            DataKeyNames="Configuration ID"
                            EmptyDataText="There is no data available to display"
                            AutoGenerateColumns="true"
                            ViewStateMode="Enabled" RowStyle-CssClass="WrapText"
                            CssClass="table table-striped table-bordered table-hover table-header-fixed"
                            OnRowDataBound="gridViewPasswordPolicy_RowDataBound" OnSelectedIndexChanged="gridViewPasswordPolicy_SelectedIndexChanged"
                            AutoGenerateSelectButton="true">
                            <EditRowStyle BackColor="#000FFF" />
                            <SelectedRowStyle BackColor="#999999" ForeColor="white" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>

        <!-- Modal Work Collection tabindex="-1"-->
        <div class="modal fade" id="exampleModalCenterX" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLongTitleX">Update Password Policy Entry</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body" style="overflow: hidden;">
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <div class="alert alert-danger alert-dismissible" role="alert" runat="server" visible="false"  id="divAlertInPopupX">
                                    <asp:Label runat="server" ID="lblErrorInPopupX" Text=""></asp:Label>
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <label class="h5" runat="server" id="lblEntryTitleX"></label>
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="form-group col-md-4">
                                <label for="txtDefaultValue">Default Value
                                    <label style="color: red">*</label>
                                </label>
                                <input type="text" id="txtDefaultValue" runat="server" required="required" placeholder="Default Value" class="form-control" />
                            </div>

                            <div class="form-group col-md-4">
                                <label for="txtPolicyValue">Policy Value
                                    <label style="color: red">*</label>
                                </label>
                                <input type="text" id="txtPolicyValue" runat="server" required="required" placeholder="Policy Value" class="form-control" />
                            </div>

                            <div class="form-group col-md-4">
                                <label for="cmbEnable">Enable
                                    <label style="color: red">*</label>
                                </label>
                                <asp:DropDownList CssClass="form-control" ID="cmbEnable" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbRequiredDigit_SelectedIndexChanged">
                                    <asp:ListItem Text="--choose one--" Value="00" Selected="True"> </asp:ListItem>
                                    <asp:ListItem Text="Enable" Value="1"> </asp:ListItem>
                                    <asp:ListItem Text="Disabled" Value="0"> </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        
                    </div>
                    <div class="modal-footer">
                        <button type="button" id="btnUpdatePolicySettings" runat="server" class="btn btn-primary" onserverclick="btnUpdatePolicySettings_ServerClick">Update Policy Settings</button>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Modal -->

    </form>
    <script type="text/javascript">
        //filtering function
        function filterGrid(columnIndex, id) {
            var filterText = $("#" + id).val().toLowerCase();

            var cellText = "";
            var cellTextSampleToCompare = "";

            $("#<%=gridViewPasswordPolicy.ClientID%> tr:has(td)").each(function () {
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
            $("#txtSearchPolicy").on("keyup", function () {
                filterGrid(4, "txtSearchPolicy");
            });
        });
    </script>
</body>
</html>

