using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.StudentsEnrolled2014or2015
{
    public class StudentsEnr
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
                    FacultyNumber = studentInfo[0],
                    Marks = studentInfo
                        .Skip(1)
                        .Select(int.Parse)
                        .ToList()
                });
            }

            students
                .Where(x=>x.FacultyNumber.EndsWith("14") || x.FacultyNumber.EndsWith("15"))
                .ToList()
                .ForEach(x=>Console.WriteLine(string.Join(" ",x.Marks)));
        }
    }

    public class Student
    {
        public string FacultyNumber { get; set; }

        public List<int> Marks { get; set; }
    }
}
