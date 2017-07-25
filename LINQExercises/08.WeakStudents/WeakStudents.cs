using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.WeakStudents
{
    public class WeakStudents
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
                        .Select(int.Parse)
                        .ToList()
                });
            }

            students
                .Where(x=>x.Marks.Count(y=>y<=3)>=2)
                .ToList()
                .ForEach(x=>Console.WriteLine($"{x.FirstName} {x.LastName}"));
        }
    }

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<int> Marks { get; set; }
    }
}
