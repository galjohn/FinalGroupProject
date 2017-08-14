﻿using System.Collections.Generic;
using System.Web.Script.Serialization;

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

        public static List<Section> GetStudentSections(int id)
        {
            var studentSections = new List<Section>();
            var db = ScheduleDB.GetInstance();
            var sql =
                string.Format("SELECT * " +
                              "FROM Sections " +
                              $"WHERE SectionID = {id}");
            var results = db.ExecuteSelectSql(sql);
            if (results == null)
            {
                return null;
            }
            while (results.HasRows)
            {
                results.Read();
                studentSections.Add(new Section
                {
                    SectionId = (int) results["SectionID"],
                    CourseName = results["CourseName"].ToString(),
                    Timeslots = GetTimeListFromJSON(results["Timeslots"].ToString())
                });
            }
            return studentSections;
        }

        public static List<Section> GetSections(string professor)
        {
            var sections = new List<Section>();
            var db = ScheduleDB.GetInstance();
            var results =
                db.ExecuteSelectSql("SELECT * " +
                                    "FROM Sections " +
                                    "WHERE Timeslot LIKE '%Professor%' ");

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
            for (var i = jsonStr.IndexOf('{'); i > -1; i = jsonStr.IndexOf('{', i + 2))
            {
                jsonStr = jsonStr.Insert(i, "{");
            }
            for (var i = jsonStr.IndexOf('}'); i > -1; i = jsonStr.IndexOf('}', i + 2))
            {
                jsonStr = jsonStr.Insert(i, "}");
            }
            return jsonStr;
        }

        private static List<Timeslot> GetTimeListFromJSON(string jsonTimes)
        {
            
            var timeList = new List<Timeslot>();
            if (jsonTimes != null)
            {
                for (var i = jsonTimes.IndexOf('{'); i > -1; i = jsonTimes.IndexOf('{', i + 2))
                {
                    jsonTimes = jsonTimes.Remove(i, 1);
                }
                for (var i = jsonTimes.IndexOf('}'); i > -1; i = jsonTimes.IndexOf('}', i + 2))
                {
                    jsonTimes = jsonTimes.Remove(i, 1);
                }
                var jsonSerialiser = new JavaScriptSerializer();
                var jsonList = (List<Timeslot>)jsonSerialiser.DeserializeObject(jsonTimes);
                timeList = jsonList;
            }
            return timeList;
        }
    }
}