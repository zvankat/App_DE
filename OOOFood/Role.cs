﻿using System.ComponentModel.DataAnnotations;

namespace OOOFood
{
    public class Role
    {
        [Key]
        public int role_id { get; set; }
        public string role_name { get; set; }
    }
}