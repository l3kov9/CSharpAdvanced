using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ExcellentStudents
{
    public class ExcellentStudents
    {
        public static void Main()
        {
            var students=new List<Student>();

            while (true)
            {
                var studentInfo = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (studentInfo[0].Equals("END"))
                {
                    break;
                }

                students.Add(new Student
                {
                    FirstName = studentInfo[0],
                    LastName = studentInfo[1],
                    Marks = studentInfo
                        .Skip(2)
                        .Select(double.Parse)
                        .ToList()
                });
            }

            students
                .Where(x=>x.Marks.Any(m=>m==6))
                .ToList()
                .ForEach(x=>Console.WriteLine($"{x.FirstName} {x.LastName}"));
        }
    }

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<double> Marks { get; set; }
    }
}
