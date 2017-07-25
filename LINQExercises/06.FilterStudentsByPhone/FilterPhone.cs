using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.FilterStudentsByPhone
{
    public class FilterPhone
    {
        public static void Main()
        {
            var students=new List<Student>();

            while (true)
            {
                var info = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (info[0].Equals("END"))
                {
                    break;
                }

                students.Add(new Student
                {
                    FirstName = info[0],
                    LastName = info[1],
                    PhoneNumber = info[2]
                });
            }

            students
                .Where(x=>x.PhoneNumber.StartsWith("+3592") || x.PhoneNumber.StartsWith("02"))
                .ToList()
                .ForEach(x=>Console.WriteLine($"{x.FirstName} {x.LastName}"));
        }
    }

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
    }
}
