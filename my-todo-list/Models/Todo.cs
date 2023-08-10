using System;
using System.Collections.Generic;

namespace my_todo_list.Models
{
    public partial class Todo
    {
        public long Id { get; set; }
        public string? TodoTitle { get; set; }
    }
}
