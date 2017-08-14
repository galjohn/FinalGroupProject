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
                              $"VALUES ('{restriction.StudentId}'" +
                              $", {BoolToInt(restriction.NoGapsBiggerThanOneHour)}" +
                              $", {BoolToInt(restriction.NoGaps)}" +
                              $", '{GetJSONTimeList(restriction.Timeslots)}')");
            db.ExecuteSql(sql);
        }

        public static Restriction GetRestriction(string studentId)
        {
            var db = ScheduleDB.GetInstance();
            var sql =
                string.Format("SELECT * " +
                              "FROM Restrictions " +
                              $"WHERE StudentID = '{studentId}'");
            var results = db.ExecuteSelectSql(sql);
            if (results.HasRows)
            {
                results.Read();
                
                return new Restriction
                {
                    StudentId = results["StudentID"].ToString(),
                    NoGaps = results.GetBoolean(results.GetOrdinal("MustHaveOneHourBreaks")),
                    Timeslots = GetTimeListFromJSON(results["Timeslots"].ToString()),
                    NoGapsBiggerThanOneHour = results.GetBoolean(results.GetOrdinal("NoGapsBiggerThanOneHour"))
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
                                    $"SET MustHaveOneHourBreaks = '{BoolToInt(restriction.NoGaps)}'" +
                                    $", NoGapsBiggerThanOneHour = {BoolToInt(restriction.NoGapsBiggerThanOneHour)}" +
                                    $", Timeslots = '{GetJSONTimeList(restriction.Timeslots)}' " +
                                    $"WHERE StudentID = '{restriction.StudentId}'");
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
            var jsonSerialiser = new JavaScriptSerializer();
            var jsonList = jsonSerialiser.Deserialize<List<Timeslot>>(jsonTimes);
            timeList = jsonList;
            return timeList;
        }

        private static int BoolToInt(bool input)
        {
            return input ? 1 : 0;
        }

        private static bool IntToBool(int input)
        {
            return input == 1;
        }
    }
}