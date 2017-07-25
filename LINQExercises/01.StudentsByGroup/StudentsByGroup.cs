using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.StudentsByGroup
{
    public class StudentsByGroup
    {
        public static void Main()
        {
            var listOfStudents=new List<Student>();

            var studentInfo = Console.ReadLine();

            while (studentInfo!="END")
            {
                var tokens = studentInfo
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                listOfStudents.Add(new Student
                {
                    FirstName = tokens[0],
                    LastName = tokens[1],
                    UniversityGroup = int.Parse(tokens[2])
                });

                studentInfo = Console.ReadLine();
            }

            listOfStudents
                .Where(x=>x.UniversityGroup==2)
                .OrderBy(x=>x.FirstName)
                .ToList()
                .ForEach(x=>Console.WriteLine($"{x.FirstName} {x.LastName}"));
        }
    }

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int UniversityGroup { get; set; }
    }
}
