<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bankratingsetupview.aspx.cs" Inherits="Adhocs.mgtcomponent.bankratingsetupview" %>

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
    <form id="frmBankRatingSetupView" runat="server">
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
        <div class="form-row mb-4">
            <div class="col-md-6">
                <span class="h4">Bank Rating List</span>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-6">
                <input type="text" placeholder="Filter - @ritype or  @code or @date" autocomplete="off" id="txtSearchReports" class="form-control" />
            </div>
            <div class="form-group col-md-6">
                    <div class="dropdown">
                        <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButtonQuery" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Choose Action</button>
                        <div class="dropdown-menu" aria-labelledby="dropdownMenuButtonQuery">
                            <a class="dropdown-item" runat="server" id="lblBankSetup" onserverclick="lblBankSetup_ServerClick" href="#">Bank Setup</a>
                            <a class="dropdown-item" runat="server" id="lblBankScoring" onserverclick="lblBankScoring_ServerClick" href="#">Bank Scoring</a>
                        </div>
                    </div>
             </div>    
        </div>

         <div class="form-row">
                        
            </div>

        <div class="form-row">
            <div class="form-group col-md-12" style="overflow: scroll; max-height: 400px">
                <div>
                    <asp:GridView ID="gridViewBankRatingSetup"
                        runat="server"
                        HeaderStyle-Wrap="false"
                        RowStyle-Wrap="false"
                        EmptyDataText="There is no report(s) to display for the selected department"
                        AutoGenerateColumns="true"
                        ViewStateMode="Enabled"
                        CssClass="table table-striped table-bordered table-hover table-header-fixed pre-scrollable" OnSelectedIndexChanged="gridViewBankRatingSetup_SelectedIndexChanged">
                        <EditRowStyle BackColor="#000FFF" />
                        <SelectedRowStyle BackColor="#999999" ForeColor="white" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
