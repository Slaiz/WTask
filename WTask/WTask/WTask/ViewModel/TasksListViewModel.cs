using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using PropertyChanged;
using Shared;
using WTask.Model;
using WTask.View;

namespace WTask.ViewModel
{
    [ImplementPropertyChanged]
    public class TasksListViewModel : BaseViewModel
    {
        public ObservableCollection<TaskModel> TasksList { get; set; }

        public ICommand CreateTaskCommand { get; set; }

        private TaskModel _selectedTask;

        public TaskModel SelectedTask
        {
            get { return _selectedTask; }
            set
            {
                if (_selectedTask == value)
                    return;

                _selectedTask = value;

                _selectedTask = value;
                OnPropertyChanged(nameof(SelectedTask));

                if (_selectedTask != null)
                {
                    Navigation.PushAsync(new TaskView(new TaskViewModel(_selectedTask)));
                    _selectedTask = null;
                    OnPropertyChanged(nameof(SelectedTask));
                }
            }
        }

        public TasksListViewModel()
        {
            TasksList = new ObservableCollection<TaskModel>(App.Database.GetItems());

            TaskViewModel.OnAddTask += TaskViewModelOnOnAddTask;
            TaskViewModel.OnDeleteTask += TaskViewModelOnOnDeleteTask;
            TaskViewModel.OnUpdateTask += TaskViewModelOnOnUpdateTask;

            CreateTaskCommand = new CommandHandler(arg => CreateTask());
        }

        private void TaskViewModelOnOnUpdateTask(TaskModel oldTaskModel, TaskModel newTaskModel)
        {
            var task = TasksList.First(x => x.Id == oldTaskModel.Id);
            int index = TasksList.IndexOf(task);

            TasksList.RemoveAt(index);
            TasksList.Insert(index, newTaskModel);
        }

        private void TaskViewModelOnOnDeleteTask(object sender, TaskModel taskModel)
        {
            var oldTask = TasksList.First(x => x.Id == taskModel.Id);

            TasksList.Remove(oldTask);
        }

        private void TaskViewModelOnOnAddTask(object sender, TaskModel taskModel)
        {
            TasksList.Add(taskModel);
        }

        private void CreateTask()
        {
            Navigation.PushAsync(new TaskView(new TaskViewModel(SelectedTask)));
        }
    }
}