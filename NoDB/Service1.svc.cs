using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;

namespace NoDB
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public Boolean Login(string username, string password)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source = servicechats.database.windows.net; Initial Catalog = ServiceChatBD; Persist Security Info = True; User ID = cepix1234; Password = aWr4GnuLd_1";
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.CommandText = "SELECT * FROM Uporabnik";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;

            conn.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (username.Equals(reader.GetString(reader.GetOrdinal("username"))))
                    {
                        if (MD5Hash(password).Equals(reader.GetString(reader.GetOrdinal("geslo"))))
                        {
                            return true;
                        }
                    }
                }
            }
            reader.Close();
            conn.Close();
            return false;
        }

        public void Send(string username, string password, string message)
        {
            DateTime localTime = DateTime.Now;
            var kultura = new CultureInfo("sl-SI");
            string cas = localTime.ToString(kultura);
            string[] dateTIme = cas.Split();
            string[] datum = dateTIme[0].Split('.');
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source = servicechats.database.windows.net; Initial Catalog = ServiceChatBD; Persist Security Info = True; User ID = cepix1234; Password = aWr4GnuLd_1";
            int stSporocilUporabnika = 0;
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.CommandText = "SELECT * FROM Uporabnik";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;
            conn.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (username.Equals(reader.GetString(reader.GetOrdinal("username"))))
                    {
                        if (MD5Hash(password).Equals(reader.GetString(reader.GetOrdinal("geslo"))))
                        {
                            stSporocilUporabnika = reader.GetInt32(reader.GetOrdinal("stSporocil"));
                        }
                    }
                }
            }
            reader.Close();
            conn.Close();

            SqlCommand cmdI = new SqlCommand();
            cmdI.CommandText = "INSERT INTO Pogovor (username, besedilo, casSporocila) VALUES (@username, @besedilo, @casSporocila)";
            cmdI.Parameters.AddWithValue("username", username);
            cmdI.Parameters.AddWithValue("besedilo", message);
            cmdI.Parameters.AddWithValue("casSporocila", datum[2] + "-" + datum[1] + "-" + datum[0] + " " + dateTIme[1]);
            cmdI.Connection = conn;
            SqlCommand cmdU = new SqlCommand();
            cmdU.CommandText = "UPDATE Uporabnik SET stSporocil= @stSporocil WHERE username = @username";
            cmdU.Parameters.AddWithValue("stSporocil", (stSporocilUporabnika + 1).ToString());
            cmdU.Parameters.AddWithValue("username", username);
            cmdU.Connection = conn;
            conn.Open();
            if (Login(username, password))
            {
                cmdI.ExecuteNonQuery();
                cmdU.ExecuteNonQuery();
            }
            conn.Close();
        }

        public string[] Messages(string username, string password)
        {
            List<string> sporocila = new List<string>();
            SqlDataReader reader;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source = servicechats.database.windows.net; Initial Catalog = ServiceChatBD; Persist Security Info = True; User ID = cepix1234; Password = aWr4GnuLd_1";
            SqlCommand cmdI = new SqlCommand();
            cmdI.CommandText = "SELECT * FROM Pogovor";
            cmdI.CommandType = System.Data.CommandType.Text;
            cmdI.Connection = conn;
            conn.Open();
            if (Login(username, password))
            {
                reader = cmdI.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (username.Equals(reader.GetString(reader.GetOrdinal("username"))))
                        {
                            sporocila.Add(reader.GetDateTime(reader.GetOrdinal("casSporocila")).ToString()+": " +reader.GetString(reader.GetOrdinal("besedilo")));
                        }
                    }
                }
            }
            conn.Close();

            return sporocila.ToArray();
        }

        public string[] Messagesid(string username, string password, string id)
        {
            List<string> sporocila = new List<string>();
            SqlDataReader reader;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source = servicechats.database.windows.net; Initial Catalog = ServiceChatBD; Persist Security Info = True; User ID = cepix1234; Password = aWr4GnuLd_1";
            SqlCommand cmdI = new SqlCommand();
            cmdI.CommandText = "SELECT * FROM Pogovor";
            cmdI.CommandType = System.Data.CommandType.Text;
            cmdI.Connection = conn;
            conn.Open();
            if (Login(username, password))
            {
                reader = cmdI.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (username.Equals(reader.GetString(reader.GetOrdinal("username"))))
                        {
                            if(reader.GetInt32(reader.GetOrdinal("Id")) > Convert.ToInt32(id))
                            {
                                sporocila.Add(reader.GetDateTime(reader.GetOrdinal("casSporocila")).ToString() + ": " + reader.GetString(reader.GetOrdinal("besedilo")));
                            }
                        }
                    }
                }
            }
            conn.Close();

            return sporocila.ToArray();
        }


        public string MD5Hash(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);


            System.Text.StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)

            {

                sb.Append(hash[i].ToString("X2"));

            }

            return sb.ToString();

        }
    }
}
