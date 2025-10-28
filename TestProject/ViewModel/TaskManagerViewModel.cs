using System.Collections.ObjectModel;
using System.Windows.Input;
using TestProject.Interface;

namespace TestProject.ViewModel
{
    public class TaskManagerViewModel
    {
       private readonly ITaskManager model;

        public TaskManagerViewModel(ITaskManager model)
        {
            this.model = model;

            Tasks = new ObservableCollection<TaskViewModel>(model.Tasks.Select(t => new TaskViewModel(t)));

            AddCommand = new Command(AddTask);

            FilterByDateCommand = new Command(FilterTasksByDate);

            FilterByNameCommand = new Command(FindTasksByName, () => string.IsNullOrWhiteSpace(NameFilter) == false);
        }

        public ObservableCollection<TaskViewModel> Tasks { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Now;

        public DateTime EndDate { get; set; } = DateTime.Now;

        public string NameFilter { get; set; } = string.Empty;

        public ICommand AddCommand { get; set; }

        public ICommand FilterByDateCommand { get; set; }

        public ICommand FilterByNameCommand { get; set; }

        private void AddTask()
        {
            model.AddTask();

            var newTask = model.Tasks.Last();
            var newTaskViewModel = new TaskViewModel(newTask);

            Tasks.Add(newTaskViewModel);

            newTaskViewModel.Deleted += OnTaskDeleted;
        }

        private void OnTaskDeleted(Guid taskId)
        {
            model.RemoveTask(taskId);

            var taskViewModel = Tasks.FirstOrDefault(t => t.Id == taskId);
            if (taskViewModel != null)
            {
                taskViewModel.Deleted -= OnTaskDeleted;
                Tasks.Remove(taskViewModel);
            }
        }

        private void ClearTasks()
        {
            foreach (var taskViewModel in Tasks)
            {
                taskViewModel.Deleted -= OnTaskDeleted;
            }
            Tasks.Clear();
        }

        private void FilterTasksByDate()
        {
            ClearTasks();
            var filteredTasks = model.GetTasksForPeriod(StartDate, EndDate);
            foreach (var task in filteredTasks)
            {
                var taskViewModel = new TaskViewModel(task);
                taskViewModel.Deleted += OnTaskDeleted;
                Tasks.Add(taskViewModel);
            }
        }

        private void FindTasksByName()
        {
            ClearTasks();
            var filteredTasks = model.GetTasksForName(NameFilter);
            foreach (var task in filteredTasks)
            {
                var taskViewModel = new TaskViewModel(task);
                taskViewModel.Deleted += OnTaskDeleted;
                Tasks.Add(taskViewModel);
            }
        }
    }
}
