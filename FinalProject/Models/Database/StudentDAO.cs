using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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
                string.Format("INSERT INTO Students " +
                              $"VALUES ('{student.firstName}' , '{student.lastName}', '{student.program}')");
            db.ExecuteSql(sql);
        }

        public static Student GetStudent(int id)
        {
            var db = ScheduleDB.GetInstance();
            var sql =
                string.Format("SELECT * " +
                              "FROM Customers " +
                              $"WHERE StudentID = {id}");
            var results = db.ExecuteSelectSql(sql);
            if (results.HasRows)
            {
                results.Read();
                return new Student
                {
                    studentID = (int)results["StudentID"],
                    firstName = results["FirstName"].ToString(),
                    lastName = results["LastName"].ToString(),
                    program = results["Program"].ToString()
                };
            }
            return null;
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
                    studentID = (int)results["StudentID"],
                    firstName = results["FirstName"].ToString(),
                    lastName = results["LastName"].ToString(),
                    program = results["Program"].ToString()
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
            //var restrictions = student.
            var db = ScheduleDB.GetInstance();
            var sql = string.Format("UPDATE Students " +
                                    $"SET FirstName = '{student.firstName}'" +
                                    $", LastName = '{student.lastName}'" +
                                    $", Program = '{student.program}'");
                                    //$", Restrictions = {} Where Id = {4}",
               
            db.ExecuteSql(sql);
        }
    }
}