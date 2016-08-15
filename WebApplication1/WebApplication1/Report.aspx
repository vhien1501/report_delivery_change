<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="WebApplication1.Report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" media="screen" />
    <link href="/assets/css/bootstrap-theme.min.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="table-responsive">
        <table class="table table-striped table-bordered table-hover table-condensed" border="1">
            <thead>
                <tr>
                    <th style="text-align:center">ID</th>
                    <th style="text-align:center">Job No</th>
                    <th style="text-align:center">Original Delivery Date</th>
                    <th style="text-align:center">New Delivery Date</th>
                    <th style="text-align:center">Reason For Change</th>
                    <th style="text-align:center">Comments</th>
                    <th style="text-align:center">Customer Name</th>
                    <%--<th>updated_by</th>--%>
                    <th style="text-align:center">Created</th>
                    <%--<th>user_login</th>--%>
                    <th style="text-align:center">User Name</th>
                </tr>
            </thead>
            <tbody id="tableResults" runat="server">
            </tbody>
        </table>
    </div>
    </form>
    <script src="/assets/js/jquery-2.1.1.js"></script>
    <script src="/assets/js/bootstrap.min.js"></script>
</body>
</html>
