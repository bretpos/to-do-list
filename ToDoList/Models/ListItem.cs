using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class ListItem
    {
        public int ListItemId { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedOn { get; set; }
        [Required]
        public int ListId { get; set; }
    }
}