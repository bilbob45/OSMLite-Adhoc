<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="downloadrb.aspx.cs" Inherits="Adhocs.smartclient.downloadrb" %>

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
        $(document).ready(function () {
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
    <form id="frmDownloadRb" runat="server">
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
        <div class="form-row">
            <div class="form-group col-md-12">
                <h4>Return Builder Download</h4>
            </div>
            <div class="form-group col-md-12" style="overflow: scroll; max-height: 400px">
                    <div class="WrapText">
                        <asp:GridView ID="gridViewRb"
                            runat="server"
                            HeaderStyle-Wrap="false"
                            DataKeyNames="id"
                            RowStyle-Wrap="false"
                            EmptyDataText="There is no data available to display"
                            AutoGenerateColumns="true"
                            ViewStateMode="Enabled" RowStyle-CssClass="WrapText" AutoGenerateSelectButton="true" OnSelectedIndexChanged="gridViewRb_SelectedIndexChanged"
                            CssClass="table table-striped table-bordered table-hover table-header-fixed">
                            <EditRowStyle BackColor="#000FFF" />
                            <SelectedRowStyle BackColor="#999999" ForeColor="white" />
                        </asp:GridView>
                    </div>
                </div>
        </div>

        <div class="form-row">
            <div class="form-group col-md-12">
                <h4>Return Builder Upload</h4>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-8">
                <asp:FileUpload ID="customFile" runat="server" CssClass="custom-file-input" />
                <label class="custom-file-label" for="customFile">Choose file</label>
            </div>
            <div class="form-group col-md-4">
                <div class="form-row">
                    <div class="form-group col-md-12">
                        <div class="dropdown">
                            <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButtonQuery" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                Choose Action</button>
                            <div class="dropdown-menu" aria-labelledby="dropdownMenuButtonQuery">
                                <a class="dropdown-item" runat="server" id="btnAddBuild" href="#">Upload Return Builder</a>
                                <hr />
                                <a class="dropdown-item" runat="server" id="btnDownload" onserverclick="btnDownload_ServerClick" href="#">Download Return Builder</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%--<div class="form-group col-md-2">
                <button type="button" id="btnAddBuild" runat="server" class="btn btn-primary">Add Build Number</button>
            </div>
            <div class="form-group col-md-2">
                <button type="button" id="btnDownload" runat="server" class="btn btn-primary">Download Return Builder</button>
            </div>--%>
        </div>
        
        <!-- Modal Work Collection tabindex="-1"-->
        <div class="modal fade" id="exampleModalCenterX" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLongTitleX">Return Builder - Add Build Number</h5>
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
                                <label for="txtBuildNumber">Build/Version Number
                                    <%--<label style="color: red">*</label>--%>
                                </label>
                                <input type="text" id="txtBuildNumber" runat="server" required="required" placeholder="Default Value" class="form-control" />
                            </div>
                        </div>
                        
                    </div>
                    <div class="modal-footer">
                        <button type="button" id="btnUpload" onserverclick="btnUpload_ServerClick" runat="server" class="btn btn-primary">Upload Return Builder</button>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Modal -->

    </form>
    <script>
        // Add the following code if you want the name of the file appear on select
        $(document).ready(function () {
            var _postedFileName;
            $(".custom-file-input").on("change", function () {
                var fileName = $(this).val().split("\\").pop();
                $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
                _postedFileName = fileName;
            });

            //Display the modal box
            $("#btnAddBuild").click(function () {
                if (_postedFileName.lenght < 1)
                    return;
                else
                    $('#exampleModalCenterX').modal('show');
            });
        });
    </script>
</body>
</html>
