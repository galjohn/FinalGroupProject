using System.Collections.Generic;

namespace FinalProject.Models.Database
{
    public class ScheduleDAO
    {
        public static void Create(Schedule schedule)
        {
            var db = ScheduleDB.GetInstance();
            foreach (var section in schedule.Sections)
            {
                var sql =
                    string.Format("INSERT INTO Restrictions " +
                                  $"VALUES ({schedule.StudentId} " +
                                  $", {section.SectionId}");
                db.ExecuteSql(sql);
            }
        }

        public static Schedule GetSchedule(string studentId)
        {
            var schedule = new Schedule();
            var sections = new List<Section>();
            var db = ScheduleDB.GetInstance();
            var results =
                db.ExecuteSelectSql("SELECT SectionID " +
                                    "FROM Schedule " +
                                    $"WHERE StudentId = '{studentId}'");

            while (results.Read())
            {
                var sectionId = (int) results["SectionId"];
                var section = SectionDAO.GetSection(sectionId); 
                sections.Add(section);
            }

            schedule.StudentId = studentId;
            schedule.Sections = sections;

            return schedule;
        }

        public static void Update(Schedule schedule)
        {
            Delete(schedule.StudentId);
            Create(schedule);
        }

        public static void Delete(string studentId)
        {
            var db = ScheduleDB.GetInstance();
            var sql =
                string.Format("DELETE FROM Schedule " +
                              $"WHERE StudentId = {studentId}");
            db.ExecuteSql(sql);
        }
    }
}