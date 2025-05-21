using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Linq_Lab1
{
    public partial class Form1 : Form
    {
        SqlDataAdapter sqlDataAdapter1;
        SqlConnection SqlConnection1;
        DataSet Dset;
        SqlCommand SelectCmd;
        SqlCommand InsertCmd;
        SqlCommand DelCmd;
        SqlCommand UpdateCmd;
        SqlCommand selectRow;


        public Form1()
        {
            InitializeComponent();
            sqlDataAdapter1 = new SqlDataAdapter();
            SqlConnection1 = new SqlConnection();
            SqlConnection1.ConnectionString = "Data Source = REEM\\SQLEXPRESS ; Initial Catalog = Liinq_Lab ; Integrated Security = true ; TrustServerCertificate = true";

            Dset = new DataSet();

            SelectCmd = new SqlCommand();
            SelectCmd.Connection = SqlConnection1;
            SelectCmd.CommandText = "select * from Emp";
            sqlDataAdapter1.SelectCommand = SelectCmd;

            InsertCmd = new SqlCommand();
            InsertCmd.Connection = SqlConnection1;
            InsertCmd.CommandText = "Insert into Emp (EmpID,EmpName , DepName) Values (@EmpID, @EmpName , @DepName)";

            SqlParameter s_EmpID = new SqlParameter("@EmpID", SqlDbType.Int, 0, "EmpID");
            SqlParameter s_EmpName = new SqlParameter("@EmpName", SqlDbType.NVarChar, 0, "EmpName");
            SqlParameter s_DepName = new SqlParameter("@DepName", SqlDbType.NVarChar, 0, "DepName");

            InsertCmd.Parameters.Add(s_EmpID);
            InsertCmd.Parameters.Add(s_EmpName);
            InsertCmd.Parameters.Add(s_DepName);
            sqlDataAdapter1.InsertCommand = InsertCmd;


            sqlDataAdapter1.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord;
            sqlDataAdapter1.InsertCommand = InsertCmd;


            UpdateCmd = new SqlCommand();
            UpdateCmd.Connection = SqlConnection1;
            


            DelCmd = new SqlCommand();
            DelCmd.Connection = SqlConnection1;
            DelCmd.CommandText = "DELETE FROM Emp WHERE EmpID = @EmpID";

            SqlParameter del_EmpID = new SqlParameter("@EmpID", SqlDbType.Int, 0, "EmpID");
            DelCmd.Parameters.Add(del_EmpID);

            sqlDataAdapter1.DeleteCommand = DelCmd;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection1.Open();
            sqlDataAdapter1.Fill(Dset);
            SqlConnection1.Close();

            dataGridView1.DataSource = Dset.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataRow Drow = Dset.Tables[0].NewRow();
            Drow[0] = int.Parse(textBox3.Text);
            Drow[1] = textBox1.Text;
            Drow[2] = textBox2.Text;
            Dset.Tables[0].Rows.Add(Drow);
            textBox1.Text = textBox2.Text = textBox3.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int rowIndex = dataGridView1.CurrentRow.Index;
                DataRow row = Dset.Tables[0].Rows[rowIndex];

                // Update values in the DataTable from the textboxes
                row["EmpName"] = textBox1.Text;
                row["DepName"] = textBox2.Text;

                // Set the UpdateCommand with proper SQL and parameters
                UpdateCmd.CommandText = "UPDATE Emp SET EmpName = @EmpName, DepName = @DepName WHERE EmpID = @EmpID";

                UpdateCmd.Parameters.Clear(); // Important to avoid duplicate parameters

                UpdateCmd.Parameters.Add("@EmpName", SqlDbType.NVarChar, 50, "EmpName");
                UpdateCmd.Parameters.Add("@DepName", SqlDbType.NVarChar, 50, "DepName");

                SqlParameter empID = new SqlParameter("@EmpID", SqlDbType.Int);
                empID.SourceColumn = "EmpID";
                empID.SourceVersion = DataRowVersion.Original; 
                UpdateCmd.Parameters.Add(empID);

                sqlDataAdapter1.UpdateCommand = UpdateCmd;

                SqlConnection1.Open();
                sqlDataAdapter1.Update(Dset);
                SqlConnection1.Close();

                MessageBox.Show("Database Updated");
            }
            else
            {
                MessageBox.Show("Please select a row to update.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow != null)
            {
                int rowIndex = dataGridView1.CurrentRow.Index;

                
                Dset.Tables[0].Rows[rowIndex].Delete();

                
                SqlConnection1.Open();
                sqlDataAdapter1.Update(Dset);
                SqlConnection1.Close();

                MessageBox.Show("Selected row deleted from database.");
            }


        }











        //private void label1_Click(object sender, EventArgs e)
        //{


        //}

        //private void label1_Click_1(object sender, EventArgs e)
        //{

        //}

        //private void label3_Click(object sender, EventArgs e)
        //{

        //}

        //private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}

    }
}
