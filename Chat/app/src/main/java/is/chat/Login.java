package is.chat;

import android.content.Intent;
import android.os.StrictMode;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import org.w3c.dom.Text;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;

public class Login extends AppCompatActivity {
    Button button_login;
    EditText editText_up, editText_pw;
    String name;
    String pw;
    TextView tw;
    boolean login = false;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();

        StrictMode.setThreadPolicy(policy);

        button_login = (Button)findViewById(R.id.button_login);
        editText_up = (EditText) findViewById(R.id.editText_up);
        editText_pw = (EditText)findViewById(R.id.editText_pw);
        tw = (TextView) findViewById(R.id.textView4);
        login();
    }

    public  void login() {
        button_login.setOnClickListener(
                new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        name = editText_up.getText().toString();
                        pw = editText_pw.getText().toString();
                        getText(name, pw);
                        if(login){// POŠLE TJA KO MORE POL PA ČE DOBI TRUE POŠLE UP_IME NAPREJ
                            Intent i = new Intent(Login.this, Chat.class);
                            i.putExtra("name", name);
                            i.putExtra("pw", pw);
                            startActivity(i);
                        }else{
                            tw.setText("Uporabniško ime in/ali geslo ni pravilno.");
                        }
                    }
                });
    }

    void getText(String name, String pw){
        try {

            URL url = new URL("http://servicechatbt.azurewebsites.net/Service1.svc/Login/"+ name + "/"+pw);
            HttpURLConnection conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("GET");
            conn.setRequestProperty("Accept", "application/json");

            if (conn.getResponseCode() != 200) {
                throw new RuntimeException("Failed : HTTP error code : "
                        + conn.getResponseCode());
            }

            BufferedReader br = new BufferedReader(new InputStreamReader(
                    (conn.getInputStream())));

            String output;
            System.out.println("Output from Server .... \n");
            //while ((output = br.readLine()) != null) {
            output = br.readLine();
                login = Boolean.valueOf(output);
            //}

            conn.disconnect();

        } catch (MalformedURLException e) {

            e.printStackTrace();

        } catch (IOException e) {

            e.printStackTrace();

        }
    }
}
