namespace TestProject.Interface
{
    public interface ITask
    {
        Guid Id { get; set; }
        DateTime Date { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        bool IsCompleted { get; set; }
    }
}
