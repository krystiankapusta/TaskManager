using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_ToDoList.Models
{
    public class ToDoList
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Performer { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; }
    }


}
