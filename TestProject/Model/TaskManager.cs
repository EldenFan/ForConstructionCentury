using TestProject.Interface;

namespace TestProject.Model
{
    public class TaskManager : ITaskManager
    {
        List<ITask> Tasks { get; set; } = new List<ITask>();
    }
}
