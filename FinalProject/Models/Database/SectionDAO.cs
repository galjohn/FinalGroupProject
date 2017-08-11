using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace FinalProject.Models.Database
{
    public class SectionDAO
    {
        public static void Create(Section section)
        {
            //todo  Talk about timeslot
            //      Section in general w/DB

            //            var db = ScheduleDB.GetInstance();
            //            var sql =
            //                string.Format("INSERT INTO Sections " +
            //                              $"VALUES ('{section.courseName}' , '{section.professor}', '{}')");
            //            db.ExecuteSql(sql);
        }

        public static Section GetSection(int id)
        {
//            var db = ScheduleDB.GetInstance();
//            var sql =
//                string.Format("SELECT * " +
//                              "FROM Sections " +
//                              $"WHERE StudentID = {id}");
//            var results = db.ExecuteSelectSql(sql);
//            if (results.HasRows)
//            {
//                results.Read();
//                return new Section
//                {
//                   
//                };
//            }
            return null;
        }

        public static List<Section> GetSections(Timeslot timeslot)
        {
//            var sections = new List<Section>();
//            var db = ScheduleDB.GetInstance();
//            var results =
//                db.ExecuteSelectSql("SELECT * " +
//                                    "FROM Sections " +
//                                    "WHERE Timeslot = ");
//
//            while (results.Read())
//            {
//
//                var section = new Section()
//                {
//                    
//                };
//
//                sections.Add(section);
//
//            }
//
//            return sections;
        }

        public static List<Section> GetSections(string professor)
        {
//            var sections = new List<Section>();
//            var db = ScheduleDB.GetInstance();
//            var results =
//                db.ExecuteSelectSql("SELECT * " +
//                                    "FROM Sections " +
//                                    "WHERE Timeslot = ");
//
//            while (results.Read())
//            {
//
//                var section = new Section()
//                {
//                    
//                };
//
//                sections.Add(section);
//
//            }
//
//            return sections;
throw new NotImplementedException();
        }

        public static void Delete(int id)
        {
            var db = ScheduleDB.GetInstance();
            var sql =
                string.Format("Delete FROM Sections " +
                              $"WHERE Id = {id}");
            db.ExecuteSql(sql);
        }

        public static void Update(Section section)
        {
//            var db = ScheduleDB.GetInstance();
//            var sql = string.Format("UPDATE Students " +
//                                    $"SET FirstName = '{student.firstName}'" +
//                                    $", LastName = '{student.lastName}'" +
//                                    $", Program = '{student.program}'");
//            //$", Restrictions = {} Where Id = {4}",
//
//            db.ExecuteSql(sql);
        }
    }
}