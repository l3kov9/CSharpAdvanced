using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace LinqDemo
{
    public class LinqDemo
    {
        public static void Main(string[] args)
        {
            var list=new List<int>{5,2,4,7,78,5,3,2,234,-23,5,4};

            var groupingList = list.GroupBy(x => x <=2);

            foreach (var group in groupingList)
            {
                Console.WriteLine("Is even: {0}- ", group.Key);
                Console.WriteLine(string.Join(", ", group));
            }

            var dictionary = groupingList.ToDictionary(x => x.Key, x => x.ToList());

            //var someStudent=new Student
            //{
            //    FirstName = "Pesho",
            //    LastName = "Goshev",
            //    Mark = 5.44,
            //    DateOfBirth = new DateTime(2000,10,22)
            //};

            //var studentsList=new List<Student>
            //{
            //    someStudent,
            //    new Student
            //    {
            //        FirstName = "Mishooooooo",
            //        LastName = "Glupakov",
            //        Mark = 2.44,
            //        DateOfBirth = new DateTime(1999,4,4)
            //    },
            //    new Student
            //    {
            //        FirstName = "Petko",
            //        LastName = "Idiotov",
            //        Mark = 3.2,
            //        DateOfBirth = new DateTime(1989,12,12)
            //    }
            //};

            //var choosenStudenst = studentsList.Where(x => x.FirstName.StartsWith("P")).ToList();

            //Print(choosenStudenst);
        }

        private static void Print(List<Student> choosenStudenst)
        {
            foreach (var student in choosenStudenst)
            {
                Console.WriteLine($"Name: {student.FirstName} {student.LastName}\n{student.Mark}\n{student.DateOfBirth:d}");
            }
        }
    }
}
