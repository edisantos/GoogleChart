<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Dashboard.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container">
                <div class="form-group">
                    <asp:DropDownList ID="ddlMes" runat="server">
                        <asp:ListItem Text="SELECT" Value="0"></asp:ListItem>
                        <asp:ListItem Text="JAN" Value="1"></asp:ListItem>
                        <asp:ListItem Text="FEB" Value="2"></asp:ListItem>
                        <asp:ListItem Text="MARC" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                
                <div class="form-group">
                    <asp:Button ID="btn" runat="server" Text="Pesquisar" OnClick="btn_Click" />
                </div>
                <hr />
                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                <hr />
                <canvas id="chart1" runat="server" width="200" height="200"></canvas>
            </div>

        </div>
    </form>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.4.0/Chart.min.js"></script>

   <%-- <script src="Scripts/Chart.js"></script>
    <script src="Scripts/jquery-3.3.1.js"></script>--%>
    <script>
        var ctx = document.getElementById('chart1').getContext('2d');
        var chart = new Chart(ctx, {
            // The type of chart we want to create
            type: 'bar',

            // The data for our dataset
            data: {
                labels: ["January", "February", "March", "April", "May", "June", "July"],
                datasets: [{
                    label: "My First dataset",
                    backgroundColor: 'rgb(255, 99, 132)',
                    borderColor: 'rgb(255, 99, 132)',
                    data: [13, 10, 5, 2, 20, 30, 45],
                    backgroundColor: [
                 'rgba(255, 99, 132, 0.2)',
                 'rgba(54, 162, 235, 0.2)',
                 'rgba(255, 206, 86, 0.2)',
                 'rgba(75, 192, 192, 0.2)',
                 'rgba(153, 102, 255, 0.2)',
                 'rgba(255, 159, 64, 0.2)'
                    ],
                }]
            },

            // Configuration options go here
            options: {}
        });
    </script>

</body>
</html>
