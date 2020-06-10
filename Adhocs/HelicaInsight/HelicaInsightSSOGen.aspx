<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HelicaInsightSSOGen.aspx.cs" Inherits="Adhocs.HelicaInsight.HelicaInsightSSOGen" %>

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
        function loadTab(url)
        {
            window.open(url, '_blank', 'location=no,menubar=no,status=yes,toolbar=no');
        }
    </script>
</head>
<body>
    <div class="container">
        <form id="form1" runat="server">
            <div>
                <div class="card text-center">
                    <h5 class="card-header">Caution</h5>
                    <div class="card-body">
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

                        <div class="form-row"></div>

                        <p>
                            <asp:Label ID="lblerror" runat="server"></asp:Label>
                        </p>
                        <a href="#" target="_blank" runat="server" id="qbNew" class="btn btn-primary">Open In New Tab</a>
                    </div>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
