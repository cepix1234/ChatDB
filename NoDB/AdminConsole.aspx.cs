using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NoDB
{
    public partial class AdminConsole : System.Web.UI.Page
    {
             
        protected void Page_Load(object sender, EventArgs e)
        {
            
            String s = Request.QueryString["field1"];
            NaslovnicaL.Text = "Prijavljeni ste kot: " + s;
            if (s == null)
            {
                Response.BufferOutput = true;
                Response.Redirect("http://servicechatbt.azurewebsites.net/Login.aspx");
            }

            refreshGW();
            dissableAll();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            izbira();
        }

        public void izbira()
        {
            Session["trenutnoIzbraniUporabnik"] = GridView1.SelectedRow.Cells[1].Text;
            IzbraniUporabnikL.Text = "Trenutno izbrani uporabnik : " + Session["trenutnoIzbraniUporabnik"];

            SqlDataReader reader;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=servicechats.database.windows.net;Initial Catalog=ServiceChatBD;User ID=cepix1234;Password=aWr4GnuLd_1";
            SqlCommand cmdI = new SqlCommand();
            cmdI.CommandText = "SELECT * FROM Uporabnik";
            cmdI.CommandType = System.Data.CommandType.Text;
            cmdI.Connection = conn;
            conn.Open();
            reader = cmdI.ExecuteReader();
            Boolean jeAdmin = false;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (Session["trenutnoIzbraniUporabnik"].Equals(reader.GetString(reader.GetOrdinal("username"))))
                    {
                        jeAdmin = reader.GetBoolean(reader.GetOrdinal("admin"));
                    }
                }
            }
            conn.Close();

            if (jeAdmin)
            {
                SpremeniVAdminB.Enabled = !jeAdmin;
                SpremenivNavadniB.Enabled = jeAdmin;
            }
            else
            {
                SpremeniVAdminB.Enabled = !jeAdmin;
                SpremenivNavadniB.Enabled = jeAdmin;
            }
            IzbrisUporabnikaB.Enabled = true;
        }

        public void refreshGW()
        {
            SQLDSPridobitevUNameInStSporocil.DataBind();
            GridView1.DataBind();
        }

        public void dissableAll()
        {
            IzbrisUporabnikaB.Enabled = false;
            SpremeniVAdminB.Enabled = false;
            SpremenivNavadniB.Enabled = false;
            IzbraniUporabnikL.Text = "Trenutno izbrani uporabnik : ";
        }

        protected void IzbrisUporabnikaB_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=servicechats.database.windows.net;Initial Catalog=ServiceChatBD;User ID=cepix1234;Password=aWr4GnuLd_1";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM Pogovor WHERE username = @username";
            cmd.Parameters.AddWithValue("username", Session["trenutnoIzbraniUporabnik"]);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;
            SqlCommand cmdU = new SqlCommand();
            cmdU.CommandText = "DELETE FROM Uporabnik WHERE username = @username";
            cmdU.Parameters.AddWithValue("username", Session["trenutnoIzbraniUporabnik"]);
            cmdU.CommandType = System.Data.CommandType.Text;
            cmdU.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            cmdU.ExecuteNonQuery();
            conn.Close();
            refreshGW();
            dissableAll();
        }

        protected void SpremeniVAdminB_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=servicechats.database.windows.net;Initial Catalog=ServiceChatBD;User ID=cepix1234;Password=aWr4GnuLd_1";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE Uporabnik SET admin = @admin WHERE username=@username";
            cmd.Parameters.AddWithValue("username", Session["trenutnoIzbraniUporabnik"]);
            cmd.Parameters.AddWithValue("admin", "1");
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            izbira();
            refreshGW();
            dissableAll();
        }

        protected void SpremenivNavadniB_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=servicechats.database.windows.net;Initial Catalog=ServiceChatBD;User ID=cepix1234;Password=aWr4GnuLd_1";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE Uporabnik SET admin = @admin WHERE username = @username";
            cmd.Parameters.AddWithValue("username", Session["trenutnoIzbraniUporabnik"]);
            cmd.Parameters.AddWithValue("admin", "0");
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            izbira();
            refreshGW();
            dissableAll();
        }

        protected void OdjavaB_Click(object sender, EventArgs e)
        {
            Response.BufferOutput = true;
            Response.Redirect("http://servicechatbt.azurewebsites.net/Login.aspx");
        }
    }
}