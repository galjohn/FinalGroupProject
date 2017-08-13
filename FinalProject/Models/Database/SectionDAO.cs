using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;

namespace FinalProject.Models.Database
{
    public class SectionDAO
    {
        public static void Create(Section section)
        {
            var timeslots = GetJSONTimeList(section.Timeslots);
            var db = ScheduleDB.GetInstance();
            var sql =
                string.Format("INSERT INTO Sections " +
                                $"VALUES ('{section.CourseName}' , '{timeslots}')");
            db.ExecuteSql(sql);
        }

        public static Section GetSection(int id)
        {
            var db = ScheduleDB.GetInstance();
            var sql =
                string.Format("SELECT * " +
                              "FROM Sections " +
                              $"WHERE SectionID = {id}");
            var results = db.ExecuteSelectSql(sql);
            if (results.HasRows)
            {
                results.Read();
                return new Section
                {
                   SectionId = (int)results["SectionID"],
                   CourseName = results["CourseName"].ToString(),
                   Timeslots = GetTimeListFromJSON(results["Timeslots"].ToString())
                };
            }
            return null;
        }

        public static List<Section> GetSections(Timeslot timeslot)
        {
            var timeList = new List<Timeslot>();
            timeList.Add(timeslot);
   
            var sections = new List<Section>();
            var db = ScheduleDB.GetInstance();
            var results =
                db.ExecuteSelectSql("SELECT * " +
                                    "FROM Sections " +
                                    $"WHERE Timeslot = {GetJSONTimeList(timeList)}");

            while (results.Read())
            {

                var section = new Section()
                {
                    SectionId = (int)results["SectionID"],
                    CourseName = results["CourseName"].ToString(),
                    Timeslots = GetTimeListFromJSON(results["Timeslots"].ToString())
                };

                sections.Add(section);

            }
            return sections;
        }

        public static List<Section> GetSections(string professor)
        {
            var sections = new List<Section>();
            var db = ScheduleDB.GetInstance();
            var results =
                db.ExecuteSelectSql("SELECT * " +
                                    "FROM Sections " +
                                    "WHERE Timeslot = ");

            while (results.Read())
            {

                var section = new Section()
                {
                    SectionId = (int)results["SectionID"],
                    CourseName = results["CourseName"].ToString(),
                    Timeslots = GetTimeListFromJSON(results["Timeslots"].ToString())
                };

                sections.Add(section);

            }

            return sections;
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
            var db = ScheduleDB.GetInstance();
            var sql = string.Format("UPDATE Sections " +
                                    $"SET CourseName = '{section.CourseName}'" +
                                    $", Timeslots = '{GetJSONTimeList(section.Timeslots)}' " +
                                    $"WHERE SectionID = {section.SectionId}");
          db.ExecuteSql(sql);
        }

        private static string GetJSONTimeList(List<Timeslot> times)
        {
            var jsonSerialiser = new JavaScriptSerializer();
            var jsonStr = jsonSerialiser.Serialize(times);
            return jsonStr;
        }

        private static List<Timeslot> GetTimeListFromJSON(string jsonTimes)
        {
            var timeList = new List<Timeslot>();
            if (jsonTimes != null)
            {
                var jsonSerialiser = new JavaScriptSerializer();
                var jsonList = (List<Timeslot>)jsonSerialiser.DeserializeObject(jsonTimes);
                timeList = jsonList;
            }
            return timeList;
        }
    }
}