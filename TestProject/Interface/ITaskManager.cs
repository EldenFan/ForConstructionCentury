namespace TestProject.Interface
{
    public interface ITaskManager
    {
        List<ITask> Tasks { get; set; }

        void AddTask(ITask task);

        void RemoveTask(Guid taskId);

        List<ITask> GetTasksForDate(DateTime date);

        List<ITask> GetTasksForWeek(DateTime date);

        List<ITask> GetTasksForMonth(DateTime date);

        List<ITask> GetTasksForYear(DateTime date);
    }
}
