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
                new Person {FirstName = "Georgeta-Maria", LastName = "Blagoci", Id = "024", HasPayed = true}, 
                new Person {FirstName = "Maria-Ana", LastName = "Blagoci", Id = "025", HasPayed = false}, 
                new Person {FirstName = "Ion", LastName = "Gheorghe", Id = "026", HasPayed = true}, 
                new Person {FirstName = "Vasile", LastName = "Blaj", Id = "027", HasPayed = true}
            };
            List<Person> speakersList = new List<Person>()
            {
                new Person {FirstName = "Nume", LastName = "alt nume", Id="123" }
            };

            var speakers = new Speakers();
            var attendees = new Attendees();
            attendees.AddFromFile("fisier.csv");
            speakers.AddSpeaker(persons.Find(x => x.Id == "#026"));
            speakers.AddSpeakers(speakersList);

            speakers.AddFromFile("fisier.csv");
            speakers.DisplaySpeakers();
           
            attendees.AddPeople(persons);              
            attendees.DisplayAllPeople();
            attendees.SelectHasPayedPeople();
            




        }
    }
}
