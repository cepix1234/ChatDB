using System;
using System.Collections.Generic;
using System.Data;
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
            String s = Request.QueryString["field1"];
            Label1.Text = s;
            //dodajanje novega besedila v bazo
            DateTime localTime = DateTime.Now;
            var kultura = new CultureInfo("sl-SI");
            string cas = localTime.ToString(kultura);
            string[] dateTIme = cas.Split();
            dateTIme[0] = dateTIme[0].Remove(dateTIme[0].Length - 1);
            dateTIme[1] = dateTIme[1].Remove(dateTIme[1].Length - 1);
            SqlDataSource1.InsertCommandType = SqlDataSourceCommandType.Text;
            SqlDataSource1.InsertCommand = "INSERT INTO [Pogovor] ([username], [besedilo], [casSporocila]) VALUES (@username, @besedilo, @casSporocila)";
            SqlDataSource1.InsertParameters.Add("username", s);
            SqlDataSource1.InsertParameters.Add("besedilo", Message.Text);
            SqlDataSource1.InsertParameters.Add("casSporocila", dateTIme[2]+"-"+dateTIme[1]+"-"+dateTIme[0]+" "+dateTIme[3]);
            SqlDataSource1.Insert();
            var dv = SqlDataSource1.Select(DataSourceSelectArguments.Empty) as DataView;
            var dt = dv.ToTable();
            Messages.Text = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Messages.Text += dt.Rows[i]["casSporocila"].ToString()+": "+ dt.Rows[i]["username"].ToString() + ": " + dt.Rows[i]["besedilo"].ToString() + "\n";
            }

            var du = SqlDataSource2.Select(DataSourceSelectArguments.Empty) as DataView;
            var dz = du.ToTable();
            int indexUporabnika = 0;
            for (int i = 0; i < dz.Rows.Count; i++)
            {
                if(dz.Rows[i]["username"].ToString().Equals(s))
                {
                    indexUporabnika = i;
                }
            }
            SqlDataSource2.UpdateCommandType = SqlDataSourceCommandType.Text;
            SqlDataSource2.UpdateCommand = "UPDATE [Uporabnik] SET [stSporocil] = @stSporocil WHERE [username] = @username";;
            SqlDataSource2.UpdateParameters.Add("stSporocil", (Convert.ToInt16(dz.Rows[indexUporabnika]["stSporocil"].ToString()) + 1).ToString());
            SqlDataSource2.UpdateParameters.Add("username", s);
            SqlDataSource2.Update();
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