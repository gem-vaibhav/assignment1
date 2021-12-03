using System;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
namespace assaignment.DataLayer
{
    public class Database
    {
        static string connectionstring = "Server=localhost\\sqlexpress;Database=mydb;Integrated Security=True;";
        static SqlConnection connection = new SqlConnection(connectionstring);
        public static  SqlCommand command_creator(string query, Models.RegisterationRecord details)
        {
            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@firstname", details.First_Name);
            command.Parameters.AddWithValue("@lastname", details.Last_Name);
            command.Parameters.AddWithValue("@dob", details.DateOfBirth);
            command.Parameters.AddWithValue("@gender", Convert.ToString(details.UserGender));
            command.Parameters.AddWithValue("@email", details.Email_address);
            return command;
        }
        public static void RegisterDB(Models.RegisterationRecord record,out bool state)
        {
            var insert_query = "insert into [dbo].[UserDetails]" +
                    "([FirstName], [Lastname],[DOB],[Gender],[EmailAddress])" +
                    "values (@firstname,@lastname,@dob,@gender,@email);";

            var select_query = "select count(*) from [dbo].[UserDetails] " +
                "where [FirstName]=@firstname and [LastName]=@lastname and [DOB]=@dob " +
                "and [Gender]=@gender and [EmailAddress]=@email;";
            //var table_user_id_query = "select max([UserId]) from [dbo].[UserDetails];";
            
            var insert_command = command_creator(insert_query, record);
            var select_command = command_creator(select_query, record);
            //var user_id_command = new SqlCommand(table_user_id_query, connection);
            connection.Open();

            int row_count = Convert.ToInt32(select_command.ExecuteScalar());
            if (row_count == 0)
            {
                insert_command.ExecuteNonQuery();
                
                connection.Close();
                state = true;
            }
            else
            {
                connection.Close();
                state = false;
                
            }
        }

        public static void Editrecord(Models.AllUsers user)
        {   connection.Open();
            string query = "update [dbo].[UserDetails] set [FirstName]=@firstname,[LastName]=@lastname" +
              ",[DOB]=@dob,[Gender]=@gender,[EmailAddress]=@email where [UserId]=@id";
            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@firstname", user.FirstName);
            command.Parameters.AddWithValue("@lastname", user.LastName);
            command.Parameters.AddWithValue("@dob", user.DateOfBirth);
            command.Parameters.AddWithValue("@gender", Convert.ToString(user.gender));
            command.Parameters.AddWithValue("@email", user.EmailAdd);
            command.Parameters.AddWithValue("@id", user.Id);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static Models.AllUsers DetailDB(int id)
        { Models.AllUsers Details=new Models.AllUsers();
            connection.Open();
            string query = "select * from [dbo].[UserDetails] where [UserId]=@id;";
            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            var reader=command.ExecuteReader();
            while (reader.Read())
            {
              
                Details.Id = Convert.ToInt32(reader.GetOrdinal("UserId"));
                Details.FirstName = Convert.ToString(reader.GetValue(1));
                Details.LastName = Convert.ToString(reader.GetValue(2));
                Details.gender = Convert.ToString(reader.GetValue(4));
                Details.DateOfBirth = Convert.ToDateTime(reader.GetValue(3));
                Details.EmailAdd = Convert.ToString(reader.GetValue(5));
            }
            connection.Close();
            return Details;
        }

       public static void PasswordDB(Models.PasswordVerification record)
        {   connection.Open();
            string query = "insert into [dbo].[PasswordDetails] ([UserId],[Password])" +
                "values ((select max([UserId]) from [dbo].[UserDetails]),@password);";
            var command= new SqlCommand(query, connection);            
            command.Parameters.AddWithValue("@password", Encrypt(record.Password));
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static bool LoginDB(Models.LoginRecords data)
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
            connection.Open();
            
             string query = "select count([dbo].[UserDetails].[UserId]) from [dbo].[UserDetails]" +
                " inner join [dbo].[PasswordDetails] " +
                "on [dbo].[UserDetails].[UserId] =[dbo].[PasswordDetails].[UserId] " +
                "where [dbo].[UserDetails].[EmailAddress]=@email and " +
                "[dbo].[PasswordDetails].[Password]=@password;";
            if (string.IsNullOrEmpty(data.Password) || string.IsNullOrEmpty(data.Name))
            {
                connection.Close();
                return false;
            }
            var command=new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@email", data.Name);
            command.Parameters.AddWithValue("@password",Encrypt(data.Password));
            int number_of_records=Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            
            if (number_of_records == 0) return false;
            return true;
        }
        
        public static bool ChangePasswordDB(Models.FindUser data)
        { if(connection.State==System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
            connection.Open();
           var query = "update [dbo].[PasswordDetails] set [Password]=@newpassword where [UserId]=" +
                "(select [UserId] from [dbo].[UserDetails] where [EmailAddress]=@email);";
            var command=new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@newpassword", Encrypt(data.New_Password));
            command.Parameters.AddWithValue("@email", data.Email);
            int presence=command.ExecuteNonQuery();
            if (presence == 0) return false;
            return true;
        }

        public static List<Models.AllUsers> GetUsers()
        {
            connection.Open();
            List<Models.AllUsers> allUsers = new List<Models.AllUsers>();
            var query = "select * from [dbo].[UserDetails];";
            var command=new SqlCommand(query,connection);
            var reader=command.ExecuteReader();
            while (reader.Read())
            {
                Models.AllUsers users = new Models.AllUsers();
                users.Id =Convert.ToInt32(reader.GetValue(0));
                users.FirstName = Convert.ToString(reader.GetValue(1));
                users.LastName=Convert.ToString(reader.GetValue(2));
                users.gender=Convert.ToString(reader.GetValue(4));
                users.DateOfBirth=Convert.ToDateTime(reader.GetValue(3));
                users.EmailAdd=Convert.ToString(reader.GetValue(5));

                allUsers.Add(users);
            }
            connection.Close();
            return allUsers;
        }
        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
    }
}
