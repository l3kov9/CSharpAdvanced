using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterStudentsByEmailDomain
{
    public class FilterEmails
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
                    Email = studentInfo[2]
                });
            }

            students
                .Where(x=>x.Email.Length>10 && x.Email.Substring(x.Email.Length-10)=="@gmail.com")
                .ToList()
                .ForEach(x=>Console.WriteLine($"{x.FirstName} {x.LastName}"));
        }
    }

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}
