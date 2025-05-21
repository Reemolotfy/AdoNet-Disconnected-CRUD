using System.Data;
using System.Data.SqlClient;


namespace LinqLab2
{
    public partial class Form1 : Form
    {
        SqlConnection mSqlConnection;
        SqlCommand msqlCommand;


        public Form1()
        {
            InitializeComponent();
            mSqlConnection = new SqlConnection();
            msqlCommand = new SqlCommand();
            mSqlConnection.ConnectionString = "Data Source = REEM\\SQLEXPRESS ; Initial Catalog = Liinq_Lab ; Integrated Security = true ; TrustServerCertificate = true";
            msqlCommand.Connection = mSqlConnection;

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;
            button5.Enabled = true;



        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataReader dReader;
            msqlCommand.CommandText = "select * from Emp";
            listBox1.Items.Clear();
            if (mSqlConnection.State != ConnectionState.Open)
                mSqlConnection.Open();
            dReader = msqlCommand.ExecuteReader();
            while (dReader.Read())
            {
                String str = (int)dReader[0] + "\t" + dReader[1].ToString() + "\t" + dReader[2].ToString();
                listBox1.Items.Add(str);
            }
            dReader.Close();
            mSqlConnection.Close();

        }


        private void button2_Click(object sender, EventArgs e)
        {
            string str = "INSERT INTO Emp VALUES (" + textBox1.Text + ", '" + textBox3.Text + "', '" + textBox2.Text + "')";
            ExecuteStatement(str, "Added");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = "UPDATE Emp SET EmpName = '" + textBox3.Text + "', DepName = '" + textBox2.Text + "' WHERE EmpID = " + textBox1.Text;
            ExecuteStatement(str, "Updated");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string str = "DELETE FROM Emp WHERE EmpID = " + textBox1.Text;
            ExecuteStatement(str, "Deleted");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mSqlConnection.Open();
            button5.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button6.Enabled = true;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            mSqlConnection.Close();
            button5.Enabled = true;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;
        }

        private void ExecuteStatement(string str, string state)
        {
            msqlCommand.CommandText = str;
           mSqlConnection.Open();
            int affectedrow = msqlCommand.ExecuteNonQuery();
            mSqlConnection.Close();
            MessageBox.Show(state);
            textBox1.Text = textBox2.Text = textBox3.Text = "";
            mSqlConnection.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


    }
}
