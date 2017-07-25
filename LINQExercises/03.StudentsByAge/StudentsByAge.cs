using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.StudentsByAge
{
    public class StudentsByAge
    {
        public static void Main()
        {
            var students=new List<Student>();

            while (true)
            {
                var studentInfo = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (studentInfo[0] == "END")
                {
                    break;
                }

                students.Add(new Student
                {
                    FirstName = studentInfo[0],
                    LastName = studentInfo[1],
                    Age = int.Parse(studentInfo[2])
                });
            }

            students
                .Where(x=>x.Age>=18 && x.Age<=24)
                .ToList()
                .ForEach(x=>Console.WriteLine($"{x.FirstName} {x.LastName} {x.Age}"));
        }
    }

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
    }
}
