﻿using System.ComponentModel.DataAnnotations;

namespace WatchMNS.Models
{
    public class TrainingType
    {
        [Key]
        public int Id { get; set; }
        public string Label { get; set; }
    }
}
