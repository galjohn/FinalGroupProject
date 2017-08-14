using System.Data;
using System.Data.SqlClient;

namespace FinalProject.Models.Database
{
    public class ScheduleDB
    {
        private static ScheduleDB _instance;

        private SqlConnection _connection;

        private ScheduleDB()
        {
            //John's Connection String
            _connection = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ScheduleDB;MultipleActiveResultSets=true");
            // Jamie's Connection String
            //_connection = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ScheduleDB;Data Source=LEMON-LAPTOP;MultipleActiveResultSets=true");
            //Joao's Connection String
            //_connection = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ScheduleDB;Data Source=DESKTOP-M77BAR2;MultipleActiveResultSets=true");
        }

        public static ScheduleDB GetInstance()
        {
            if (_instance == null)
                _instance = new ScheduleDB();
            return _instance;
        }

        public void ExecuteSql(string sql)
        {
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();

            var command = _connection.CreateCommand();
            command.CommandText = sql;
            command.ExecuteNonQuery();

            _connection.Close();
        }


        public SqlDataReader ExecuteSelectSql(string sql)
        {
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();

            var command = _connection.CreateCommand();
            command.CommandText = sql;
            return command.ExecuteReader();
        }
    }
}