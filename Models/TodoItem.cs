using System;
using System.ComponentModel.DataAnnotations;

namespace Todo.Models
{
    public class TodoItem
    {
        public int ID { get; set; }

        public string Content { get; set; }

        [Display(Name = "Expect Finished Date")]
        [DataType(DataType.Date)]
        public DateTime ExpectFinishedDate { get; set; }

        public bool IsDone { get; set; }
    }
}