using System;

namespace Shared
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"ID:{Id} + FIRSTNAME:{FirstName} + LASTNAME:{LastName} + AGE:{Age}";
        }
    }
}
