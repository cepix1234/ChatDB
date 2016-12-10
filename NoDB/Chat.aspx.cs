using System;
using System.Collections.Generic;
using System.Data;
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
                Response.Redirect("http://localhost:15052/Login.aspx");
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
                Messages.Text += dt.Rows[i]["username"].ToString() + ": " + dt.Rows[i]["besedilo"].ToString() + "\n" ;
            }
        }

        protected void Send_Click(object sender, EventArgs e)
        {
            String s = Request.QueryString["field1"];
            Label1.Text = s;
            //dodajanje novega besedila v bazo
            SqlDataSource1.InsertCommandType = SqlDataSourceCommandType.Text;
            SqlDataSource1.InsertCommand = "INSERT INTO [Pogovor] ([username], [besedilo]) VALUES (@username, @besedilo)";
            SqlDataSource1.InsertParameters.Add("username", s);
            SqlDataSource1.InsertParameters.Add("besedilo", Message.Text);
            SqlDataSource1.Insert();
            var dv = SqlDataSource1.Select(DataSourceSelectArguments.Empty) as DataView;
            var dt = dv.ToTable();
            Messages.Text = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Messages.Text += dt.Rows[i]["username"].ToString() + ": " + dt.Rows[i]["besedilo"].ToString() + "\n";
            }

            Users.Text = "";
            foreach (String x in pr2)
            {
                Users.Text += x + "\n";
            }
            Message.Text = "";
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
                Messages.Text += dt.Rows[i]["username"].ToString() + ": " + dt.Rows[i]["besedilo"].ToString() + "\n";
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
            Response.Redirect("http://localhost:15052/Login.aspx");
        }
    }
}