using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DentalClinicProject
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

       ConnectionString MyConnection = new ConnectionString();


        private void DashBoard_Load(object sender, EventArgs e)
        {
            //PendingAppProgress.Value = 100;
            //UsersProgress.Value = 100;
            //Patients.Value = 100;
            //NextApp.Value = 100;

            
            SqlConnection Con = MyConnection.GetCon();
            Con.Open();

            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from AppointmentTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            //Pendinglbl.Text = dt.Rows[0][0].ToString();

            SqlDataAdapter sda1 = new SqlDataAdapter("select count(*) from PatientTbl", Con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            //Patientlbl.Text = dt1.Rows[0][0].ToString();

            SqlDataAdapter sda2 = new SqlDataAdapter("select count(*) from UserTbl", Con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            //Userlbl.Text = dt2.Rows[0][0].ToString();

            SqlDataAdapter sda3 = new SqlDataAdapter("select min(ApDate) from AppointmentTbl", Con);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            //Datelbl.Text = dt3.Rows[0][0].ToString();

           
            PopulateChart(dt.Rows[0][0], dt1.Rows[0][0], dt2.Rows[0][0]);

            Con.Close();
        }
        private void PopulateChart(object appointmentCount, object patientCount, object userCount)
        {
          
            Chart1.Series.Clear();
            Chart1.ChartAreas.Clear();

            
            ChartArea chartArea = new ChartArea("MainArea");
            Chart1.ChartAreas.Add(chartArea);

          
            Series series = new Series("Counts")
            {
                ChartType = SeriesChartType.Column
            };

         
            series.Points.AddXY("Appointments", appointmentCount);
            series.Points.AddXY("Patients", patientCount);
            series.Points.AddXY("Users", userCount);
          


            Chart1.Series.Add(series);

           
            CustomizeChartAxis();
        }
        private void CustomizeChartAxis()
        {
          
            var axisX = Chart1.ChartAreas[0].AxisX;

           
            axisX.Interval = 1;

          
            axisX.LabelStyle.Angle = 45; 
            axisX.LabelStyle.IsStaggered = true; 

            
            var axisY = Chart1.ChartAreas[0].AxisY;
            axisY.Title = "Counts"; 
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Patientlbl_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Appointment App= new Appointment();
            App.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Pendinglbl_Click(object sender, EventArgs e)
        {

        }

        private void PendingAppProgress_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
    }
}
