using LitePDV.Model;
using LitePDV.Repository;
using LitePDV.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LitePDV.View
{
    public partial class DashboardView : UserControl
    {
        DataTable ordersTable = new DataTable();
        DataTable productsTable = new DataTable();
        DataTable orderItemsTable = new DataTable();
        private readonly OrderService _service;
        private readonly ProductService _serviceProduct;

        public DashboardView()
        {
            InitializeComponent();
            _service = new OrderService();
            _serviceProduct = new ProductService();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void WeekSell_Click(object sender, EventArgs e)
        {

        }

        private void DashboardView_Load(object sender, EventArgs e)
        {
            var orders = _service.GetAll();
            DateTime date = DateTime.Now;
            date.AddDays(-5);

            var ordersTable = new DataTable();
            ordersTable.Columns.Add("totalValue", typeof(decimal));
            ordersTable.Columns.Add("date", typeof(DateTime));

            foreach (Order order in orders)
            {
                if (order.date > date) continue;
                ordersTable.Rows.Add(order.totalValue, order.date);
            }

            WeekSell.DataSource = ordersTable;
            WeekSell.Series.Clear();  

            var series = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Total Sales",
                XValueMember = "date", 
                YValueMembers = "totalValue",
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar
            };

            WeekSell.Series.Add(series);

            var chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            chartArea.AxisX.LabelStyle.Format = "dd/MM/yyyy";
            chartArea.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days; 
            chartArea.AxisX.Interval = 1; 

            WeekSell.ChartAreas.Clear();
            WeekSell.ChartAreas.Add(chartArea);

            chartArea.AxisX.IsReversed = false; 
            chartArea.AxisY.Title = "Total de Vendas";

            chartArea.AxisX.Title = "Data";

            series.IsValueShownAsLabel = true;
            series.LabelBackColor = System.Drawing.Color.Transparent; 
            series.LabelForeColor = System.Drawing.Color.Black;
            series.Font = new System.Drawing.Font("Arial", 10); 
            series.LabelAngle = 0;

            WeekSell.Legends.Clear();
            series.SmartLabelStyle.Enabled = true;
            series.SmartLabelStyle.AllowOutsidePlotArea = System.Windows.Forms.DataVisualization.Charting.LabelOutsidePlotAreaStyle.No; 
            series.SmartLabelStyle.IsMarkerOverlappingAllowed = true; 

            chartArea.AxisX.LabelStyle.Format = "dd/MM/yyyy";

            WeekSell.Titles.Clear();
            WeekSell.Titles.Add("Vendas por Semana");
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
