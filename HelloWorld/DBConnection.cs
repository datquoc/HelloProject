using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class DBConnection
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public DBConnection()
        {
            Initialize();
        }



        //Initialize values
        private void Initialize()
        {
            server = "localhost:3306";
            database = "student";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Error");
                        break;

                    case 1045:
                        Console.WriteLine("Error");
                        break;
                }
                return false;
            }
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
                Console.WriteLine("Error");
                return false;
            }
        }

        public bool Insert(Student student)
        {
            string query = "INSERT INTO students (id,name, rollNumber) VALUES("+ student.Id +",'"+ student.Name +"', '"+ student.RollNumber +"')";

            //open connection
            if (this.OpenConnection() == true)
            {
                try
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error " + ex.Message);
                }
            }
            return false;
        }

        static void Main(string[] args)
        {
            DBConnection p = new DBConnection();
            Student st = new Student(2,"Ta Quoc Dat","ABCDEF");
            p.Insert(st);
            Console.ReadLine();
        }
    }
}
