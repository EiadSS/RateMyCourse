﻿namespace backend.Entity
{
    public class Post
    {
        public int Id { get; set; }
        public string comment { get; set; } = string.Empty;

        public int userId { get; set; } 

        public float rating { get; set; }
        public int courseId { get; set; }
    }
}
