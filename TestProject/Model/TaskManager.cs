using System.Globalization;
using TestProject.Interface;

namespace TestProject.Model
{
    public class TaskManager : ITaskManager
    {
        public List<ITask> Tasks { get; set; } = new List<ITask>();

        public void AddTask(ITask task)
        {
            Tasks.Add(task);
        }

        public void RemoveTask(ITask task)
        {
            Tasks.Remove(task);
        }

       public  List<ITask> GetTasksForDate(DateTime date)
       {
            return Tasks.Where(x => x.Date.Date == date).ToList();
       }

        public List<ITask> GetTasksForWeek(DateTime date)
        {
            var firstDayOfWeek = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            int diff = (7 + (date.Date.DayOfWeek - firstDayOfWeek)) % 7;
            var weekStart = date.Date.AddDays(-diff);
            var weekEndExclusive = weekStart.AddDays(7);

            return Tasks.Where(t => t.Date.Date >= weekStart && t.Date.Date < weekEndExclusive).ToList();
        }

        public List<ITask> GetTasksForMonth(DateTime date)
        {
            var monthStart = new DateTime(date.Year, date.Month, 1);
            var monthEndExclusive = monthStart.AddMonths(1);

            return Tasks.Where(t => t.Date.Date >= monthStart && t.Date.Date < monthEndExclusive).ToList();
        }

        public List<ITask> GetTasksForYear(DateTime date)
        {
            var yearStart = new DateTime(date.Year, 1, 1);
            var yearEndExclusive = yearStart.AddYears(1);

            return Tasks.Where(t => t.Date.Date >= yearStart && t.Date.Date < yearEndExclusive).ToList();
        }
    }
}
