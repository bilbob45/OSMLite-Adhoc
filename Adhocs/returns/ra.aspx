<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ra.aspx.cs" Inherits="Adhocs.returns.ra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../assets/style/bootstrap.min.css" rel="stylesheet" />
    <script src="../assets/WebForms/GridView.js"></script>
    <script src="../assets/WebForms/TreeView.js"></script>
</head>
<body <%--id="returnBody" data-target="#exampleModalCenter" data-toggle="modal"--%>>
    <form runat="server" id="frmQueryBuilder">
        <asp:HiddenField ID="hdnValues" runat="server"/>
        <div class="container" style="width: 75%; font-size: small" runat="server">
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

            <div class="form-row">
                <div class="form-group col-md-6">
                    <label for="cmbInstitutionType">Institution Type</label>
                    <asp:DropDownList CssClass="form-control" ID="cmbInstitutionType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbInstitutionType_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="form-group col-md-6">
                    <label for="cmbReportingInstitution">Reporting Institution</label>
                    <asp:DropDownList CssClass="form-control" ID="cmbReportingInstitution" OnSelectedIndexChanged="lblSubmit_ServerClick" runat="server" AutoPostBack="True"></asp:DropDownList>
                </div>
            </div>

            <div class="form-row">
                <div class="form-group col-md-12">
                    <div id="datetimepicker" class="input-append date">
                        <label for="txtDate">Date</label>
                        <input type="datetime" class="form-control" runat="server" id="txtDate"/>
                        <span class="add-on">
                            <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
                        </span>
                    </div>
                </div>
                <div class="form-group col-md-6" style="display:none">
                    <label for="cmbTableNames">Table Names</label>
                    <asp:DropDownList CssClass="form-control" ID="cmbTableNames" runat="server" AutoPostBack="True"></asp:DropDownList>
                </div>
            </div>

            <div class="form-row">
                
            </div>

            <div class="form-row" style="display:flex" id="divResultGrids">
                <div class="form-group col-md-2">
                    <div class="dropdown">
                        <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButtonQuery" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Action</button>
                        <div class="dropdown-menu" aria-labelledby="dropdownMenuButtonQuery">
                            <%--<a class="dropdown-item" runat="server" id="lblSubmit" onserverclick="lblSubmit_ServerClick" href="#">Display</a>--%>
                            <a class="dropdown-item" runat="server" id="lblAdjustReturn" href="#">Adjust Return</a>
                            <a class="dropdown-item" runat="server" id="btnSaveQuery" href="#">Save Query</a>
                        </div>
                    </div>
                </div>

                <div class="form-group col-md-2">
                    <div class="dropdown">
                        <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButtonAdjust" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Adjustment Options</button>
                        <div class="dropdown-menu" aria-labelledby="dropdownMenuButtonAdjust">
                            <%--<a class="dropdown-item" runat="server" id="lblSubmit" onserverclick="lblSubmit_ServerClick" href="#">Display</a>--%>
                            <a class="dropdown-item" runat="server" id="A1" href="#">Adjust MBR300</a>
                            <a class="dropdown-item" runat="server" id="A2" href="#">Adjust MBR1000</a>
                        </div>
                    </div>
                </div>
            </div>

            <div class="form-row">
                    <div class="form-group col-md-12">
                        <div class="overflow-auto">
                                    <asp:GridView ID="griviewReturnAdjusted" Height="550px" 
                                    runat="server"
                                    EmptyDataText="There is no record(s) to display from the selected table"
                                    AutoGenerateColumns="true" 
                                    PageSize="10"
                                    ViewStateMode="Enabled"
                                    AllowPaging="true"
                                    CssClass="table table-striped table-bordered table-hover table-header-fixed pre-scrollable" OnRowCancelingEdit="griviewReturnAdjusted_RowCancelingEdit" OnRowEditing="griviewReturnAdjusted_RowEditing" OnRowUpdating="griviewReturnAdjusted_RowUpdating" OnSelectedIndexChanged="griviewReturnAdjusted_SelectedIndexChanged" AutoGenerateSelectButton="True" OnPageIndexChanging="griviewReturnAdjusted_PageIndexChanging">
                                    <EditRowStyle BackColor="#000FFF" />
                                    <SelectedRowStyle BackColor="#999999" ForeColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="align-items-center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkBtnStatus" runat="server" Text="?"></asp:LinkButton>
                                                <asp:Label runat="server" ID="lblAdjustmentStatus"></asp:Label>
                                            </ItemTemplate>

                                        <HeaderStyle CssClass="align-items-center"></HeaderStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                </div>
                    </div>
                </div>

            <div class="form-row">
                <div class="form-group com-md-12">
                    <div class="overflow-auto">
                            <asp:GridView ID="GridView1" Height="550px" 
                            runat="server"
                            EmptyDataText="There is no record(s) to display from the selected table"
                            AutoGenerateColumns="true" 
                            PageSize="10"
                            ViewStateMode="Enabled"
                            AllowPaging="true"
                            CssClass="table table-striped table-bordered table-hover table-header-fixed pre-scrollable" OnRowCancelingEdit="griviewReturnAdjusted_RowCancelingEdit" OnRowEditing="griviewReturnAdjusted_RowEditing" OnRowUpdating="griviewReturnAdjusted_RowUpdating" OnSelectedIndexChanged="griviewReturnAdjusted_SelectedIndexChanged" AutoGenerateSelectButton="True" OnPageIndexChanging="griviewReturnAdjusted_PageIndexChanging">
                            <EditRowStyle BackColor="#000FFF" />
                            <SelectedRowStyle BackColor="#999999" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="align-items-center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkBtnStatus" runat="server" Text="?"></asp:LinkButton>
                                        <asp:Label runat="server" ID="lblAdjustmentStatus"></asp:Label>
                                    </ItemTemplate>

                                <HeaderStyle CssClass="align-items-center"></HeaderStyle>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                          </div>
                </div>
            </div>

            
      </div>

        <!-- Modal -->
            <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLongTitle">Return Adjustment Parameter</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>

                    <div class="modal-body">
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <div class="alert alert-danger alert-dismissible" role="alert" runat="server" visible="true" id="divAlertInPopup">
                                    <asp:Label runat="server" ID="lblErrorMsgInPopup" Text=""></asp:Label>
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-12 mb-0">
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
                         <div class="form-row">
                            <div class="form-group col-md-12 mb-0">
                                <hr />
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <label for="txtNewCurrencyValue">New Local Currency</label>
                                <input type="text" id="txtNewCurrencyValue" runat="server" required="required" placeholder="Currency" class="form-control" />
                            </div>
                            <div class="form-group col-md-12">
                                <label for="txtQueryDescription">Analyst Comments</label>
                                <textarea type="text" id="txtAnalystComments" rows="8" runat="server" required="required" placeholder="Comments..." class="form-control" />
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" id="btnProceedToReturnAdjustment" onserverclick="btnProceedToReturnAdjustment_ServerClick" runat="server" class="btn btn-primary">Proceed</button>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Modal -->
        
        <!--Registered script block-->
        <script type="text/javascript">
            
        </script>
    </form>

    <!--javascript-->
    <%--<script src="../assets/script/jquery-3.4.0.min.js"></script>--%>
    <script src="../assets/script/jquery-2.2.4.min.js"></script>
    <script src="../assets/script/bootstrap.bundle.min.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function (e) {
            jQuery("#lblAdjustReturn").click(function (e) {
                jQuery("#exampleModalCenter").modal("show");
            });

            jQuery("#cmbReportingInstitution").on("change", function () {
                jQuery("#divResultGrids").attr("display", "flex");
            });

            jQuery("#btnProceedToReturnAdjustment").click(function () {
                var txtNewCurrencyValue = jQuery("#txtNewCurrencyValue").val();
                var txtAnalystComments = jQuery("#txtAnalystComments").val();
                if((txtNewCurrencyValue == null || txtNewCurrencyValue.length < 1) && (txtAnalystComments == null || txtAnalystComments.length < 1))
                {
                    jQuery("#lblErrorMsgInPopup").val("All fields are required");
                    jQuery("#lblErrorMsgInPopup").text("All fields are required");
                }
            });
        });
    </script>
</body>
</html>

