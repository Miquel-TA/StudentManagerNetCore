using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagerNetCore.Models
{
    public class Student
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public int Age { get; set; }

        public DateTime CreatedDate { get; set; }

        public Student(string name, DateTime birthday, int age, DateTime createdDate)
        {
            Name = name;
            Birthday = birthday;
            Age = age;
            CreatedDate = createdDate;
        }
    }
}
