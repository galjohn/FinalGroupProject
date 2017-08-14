using System.Collections.Generic;
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
                              $", '{restriction.NoGaps}" +
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
                    NoGaps = (bool)results["MustHaveOneHourBreaks"],
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
                                    $"SET MustHaveOneHourGaps = '{restriction.NoGaps}'" +
                                    $", NoGapsBiggerThanOneHour = '{restriction.NoGapsBiggerThanOneHour}'" +
                                    $", Timeslots = '{GetJSONTimeList(restriction.Timeslots)}' " +
                                    $"WHERE RestrictionID = {restriction.RestrictionId}");
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