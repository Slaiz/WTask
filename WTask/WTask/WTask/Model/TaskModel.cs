using System;
using SQLite;

namespace WTask.Model
{
    [Table("Task")]
    public class TaskModel
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Note { get; set; }
        public bool Done { get; set; }
        public string Priority { get; set; }
        public string PriorityColor { get; set; }
        public TimeSpan Time { get; set; }
        public DateTime DataEnd { get; set; }
        public DateTime DataStart { get; set; }
    }
}