using System.Data.Entity;
using ToDoList.Models;

namespace ToDoList.Persistence
{
    public class ToDoListContext : DbContext
    {
        public DbSet<List> Lists { get; set; }
        public DbSet<ListItem> ListItems { get; set; }

        //public ToDoListContext() : base("") { }
    }
}