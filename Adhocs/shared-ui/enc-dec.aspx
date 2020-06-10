<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="enc-dec.aspx.cs" Inherits="Adhocs.shared_ui.enc_dec" %>

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
     <style type="text/css" lang="en">
        * {
            font-size: 14px;
            line-height: 2;
        }
    </style>
</head>
<body>
    <form id="frmEncDec" runat="server">
        <div class="container">
            <div class="form-row">
                <div class="form-group col-md-12">
                    <div class="alert alert-danger alert-dismissible" role="alert" visible="false" runat="server" id="divAlert">
                        <asp:Label ID="lblError" runat="server"> </asp:Label>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                </div>
            </div>
            <label class="h5">OSMLite - String Encryption & Decryption Generator</label>
            <div class="form-row">
                <div class="form-group col-md-12">
                    <label for="txtEncyptDecrypt">Enter String</label>
                    <input type="text" required="required" id="txtEncyptDecrypt" runat="server" placeholder="String to encrypt or decrypt" class="form-control" />
                </div>
                <div class="form-group col-md-12">
                    <%--<input type="text" required="required" placeholder="String output" class="form-control-plaintext" />--%>
                    <textarea readonly="readonly" id="rchTxtOutput" runat="server" placeholder="String output" class="form-control"></textarea>
                </div>
                <div class="form-group col-md-4">
                    <input type="button" id="btnEncrypt" value="Encrypt String" class="btn btn-info" runat="server" onserverclick="btnEncrypt_ServerClick"/>
                    <input type="button" id="btnDecrypt" value="Decrypt String" class="btn btn-danger" runat="server" onserverclick="btnDecrypt_ServerClick"/>
                </div>
            </div>

            <div class="form-row">
                <div class="form-group col-md-12">
                    <label for="txtEncyptDecrypt">Enter String</label>
                    <%--<textarea id="txtEncodeDecode" runat="server" placeholder="String to encode or decode" class="form-control"></textarea>--%>
                    <textarea id="txtEncodeDecod" runat="server" placeholder="String output" class="form-control"></textarea>
                </div>
                <div class="form-group col-md-12">
                    <%--<input type="text" required="required" placeholder="String output" class="form-control-plaintext" />--%>
                    <textarea readonly="readonly" id="rchTxtEncodeDecodeOutput" runat="server" placeholder="String output" class="form-control"></textarea>
                </div>
                <div class="form-group col-md-4">
                    <input type="button" id="btnEncode" value="Encode String" class="btn btn-info" runat="server" onserverclick="btnEncode_ServerClick"/>
                    <input type="button" id="btnDecode" value="Decode String" class="btn btn-danger" runat="server" onserverclick="btnDecode_ServerClick"/>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
