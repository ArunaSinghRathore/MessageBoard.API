﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoard.API.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PostText { get; set; }
        public DateTime PostDate { get; set; }
    }
}
