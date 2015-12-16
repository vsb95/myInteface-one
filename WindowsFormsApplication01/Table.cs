using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace UserService
{
    public class Table : IDisposable
    {
        private readonly SqlConnection _connection;
        public string Name { get; private set; }
        public List<Field> Fields { get; private set; }

        public Table(string name, SqlConnection connection)
        {
            Fields = new List<Field>();
            _connection = connection;
            Name = name;
            var query =
                $"SELECT INFORMATION_SCHEMA.COLUMNS.* FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{name}'";
            var command = new SqlCommand(query, _connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var a = new Field(reader["COLUMN_NAME"].ToString(), reader["DATA_TYPE"].ToString());
                Fields.Add(a);
            }
            reader.Close();
        }

        /// <summary>
        /// Добавляет запись в таблицу
        /// </summary>
        /// <param name="values">Список значений</param>
        public void InsertQuery(ArrayList values)
        {
            var query = $"insert into {Name} values (";
            for (var i = 0; i < values.Count; i++)
            {
                if (i > 0) query += ", ";
                query += $"'{values[i]}'";
            }
            query += ")";
            var command = new SqlCommand(query, _connection);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Изменяет строку таблицы по указанному ID
        /// </summary>
        /// <param name="id">ID записи</param>
        /// <param name="values">Список значений</param>
        public void UpdateQuery(int id, ArrayList values)
        {
            var query = $"update {Name} set ";

            for (var i = 0; i < Fields.Count; i++)
            {
                if (Fields[i].Name == "id") continue;
                query += $"[{Fields[i].Name}] = '{values[i]}'";
                if (i < Fields.Count - 1)
                    query += ", ";
            }
            query += $"where id = {id}";
            var command = new SqlCommand(query, _connection);
            command.ExecuteNonQuery();
        }
        public ArrayList SelectQuery()
        {
            var list = new ArrayList();
            var command = new SqlCommand($"select * from [{Name}]", _connection);
            var reader = command.ExecuteReader();
            foreach (var record in reader)
                list.Add(record);
            reader.Close();
            return list;
        }

        public void DeleteQuery(int id)
        {
            var query = $"delete from {Name} where id = {id}";
            var command = new SqlCommand(query, _connection);
            command.ExecuteNonQuery();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}