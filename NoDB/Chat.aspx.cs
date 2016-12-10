using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NoDB
{
    public partial class Chat : System.Web.UI.Page
    {
       
        public static List<String> pr2 = new List<string>();
        public static List<String> msg = new List<string>();
        public static String[] naziv = new String[3];
        protected void Page_Load(object sender, EventArgs e)
        {
            //String s = Request.QueryString["field1"];
            String s = "blaz";
            if (s == null)
            {
                Response.BufferOutput = true;
                Response.Redirect("http://localhost:15052/Login.aspx");
            }

            if (!pr2.Contains(naziv[Int32.Parse(s)]))
            {
                pr2.Add(naziv[Int32.Parse(s)]);
            }

            Users.Text = "";
                foreach (String x in pr2)
                {
                    Users.Text += x + "\n";
                }

            Messages.Text = "";
            foreach (String x in msg)
            {
                Messages.Text += x + "\n";
            }


        }

        protected void Send_Click(object sender, EventArgs e)
        {
            String s = Request.QueryString["field1"];
            msg.Add(Message.Text);
            Messages.Text = "";
            foreach (String x in msg)
            {
                Messages.Text += naziv[Int32.Parse(s)] + ": "+  x + "\n";
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
            Messages.Text = "";
            foreach (String x in msg)
            {
                Messages.Text += x + "\n";
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
            pr2.Remove(naziv[Int32.Parse(s)]);
            Response.BufferOutput = true;
            Response.Redirect("http://localhost:15052/Login.aspx");
        }
    }
}