namespace TestProject.Interface
{
    public interface ITaskManager
    {
        List<ITask> Tasks { get; set; }

        void AddTask();

        void RemoveTask(Guid task);

        List<ITask> GetTasksForPeriod(DateTime startDate, DateTime endDate);

        List<ITask> GetTasksForName(string name);
    }
}
