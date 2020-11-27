using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using Google.Protobuf.WellKnownTypes;

namespace ModelLayer.Data
{
    public class Dbal
    {
        private MySqlConnection connection;


        //Constructor
        public Dbal(string database, string uid = "root", string password = "5MichelAnnecy", string server = "localhost")
        {
            Initialize(database, uid, password, server);
        }

        //Initialize values
        private void Initialize(string database, string uid, string password, string server)
        {
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;

        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        //CURQuery: Create, Update, Delete query execution method
        private void CUDQuery(string query)
        {
            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Insert statement
        public void Insert(string query)
        {
            query = "INSERT INTO " + query; // tablename (field1, field2) VALUES('value 1', 'value 2')";
            CUDQuery(query);

        }

        //Update statement
        public void Update(string query)
        {
            query = "UPDATE " + query;

            CUDQuery(query);
        }

        //Delete statement
        public void Delete(string query)
        {
            query = "DELETE FROM " + query;

            CUDQuery(query);
        }

        //RQuery: Read query method (to execute SELECT queries)
        private DataSet RQuery(string query)
        {
            DataSet dataset = new DataSet();
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Add query data in a DataSet
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                adapter.Fill(dataset);
                CloseConnection();
            }
            return dataset;
        }


        //Select statement
        public DataTable SelectAll(string table)
        {
            string query = "SELECT * FROM " + table;
            DataSet dataset = RQuery(query);

            return dataset.Tables[0];
        }

        public DataTable SelectByField(string table, string fieldTestCondition)
        {
            string query = "SELECT * FROM " + table + " where " + fieldTestCondition;
            DataSet dataset = RQuery(query);

            return dataset.Tables[0];
        }

        public DataRow SelectById(string table, int id)
        {
            string query = "SELECT * FROM " + table + " where id='" + id + "'";
            DataSet dataset = RQuery(query);

            return dataset.Tables[0].Rows[0];
        }
    }
}
