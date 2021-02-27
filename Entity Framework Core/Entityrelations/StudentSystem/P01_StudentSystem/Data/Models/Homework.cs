﻿
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Homework
    {
        public int HomeworkId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(260)")]
        public string Content { get; set; }

        [Required]
        public ContentType ContentType { get; set; }

        public DateTime SubmissionTime { get; set; }


        public int StudentId { get; set; }
        public Student Student { get; set; }


        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
