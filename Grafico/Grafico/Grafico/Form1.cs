using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql;
using MySql.Data;
using System.Windows.Forms.DataVisualization.Charting;

namespace Grafico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.Legends.Clear();

            chart1.Legends.Add("Vendas mensais");
            chart1.Legends[0].LegendStyle = LegendStyle.Table;
            chart1.Legends[0].Docking = Docking.Right;
            chart1.Legends[0].Alignment = StringAlignment.Center;
            chart1.Legends[0].BorderColor = Color.Black;
            chart1.Legends[0].Title = "Vendas";


            String stringC = "SERVER=localhost;DATABASE=grafico;UID=root;PASSWORD=";
            MySqlConnection con = new MySqlConnection(stringC);
            MySqlCommand comandos = con.CreateCommand();
            con.Open();
            comandos.CommandText = "Select * from grafico";
            MySqlDataReader resultado = comandos.ExecuteReader();




            while (resultado.Read()) {
                String mes = resultado.GetString("mes");
                double valor = resultado.GetFloat("valor");

                chart1.Series.Add(mes);
                chart1.Series[mes].Points.Add(valor);
            }
            }

        private void button2_Click(object sender, EventArgs e)
        {

            chart2.Series.Clear();
            chart2.Titles.Clear();
            chart2.Legends.Clear();

            chart2.Legends.Add("Vendas mensais");
            chart2.Legends[0].LegendStyle = LegendStyle.Row;
            chart2.Legends[0].Docking = Docking.Right;
            chart2.Legends[0].Alignment = StringAlignment.Center;
            chart2.Legends[0].BorderColor = Color.Black;
            chart2.Legends[0].Title = "Vendas";

            chart2.Series.Add("Pizza");
            chart2.Series["Pizza"].ChartType = SeriesChartType.Doughnut;

            String stringC = "SERVER=localhost;DATABASE=grafico;UID=root;PASSWORD=";
            MySqlConnection con = new MySqlConnection(stringC);
            MySqlCommand comandos = con.CreateCommand();
            con.Open();
            comandos.CommandText = "Select * from grafico";
            MySqlDataReader resultado = comandos.ExecuteReader();




            while (resultado.Read())
            {
                String mes = resultado.GetString("mes");
                double valor = resultado.GetFloat("valor");

                chart2.Series.Add(mes);
                chart2.Series[mes].Points.Add(valor);
            }
        }
    }
 }

