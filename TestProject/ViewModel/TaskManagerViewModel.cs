using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using TestProject.Interface;

namespace TestProject.ViewModel
{
    public class TaskManagerViewModel : INotifyPropertyChanged
    {
       private readonly ITaskManager model;

        public TaskManagerViewModel(ITaskManager model)
        {
            this.model = model;

            Tasks = new ObservableCollection<TaskViewModel>(model.Tasks.Cast<TaskViewModel>());

            InitCommand();
        }

        public ObservableCollection<TaskViewModel> Tasks { get; set; }

        public TaskViewModel? SelectedTask { get; set; }

        public ICommand AddComand { get; private set; }
        public ICommand RemoveCommand { get; private set; }

        private void InitCommand()
        {
            AddComand = new Command(AddTask);
            RemoveCommand = new Command(RemoveTask, () => SelectedTask != null);
        }

        private void AddTask()
        {
        }

        private void RemoveTask()
        {
        }
    }
}
