using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.GroupByGroup
{
    public class GroupByGroup
    {
        public static void Main()
        {
            var students=new List<Person>();

            while (true)
            {
                var studentInfo = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (studentInfo[0] == "END")
                {
                    break;
                }

                students.Add(new Person
                {
                    FirstName = studentInfo[0],
                    LastName = studentInfo[1],
                    Group = int.Parse(studentInfo[2])
                });
            }

            var result=students
                .GroupBy(x => x.Group)
                .ToList();

            foreach (var groupNames in result)
            {
                var stu=new Person();
            }
        }
    }

    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Group { get; set; }
    }
}
