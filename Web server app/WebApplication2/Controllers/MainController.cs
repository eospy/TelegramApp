using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        // POST api/<ValuesController>
        [HttpPost("Reg")]
        public ContentResult Reg(Users usr)
        {
            if ((usr.Chatid.Contains(","))|| (usr.Login.Contains(","))||(usr.Password.Contains(",")))
            {
                return Content("Нельзя использовать запятые");
            }
            Database db = new Database();
            SqlCommand command = new SqlCommand($"INSERT INTO [Users] (Login, Password, Chatid) VALUES (@Login, @Password, @Chatid)", db.GetConnection());
            command.Parameters.AddWithValue("Login", usr.Login);
            command.Parameters.AddWithValue("Password", usr.Password);
            command.Parameters.AddWithValue("Chatid", usr.Chatid);
            //проверка при регистрации
            SqlCommand check = new SqlCommand($"SELECT * FROM [Users] WHERE Login=@Login OR Password=@Password OR Chatid=@Chatid", db.GetConnection());
            check.Parameters.AddWithValue("Login", usr.Login);
            check.Parameters.AddWithValue("Password", usr.Password);
            check.Parameters.AddWithValue("Chatid", usr.Chatid);
            db.openConnection();
            if (check.ExecuteReader().HasRows)
            { 
                return Content("Такой аккаунт уже существует");
            }
            db.closeConnection();
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return Content("Аккаунт был создан");
            }
            else
            {
                db.closeConnection();
                return Content("Аккаунт не был создан");
            }
            

        }
        [HttpPost("Log")]
        public ContentResult Log(Users usr)
        {
            bool success = false;
            string chatid = "";
            Database db = new Database();
            SqlCommand command = new SqlCommand($"SELECT Chatid FROM [Users] WHERE  Login=@Login AND Password=@Password", db.GetConnection());
            command.Parameters.AddWithValue("Login", usr.Login);
            command.Parameters.AddWithValue("Password", usr.Password);
            db.openConnection();
            using (var dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    chatid = dataReader[0].ToString();
                }
                success = dataReader.HasRows;
            }

            if (success)
            {
                db.closeConnection();
                return Content(chatid);
            }
            else
            {
                db.closeConnection();
                return Content("Неверный логин/пароль");
            }

        }
        [HttpPost("Tokens")]
        public ContentResult Tokens(Users usr)
        {
            Random rnd = new Random();
            int rnd1 = rnd.Next(100,999);
            int rnd2 = rnd.Next(100,999);
            string a = "access";
            string r = "refresh";
            string accesstoken = "acc," + usr.Login + usr.Password+","+rnd1;
            string refreshtoken = "ref," + usr.Login + usr.Password+","+rnd2;
            Database db = new Database();
            SqlCommand command = new SqlCommand($"INSERT INTO [Tokens] (Tokenstring,dateTime,Type) VALUES (@Tokenstring,@Datetime,@Type)", db.GetConnection());
            command.Parameters.AddWithValue("Tokenstring", accesstoken);
            command.Parameters.AddWithValue("Datetime", DateTime.Now);
            command.Parameters.AddWithValue("Type", a);
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
            }

            SqlCommand command2 = new SqlCommand($"INSERT INTO [Tokens] (Tokenstring,dateTime,Type) VALUES (@Tokenstring,@Datetime,@Type)", db.GetConnection());
            command2.Parameters.AddWithValue("Tokenstring", refreshtoken);
            command2.Parameters.AddWithValue("Datetime", DateTime.Now);
            command2.Parameters.AddWithValue("Type", r);
            db.openConnection();
            if (command2.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
            }

            return Content(accesstoken+";"+refreshtoken);
        }
        [HttpPost("Check")]
        public ContentResult Check(string token)
        {
            DateTime tokendate = new DateTime();
            string type = "";
            Database db = new Database();
            SqlCommand command = new SqlCommand($"SELECT Datetime FROM [Tokens] WHERE Tokenstring=@Tokenstring", db.GetConnection());
            command.Parameters.AddWithValue("Tokenstring", token);
            db.openConnection();
            using (var dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tokendate =DateTime.Parse(dataReader[0].ToString());
                }
               db.closeConnection();
            }
            SqlCommand command2 = new SqlCommand($"SELECT Type FROM [Tokens] WHERE Tokenstring=@Tokenstring", db.GetConnection());
            command2.Parameters.AddWithValue("Tokenstring", token);
            db.openConnection();
            using (var dataReader = command2.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    type=dataReader[0].ToString();
                }
                db.closeConnection();
            }
            if (type =="")
            {
                return Content("Токен не существует");
            }

            if((type.Contains("access"))&((DateTime.Now - tokendate).Minutes > 5))
            {
                return Content("Токен недействителен");
            }
            else if ((type.Contains("refresh")) & ((DateTime.Now - tokendate).Minutes > 60))
            {
                return Content("Токен недействителен");
            }
            else return Content("Действительный токен");

        }
        [HttpPost("Update")]
        public ContentResult Update(string token)
        {
            string acctoken = "";
            string reftoken = "";
            string a = "access";
            string r = "refresh";
            Random rnd = new Random();
            int rnd1 = rnd.Next(100, 999);
            int rnd2 = rnd.Next(100, 999);
            DateTime tokendate = new DateTime();
            string type = "";
            Database db = new Database();
            SqlCommand command = new SqlCommand($"SELECT Datetime FROM [Tokens] WHERE Tokenstring=@Tokenstring", db.GetConnection());
            command.Parameters.AddWithValue("Tokenstring", token);
            db.openConnection();
            using (var dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tokendate = DateTime.Parse(dataReader[0].ToString());
                }
                db.closeConnection();
            }
            SqlCommand command2 = new SqlCommand($"SELECT Type FROM [Tokens] WHERE Tokenstring=@Tokenstring", db.GetConnection());
            command2.Parameters.AddWithValue("Tokenstring", token);
            db.openConnection();
            using (var dataReader = command2.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    type = dataReader[0].ToString();
                }
                db.closeConnection();
            }
            if ((type.Contains("refresh")) & ((DateTime.Now - tokendate).Minutes > 60))
            {
                return Content("Токен недействителен");
            }
            else if (!type.Contains("refresh"))
            {
                return Content("Токен не подходит");
            }
            else
            {
                string[] vs = token.Split(',');
                acctoken = "acc," +vs[1] + "," + rnd1;
                reftoken = "ref," + vs[1] + "," + rnd2;
                SqlCommand command3 = new SqlCommand($"INSERT INTO [Tokens] (Tokenstring,dateTime,Type) VALUES (@Tokenstring,@Datetime,@Type)", db.GetConnection());
                command3.Parameters.AddWithValue("Tokenstring", acctoken);
                command3.Parameters.AddWithValue("Datetime", DateTime.Now);
                command3.Parameters.AddWithValue("Type", a);
                db.openConnection();
                if (command3.ExecuteNonQuery() == 1)
                {
                    db.closeConnection();
                }
                SqlCommand command4 = new SqlCommand($"INSERT INTO [Tokens] (Tokenstring,dateTime,Type) VALUES (@Tokenstring,@Datetime,@Type)", db.GetConnection());
                command4.Parameters.AddWithValue("Tokenstring", reftoken);
                command4.Parameters.AddWithValue("Datetime", DateTime.Now);
                command4.Parameters.AddWithValue("Type", r);
                db.openConnection();
                if (command4.ExecuteNonQuery() == 1)
                {
                    db.closeConnection();
                }
                return Content(acctoken + ";" + reftoken);
            }

        }
    }

    internal class Database
    {
        SqlConnection sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Эмиль\\userstore2.mdf;Integrated Security=True;Connect Timeout=30");
        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
                sqlConnection.Open();
        }

        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
                sqlConnection.Close();
        }

        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }
    }
}
