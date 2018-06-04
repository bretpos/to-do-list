using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class List
    {
        public int ListId { get; set; }
        [Required]
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public ICollection<ListItem> ListItems { get; private set; }
    }
}