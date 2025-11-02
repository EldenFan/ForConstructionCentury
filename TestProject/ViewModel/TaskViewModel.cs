using System.ComponentModel;
using System.Windows.Input;
using TestProject.Interface;

namespace TestProject.ViewModel
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        private readonly ITask model;

        private string name;
        private string description;
        private DateTime date;
        private bool isCompleted;

        private bool isChanged = false;

        public TaskViewModel(ITask task)
        {
            model = task;
            name = task.Name;
            description = task.Description;
            date = task.Date;
            isCompleted = task.IsCompleted;

            SaveChangeCommand = new Command(SaveChange, () => isChanged);
            DiscardChangeCommand = new Command(DiscardChange, () => isChanged);
            DeleteCommand = new Command(Delete);
        }

        public Guid Id => model.Id;

        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    isChanged = true;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string Description
        {
            get => description;
            set
            {
                if (description != value)
                {
                    description = value;
                    isChanged = true;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public DateTime Date
        {
            get => date;
            set
            {
                if (date != value)
                {
                    date = value;
                    isChanged = true;
                    OnPropertyChanged(nameof(Date));
                }
            }
        }

        public bool IsCompleted
        {
            get => isCompleted;
            set
            {
                if (isCompleted != value)
                {
                    isCompleted = value;
                    isChanged = true;
                    OnPropertyChanged(nameof(IsCompleted));
                }
            }
        }

        public ICommand SaveChangeCommand { get; set; }

        public ICommand DiscardChangeCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        private void SaveChange()
        {
            if (isChanged)
            {
                model.Name = name;
                model.Description = description;
                model.Date = date;
                model.IsCompleted = isCompleted;
                isChanged = false;
            }
        }

        private void DiscardChange()
        {
            if (isChanged)
            {
                Name = model.Name;
                Description = model.Description;
                Date = model.Date;
                IsCompleted = model.IsCompleted;
                isChanged = false;
            }
        }

        private void Delete()
        {
            Deleted?.Invoke(model.Id);
        }

        public Action<Guid>? Deleted;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
