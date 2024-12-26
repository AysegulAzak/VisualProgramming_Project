using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace DentalClinicProject
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        void populate()
        {
            MyPatient Pat = new MyPatient();
            string query = "select * from UserTbl";
            DataSet ds = Pat.ShowPatient(query);
            UserDGV.DataSource = ds.Tables[0];
        }
        private void button1_Click(object sender, EventArgs e)
        {

            string query = "insert into UserTbl values('" + UnameTb.Text + "', '" + PhoneTb.Text + "','" + PasswordTb.Text + "') ";
            MyPatient Pat = new MyPatient();
            try
            {
                Pat.AddPatient(query);
                MessageBox.Show("User Successfully Added");
                populate();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void User_Load(object sender, EventArgs e)
        {
            populate();
        }
        int key = 0;
        private void UserDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UnameTb.Text = UserDGV.SelectedRows[0].Cells[1].Value.ToString();
          
            PasswordTb.Text = UserDGV.SelectedRows[0].Cells[3].Value.ToString();
            PhoneTb.Text = UserDGV.SelectedRows[0].Cells[2].Value.ToString();
            string pat = UserDGV.SelectedRows[0].Cells[3].Value.ToString();

            if (UnameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(UserDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyPatient Pat = new MyPatient();
            if (key == 0)
            {
                MessageBox.Show("Select The User To Be Deleted");
            }
            else
            {
                try
                {
                    string query = "Delete from UserTbl where Uid=" + key + "";
                    Pat.DeletePatient(query);
                    MessageBox.Show("User Successfully Deleted");
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
                MessageBox.Show("Select The User");
            }
            else
            {
                try
                {
                    string query = "Update UserTbl set Uname = '" + UnameTb.Text + "', Phone = '" + PhoneTb.Text + "', Upass = '" + PasswordTb.Text + "'  where Uid = " + key + "";
                    Pat.DeletePatient(query);
                    MessageBox.Show("User Successfully Updated");
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label8_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
                
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
