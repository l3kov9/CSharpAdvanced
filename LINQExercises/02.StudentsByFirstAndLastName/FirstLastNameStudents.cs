using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StudentsByFirstAndLastName
{
    public class FirstLastNameStudents
    {
        public static void Main()
        {
            var students=new List<Student>();

            var studentInfo = Console.ReadLine()
                .Split(new []{' '},StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (studentInfo[0]!="END")
            {
                students.Add(new Student
                {
                    FirstName = studentInfo[0],
                    LastName = studentInfo[1]
                });

                studentInfo = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
            }

            students
                .Where(x=>x.FirstName.CompareTo(x.LastName)==-1)
                .ToList()
                .ForEach(x=>Console.WriteLine($"{x.FirstName} {x.LastName}"));
        }
    }

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
