using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using FinalProject.Models.Database;
using FinalProject.Models.ViewModels;

//using Microsoft.ApplicationInsights.Extensibility.Implementation;

namespace FinalProject.Models
{
    public class StudentDAO
    {
        public static void Create(Student student)
        {
            var db = ScheduleDB.GetInstance();
            var sql =
                string.Format("INSERT INTO Students (Firstname, Lastname, Program, Username, Password)" +
                              $"VALUES ('{student.FirstName}' , '{student.LastName}', '{student.Program}'," +
                              $"'{student.Username}', '{student.Password}')");
            db.ExecuteSql(sql);
        }

        internal static Student GetStudent(string username)
        {
            throw new NotImplementedException();
        }

        public static Student GetStudent(int id)
        {
            var db = ScheduleDB.GetInstance();
            var sql =
                string.Format("SELECT * " +
                              "FROM Students " +
                              $"WHERE StudentID = {id}");
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
        }
        public static bool CheckForStudent(Student student)
        {
            var db = ScheduleDB.GetInstance();
            var sql =
                string.Format("SELECT * FROM Students where Username = '{0}'", student.Username);
            var results = db.ExecuteSelectSql(sql);
            if (results.HasRows)
            {
                return true;
            }
            return false;
        }

        public static Student GetStudent(string firstName, string lastName)
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
        }

        public static void Delete(int id)
        {
            var db = ScheduleDB.GetInstance();
            var sql =
                string.Format("Delete FROM Students " +
                              $"WHERE Id = {id}");
            db.ExecuteSql(sql);
        }

        public static void Update(Student student)
        {
            var db = ScheduleDB.GetInstance();
            var sql = string.Format("UPDATE Students " +
                                    $"SET FirstName = '{student.FirstName}'" +
                                    $", LastName = '{student.LastName}'" +
                                    $", Program = '{student.Program}'" +
                                    $", Username = '{student.Username}'" +
                                    $", Password = '{student.Password}'");
               
            db.ExecuteSql(sql);
        }
    }
}