using System;
using System.Collections;

namespace LinqDemo
{
    public class Student : IEnumerable
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Mark { get; set; }

        public DateTime DateOfBirth { get; set; }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
