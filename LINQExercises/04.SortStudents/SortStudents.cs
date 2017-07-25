using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SortStudents
{
    public class SortStudents
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
                    LastName = studentInfo[1]
                });
            }

            students
                .OrderBy(x=>x.LastName)
                .ThenByDescending(x=>x.FirstName)
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
