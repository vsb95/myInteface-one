using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserService
{
    /// <summary>
    ///  Представляет собой службу для манипулирования таблицами на сервере посредством SQL-запросов
    /// </summary>
    public class UserService
    {
        private SqlConnection _connection;
        public List<Table> Tables { get; private set; }

        /// <summary>
        /// Устанавливает соединение с БД с исползованием логина и пароля
        /// </summary>
        /// <param name="database">Имя базы данных</param>
        /// <param name="username">Имя пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        public UserService(string database, string username, string password)
        {
            Tables = new List<Table>();
            var tableNames = new List<string>();
            string connectionString = $"Server=localhost; Database={database}; User Id={username}; password={password}";
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            const string query = "SELECT * FROM INFORMATION_SCHEMA.TABLES";
            var command = new SqlCommand(query, _connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
                tableNames.Add(reader["TABLE_NAME"].ToString());
            reader.Close();
            tableNames.Remove(tableNames.FirstOrDefault(t => t == "sysdiagrams"));
            foreach (var tableName in tableNames)
                Tables.Add(new Table(tableName, _connection));
        }

        /// <summary>
        /// Принимает на вход connectionString в свободном виде
        /// </summary>
        /// <param name="connectionString"></param>
        public UserService(string connectionString)
        {
            Tables = new List<Table>();
            var tableNames = new List<string>();
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            const string query = "SELECT * FROM INFORMATION_SCHEMA.TABLES";
            var command = new SqlCommand(query, _connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
                tableNames.Add(reader["TABLE_NAME"].ToString());
            reader.Close();
            tableNames.Remove(tableNames.FirstOrDefault(t => t == "sysdiagrams"));
            foreach (var tableName in tableNames)
                Tables.Add(new Table(tableName, _connection));
        }

        /// <summary>
        /// Возвращает коллекцию всех записей указанной таблицы
        /// </summary>
        /// <param name="tablename">Название таблицы</param>
        /// <returns></returns>
        public ArrayList SelectFromTable(string tablename)
        {
            var list = new ArrayList();
            var command = new SqlCommand($"select * from [{tablename}]", _connection);
            var reader = command.ExecuteReader();
            foreach (var record in reader)
                list.Add(record);
            reader.Close();
            return list;
        }

        /// <summary>
        /// Возвращает коллекцию из одного элемента - записи указанной таблицы, соответствующей указанному ID
        /// </summary>
        /// <param name="tablename">Название таблицы</param>
        /// <param name="id">ID требуемой записи</param>
        /// <returns></returns>
        public ArrayList SelectFromTable(string tablename, int id)
        {
            var list = new ArrayList();
            var command = new SqlCommand($"select * from [{tablename}] where id = {id}", _connection);
            var reader = command.ExecuteReader();
            foreach (var record in reader)
                list.Add(record);
            reader.Close();
            return list;
        }

        /// <summary>
        /// Записывает последовательность значений в указанную таблицу
        /// </summary>
        /// <param name="tablename">Название таблицы</param>
        /// <param name="values">Коллекция значений</param>
        public void InsertQuery(ArrayList values, string tablename)
        {
            var firstOrDefault = Tables.FirstOrDefault(t => t.Name == tablename);
            firstOrDefault?.InsertQuery(values);
        }
        /// <summary>
        /// Изменяет запись указанной таблицы, соответствующую указанному ID
        /// </summary>
        /// <param name="values">Коллекция значений</param>
        /// <param name="tablename">Название таблицы</param>
        /// <param name="id">ID записи</param>
        public void UpdateQuery(ArrayList values, string tablename, int id)
        {
            var firstOrDefault = Tables.FirstOrDefault(t => t.Name == tablename);
            firstOrDefault?.UpdateQuery(id, values);
        }

        /// <summary>
        /// Возвращает строку, содержащую название роли текущего пользователя
        /// </summary>
        /// <returns></returns>
        public string GetCurrentRole()
        {
            var command = new SqlCommand("declare @user sysname set @user = user exec sp_helpuser @user", _connection);
            var reader = command.ExecuteReader();
            reader.Read();
            var role = reader["RoleName"].ToString();
            reader.Close();
            return role;
        }

        public void DeleteFromTable(string tablename, int id)
        {
            var firstOrDefault = Tables.FirstOrDefault(t => t.Name == tablename);
            firstOrDefault?.DeleteQuery(id);
        }
    }
}
