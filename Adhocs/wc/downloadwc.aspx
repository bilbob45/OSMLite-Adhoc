<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="downloadwc.aspx.cs" Inherits="Adhocs.wc.downloadwc" %>

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
            $('#cmbInstitutionType').select2();
            $('#cmbReportingInstitution').select2();
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
    </style>
</head>
<body>
    <form runat="server" id="frmDownloadWc">
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
                    <span class="h4">Download Work Collection</span>
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
                            <a class="dropdown-item" runat="server" id="btnDownload" onserverclick="A1_ServerClick" href="#">Download</a>
                            <a class="dropdown-item" runat="server" id="btnViewDetails" onserverclick="btnViewDetails_ServerClick" hresf="#">View Details</a>
                        </div>
                    </div>
             </div>            
            </div>
            
            <div runat="server" id="divGridResult" visible="false">
                <div class="form-row" id="divGrids" runat="server">
                        <div class="form-group col-md-6" style="top: -2px; left: 4px; ">
                            <label for="gridviewWc" runat="server" id="lblTableName300"  class="font-weight-bold"></label>
                            <div class="overflow-auto" style="height:auto">
                                        <asp:GridView ID="gridviewLeft300"
                                        runat="server" 
                                        HeaderStyle-Wrap="false"
                                        RowStyle-Wrap="true"
                                        EmptyDataText="There is no record(s) to display for the selected date"
                                        AutoGenerateColumns="true"
                                        ViewStateMode="Enabled"                                
                                        CssClass="table table-striped table-bordered table-hover table-header-fixed pre-scrollable table-responsive" 
                                            OnSelectedIndexChanged="gridviewLeft300_SelectedIndexChanged" AutoGenerateSelectButton="True" OnRowDataBound="gridviewLeft300_RowDataBound">
                                        <EditRowStyle BackColor="#000FFF" />
                                        <SelectedRowStyle BackColor="#999999" ForeColor="White" />
                                    </asp:GridView>
                                    </div>
                        </div>
                </div>
        </div>
        </div>
    </form>  
</body>
</html>
