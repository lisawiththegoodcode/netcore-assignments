﻿using System.ComponentModel.DataAnnotations;
using System;

namespace ToDoApp.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [UIHint("Status")]
        public Status Status { get; set; }
        public DateTime Created { get; set; } 
    }
}
