using System;

namespace ConferenceLibrary
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public bool HasPaid { get; set; }
        public int PayedNumber { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName.ToUpper()}";
            }
        }                


    }
}
