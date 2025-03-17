using System;
using System.IO;
using System.Data;
using System.Data.SQLite;
using System.Reflection;

namespace CleanCode_ExampleMVP
{
    class SqlQueryExecutor
    {
        private string _connectionString = $"Data Source = {Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\db.sqlite";

        private SQLiteConnection _connection;

        public SqlQueryExecutor()
        {
            _connection = new SQLiteConnection(_connectionString);
        }

        public DataTable ExecuteQuery(string query)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentNullException();

            _connection.Open();

            if (_connection.State != ConnectionState.Open)
                throw new SQLiteException("Ошибка подключения к БД.");

            SQLiteDataAdapter sqLiteDataAdapter = new SQLiteDataAdapter(new SQLiteCommand(query, _connection));
            DataTable queryResult = new DataTable();
            sqLiteDataAdapter.Fill(queryResult);
            _connection.Close();

            return queryResult;
        }
    }
}
