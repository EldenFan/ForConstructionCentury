using System.ComponentModel;
using TestProject.Interface;

namespace TestProject.ViewModel
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        private readonly ITask model;

        public TaskViewModel(ITask task)
        {
            model = task;
        }

        public string Name
        {
            get => model.Name;
            set
            {
                if (model.Name != value)
                {
                    model.Name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string Description
        {
            get => model.Description;
            set
            {
                if (model.Description != value)
                {
                    model.Description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public DateTime Date
        {
            get => model.Date;
            set
            {
                if (model.Date != value)
                {
                    model.Date = value;
                    OnPropertyChanged(nameof(Date));
                }
            }
        }

        public bool IsCompleted
        {
            get => model.IsCompleted;
            set
            {
                if (model.IsCompleted != value)
                {
                    model.IsCompleted = value;
                    OnPropertyChanged(nameof(IsCompleted));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
