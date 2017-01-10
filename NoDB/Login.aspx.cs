using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
            
            String up_ime="";
            String pass="";
            var dv = SqlDataSource1.Select(DataSourceSelectArguments.Empty) as DataView;
            var dt = dv.ToTable();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //dt.Rows pridobim vse vrstice iz tabele [0] je prva vrstica [username] je kateri stolpec
                up_ime = dt.Rows[i]["username"].ToString();
                if(up_ime == Username.Text)
                {
                    up_ime = dt.Rows[i]["username"].ToString();
                    pass = dt.Rows[i]["geslo"].ToString();
                    Username.Text = pass;
                    break;
                }
            }


            if(pass == Password.Text)
            {
                Response.BufferOutput = true;
                //Za govor naprej poslji username ker je to glavni kljuc
                Response.Redirect("http://localhost:15052/Chat.aspx?field1=" + up_ime);
            }else
            {
                Label2.Text = "Geslo ali uporabniško ime ni pravilno!";
            }
           
        }
        int numm(String x)
        {
            int num = 0;
            foreach(char cd in x)
            {
                if (char.IsDigit(cd))
                {
                    num++;
                }
            }

            return num;
        }

        int vlka(String x)
        {
            int num = 0;
            foreach (char cd in x)
            {
                if (char.IsUpper(cd))
                {
                    num++;
                }
            }
            return num;
        }

        int znaki(String x)
        {
            int num = 0;
            foreach (char cd in x)
            {
                if (cd == '!' || cd == '.' || cd == '*' || cd == ':')
                {
                    num++;
                }
            }
            return num;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            const int MIN_LEN = 8;

            if(g1.Text.Length>8 && numm(g1.Text) >= 2 && vlka(g1.Text) >= 2 && znaki(g1.Text) >=1)
            {

            }

            String[] s = Ime.Text.Split();

            SqlDataSource1.InsertCommandType = SqlDataSourceCommandType.Text;
            SqlDataSource1.InsertCommand = "INSERT INTO [Uporabnik] ([username], [ime], [priimek], [geslo], [stSporocil]) VALUES (@username, @ime, @priimek, @geslo, @stSporocil)";
            SqlDataSource1.InsertParameters.Add("username", up_ime.Text);
            SqlDataSource1.InsertParameters.Add("ime", s[0]);
            SqlDataSource1.InsertParameters.Add("priimek", s[1]);
            SqlDataSource1.InsertParameters.Add("stSporocil", "0");
            if (g1.Text.Length > 8 && numm(g1.Text) >= 2 && vlka(g1.Text) >= 2 && znaki(g1.Text) >= 1)
            {
                if (g1.Text != g2.Text)
                {
                    Label1.Text = "Gesli se ne ujemata!";
                }
                else
                {
                    string gesloHashed = MD5Hash(g2.Text);
                    SqlDataSource1.InsertParameters.Add("geslo", gesloHashed);
                    SqlDataSource1.Insert();
                    Label1.Text = "Vaš uporabniški račun je bil uspešno ustvarjen!";
                    Ime.Text = "";
                    up_ime.Text = "";
                    g1.Text = "";
                    g2.Text = "";
                }
            }
            else
            {
                Label1.Text = "Geslo ni pravilno napisano.";
            }
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