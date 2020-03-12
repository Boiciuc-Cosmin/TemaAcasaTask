using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConferenceLibrary
{
    public class Attendees : IFileWork, IDisplayMethod
    {
        public List<Person> People = new List<Person>();
        private Random Random = new Random();

        public void AddPeople(List<Person> people)
        {
            foreach (var person in people)
            {
                People.Add(person);
                int random = Random.Next(1000, 10000);
                if (random != person.PayedNumber && person.HasPaid)
                {
                    person.PayedNumber = random;
                }
            }
        }

        public void DisplayAllMembers()
        {
            Console.WriteLine("\tAttendees");
            Console.WriteLine($"   ID    PayID \tName");
            foreach (var person in People)
            {
                Console.WriteLine($"   #{person.Id}  {person.PayedNumber}  \t{person.FullName} {person.HasPaid}");
            }
        }

        public void SelectPersonById(string id)
        {
            var personById = from person in People
                             where person.Id == id
                             select person;

            foreach (var personBy in personById)
            {
                Console.WriteLine($"   {personBy.Id}  {personBy.PayedNumber}  \t{personBy.FullName}");
            }
        }

        public void ReadFromFile(string filePath)
        {
            try
            {
                List<string> lines = File.ReadAllLines(@filePath).ToList();

                foreach (var line in lines)
                {
                    string[] fields = line.Split(',');
                    Person newPerson = new Person();
                    newPerson.Id = fields[0];
                    newPerson.FirstName = fields[1];
                    newPerson.LastName = fields[2];
                    int payed = int.Parse(fields[4]);
                    if (fields[3].ToUpper() == "TRUE")
                    {
                        newPerson.HasPaid = true;
                        newPerson.PayedNumber = payed;
                    }
                    else if (fields[3].ToUpper() == "FALSE")
                    {
                        newPerson.HasPaid = false;
                    }
                    People.Add(newPerson);
                }
            }
            catch (Exception)
            {
                throw new FileNotFoundException();
            }
        }

        public void WriteToFile(string filePath)
        {
            List<string> output = new List<string>();
            foreach (var person in People)
            {
                output.Add($"{person.Id},{person.FullName},{person.HasPaid},{person.PayedNumber}");
            }
            Console.WriteLine("Writing data to file...");
            try
            {
                File.WriteAllLines(@filePath, output);
                Console.WriteLine("All entries written");
            }
            catch (Exception)
            {
                throw new InvalidCastException();
            }
        }
    }
}