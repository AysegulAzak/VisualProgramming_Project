using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DentalClinicProject
{
    public partial class Appointment : Form
    {
        public Appointment()
        {
            InitializeComponent();
        }
        ConnectionString MyCon = new ConnectionString();
     
        private void fillPatient()
        {
            SqlConnection Con = MyCon.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select PatName from PatientTbl", Con);
            SqlDataReader rdr;
            rdr= cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("PatName", typeof(string));
            dt.Load(rdr);
            PatientCb.ValueMember = "PatName";
            PatientCb.DataSource = dt;
            Con.Close();
        }
        private void fillTreatment()
        {
            SqlConnection Con = MyCon.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select TreatName from TreatmentTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TreatName", typeof(string));
            dt.Load(rdr);
            TreatmentCb.ValueMember = "TreatName";
            TreatmentCb.DataSource = dt;
            Con.Close();
        }
        private void panel1_Paint(object sender, PaintEventArgs e) {}
        private void label1_Click(object sender, EventArgs e) {}

        private void Appointment_Load(object sender, EventArgs e)
        {
            fillPatient();
            fillTreatment();
            populate();
        }
        void filter()
        {
            MyPatient Pat = new MyPatient();

            string query = "select * from AppointmentTbl where Patient like '%" + SearchTb.Text + "%'";

            DataSet ds = Pat.ShowPatient(query);
            AppointmentDGV.DataSource = ds.Tables[0];
        }
        void populate()
        {
            MyPatient Pat = new MyPatient();
            string query = "select * from AppointmentTbl";
            DataSet ds = Pat.ShowPatient(query);
            AppointmentDGV.DataSource = ds.Tables[0];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string query = "insert into AppointmentTbl values('" + PatientCb.SelectedValue.ToString() + "', '" + TreatmentCb.SelectedValue.ToString() + "', '" + Date.Value.Date.ToString("yyyy-MM-dd") + "', '"+Time.Value.TimeOfDay+"') ";
            MyPatient Pat = new MyPatient();
            try
            {
                Pat.AddPatient(query);
                MessageBox.Show("Appointment Successfully Recorded");
                populate();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        int key = 0;
        private void AppointmentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PatientCb.SelectedValue = AppointmentDGV.SelectedRows[0].Cells[1].Value.ToString();
            TreatmentCb.SelectedValue = AppointmentDGV.SelectedRows[0].Cells[2].Value.ToString();
            string pat = AppointmentDGV.SelectedRows[0].Cells[1].Value.ToString();

            if (pat == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(AppointmentDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyPatient Pat = new MyPatient();
            if (key == 0)
            {
                MessageBox.Show("Select The Appointment To Cancel");
            }
            else
            {
                try
                {
                    string query = "Delete from AppointmentTbl where ApId=" + key + "";
                    Pat.DeletePatient(query);
                    MessageBox.Show("Appointment Successfully Cancelled");
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MyPatient Pat = new MyPatient();
            if (key == 0)
            {
                MessageBox.Show("Select The Appointment");
            }
            else
            {
                try
                {
                    string query = "Update AppointmentTbl set Patient = '"+ PatientCb.SelectedValue.ToString() + "', Treatment = '" + TreatmentCb.SelectedValue.ToString() + "', ApDate = '"+Date.Value.Date+"', ApTime='" +Time.Value.TimeOfDay+"'  where ApId = " + key + "";
                    Pat.UpdatePatient(query);
                    MessageBox.Show("Appointment Successfully Updated");
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void SearchTb_OnValueChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Patient Pat = new Patient();
            Pat.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Treatment Treat = new Treatment();
            Treat.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Prescription Presc = new Prescription();
            Presc.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            DashBoard dash = new DashBoard();
            dash.Show();
            this.Hide();
        }

        private void TreatmentCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
