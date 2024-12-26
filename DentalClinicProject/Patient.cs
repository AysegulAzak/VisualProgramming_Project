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
    public partial class Patient : Form
    {
        public Patient()
        {
            InitializeComponent();
        }

        void populate()
        {
            MyPatient Pat = new MyPatient();
            string query = "select * from PatientTbl";
            DataSet ds = Pat.ShowPatient(query);
            PatientDGV.DataSource = ds.Tables[0];
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string query = "insert into PatientTbl (PatName, PatPhone, PatAddress, PatDOB, PatGender, PatAllergies) values ('" + PatNameTb.Text + "', '" + PatPhoneTb.Text + "', '" + AddressTb.Text + "', '" + DOBDate.Value.Date.ToString("yyyy-MM-dd") + "', '" + PatGender.SelectedItem.ToString() + "', '" + AllergyTb.Text + "')";

            MyPatient Pat = new MyPatient();
            try
            {
                Pat.AddPatient(query);
                MessageBox.Show("Patient Successfully Added");
                populate();
            } catch (Exception Ex) {
                MessageBox.Show(Ex.Message);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
       
        void filter()
        {
            MyPatient Pat = new MyPatient();
         
            string query = "select * from PatientTbl where PatName like '%" + SearchTb.Text + "%'";

            DataSet ds = Pat.ShowPatient(query);
            PatientDGV.DataSource = ds.Tables[0];
        }

        private void Patient_Load(object sender, EventArgs e)
        {
            populate();
        }

        int key = 0;
        private void PatientDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PatNameTb.Text = PatientDGV.SelectedRows[0].Cells[1].Value.ToString();
            PatPhoneTb.Text = PatientDGV.SelectedRows[0].Cells[2].Value.ToString();
            AddressTb.Text = PatientDGV.SelectedRows[0].Cells[3].Value.ToString();


            if (DateTime.TryParse(PatientDGV.SelectedRows[0].Cells[4].Value?.ToString(), out DateTime dob))
            {
                DOBDate.Value = dob;
            }
            else
            {
                DOBDate.Value = DateTime.Today; 
            }





            PatGender.SelectedItem = PatientDGV.SelectedRows[0].Cells[5].Value.ToString();
            AllergyTb.Text = PatientDGV.SelectedRows[0].Cells[6].Value.ToString();

            if(PatNameTb.Text == "")
            {
                key = 0;
            }else
            {
                key = Convert.ToInt32(PatientDGV.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyPatient Pat = new MyPatient();
            if(key == 0)
            {
                MessageBox.Show("Select The Patient");
            }
            else
            {
                try
                {
                    string query = "Delete from PatientTbl where PatId=" + key + "";
                    Pat.DeletePatient(query);
                    MessageBox.Show("Patient Successfully Deleted");
                    populate();
                }
                catch(Exception Ex)
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
                MessageBox.Show("Select The Patient");
            }
            else
            {
                try
                {
                    string query = "Update PatientTbl set PatName = '" + PatNameTb.Text + "', PatPhone = '" + PatPhoneTb.Text + "', PatAddress = '" + AddressTb.Text + "', PatDOB = '" + DOBDate.Value.Date + "', PatGender = '" + PatGender.SelectedItem.ToString() + "', PatAllergies = '" + AllergyTb.Text + "' where PatId = " +  key;
                    Pat.UpdatePatient(query);
                    MessageBox.Show("Patient Successfully Updated");
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

        private void label8_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();

        }

        private void label7_Click(object sender, EventArgs e)
        {
            DashBoard dash = new DashBoard();
            dash.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Prescription Presc = new Prescription();
            Presc.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

            Treatment Treat = new Treatment();
            Treat.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

            Appointment App = new Appointment();
            App.Show();
            this.Hide();
        }

        private void PatNameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
    }

