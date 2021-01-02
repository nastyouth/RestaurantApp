using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using System;

namespace Final_project
{
    internal class Database: IDatabase
    {
        private readonly MySqlConnection _connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=database");

        public void OpenConnection()
        {
            if(_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public MySqlConnection GetConnection()
        {
            return _connection;
        }
       
        public void CreateDbIfNotExist()
        {
            MySqlCommand command = new MySqlCommand("CREATE DATABASE IF NOT EXISTS `database`", Program.Db.GetConnection());
            this.OpenConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                Console.WriteLine("База данных создана");
            }
            this.CloseConnection();
        }
        
        public void CreateUsersTableIfNotExist()
        {
            MySqlCommand command = new MySqlCommand("CREATE TABLE IF NOT EXISTS `database`.`users` ( `id` INT(11) NOT NULL AUTO_INCREMENT ," +
                                                                                                    " `fullname` VARCHAR(99) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ," +
                                                                                                    " `login` VARCHAR(99) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ," +
                                                                                                    " `password` VARCHAR(99) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ," +
                                                                                                    " UNIQUE (`id`)) ENGINE = InnoDB;;",
                                                                                                    Program.Db.GetConnection());
            this.OpenConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                Console.WriteLine("Таблица users создана");
            }
            this.CloseConnection();
        }

        public void CreateProductsTableIfNotExist()
        {
            MySqlCommand command = new MySqlCommand("CREATE TABLE IF NOT EXISTS `database`.`products` ( `id` INT(11) NOT NULL AUTO_INCREMENT ," +
                                                                                                        " `name` VARCHAR(99) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ," +
                                                                                                        " `description` VARCHAR(200) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ," +
                                                                                                        " `price` INT(11) NOT NULL , UNIQUE (`id`)) ENGINE = InnoDB;",
                                                                                                        Program.Db.GetConnection());
            this.OpenConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                Console.WriteLine("Таблица database создана");
            }
            this.CloseConnection();
        }

            public void Registration(string fullname, string login, string password)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`id`, `fullname`, `login`, `password`) VALUES (NULL, @fullname, @login, @password)", Program.Db.GetConnection());
            command.Parameters.Add("@fullname", MySqlDbType.VarChar).Value = fullname;
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;

            this.OpenConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт был создан");
            }
            else
            {
                MessageBox.Show("Аккаунт не был создан");
            }

            this.CloseConnection();
        }

        public bool Auth(string login, string password)
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL AND `password` = @uP", Program.Db.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Авторизация прошла успешно.");
                return true;
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.");
                return false;
            }
        }

        public List<string> GetProductsList(int rowNumber = 1)
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `products`", Program.Db.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            List<string> list = new List<string>();
            foreach (DataRow row in table.Rows)
            {
                list.Add(row[rowNumber].ToString());
            }
            return list;
        }

        public DataTable GetProduct(string productName)
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `products` WHERE `name` = @productName", Program.Db.GetConnection());
            command.Parameters.Add("@productName", MySqlDbType.VarChar).Value = productName;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        public DataTable GetAllProducts()
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `products`", Program.Db.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        public void InsertProduct(string name, string description, int price)
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("INSERT INTO `products` (`id`, `name`, `description`, `price`) VALUES(NULL, @name, @description, @price)", Program.Db.GetConnection());
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@description", MySqlDbType.VarChar).Value = description;
            command.Parameters.Add("@price", MySqlDbType.VarChar).Value = price;

            adapter.SelectCommand = command;
            adapter.Fill(table);
        }
   
        public void DeleteProduct(int id)
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("DELETE FROM `products` WHERE `products`.`id` = @id", Program.Db.GetConnection());
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;

            adapter.SelectCommand = command;
            adapter.Fill(table);
        }
    }
}