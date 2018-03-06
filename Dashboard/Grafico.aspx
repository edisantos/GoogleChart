<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Grafico.aspx.cs" Inherits="Dashboard.Grafico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>


    <script type="text/javascript">
        google.charts.load('current', { packages: ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {
            // Define the chart to be drawn.
            //var data = new google.visualization.DataTable();
            var data = google.visualization.arrayToDataTable(<%=obterDados()%>);
           
            var options = {
                "title": "Dashboard",
                "backgroundColor": { "fill": "#ededed" },
                "is3d": false, "pieHole": 0.4,
                "fontSize": 12,
                "pieSliceTextStyle": { "color": "#FFF" },
                "sliceVisibilityThreshold": false,
                "legend": {
                    "position": "right",
                    "textStyle": {
                        "color": "#000000",
                        "fontSize": 14
                    }
                },
                "tooltip":
                    {
                        "textStyle": { "color": "#000000" },
                        "showColorCode": false
                    },
                "colors": ["#1f386b", "#DC3912", "#FF9900", "#109618", "#990099"]

            };

            // Instantiate and draw the chart.
            // var chart = new google.visualization.PieChart(document.getElementById('myPieChart'));
           // var chart = new google.visualization.BarChart(document.getElementById('myPieChart'));
            var chart = new google.visualization.ColumnChart(document.getElementById('myPieChart'));
            chart.draw(data, options);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="myPieChart" style="width:900px;height:500px"></div>
        </div>
    </form>
</body>
</html>
