using System;
using FinalProject.Models.Database;

//using Microsoft.ApplicationInsights.Extensibility.Implementation;

namespace FinalProject.Models
{
    public class StudentDAO
    {
        public static void Create(Student student)
        {
            var db = ScheduleDB.GetInstance();
            var sql =
                string.Format("INSERT INTO Students (StudentID, Firstname, Lastname, Program, Password)" +
                              $"VALUES ('{student.Username}','{student.FirstName}' , '{student.LastName}', '{student.Program}'," +
                              $"'{student.Password}')");
            db.ExecuteSql(sql);
        }

        public static Student GetStudent(string username, string password)
        {
            //throw new NotImplementedException();
            var db = ScheduleDB.GetInstance();
            var sql =
                string.Format("SELECT * " +
                              "FROM Students " +
                              $"WHERE StudentID = '{username}'" +
                              $"AND Password = '{password}'");
            var results = db.ExecuteSelectSql(sql);
            if (results.HasRows)
            {
                results.Read();
                return new Student
                {
                    Username = results["StudentID"].ToString(),
                    FirstName = results["FirstName"].ToString(),
                    LastName = results["LastName"].ToString(),
                    Program = results["Program"].ToString(),
                    Password = results["Password"].ToString()
                };
            }
            return null;
        }

        public static Student GetStudent(Student student)
        {
            var db = ScheduleDB.GetInstance();
            var sql =
                string.Format("SELECT * " +
                              "FROM Students " +
                              $"WHERE StudentID = {student.Username}");
            var results = db.ExecuteSelectSql(sql);
            if (results.HasRows)
            {
                results.Read();
                return new Student
                {
                    Username = results["StudentID"].ToString(),
                    FirstName = results["FirstName"].ToString(),
                    LastName = results["LastName"].ToString(),
                    Program = results["Program"].ToString(),
                    Password = results["Password"].ToString()
                };
            }
            return null;
        }
        public static bool CheckForStudent(Student student)
        {
            var db = ScheduleDB.GetInstance();
            var sql =
                string.Format("SELECT * FROM Students where StudentID = '{0}'", student.Username);
            var results = db.ExecuteSelectSql(sql);
            if (results.HasRows)
            {
                return true;
            }
            return false;
        }

        /*public static Student GetStudent(string firstName, string lastName)
        {
            var db = ScheduleDB.GetInstance();
            var sql =
                string.Format("SELECT * " +
                              "FROM Customers " +
                              $"WHERE FirstName = {firstName} " +
                              $"AND LastName = {lastName}");
            var results = db.ExecuteSelectSql(sql);
            if (results.HasRows)
            {
                results.Read();
                return new Student
                {
                    StudentId = (int)results["StudentID"],
                    FirstName = results["FirstName"].ToString(),
                    LastName = results["LastName"].ToString(),
                    Program = results["Program"].ToString(),
                    Username = results["Username"].ToString(),
                    Password = results["Password"].ToString()
                };
            }
            return null;
        }*/

        public static void Delete(string username)
        {
            var db = ScheduleDB.GetInstance();
            var sql =
                string.Format("Delete FROM Students " +
                              $"WHERE StudentID = '{username}'");
            db.ExecuteSql(sql);
        }

        public static void Update(Student student)
        {
            var db = ScheduleDB.GetInstance();
            var sql = string.Format("UPDATE Students " +
                                    $"SET FirstName = '{student.FirstName}'" +
                                    $", LastName = '{student.LastName}'" +
                                    $", Program = '{student.Program}'" +
                                    $", Password = '{student.Password}'" +
                                    $" WHERE StudentID = '{student.Username}'");
               
            db.ExecuteSql(sql);
        }
    }
}