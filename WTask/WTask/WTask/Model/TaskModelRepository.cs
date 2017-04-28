using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using WTask.Interface;
using Xamarin.Forms;

namespace WTask.Model
{
    public class TaskModelRepository
    {
        SQLiteConnection database;
        public TaskModelRepository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);
            database.CreateTable<TaskModel>();
        }
        public IEnumerable<TaskModel> GetItems()
        {
            return (from i in database.Table<TaskModel>() select i).ToList();

        }
        public TaskModel GetItem(int id)
        {
            return database.Get<TaskModel>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<TaskModel>(id);
        }
        public int SaveItem(TaskModel item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
