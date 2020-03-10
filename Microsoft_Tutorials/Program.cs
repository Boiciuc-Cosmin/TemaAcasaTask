using System.Collections.Generic;
using System;
using System.Linq;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
           
            List<Person> persons = new List<Person>()
            {
                new Person {FirstName = "Georgeta-Maria", LastName = "Blagoci", Id = "024", HasPaid = true}, 
                new Person {FirstName = "Maria-Ana", LastName = "Blagoci", Id = "025", HasPaid = false}, 
                new Person {FirstName = "Ion", LastName = "Gheorghe", Id = "026", HasPaid = true}, 
                new Person {FirstName = "Vasile", LastName = "Blaj", Id = "027", HasPaid = true}
            };

            List<Talks> talks1 = new List<Talks>()
            {
                new Talks {Subjects = "All about C#", SeatsAvaillable = 40, Datetimes = "3/10/2020 11:10"},
                new Talks {Subjects = "All about python", SeatsAvaillable = 30, Datetimes = "7/10/2020 4:10"}
            };
          

            var speakers = new Speakers();
            var attendees = new Attendees();
            var talks = new Talks();

            talks.AddTalkMeeting(talks1);  
            talks.DisplayTalk();
                   
            speakers.ReadFromFile("Speakers.csv");
            speakers.DisplaySpeakers();
            speakers.WriteToFile("DataSpeakers.csv");

            attendees.ReadFromFile("Attendees.csv");
            attendees.AddPeople(persons);              
            attendees.DisplayAllPeople();
            attendees.SelectHasPaidPeople();
            attendees.WriteToFile("DataAttendees.csv");
            
            




        }
    }
}
