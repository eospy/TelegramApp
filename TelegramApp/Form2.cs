using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Collections.Specialized;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using System.IO;
using System.Net.Http;
namespace TelegramApp
{
    public partial class Form2 : Form
    {
        TelegramBotClient botClient = new TelegramBotClient("2081068774:AAGxkq57ZRl9oCD_I0OIa1eacrP0MOf3WQw");
        string Textstring = "";
        int key;
        string anotherchatid;
        public Form2(string chatid,string accesstoken,string refreshtoken)
        {
            InitializeComponent();
            anotherchatid= chatid;
            youracctoken.Text = accesstoken;
            yourreftoken.Text = refreshtoken;

        }
        private void botClient_OnMessage(object sender, MessageEventArgs e)
        {
            var id = e.Message.From.Id;
            var text = e.Message.Text.ToString();

            if (text == "1398095331")
                botClient.SendTextMessageAsync(id, id.ToString());
            else
                botClient.SendTextMessageAsync(id, text);
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Textstring = textBoxmessage.Text;
            bool success = false;
            //кнопка отправить(отправляет код из телеги на сервер
            if (textBoxmessage.Text == key.ToString())
            {
                success = true;
            }
            if (success)
            {
                MessageBox.Show("Успех");
            }
            else MessageBox.Show("Неверный код авторизации");
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            //get token

             


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //для токена
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            //sendtoken
            var data = new StringContent("");
            var url = ("http://localhost:5091/api/main/check?token="+ textBoxtoken.Text);
            var client = new HttpClient();
            var response = await client.PostAsync(url, data);
            var result=await response.Content.ReadAsStringAsync();
            if (result== "Действительный токен")
            {
                botClient.OnMessage += botClient_OnMessage;
                botClient.StartReceiving();
                string apiToken = "2081068774:AAGxkq57ZRl9oCD_I0OIa1eacrP0MOf3WQw";
                Random rnd = new Random();
                key = rnd.Next();
                HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create("https://api.telegram.org/bot" + apiToken + "/sendMessage?chat_id=" + anotherchatid + "&text=" + key);
                HttpWebResponse response1 = (HttpWebResponse)request1.GetResponse();
                response1.Close();
            }

                 
                            
                    
            
            
            //если все хорошо отправить сообщение
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            //refresh button
            var data = new StringContent("");
            Uri uri = new Uri("http://localhost:5091/api/main/update?token="+ yourreftoken.Text);
            var client = new HttpClient();
            var response = await client.PostAsync(uri, data);
            var result = await response.Content.ReadAsStringAsync();
            string res = result;
            string[] vs = result.Split(';');
            youracctoken.Text = vs[0];
            yourreftoken.Text = vs[1];

        }

        private void youracctoken_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void yourreftoken_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
