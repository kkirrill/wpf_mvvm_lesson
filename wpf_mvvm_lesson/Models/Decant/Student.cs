﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_mvvm_lesson.Models.Decant
{
    internal class Student
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronomic { get; set; }

        public DateTime Birthday { get; set; }
        
        public double  Rating { get; set; }

    }

    internal class Group
    {
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }

    }
}