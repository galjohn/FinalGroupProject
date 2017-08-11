using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace FinalProject.Models.Database
{
    public class RestrictionDAO
    {
        public static void Create(Restriction restriction)
        {
            var db = ScheduleDB.GetInstance();
            var sql =
                string.Format("INSERT INTO Restrictions " +
                              $"VALUES ({restriction.StudentId} " +
                              $", '{restriction.NoGapsBiggerThanOneHour}'" +
                              $", '{restriction.MustHaveOneHourBreaks}" +
                              $", '{GetJSONTimeList(restriction.Timeslots)}'");
            db.ExecuteSql(sql);
        }

        public static Restriction GetRestriction(int studentId)
        {
            var db = ScheduleDB.GetInstance();
            var sql =
                string.Format("SELECT * " +
                              "FROM Restrictions " +
                              $"WHERE StudentID = {studentId}");
            var results = db.ExecuteSelectSql(sql);
            if (results.HasRows)
            {
                results.Read();
                return new Restriction
                {
                    RestrictionId = (int)results["RestrictionID"],
                    StudentId = (int)results["StudentID"],
                    MustHaveOneHourBreaks = (bool)results["MustHaveOneHourBreaks"],
                    Timeslots = GetTimeListFromJSON(results["Timeslots"].ToString()),
                    NoGapsBiggerThanOneHour = (bool)results["NoGapsBiggerThanOneHour"]
                };
            }
            return null;
        }

        public static void Delete(int id)
        {
            var db = ScheduleDB.GetInstance();
            var sql =
                string.Format("DELETE FROM Restrictions " +
                              $"WHERE Id = {id}");
            db.ExecuteSql(sql);
        }

        public static void Update(Restriction restriction)
        {
            var db = ScheduleDB.GetInstance();
            var sql = string.Format("UPDATE Restrictions " +
                                    $"SET MustHaveOneHourGaps = '{restriction.MustHaveOneHourBreaks}'" +
                                    $", NoGapsBiggerThanOneHour = '{restriction.NoGapsBiggerThanOneHour}'" +
                                    $", Timeslots = '{GetJSONTimeList(restriction.Timeslots)}' " +
                                    $"WHERE RestrictionID = {restriction.RestrictionId}");
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