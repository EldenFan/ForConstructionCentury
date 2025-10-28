using System.Globalization;
using TestProject.Interface;

namespace TestProject.Model
{
    public class TaskManager : ITaskManager
    {
        public List<ITask> Tasks { get; set; } = new List<ITask>();

        public void AddTask()
        {
            var newTask = new Task();
            Tasks.Add(newTask);
        }

        public void RemoveTask(Guid taskId)
        {
            var findTask = Tasks.Find(task => task.Id == taskId);

            if (findTask != null)
            {
                Tasks.Remove(findTask);
            }
        }

        public List<ITask> GetTasksForPeriod(DateTime startDate, DateTime endDate)
        {
            return Tasks.Where(t => t.Date.Date >= startDate.Date && t.Date.Date <= endDate.Date).ToList();
        }

        public List<ITask> GetTasksForName(string name)
        {
            return Tasks.Where(t => t.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
