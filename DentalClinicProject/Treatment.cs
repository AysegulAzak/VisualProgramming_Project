using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentalClinicProject
{
    public partial class Treatment : Form
    {
        public Treatment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "insert into TreatmentTbl values('" + TreatNameTb.Text + "', '" + TreatCost.Text + "', '" + TreatDesc.Text + "') ";
            MyPatient Pat = new MyPatient();
            try
            {
                Pat.AddPatient(query);
                MessageBox.Show("Treatment Successfully Added");
                populate();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        void populate()
        {
            MyPatient Pat = new MyPatient();
            string query = "select * from TreatmentTbl";
            DataSet ds = Pat.ShowPatient(query);
            TreatmentDGV.DataSource = ds.Tables[0];
        }
        void filter()
        {
            MyPatient Pat = new MyPatient();

            string query = "select * from TreatmentTbl where TreatName like '%" + SearchTb.Text + "%'";

            DataSet ds = Pat.ShowPatient(query);
            TreatmentDGV.DataSource = ds.Tables[0];
        }

        private void Treatment_Load(object sender, EventArgs e)
        {
            populate();
        }

        int key = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            MyPatient Pat = new MyPatient();
            if (key == 0)
            {
                MessageBox.Show("Select The Treatment");
            }
            else
            {
                try
                {
                    string query = "Update TreatmentTbl set TreatName = '" + TreatNameTb.Text + "', TreatCost = '" + TreatCost.Text + "', TreatDesc = '" + TreatDesc.Text + "' where TreatId = " + key + ";";
                    Pat.UpdatePatient(query);
                    MessageBox.Show("Treatment Successfully Updated");
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void TreatmentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TreatNameTb.Text = TreatmentDGV.SelectedRows[0].Cells[1].Value.ToString();
            TreatCost.Text = TreatmentDGV.SelectedRows[0].Cells[2].Value.ToString();
            TreatDesc.Text = TreatmentDGV.SelectedRows[0].Cells[3].Value.ToString();
           
            if (TreatNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(TreatmentDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyPatient Pat = new MyPatient();
            if (key == 0)
            {
                MessageBox.Show("Select The Treatment");
            }
            else
            {
                try
                {
                    string query = "Delete from TreatmentTbl where TreatId=" + key + "";
                    Pat.DeletePatient(query);
                    MessageBox.Show("Treatment Successfully Deleted");
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

        private void label5_Click(object sender, EventArgs e)
        {
            Patient Pat = new Patient();
            Pat.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Prescription Presc = new Prescription();
            Presc.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Appointment App = new Appointment();
            App.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            DashBoard dash = new DashBoard();
            dash.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
