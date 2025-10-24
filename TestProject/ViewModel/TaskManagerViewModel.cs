using System.Collections.ObjectModel;
using System.ComponentModel;
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
        }

        public ObservableCollection<TaskViewModel> Tasks { get; set; }

        public TaskViewModel? SelectedTask { get; set; }
    }
}
