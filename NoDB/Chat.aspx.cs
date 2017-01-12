using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NoDB
{
    public partial class Chat : System.Web.UI.Page
    {
        public static List<String> pr2 = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            String s = Request.QueryString["field1"];
            Label1.Text = s;
            //pridobim tabelo iz baze
            var dv = SqlDataSource1.Select(DataSourceSelectArguments.Empty) as DataView;
            var dt = dv.ToTable();
            if (s == null)
            {
                Response.BufferOutput = true;
                Response.Redirect("http://servicechatbt.azurewebsites.net/Login.aspx");
            }

            if (!pr2.Contains(s))
            {
                pr2.Add(s);
            }

            Users.Text = "";
            foreach (String x in pr2)
            {
                Users.Text += x + "\n";
            }

            Messages.Text = "";
            for(int i = 0; i< dt.Rows.Count;i++)
            {
                //dt.Rows pridobim vse vrstice iz tabele [0] je prva vrstica [username] je kateri stolpec
                Messages.Text += dt.Rows[i]["casSporocila"].ToString() + ": " +  dt.Rows[i]["username"].ToString() + ": " + dt.Rows[i]["besedilo"].ToString() + "\n" ;
            }
        }

        protected void Send_Click(object sender, EventArgs e)
        {
            if (Message.Text.Trim().Length > 0 )
            { 
                String s = Request.QueryString["field1"];
                Label1.Text = s;
                //dodajanje novega besedila v bazo

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
                        if (s.Equals(reader.GetString(reader.GetOrdinal("username"))))
                        {
                            stSporocilUporabnika = reader.GetInt32(reader.GetOrdinal("stSporocil"));
                        }
                    }
                }
                reader.Close();
                conn.Close();

                SqlCommand cmdI = new SqlCommand();
                cmdI.CommandText = "INSERT INTO Pogovor (username, besedilo, casSporocila) VALUES (@username, @besedilo, @casSporocila)";
                cmdI.Parameters.AddWithValue("username", s);
                cmdI.Parameters.AddWithValue("besedilo", Message.Text);
                cmdI.Parameters.AddWithValue("casSporocila", datum[2] + "-" + datum[1] + "-" + datum[0] + " " + dateTIme[1]);
                cmdI.Connection = conn;
                SqlCommand cmdU = new SqlCommand();
                cmdU.CommandText = "UPDATE Uporabnik SET stSporocil= @stSporocil WHERE username = @username";
                cmdU.Parameters.AddWithValue("stSporocil", (stSporocilUporabnika + 1).ToString());
                cmdU.Parameters.AddWithValue("username", s);
                cmdU.Connection = conn;
                conn.Open();
                cmdI.ExecuteNonQuery();
                cmdU.ExecuteNonQuery();
                conn.Close();
                
                var dv = SqlDataSource1.Select(DataSourceSelectArguments.Empty) as DataView;
                var dt = dv.ToTable();
                Messages.Text = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Messages.Text += dt.Rows[i]["casSporocila"].ToString() + ": " + dt.Rows[i]["username"].ToString() + ": " + dt.Rows[i]["besedilo"].ToString() + "\n";
                }

               
                Users.Text = "";
                foreach (String x in pr2)
                {
                    Users.Text += x + "\n";
                }
                Message.Text = "";
            }            
        }

        protected void Refresh_Click(object sender, EventArgs e)
        {
            String s = Request.QueryString["field1"];
            Label1.Text = s;
            var dv = SqlDataSource1.Select(DataSourceSelectArguments.Empty) as DataView;
            var dt = dv.ToTable();
            Messages.Text = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Messages.Text += dt.Rows[i]["casSporocila"].ToString() + ": " +  dt.Rows[i]["username"].ToString() + ": " + dt.Rows[i]["besedilo"].ToString() + "\n";
            }

            Users.Text = "";
            foreach (String x in pr2)
            {
                Users.Text += x + "\n";
            }
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            String s = Request.QueryString["field1"];
            pr2.Remove(s);
            Response.BufferOutput = true;
            Response.Redirect("http://servicechatbt.azurewebsites.net/Login.aspx");
        }
    }
}