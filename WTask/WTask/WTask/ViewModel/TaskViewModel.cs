using System;
using System.Collections.Generic;
using System.Windows.Input;
using PropertyChanged;
using Shared;
using WTask.Enum;
using WTask.Model;
using WTask.Shared;
using Xamarin.Forms;

namespace WTask.ViewModel
{
    [ImplementPropertyChanged]
    public class TaskViewModel:BaseViewModel
    {
        public static event EventHandler<TaskModel> OnAddTask;
        public static event EventHandler<TaskModel> OnDeleteTask;
        public static event Action<TaskModel, TaskModel> OnUpdateTask;

        public TaskModel TempTask { get; private set; }
        public TaskModel OldTask { get; private set; }
        public List<string> PriorityList { get; set; }

        public ICommand DeleteTaskCommand { get; set; }
        public ICommand SaveTaskCommand { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public string Priority { get; set; }
        public string PriorityColor { get; set; }
        public DateTime DateStart { get; set; }
        public TimeSpan Time { get; set; }

        public TaskViewModel(TaskModel selectedTask)
        {
            TempTask = new TaskModel();

            if (selectedTask != null)
            {
                OldTask = selectedTask;

                Id = selectedTask.Id;

                Name = selectedTask.Name;
                Note = selectedTask.Note;
                Priority = selectedTask.Priority;
                PriorityColor = selectedTask.PriorityColor;
                DateStart = selectedTask.DateStart;
                Time = selectedTask.Time;
            }
            else
            {
                Id = 0;
                Priority = PriorityItem.None.ToString();
                DateStart = DateTime.Now;
                Time = TimeSpan.Zero;
            }

            PriorityList = new List<string>(EnumConverter.Converter());

            DeleteTaskCommand = new CommandHandler(arg => DeleteTask());
            SaveTaskCommand = new CommandHandler(arg => SaveTask());
        }

        public bool IsValid
        {
            get
            {
                return ((!string.IsNullOrEmpty(Name.Trim())) ||
                    (!string.IsNullOrEmpty(Note.Trim())));
            }
        }

        private void Back()
        {
            Navigation.PopAsync();
        }

        private void SaveTask()
        {
            SetPriorityColor();

            TempTask.Name = Name;
            TempTask.Note = Note;
            TempTask.Priority = Priority;
            TempTask.PriorityColor = PriorityColor;
            TempTask.DateStart = DateStart;
            TempTask.Time = Time;

            App.Database.SaveItem(TempTask);

            if (Id == 0)
            {               
                DoOnAddTask(TempTask);
            }
            else
            {
                DoOnUpdateTask(OldTask,TempTask);
            }

            TempTask = null;

            Back();
        }

        private void SetPriorityColor()
        {
            if (Priority == PriorityItem.Hight.ToString())
                PriorityColor = "#F44336";
            if (Priority == PriorityItem.Low.ToString())
                PriorityColor = "#4CAF50";
            if (Priority == PriorityItem.Major.ToString())
                PriorityColor = "#9C27B0";
            if (Priority == PriorityItem.Medium.ToString())
                PriorityColor = "#FFEB3B";
            if (Priority == PriorityItem.None.ToString())
                PriorityColor = "#9E9E9E";
        }

        private void DeleteTask()
        {
            App.Database.DeleteItem(Id);

            DoOnDeleteTask(TempTask);

            Back();
        }

        private static void DoOnAddTask(TaskModel e)
        {
            OnAddTask?.Invoke(null, e);
        }

        private static void DoOnDeleteTask(TaskModel e)
        {
            OnDeleteTask?.Invoke(null, e);
        }

        private static void DoOnUpdateTask(TaskModel arg1, TaskModel arg2)
        {
            OnUpdateTask?.Invoke(arg1, arg2);
        }
    }
}