using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using System.Drawing;
namespace MachineRenting
{
    public class DBConnection
    {
        public MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnection()
        {
            Initialize();
        }

        //Initialize values
        public void Initialize()
        {
            server = "localhost";
            database = "vikram";
            uid = "root";
            password = "bavithran@14";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                // MessageBox.Show("Invalid username/password, please try again");
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;

                }
                return false;
            }

        }

        //Close connection
        public bool CloseConnection()
        {
            return true;
        }

        //Insert statement
        public void Insert(string query)
        {
            // query = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";

            //open connection
            if (connection.State != System.Data.ConnectionState.Open) { connection.Open(); }

            //create command and assign the query and connection from the constructor
            MySqlCommand cmd = new MySqlCommand(query, connection);

            //Execute command
            cmd.ExecuteNonQuery();

            //close connection
            this.CloseConnection();

        }
        /* public  void proofdbload()
         {

            // obj.proofload(connection);
         }*/

        public void update(string query)
        {
            // query = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";

            //open connection
            if (connection.State != System.Data.ConnectionState.Open) { connection.Open(); }

            //create command and assign the query and connection from the constructor
            MySqlCommand cmd = new MySqlCommand(query, connection);

            //Execute command
            cmd.ExecuteNonQuery();

            //close connection
            this.CloseConnection();

        }

        public MySqlDataReader autofill(string query)
        {
            //using() 
            //{
            MySqlCommand cmd = new MySqlCommand(query, connection);
            // connection.Open();
            //DBConnection db = new DBConnection();
            // db.OpenConnection();
            MySqlDataReader reader = cmd.ExecuteReader();
            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
            while (reader.Read())
            {
                MyCollection.Add(reader.GetString(0));
            }
            //textBox1.AutoCompleteCustomSource = MyCollection;
            connection.Close();
            //}
            return reader;
        }
        public DataTable select(String selectQuery)
        {
            DataTable data = new DataTable();
            try
            {
                //open connection
                if (connection.State != System.Data.ConnectionState.Open) { connection.Open(); }
                MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, connection);

                adapter.Fill(data);
                foreach (DataRow row in data.Rows)
                {
                    //Console.WriteLine(row["COLUMN_NAME"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return data;
        }
        public MySqlDataAdapter selectadapter(string query)
        {
            MySqlDataAdapter data = new MySqlDataAdapter(query, connection);
            connection.Close();
            return data;
        }
        public DataTable selectrefer(string query)
        {
            DataTable data = new DataTable();
            if (connection.State != System.Data.ConnectionState.Open) { connection.Open(); }
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);

            adapter.Fill(data);
            foreach (DataRow row in data.Rows)
            {
                //Console.WriteLine(row["COLUMN_NAME"]);
            }
            // MySqlCommand cmd = new MySqlCommand(query, connection);
            // MessageBox.Show("hi");
            // int a=0;
            //Execute command
            //= cmd.ExecuteNonQuery();

            //close connection
            // cmd.ExecuteNonQuery();
            return data;

        }
        public int selectNextBillNo()
        {
            int newBillNo = 0;
            string query = "select max(bill_no) as bill_no from billdetails";
            DataTable data = select(query);

            foreach (DataRow row in data.Rows)
            {
                newBillNo = Int32.Parse(row["bill_no"].ToString());
                //Console.WriteLine(row["COLUMN_NAME"]);
            }
            return newBillNo;
        }
        public DataTable loadMobileNumbers()
        {

            string query = "select customer_id, mobile_no from customer_info";
            DataTable data = select(query);

            return data;
        }
        public DataTable loadreferredname(string query)
        {


            DataTable data = select(query);

            return data;
        }
        public DataTable loadproofnum(string query)
        {


            DataTable data = select(query);

            return data;
        }
        public DataTable loadall(string query)
        {


            DataTable data = select(query);

            return data;
        }

        public DataTable loadreferredid(string query)
        {

            DataTable data = select(query);
            return data;
        }
        public DataTable loadmachinecode(string query)
        {

            DataTable data = select(query);
            return data;
        }
        public DataTable loadproof(string query)
        {

            DataTable data = select(query);
            return data;
        }
        public DataTable loadMachineCodes()
        {

            string query = "select machine_code from machine_details where is_available = 'Y'";
            DataTable data = select(query);

            return data;
        }
        public DataTable populateCustomerData(int customer_id)
        {
            MessageBox.Show("hello");

            string query = "select customer_name, address from customer_info where customer_id = '" + customer_id + "'";
            DataTable data = select(query);
            return data;
        }
        public DataTable populateCustinfo(int proof_num)
        {
            //MessageBox.Show("hi");
            string query = "select customer_id,proof_number, proof,address,mobile_no,customer_name,referred_by_name,referred_by_id,photo_location from customer_info where proof_number = '" + proof_num + "'";

            DataTable data = select(query);
            return data;
        }
        public DataTable populateCustid(int proof_num)
        {
            //MessageBox.Show("hi");
            string query = "select * from vikram.customer_info where customer_id = " + proof_num + "";

            DataTable data = select(query);
            return data;
        }
        public DataTable errormobileno(string query)
        {
            DataTable data = selectrefer(query);
            return data;
        }
        public DataTable populatemachinedata(string query)
        {

            DataTable data = select(query);
            return data;
        }
        public DataTable populatemachineratedata(string query)
        {

            DataTable data = select(query);
            return data;
        }
        public MySqlDataAdapter photoload(int proof_num)
        {
            string query = "select photo from customer_info where customer_id=" + proof_num + "";
            MySqlDataAdapter data = selectadapter(query);
            return data;
        }
    }
}
