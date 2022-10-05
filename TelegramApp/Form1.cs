using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;

namespace TelegramApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            //Регистрация
            var user = new Users(textboxchatid.Text, textBoxlogin.Text, textBoxpassword.Text);
            var json= JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "http://localhost:5091/api/main/reg";
            var client = new HttpClient();
            var response = await client.PostAsync(url, data);
            var result = await response.Content.ReadAsStringAsync();
            string tokens;
            if (result == "Аккаунт был создан")
            {
                tokens = await Gettokens(textBoxlogin.Text, textBoxpassword.Text);
                string[] vs = tokens.Split(';');
                Form2 f2 = new Form2(result, vs[0], vs[1]);
                f2.Show();
            }
            else MessageBox.Show(result);


        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //Вход
            var user = new Users("0",textBoxlogin.Text, textBoxpassword.Text);
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "http://localhost:5091/api/main/log";
            var client = new HttpClient();
            var response = await client.PostAsync(url, data);
            var result = await response.Content.ReadAsStringAsync();
            string tokens;
            if (result != "Неверный логин/пароль")
            {
                tokens = await Gettokens(textBoxlogin.Text, textBoxpassword.Text);
                string[] vs = tokens.Split(';');
                Form2 f2 = new Form2(result,vs[0],vs[1]);
                f2.Show();
            }
            else MessageBox.Show(result);

        }
        private async Task<string> Gettokens(string username, string password)
        {
            var user = new Users("0", username,password);
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "http://localhost:5091/api/main/tokens";
            var client = new HttpClient();
            var response = await client.PostAsync(url, data);
            return await response.Content.ReadAsStringAsync();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Чатайди

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //Логин
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //Пароль
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

       
    }
}
