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
        public string Tag { get; set; }
        public DateTime DateEnd { get; set; }
        public DateTime DateStart { get; set; }
        public TimeSpan Time { get; set; }
    }
}