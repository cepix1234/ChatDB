using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NoDB
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            int st=-1;

            String[] up_ime = new String[3];
            up_ime[0] = "63130246";
            up_ime[1] = "murkod";
            up_ime[2] = "admin";

            String[] pass = new String[3];
            pass[0] = "Geslo.Student";
            pass[1] = "Geslo.Progrmer";
            pass[2] = "Geslo.Admin";

            for (int i = 0; i < 3; i++){
                if (up_ime[i] == Username.Text ){
                st=i;
              }
            }

            if(pass[st] == Password.Text)
            {
                Response.BufferOutput = true;
                Response.Redirect("http://localhost:15052/Chat.aspx?field1=" + st);
            }

        }
    }
}