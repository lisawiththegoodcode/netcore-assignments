﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Message
    {   
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DatePosted { get; set; }
        public int ThreadId { get; set; }
    }
}
