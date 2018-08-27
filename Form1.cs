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
using System.IO;
using System.Text.RegularExpressions;
//using MySql.Data.MySqlClient;
namespace MachineRenting
{
    public partial class Form1 : Form
    {
        //private readonly object textBox1;
        // Form1 obj = new Form1();
        public Form1()
        {
            InitializeComponent();
        }

        private void vikramDataSetBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        public void Form1_Load(object sender, EventArgs e)
        {

            //string querySelect = "SELECT * FROM tblschools";
            DBConnection db = new DBConnection();
            db.OpenConnection();
            //errorProvider2.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            // ValidateTextBox(textBox3, EventArgs.Empty);
            //ValidateTextBox(txtAddress, EventArgs.Empty);
            //db.proofdbload();
            // TODO: This line of code loads data into the 'vikramDataSet.customer_info' table. You can move, or remove it, as needed.
            //this.customer_infoTableAdapter.Fill(this.vikramDataSet.customer_info);
            // TODO: This line of code loads data into the 'vikramDataSet3.machine_details' table. You can move, or remove it, as needed.
            //this.machine_detailsTableAdapter.Fill(this.vikramDataSet3.machine_details);
            // TODO: This line of code loads data into the 'vikramDataSet2.customer_info' table. You can move, or remove it, as needed.
            //this.customer_infoTableAdapter.Fill(this.vikramDataSet2.customer_info);
            // TODO: This line of code loads data into the 'vikramDataSet1.customer_info' table. You can move, or remove it, as needed.
            //this.customer_infoTableAdapter.Fill(this.vikramDataSet1.customer_info);
            //create a new datatable
            //custgrid();
            //loadall();
            // Custinfo();
            Add_Machine.Enabled = false;
            Add.Enabled = false;
            loadcustid();
            loadmachineid();
            // comboBox6.Text = "";
            // loadcustid();
            machinedatagridview();
            custdatagridview();
            custproofnum.Text = "";
            loadreferredname();
            custrefername.Text = "";
            loadMobileNumbers();
            cmbCustMobileNo.Text = "";
            loadproofnum();
            custproofnum.Text = "";
            loadproof();
            custproof.Text = "";
            custid.Text = null;
            custrefername.Text = null;
            custproofnum.Text = null;
            custproof.Text = null;
            DataGridViewComboBoxColumn dt = (DataGridViewComboBoxColumn)dataGridMachineDetils.Columns["mcode"];
            //ComboBox cb = (ComboBox)dt;
            dt.DataSource = loadMachineCodes();
            dt.DisplayMember = "machine_code";
            dt.ValueMember = "machine_code";
            // dt.Items.Add("Test1");
            //dt.Items.Add("Test2");
            // dt.DisplayStyle = ComboBoxStyle.DropDown;
        }
        /* public void proofload(MySqlConnection connection)
         {
             //string ConString =  connection;
             //string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
             using ( connection )
             {
                 MySqlCommand cmd = new MySqlCommand("SELECT FirstName FROM Employees", connection);
                 connection.Open();
                 MySqlDataReader reader = cmd.ExecuteReader();
                 AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                 while (reader.Read())
                 {
                     MyCollection.Add(reader.GetString(0));
                 }
                 textBox1.AutoCompleteCustomSource = MyCollection;
                 connection.Close();
             }
         }*/
        public void updatecust()
        {
            try
            {
                if (invalidcust.Checked == true)
                {
                    //This is  MySqlConnection here i have created the object and pass my connection string.  
                    string query = "update customer_info set  valid='N',mobile_no='" + custmobileno.Text + "',customer_name='" + custname.Text + "',address='" + custaddress.Text + "',proof='" + custproof.Text + "',referred_by_name='" + custrefername.Text + "',referred_by_id='" + custreferid.Text + "',photo='" + custimage.Image + "',photo_location='" + imglocation.Text + "' where proof_number='" + custproofnum.Text + "';";
                    DBConnection db = new DBConnection();
                    db.OpenConnection();
                    db.update(query);
                }
                else
                {
                    string query = "update customer_info set mobile_no='" + custmobileno.Text + "',customer_name='" + custname.Text + "',address='" + custaddress.Text + "',proof='" + custproof.Text + "',referred_by_name='" + custrefername.Text + "',referred_by_id='" + custreferid.Text + "',photo='" + custimage.Image + "',photo_location='" + imglocation.Text + "' where proof_number='" + custproofnum.Text + "';";
                    DBConnection db = new DBConnection();
                    db.OpenConnection();
                    db.update(query);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /* private HashSet<Control> errorControls = new HashSet<Control>();

         private void ValidateTextBox(object sender, EventArgs e)
         {
             int len = textBox3.TextLength;
             var textBox = sender as TextBox;
             if (len !=10)
             {
                 errorProvider1.SetError(textBox, (string)textBox.Tag);
                 errorControls.Add(textBox);
             }
             else
             {
                 errorProvider1.SetError(textBox, null);
                 errorControls.Remove(textBox);
             }
             Add.Enabled = errorControls.Count == 0;
         }*/
        /* public void custgrid()
         {
             DataTable dt = new DataTable();
             dt = new DataTable();
             //create our SQL SELECT statement
             string sql = "Select * from customer_info";
             //then we execute the SQL statement against the Connection using OleDBDataAdapter
             //string connection = MySqlConnection .custgrid();
             DBConnection db = new DBConnection();
             db.OpenConnection();
             string connectionString;
             //connectionString = "SERVER="localhost";" + "DATABASE=" vikram";" + "UID=" root ";" + "PASSWORD=" bavithran@14 ";";

             //MySqlConnection connection = new MySqlConnection(connectionString);
            // MySqlDataAdapter da = new MySqlDataAdapter(sql,connection);
            // da= db.select(sql);
             //we fill the result to dt which declared above as datatable
             da.Fill(dt);
             //then we populate the datagridview by specifying the datasource equal to dt
           Customer_dataGrid.DataSource = dt;
             //return dt;
         }*/
        public void updatecustinvalid()
        {
            try
            {
                if (invalidcust.Checked == true)
                {
                    //This is  MySqlConnection here i have created the object and pass my connection string.  
                    string query = "update customer_info set valid='" + "N" + "' where proof_number='" + custproofnum.Text + "';";
                    DBConnection db = new DBConnection();
                    db.OpenConnection();
                    db.update(query);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void updatemachineinvalid()
        {
            try
            {
                //This is  MySqlConnection here i have created the object and pass my connection string.  
                string query = "update machine_details set valid='" + "N" + "' where machine_code='" + machinecode.Text + "';";
                string ratequery = "update machine_rate_details set valid='" + "N" + "' where machine_code='" + machinecode.Text + "';";
                DBConnection db = new DBConnection();
                db.OpenConnection();
                db.update(query);
                db.update(ratequery);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void updatemachine()
        {
            try
            {

                if (invalidmachine.Checked == true)
                {
                    string query = "update machine_details set machine_name='" + txt_machine_name.Text + "',qty='" + txtQuantity.Text + "' ,valid='" + "N" + "' where machine_code='" + machinecode.Text + "';";
                    string ratequery = "update machine_rate_details set rate='" + txtRate.Text + "',valid='" + "N" + "' where machine_code='" + machinecode.Text + "';";
                    DBConnection db = new DBConnection();
                    db.OpenConnection();
                    db.update(query);
                    db.update(ratequery);
                    MessageBox.Show("Updated successfully", "Machine Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string query = "update machine_details set machine_name='" + txt_machine_name.Text + "',qty='" + txtQuantity.Text + "' where machine_code='" + machinecode.Text + "';";
                    string ratequery = "update machine_rate_details set rate='" + txtRate.Text + "' where machine_code='" + machinecode.Text + "';";
                    DBConnection db = new DBConnection();
                    db.OpenConnection();
                    db.update(query);
                    db.update(ratequery);
                    MessageBox.Show("Updated successfully", "Machine Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Enter all values", "Machine Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private DataTable loadMachineCodes()
        {
            DBConnection db = new DBConnection();
            db.OpenConnection();
            DataTable machine_codes = db.loadMachineCodes();
            //cmbCustMobileNo.DataSource = mobileNumbers;
            //cmbCustMobileNo.ValueMember = "customer_id";
            //cmbCustMobileNo.DisplayMember = "mobile_no";
            return machine_codes;
        }
        public void insertdata()
        {
            try
            {
                string query = "insert into billdetails values(" + cmbBillNo.Text + "," + cmbCustMobileNo.SelectedValue + "," + "'remarks'" + "," + LblTotal.Text + "," + LblBalance.Text + ")";
                DBConnection db = new DBConnection();
                db.OpenConnection();
                db.Insert(query);
                for (int rows = 0; rows < dataGridMachineDetils.Rows.Count - 1; rows++)
                {
                    String code = dataGridMachineDetils.Rows[rows].Cells["mcode"].Value.ToString();
                    String mname = dataGridMachineDetils.Rows[rows].Cells["MName"].Value.ToString();
                    int mrate = Int32.Parse(dataGridMachineDetils.Rows[rows].Cells["mrate"].Value.ToString());
                    int total = Int32.Parse(dataGridMachineDetils.Rows[rows].Cells["mtotal"].Value.ToString());
                    int quantity = Int32.Parse(dataGridMachineDetils.Rows[rows].Cells["mquantity"].Value.ToString());
                    string itemquery = "insert into bill_item_details(bill_no,machine_code,quantity,rate,total) values(" + cmbBillNo.Text + ",'" + code + "'," + quantity + "," + mrate + "," + total + ")";
                    db.Insert(itemquery);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /* public void custdatagrid()
         {
             try
             {
                // string query = "insert into billdetails values(" + cmbBillNo.Text + "," + cmbCustMobileNo.SelectedValue + "," + "'remarks'" + "," + LblTotal.Text + "," + LblBalance.Text + ")";
                 DBConnection db = new DBConnection();
                 db.OpenConnection();
                 db.Insert(query);
                 for (int rows = 0; rows < Customer_dataGrid.Rows.Count - 1; rows++)
                 {
                     String code = Customer_dataGrid.Rows[rows].Cells["customer"].Value.ToString();
                     String mname = Customer_dataGrid.Rows[rows].Cells["MName"].Value.ToString();
                     int mrate = Int32.Parse(Customer_dataGrid.Rows[rows].Cells["mrate"].Value.ToString());
                     int total = Int32.Parse(Customer_dataGrid.Rows[rows].Cells["mtotal"].Value.ToString());
                     int quantity = Int32.Parse(Customer_dataGrid.Rows[rows].Cells["mquantity"].Value.ToString());
                     string itemquery = "insert into bill_item_details(bill_no,machine_code,quantity,rate,total) values(" + cmbBillNo.Text + ",'" + code + "'," + quantity + "," + mrate + "," + total + ")";
                     db.Insert(itemquery);
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }*/
        public void insertcust()
        {
            try
            {
                string query = "insert into customer_info(proof_number,mobile_no,customer_name,address,proof,referred_by_name,referred_by_id,photo,photo_location) values('" + custproofnum.Text + "','" + custmobileno.Text + "','" + custname.Text + "','" + custaddress.Text + "','" + custproof.Text + "','" + custrefername.Text + "','" + custreferid.Text + "','" + custimage.Image + "','" + imglocation.Text + "')";
                DBConnection db = new DBConnection();
                db.OpenConnection();
                db.Insert(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void insertmachine()
        {
            try
            {
                string query = "insert into machine_details(machine_code,machine_name,qty)values('" + machinecode.Text + "','" + txt_machine_name.Text + "','" + txtQuantity.Text + "')";
                string rateqry = "insert into machine_rate_details(machine_code,rate)values('" + machinecode.Text + "','" + txtRate.Text + "')";
                DBConnection db = new DBConnection();
                db.OpenConnection();
                db.Insert(query);
                db.Insert(rateqry);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void custdatagridview()
        {
            try
            {
                String query = "Select customer_id,customer_name,address,mobile_no from customer_info";
                DBConnection db = new DBConnection();
                db.OpenConnection();
                MySqlDataAdapter da = db.selectadapter(query);
                //da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                Customer_dataGrid.DataSource = dt;

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
        public void machinedatagridview()
        {
            try
            {
                String query = "Select a.machine_code,a.machine_name,a.qty,a.is_available,b.rate from machine_details a ,machine_rate_details b where a.machine_code=b.machine_code";
                //String query1 = "Select rate from machine_rate_details where valid='Y'";
                DBConnection db = new DBConnection();
                db.OpenConnection();
                MySqlDataAdapter da = db.selectadapter(query);
               // MySqlDataAdapter da1 = db.selectadapter(query1);
                DataTable dt = new DataTable();
               //DataTable dt = new DataTable();
                da.Fill(dt);
               // da1.Fill(dt);
                Machine_dataGrid.DataSource = dt;
              // Machine_dataGrid.DataSource = dt;


            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
        private void loadNewBillNo()
        {
            DBConnection db = new DBConnection();
            db.OpenConnection();
            int billNo = db.selectNextBillNo();
            // if (billNo == 0)
            billNo++;
            cmbBillNo.Text = billNo.ToString();
        }
        private void loadMobileNumbers()
        {
            DBConnection db = new DBConnection();
            db.OpenConnection();
            DataTable mobileNumbers = db.loadMobileNumbers();
            cmbCustMobileNo.DataSource = mobileNumbers;
            cmbCustMobileNo.ValueMember = "customer_id";
            cmbCustMobileNo.DisplayMember = "mobile_no";
        }
        private void loadproofnum()
        {
            DBConnection db = new DBConnection();
            db.OpenConnection();
            string query = "select proof_number,customer_id from customer_info where valid='Y'";
            DataTable proofnum = db.loadproofnum(query);
            custproofnum.DataSource = proofnum;
            custid.ValueMember = "customer_id";
            custproofnum.DisplayMember = "proof_number";
        }
        /*  private void loadall()
          {// + comboBox3.Text + "','" +textBox3.Text+ "','" + textBox4.Text + "','" + richTextBox1.Text+"','"+comboBox2.Text +"','"+comboBox4.Text+"','"+comboBox5.Text+"','"+pictureBox1.Image +"','"+textBox7.Text +
              DBConnection db = new DBConnection();
              db.OpenConnection();
              string query = "select proof_number,mobile_no,customer_name,address,proof,referred_by_name,referred_by_id,photo,photo_location from customer_info";
              DataTable proofnum = db.loadall(query);
              comboBox3.DataSource = proofnum;
              //cmbCustMobileNo.ValueMember = "customer_id";
              comboBox3.DisplayMember = "proof_number";
              textBox3.Displaymember = "mobile_no";
              textBox4.Displaymember = "customer_name";
              richTextBox1.Displaymember = "address";
              comboBox2.Displaymember = "proof";
              comboBox4.Displaymember = "referred_by_name";
              comboBox5.Displaymember = "referred_by_id";
              pictureBox1.Displaymember = "photo";
              textBox7.Displaymember = "photo_location";
          }*/
        private void loadproof()
        {
            DBConnection db = new DBConnection();
            db.OpenConnection();
            string query = "select proof_name from proof";
            DataTable proof = db.loadproof(query);
            custproof.DataSource = proof;
            //cmbCustMobileNo.ValueMember = "customer_id";
            custproof.DisplayMember = "proof_name";
        }
        private void loadreferredname()
        {
            string query = "select customer_name,proof_number from customer_info where valid='Y'";
            DBConnection db = new DBConnection();
            db.OpenConnection();
            DataTable refertable = db.loadreferredname(query);
            custrefername.DataSource = refertable;
            custrefername.ValueMember = "proof_number";
            custrefername.DisplayMember = "customer_name";
        }
        private void loadcustid()
        {
            string query = "select customer_id from customer_info where valid='Y'";
            DBConnection db = new DBConnection();
            db.OpenConnection();
            DataTable custtable = db.loadreferredname(query);
            custid.DataSource = custtable;
            // comboBox4.ValueMember = "proof_number";
            custid.DisplayMember = "customer_id";
        }
        private void loadmachineid()
        {
            string query = "select machine_code from machine_details where valid='Y'";
            DBConnection db = new DBConnection();
            db.OpenConnection();
            DataTable custtable = db.loadreferredname(query);
            machinecode.DataSource = custtable;
            machinecode.ValueMember = "machine_code";
            machinecode.DisplayMember = "machine_code";
        }
        private void loadreferredid()
        {
            string query = "select proof_number,customer_id from customer_info where customer_name='" + custrefername.Text + "' and valid='Y'";
            DBConnection db = new DBConnection();
            db.OpenConnection();
            DataTable referidtable = db.loadreferredid(query);
            custreferid.DataSource = referidtable;
            custreferid.ValueMember = "customer_id";
            custreferid.DisplayMember = "proof_number";
        }

        //connection.Close();
        // }
        //DBConnection db = new DBConnection();
        // db.OpenConnection();
        //DataTable proofnumber = db.loadproofnumber();
        // textBox1 .AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        // textBox1.AutoCompleteCustomSource = proofnumber;
        // textBox1.ValueMember = "proof_number";
        // textBox1.DisplayMember = "proof_number";
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            loadNewBillNo();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            insertdata();
        }
        private void populateCustomerData(int customer_id)
        {
            DBConnection db = new DBConnection();
            db.OpenConnection();
            DataTable customerData = db.populateCustomerData(customer_id);
            DataRow row = customerData.Rows[0];
            //"customer_name"
            txtCustomerName.Text = row["customer_name"].ToString();
            txtCustomerAddr.Text = row["address"].ToString();
        }
        private void populatemachinedata(string machine_id)
        {
            DBConnection db = new DBConnection();
            db.OpenConnection();
            string query = "select machine_code,machine_name,qty from machine_details where machine_code= '" + machine_id + "'";
            string query1 = "select rate from machine_rate_details where  machine_code='" + machine_id + "'";
            DataTable customerData = db.populatemachinedata(query);
            DataTable customerData1 = db.populatemachineratedata(query1);
            DataRow row = customerData.Rows[0];
            DataRow row1 = customerData1.Rows[0];
            //"customer_name"
            machinecode.Text = row["machine_code"].ToString();
            txt_machine_name.Text = row["machine_name"].ToString();
            txtQuantity.Text = row["qty"].ToString();
            txtRate.Text = row1["rate"].ToString();
        }
        private void cmbCustMobileNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //MessageBox.Show(cmbCustMobileNo.SelectedIndex.ToString());
            if (cmbCustMobileNo.SelectedIndex > -1)
            {

                int selectedCustId = (int)cmbCustMobileNo.SelectedValue;
                populateCustomerData(selectedCustId);

            }
        }
        private void machinecode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //MessageBox.Show(cmbCustMobileNo.SelectedIndex.ToString());
            if (machinecode.SelectedIndex > -1)
            {
                // try
                // {
                //  MessageBox.Show(machinecode.SelectedValue.ToString());
                string selectedmachinecode = machinecode.SelectedValue.ToString();
                populatemachinedata(selectedmachinecode);
                //  }
                /* catch (System.InvalidCastException a)
                 {
                     populatemachinedata(machinecode.SelectedValue);
                 }*/
            }
        }

        /* private void populateCustinfo(int proof_number)
         {
             DBConnection db = new DBConnection();
             db.OpenConnection();

             DataTable customerinfo = db.populateCustinfo(proof_number);
             DataRow row = customerinfo.Rows[0];
             //"customer_name"
            // comboBox6.Text = row["customer_id"].ToString();
             textBox4.Text = row["customer_name"].ToString();
             richTextBox1.Text = row["address"].ToString();
             textBox3.Text = row["mobile_no"].ToString();
             //comboBox4.Text = row["referred_by_name"].ToString();
             //comboBox5.Text = row["referred_by_id"].ToString();
            // comboBox2.Text = row["proof"].ToString();
             //textBox7.Text = row["photo_location"].ToString();
             //pictureBox1.Image  =row["photo"].ToString();
         }*/
        /*private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //MessageBox.Show(cmbCustMobileNo.SelectedIndex.ToString());
            if (comboBox3.SelectedIndex > -1)
            {
              int selectedCust = (int)comboBox3.SelectedValue;
                populateCustinfo(selectedCust);
            }
        }*/
        private void populateCustid(int proof_number)
        {
            DBConnection db = new DBConnection();
            db.OpenConnection();
            MySqlDataAdapter da = db.photoload(proof_number);
            DataTable customerinfo = db.populateCustid(proof_number);
            DataRow row = customerinfo.Rows[0];
            DataSet ds = new DataSet();
            da.Fill(ds);
            //"customer_name"
            // comboBox6.Text = row["customer_id"].ToString();
            // string query = "select photo from customer_info where customer_id='" + proof_number + "'";
            custname.Text = row["customer_name"].ToString();
            custaddress.Text = row["address"].ToString();
            custmobileno.Text = row["mobile_no"].ToString();
            custproofnum.Text = row["proof_number"].ToString();
            custrefername.Text = row["referred_by_name"].ToString();
            custreferid.Text = row["referred_by_id"].ToString();
            custproof.Text = row["proof"].ToString();
            imglocation.Text = row["photo_location"].ToString();
            /*byte[] b = new byte[0];
            b = (Byte[])(customerinfo.Rows[0][1]);
            MemoryStream ms = new MemoryStream(b);
            custimage.Image = Image.FromStream(ms);*/
            // byte[] imag = (byte[])row["photo"]; 
            //stream.Write(img, 0, img.Length);
            // pictureBox1.Image=byteArrayToImage(imag);
            //Image imag = Image.FromStream(stream);
            // pictureBox1.contenttype = "img/JPEG";
            //imag.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            // MemoryStream ms = new MemoryStream(img);
            // pictureBox1.Image = Image.FromStream (ms);

            // MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["customer_info"]);
            // pictureBox1.Image = new Bitmap(ms);
            //pictureBox1.Image  =row["photo"].ToString();*/
        }
        public Image byteArrayToImage(byte[] imag)
        {

            System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
            Image img = (Image)converter.ConvertFrom(imag);

            return img;
        }
        private void custid_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //MessageBox.Show(cmbCustMobileNo.SelectedIndex.ToString());
            if (custid.SelectedIndex > -1)
            {
                int selectedCust = (int)custid.SelectedValue;
                populateCustid(selectedCust);
            }
        }
        /* private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
          {
              //MessageBox.Show(cmbCustMobileNo.SelectedIndex.ToString());
              if (comboBox3.SelectedIndex > -1)
              {
                  int selectedCustId = (int)comboBox3.SelectedValue;
                  populateCustinfo(selectedCustId);
              }
          }*/
        private void button4_Click(object sender, EventArgs e)
        {


        }

        private void cmbMobileNumber_EnterKey(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Return)
            {
                if (cmbCustMobileNo.SelectedIndex > -1)
                {
                    int selectedCustId = (int)cmbCustMobileNo.SelectedValue;
                    populateCustomerData(selectedCustId);
                }
            }

        }
        /* private void machinecode_EnterKey(object sender, KeyEventArgs e)
         {

             if (e.KeyCode == Keys.Return)
             {
                 if (machinecode.SelectedIndex > -1)
                 {
                     int selectedCustId = (int)machinecode.SelectedValue;
                     populatemachinedata(selectedCustId);
                 }
             }

         }*/
        private void comboBox3_EnterKey(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Return)
            {
                if (custproofnum.SelectedIndex > -1)
                {
                    MessageBox.Show("hi");
                    //int selectedCustId = (int)comboBox3.SelectedValue;
                    //Custinfo(selectedCustId);
                }
            }

        }
        private void textBox3_EnterKey(object sender, KeyEventArgs e)
        {
            int len = custmobileno.TextLength;

            if (len != 10)
            {
                MessageBox.Show("Enter valid mobile number");
                custmobileno.Clear();
            }
        }
        private void dataGridiewMachineDetails_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridMachineDetils.CurrentCellAddress.X == mcode.DisplayIndex)
            {
                ComboBox combo = e.Control as ComboBox;
                if (combo != null)
                {
                    combo.DropDownStyle = ComboBoxStyle.DropDown;
                }

            }
        }

        private void cmbCustMobileNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void machinecode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtCustomerAddr_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void Customer_info_Enter(object sender, EventArgs e)
        {

        }

        public void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /*public  void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox1.Text !=null)
            {
                //s query = textBox1.Text;
               // populateCustomerinfo(query);
            }
        }*/

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {


            insertcust();
            custproofnum.ResetText();
            custmobileno.Clear();
            custname.Clear();
            custaddress.Clear();
            custproof.ResetText();
            custrefername.ResetText();
            custreferid.ResetText();
            imglocation.Clear();
            custimage.Image = null;
            custid.ResetText();
            MessageBox.Show("Saved successfully", "Customer Details", MessageBoxButtons.OK, MessageBoxIcon.Information);

            /*ElseIf result = DialogResult.No Then
                MessageBox.Show("Are you sure?", "Customer Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            ElseIf result = DialogResult.Cancel Then
                MessageBox.Show("Cancelled", "Customer Details", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            }*/

        }
        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void Machine_Invalid_Click(object sender, EventArgs e)
        {
            updatemachineinvalid();
        }

        private void Machine_dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void l_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void Customer_Text_Enter(object sender, EventArgs e)
        {

        }

        private void cmbBillNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridMachineDetils_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void custname_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {



        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void machinecode_TextChanged(object sender, EventArgs e)
        {

        }

        private void Add_Machine_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Added successfully", "Machine Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            insertmachine();
            machinecode.Text = "";
            txt_machine_name.Text = "";
            txtQuantity.Text = "";
            txtRate.Text = "";
            //insertrate();
        }

        private void txt_machine_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void LblTotal_Click(object sender, EventArgs e)
        {

        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {

        }

        public void Customer_Update_Click(object sender, EventArgs e)
        {
            loadproofnumber();
            custproofnum.Text = "";
        }

        private void loadproofnumber()
        {
            //autofill();
            // throw new NotImplementedException();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            updatecust();
            MessageBox.Show("Updated successfully", "Customer Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //MessageBox("Su")
            custproofnum.Text = "";
            custmobileno.Text = "";
            custname.Text = "";
            custaddress.Text = "";
            custproof.Text = "";
            custrefername.Text = "";
            custreferid.Text = "";
            imglocation.Text = "";
            custimage.Image = null;
            custid.Text = null;
            invalidcust.Checked = false;
        }

        private void Update_Machine_Click(object sender, EventArgs e)
        {
            updatemachine();
            machinecode.Text = "";
            txt_machine_name.Text = "";
            txtQuantity.Text = "";
            txtRate.Text = "";
            // MessageBox.Show("Updated successfully", "Customer Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            invalidmachine.Checked = false;
            //this.InitializeComponent();
            // this.Refresh();
            //this.Form1_Load(object sender, EventArgs e);

            // UserInfoForm form = new UserInfoForm();
            //  form.Refresh();

        }

        private void Customer_Invalid_Click(object sender, EventArgs e)
        {
            updatecustinvalid();
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            string Chosen_File = "";
            openFileDialog1.InitialDirectory = "documents";
            openFileDialog1.Title = "Insert an Image";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "JPEG Images|*.jpg|All Files|*.*";
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                Chosen_File = openFileDialog1.FileName;
                custimage.Image = Image.FromFile(Chosen_File);
                imglocation.Text = openFileDialog1.FileName;
            }
            else
            {
                MessageBox.Show("Cancelled");
            }

            ////String location;
            //String fileName;
            //openPic.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            //Showing the fileopen dialog box
            // openPic.ShowDialog();
            //showing the image opened in the picturebox
            // pictureBox1.BackgroundImage = new Bitmap(openPic.FileName);
            //storing the location of the pic in variable
            //location = openPic.FileName;
            //textBox7.Text = location;
            //storing the filename of the pic in variable
            // fileName = openPic.SafeFileName;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtRate_Validated(object sender, EventArgs e)
        {
            bool bTest = txtRateIsValid();
            if (bTest == true)
            {
                this.errorProvider3.SetError(txtRate, "Rate must in number only");
                MessageBox.Show("Rate must in number only", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                // this.errorProvider1.SetError(textBox3, ");
                Add_Machine.Enabled = false;
                Update_Machine.Enabled = false;
            }
            else
            {
                this.errorProvider3.SetError(txtRate, "");
                // MessageBox.Show("Mobile already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Update_Machine.Enabled = true;
                Add_Machine.Enabled = true;
            }
        }
        private bool txtRateIsValid()
        {
            if (txtRate.Text == string.Empty)
            {
                return true;
            }
            char[] testArr = txtRate.Text.ToCharArray();
            bool testBool = false;
            for (int i = 0; i < testArr.Length; i++)
            {
                if (!char.IsNumber(testArr[i]))
                {
                    testBool = true;
                }
            }
            return testBool;
        }
       private void txtQuantity_Validated(object sender, EventArgs e)
        {
            bool bTest = txtQuantityIsValid();
            if (bTest == true)
            {
                this.errorProvider4.SetError(txtQuantity, "Quantity must in number only");
                MessageBox.Show("Quantity must in number only", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                // this.errorProvider1.SetError(textBox3, ");
                Add_Machine.Enabled = false;
                Update_Machine.Enabled = false;
            }
            else
            {
                this.errorProvider4.SetError(txtQuantity, "");
                // MessageBox.Show("Mobile already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Update_Machine.Enabled = true;
                Add_Machine.Enabled = true;
            }
        }
        private bool txtQuantityIsValid()
        {
            if (txtQuantity.Text == string.Empty)
            {
                return true;
            }
            char[] testArr = txtQuantity.Text.ToCharArray();
            bool testBool = false;
            for (int i = 0; i < testArr.Length; i++)
            {
                if (!char.IsNumber(testArr[i]))
                {
                    testBool = true;
                }
            }
            return testBool;
        }
        private void textBox3_Validated(object sender, EventArgs e)
        {
            bool bTest = textBox3IsValid(custmobileno.Text.ToString());
            if (bTest == true)
            {
                this.errorProvider1.SetError(custmobileno, "This field must contain a phone number XXX - XXX - XXXX");
                MessageBox.Show("Mobile must contain 10 digit number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                // this.errorProvider1.SetError(textBox3, ");
                 Add.Enabled = false;
                Update.Enabled = false;
            }
            else
            {
                // int mobile = textBox3.Text;
                string mobile;
                //int val = textBox3.Text;
                try
                {
                    string query = "select customer_name from vikram.customer_info where mobile_no='" + custmobileno.Text + "'";
                    DBConnection db = new DBConnection();
                    db.OpenConnection();
                    DataTable customerData = db.errormobileno(query);
                    DataRow row = customerData.Rows[0];
                    //"customer_name"
                    mobile = row["customer_name"].ToString();
                    // txtCustomerAddr.Text = row["address"].ToString();
                    this.errorProvider1.SetError(custmobileno, "This field must contain a phone number XXX - XXX - XXXX");
                    MessageBox.Show("Mobile already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Update.Enabled = false;
                    Add.Enabled = false;
                }
                catch (Exception ax)
                {
                    this.errorProvider1.SetError(custmobileno, "");
                    Add.Enabled = true;
                    Update.Enabled = true;
                }

            }
        }
        private bool textBox3IsValid(string textToValidate)
        {
            Regex TheRegExpression;
            string TheTextToValidate;
            string TheRegExTest = @"[0-9]\d{3}\d{3}\d{4}";
            TheTextToValidate = textToValidate;
            TheRegExpression = new Regex(TheRegExTest);
            // test text with expression
            if (TheRegExpression.IsMatch(TheTextToValidate))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void custmobileno1_Validated(object sender, EventArgs e)
        {

        }
        private bool custmobileno1IsValid()
        {
            if (custmobileno.Text == string.Empty)
            {
                return true;
            }
            char[] testArr = custmobileno.Text.ToCharArray();
            bool testBool = false;
            for (int i = 0; i < testArr.Length; i++)
            {
                if (!char.IsNumber(testArr[i]))
                {
                    testBool = true;
                }
            }
            return testBool;
        }
       

        private void comboBox3_Validated(object sender, EventArgs e)
        {
            if (custproof.Text == "Aadhar")
            {
                bool bTest = comboBox3IsValid(custproofnum.Text.ToString());
                if (bTest == false)
                {
                    this.errorProvider2.SetError(custproofnum, "Aadhar must contain 16 digit number");
                    MessageBox.Show("Aadhar must contain 16 digit number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); ;

                    Add.Enabled = false;
                    Update.Enabled = false;
                }
                else
                {
                    string mobile;
                    //int val = textBox3.Text;
                    try
                    {
                        string query = "select customer_name from vikram.customer_info where proof_number='" + custproofnum.Text + "'";
                        DBConnection db = new DBConnection();
                        db.OpenConnection();
                        DataTable customerData = db.errormobileno(query);
                        DataRow row = customerData.Rows[0];
                        mobile = row["customer_name"].ToString();
                        this.errorProvider2.SetError(custproofnum, "Aadhar number already exists");
                        MessageBox.Show("Aadhar number already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Update.Enabled = false;
                        Add.Enabled = false;
                    }
                    catch (Exception ax)
                    {
                        this.errorProvider2.SetError(custproofnum, "");
                        Add.Enabled = true;
                        Update.Enabled = true;
                    }
                }
            }
            else if (custproof.Text == "Licence")
            {
                bool bTest = licenseIsValid(custproofnum.Text.ToString());
                if (bTest == false)
                {
                    this.errorProvider2.SetError(custproofnum, "License number must in TNxx-yyyy-xxxxxxx format");
                    MessageBox.Show("License number must in TNxx-yyyy-xxxxxxx format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                    // this.errorProvider1.SetError(, ");
                    Add.Enabled = false;
                    Update.Enabled = false;
                }
                else
                {
                    string mobile;
                    //int val = textBox3.Text;
                    try
                    {
                        string query = "select customer_name from vikram.customer_info where proof_number='" + custproofnum.Text + "'";
                        DBConnection db = new DBConnection();
                        db.OpenConnection();
                        DataTable customerData = db.errormobileno(query);
                        DataRow row = customerData.Rows[0];
                        //"customer_name"
                        mobile = row["customer_name"].ToString();
                        // txtCustomerAddr.Text = row["address"].ToString();
                        this.errorProvider2.SetError(custproofnum, "License number already exists");
                        MessageBox.Show("License number already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Update.Enabled = false;
                        Add.Enabled = false;
                    }
                    catch (Exception a)
                    {
                        this.errorProvider2.SetError(custproofnum, "");
                        Add.Enabled = true;
                        Update.Enabled = true;
                    }
                }
            }
            else if (custproof.Text == "Voter Id")
            {
                bool bTest = voterIsValid(custproofnum.Text.ToString());
                if (bTest == false)
                {
                    this.errorProvider2.SetError(custproofnum, "VoterId number must  in ABC-xxxxxxx format");
                    MessageBox.Show("VoterId number must  in ABC-xxxxxxx format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                    // this.errorProvider1.SetError(, ");
                    Add.Enabled = false;
                    Update.Enabled = false;
                }
                else
                {
                    string mobile;
                    //int val = textBox3.Text;
                    try
                    {
                        string query = "select customer_name from vikram.customer_info where proof_number='" + custproofnum.Text + "'";
                        DBConnection db = new DBConnection();
                        db.OpenConnection();
                        DataTable customerData = db.errormobileno(query);
                        DataRow row = customerData.Rows[0];
                        //"customer_name"
                        mobile = row["customer_name"].ToString();
                        // txtCustomerAddr.Text = row["address"].ToString();
                        this.errorProvider2.SetError(custproofnum, "VoterId number already exists");
                        MessageBox.Show("VoterId number already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Update.Enabled = false;
                        Add.Enabled = false;
                    }
                    catch (Exception x)
                    {
                        this.errorProvider2.SetError(custproofnum, "");
                        Add.Enabled = true;
                        Update.Enabled = true;
                    }

                }
            }
        }
        private bool comboBox3IsValid(string textToValidate)
        {
            Regex TheRegExpression;
            string TheTextToValidate;
            string TheRegExTest = @"^[0-9]\d{2}\d{3}\d{4}\d{4}\d{2}$";
            TheTextToValidate = textToValidate;
            TheRegExpression = new Regex(TheRegExTest);
            // test text with expression
            if (TheRegExpression.IsMatch(TheTextToValidate))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private bool licenseIsValid(string textToValidate)
        {

            Regex TheRegExpression;
            string TheTextToValidate;
            string TheRegExTest = @"^[A-Z]{2}[0-9]{2}[0-9]{4}[0-9]{7}$";
            TheTextToValidate = textToValidate;
            TheRegExpression = new Regex(TheRegExTest);
            // test text with expression
            if (TheRegExpression.IsMatch(TheTextToValidate))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool voterIsValid(string textToValidate)
        {
            Regex TheRegExpression;
            string TheTextToValidate;
            string TheRegExTest = @"^[A-Z]{3}[0-9]{7}$";
            TheTextToValidate = textToValidate;
            TheRegExpression = new Regex(TheRegExTest);
            // test text with expression
            if (TheRegExpression.IsMatch(TheTextToValidate))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            /* updatemachineinvalid();
             Machine_code_text.Text = "";
             txt_machine_name.Text = "";
             txtQuantity.Text = "";
             txtRate.Text = "";
         }

         private void checkBox1_CheckedChanged(object sender, EventArgs e)
         {
            /* updatecustinvalid();
             comboBox3.Text = "";
             textBox3.Text = "";
             textBox4.Text = "";
             richTextBox1.Text = "";
             comboBox2.Text = "";
             comboBox4.Text = "";
             comboBox5.Text = "";
             textBox7.Text = "";
             pictureBox1.Image = null;
             checkBox1.Checked = false;*/
            // checkBox1 .

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if comboBox4.clear();

            loadreferredid();

            /*DBConnection db = new DBConnection();
            db.OpenConnection();
            db.loadreferredid(query);*/
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //loadproofnum();
            //custid();
            //Custinfo();
            //loadall();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Add.Enabled = true;
            custproofnum.Text = "";
            custmobileno.Text = "";
            custname.Text = "";
            custaddress.Text = "";
            custproof.Text = "";
            custrefername.Text = "";
            custreferid.Text = "";
            imglocation.Text = "";
            custimage.Image = null;
            invalidcust.Checked = false;
            custid.Text = null;

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            machinecode.Text = "";
            txt_machine_name.Text = "";
            txtQuantity.Text = "";
            txtRate.Text = "";
            Add_Machine.Enabled = true;
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void machinecode_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void custid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void custentry_Click(object sender, EventArgs e)
        {
            Add.Enabled = true;
        }

        private void Customer_dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}