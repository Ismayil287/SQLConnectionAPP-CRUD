using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data;
using System.Windows.Forms;

namespace SQLConnectionAPP
{
    internal class CRUD
    {

        SqlCommand command;
        SqlDataAdapter adapter;
        private static SqlConnection connection = new SqlConnection(DataSource.GetConnectionString());

        public static bool Add(int ID, string Name, string Surname, string FatherName, string Gender, string Email, string Status, string BirthDate, string Adress, string GroupNumber)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }

                SqlCommand command = new SqlCommand("insert into Student(Name,Surname,ID,FatherName,Gender,Email,Status,BirthDate,Adress,GroupNumber) values('@name','@surname',@id,'@fathername','@gender','@email','@status','@birthdate','@adress',@groupnumber)", connection);
                command.Parameters.AddWithValue("@id",ID);
                command.Parameters.AddWithValue("@name", Name);
                command.Parameters.AddWithValue("@surname", Surname);
                command.Parameters.AddWithValue("@fathername", FatherName);
                command.Parameters.AddWithValue("@gender", Gender);
                command.Parameters.AddWithValue("@email", Email);
                command.Parameters.AddWithValue("@status", Status);
                command.Parameters.AddWithValue("@birthdate", BirthDate);
                command.Parameters.AddWithValue("@adress", Adress);
                command.Parameters.AddWithValue("@groupnumber", GroupNumber);

                command.ExecuteNonQuery();

                connection.Close();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public static bool Del(string ID)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("delete Student where ID=@id", connection);
                command.Parameters.AddWithValue("@id", ID);

                command.ExecuteNonQuery();

                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool Upd(string ID, string Name, string Surname, string FatherName, string Gender, string Email, string Status, string BirthDate, string Adress, string GroupNumber)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }

                SqlCommand command = new SqlCommand("insert into Student(Name,Surname,ID,FatherName,Gender,Email,Status,BirthDate,Adress,GroupNumber) values(@name,@surname,@id,@fathername,@gender,@email,@status,@birthdate,@adress,@groupnumber)", connection);
                command.Parameters.AddWithValue("@id", ID);
                command.Parameters.AddWithValue("@name", Name);
                command.Parameters.AddWithValue("@surname", Surname);
                command.Parameters.AddWithValue("@fathername", FatherName);
                command.Parameters.AddWithValue("@gender", Gender);
                command.Parameters.AddWithValue("@email", Email);
                command.Parameters.AddWithValue("@status", Status);
                command.Parameters.AddWithValue("@birthdate", BirthDate);
                command.Parameters.AddWithValue("@adress", Adress);
                command.Parameters.AddWithValue("@groupnumber", GroupNumber);

                command.ExecuteNonQuery();

                connection.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public static DataView Read(string ID)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                DataSet dt = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter("select * from Student where ID = '" + ID + "'", connection);
                adapter.Fill(dt);
                connection.Close();
                return dt.Tables[0].DefaultView;
            }
            catch
            {
                return null;
            }
        }
        public static DataView Show()
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                DataSet dt = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter("select * from Student ", connection);
                adapter.Fill(dt);
                connection.Close();
                return dt.Tables[0].DefaultView;
            }
            catch
            {
                return null;
            }
        }
    }
}
 

