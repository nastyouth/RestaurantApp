using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace Final_project
{
    interface IDatabase
    {
        // Открыть подключение
        void OpenConnection();

        // Закрыть подключение
        void CloseConnection();

        // Регистрация
        void Registration(string fullname, string login, string password);

        // Авторизация
        bool Auth(string login, string password);

        // Создать базу данных, если она не была создана
        void CreateDbIfNotExist();

        // Создать таблицу users, если она не была создана
        void CreateUsersTableIfNotExist();

        // Создать таблицу products, если она не была создана
        void CreateProductsTableIfNotExist();

        // Добавить продукт в базу данных
        void InsertProduct(string name, string description, int price);

        // Удалить продукт из базы данных
        void DeleteProduct(int id);

        // Получить все элементы столбца таблицы
        List<string> GetProductsList(int rowNumber = 1);

        // Получить всю информацию о продукте по его названию
        DataTable GetProduct(string productName);

        // Получить все элементы таблицы
        DataTable GetAllProducts();

        // Подключение
        MySqlConnection GetConnection();
    }
}
