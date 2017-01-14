package is.chat;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.text.method.ScrollingMovementMethod;
import android.view.View;
import android.webkit.WebView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import java.io.BufferedReader;
import java.io.File;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.ArrayList;

public class Chat extends AppCompatActivity {
    String up_ime, pw, message;
    EditText editText_txt;
    Button button_send, button_refresh;
    TextView tv;
    int st=0;
    WebView wv;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_chat);

        wv = (WebView)findViewById(R.id.wv);
        wv.setVisibility(View.GONE);

        button_send = (Button)findViewById(R.id.button_send);
        button_refresh = (Button)findViewById(R.id.button_ref);
        editText_txt = (EditText) findViewById(R.id.editText_txt);
        tv = (TextView) findViewById(R.id.tv);
        tv.setMovementMethod(new ScrollingMovementMethod());

        Intent intent = getIntent();
        up_ime = intent.getExtras().getString("name");// TUKI DOBIM IZ PRVE STRANI
        pw = intent.getExtras().getString("pw");// TUKI DOBIM IZ PRVE STRANI

        String[] msg = getText(up_ime, pw);
        msg = uredi_text(msg);
        izpisi(msg);
        System.out.println(st);

        refresh();
        send();

        //textView4 = (TextView) findViewById(R.id.textView4);
        //textView4.setText(up_ime);
    }

    void izpisi(String[] msg){
        String temp="";
        for(int i=0;i<msg.length;i++){
            temp += msg[i] + "\n";
            st++;
        }
        tv.setText(temp);
    }

    String[] uredi_text(String[] msg){
        for(int i=0;i<msg.length;i++){
            msg[i]=msg[i].replace("\\", File.separator);
            msg[i]=msg[i].replaceAll("//", "/");
            msg[i]=msg[i].replaceAll("\"]", "");
            msg[i]=msg[i].replaceAll("\\[\"", "");
        }
        return msg;
    }

    public  void refresh() {
        button_refresh.setOnClickListener(
                new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        String[] msg = getText(up_ime, pw);
                        if(msg.length > 0 && !msg[0].equals("[]")){
                            msg=uredi_text(msg);
                            for(int i=0;i<msg.length;i++){
                                tv.append(msg[i]);
                                st++;
                            }
                        }else{
                            Toast.makeText(Chat.this, "Vsa sporočila so že izpisana.", Toast.LENGTH_LONG).show();
                        }
                    }
                }
        );
    }

    public  void send() {
        button_send.setOnClickListener(
                new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        message = editText_txt.getText().toString();
                        message = message + "\n";
                        if(!message.equals("")){
                            sendText(up_ime, pw, message);
                            editText_txt.setText("");
                        }else{
                            Toast.makeText(Chat.this, "Prosim  vnesite vsebino sporočila, ki ga žeite poslati.", Toast.LENGTH_LONG).show();
                        }

                    }
                }
        );
    }


    String[] getText(String name, String pw){
        try {

            URL url = new URL("http://servicechatbt.azurewebsites.net/Service1.svc/Messages/"+name+"/"+pw+"/"+st);
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
            output = br.readLine();
            System.out.println(output);
            //while ((output = br.readLine()) != null) {
            String[] msg = output.split("\",\"");
            //}
            conn.disconnect();
            return msg;

        } catch (MalformedURLException e) {

            e.printStackTrace();
            return null;

        } catch (IOException e) {

            e.printStackTrace();
            return null;

        }
    }

    void sendText(String name, String pw, String message){
        wv.loadUrl("http://servicechatbt.azurewebsites.net/Service1.svc/Send/"+name+"/"+pw+"/"+message);
        Toast.makeText(Chat.this, "Sporočilo ste ste uspešno poslali.", Toast.LENGTH_LONG).show();
    }


}
