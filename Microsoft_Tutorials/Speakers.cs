using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task
{
    public class Speakers : IFileWork, IDisplayMethod
    {
        public List<Person> SpeakersList = new List<Person>();

        public void AddSpeakers(List<Person> people)
        {
            foreach (var speaker in people)
            {
                SpeakersList.Add(speaker);
            }
        }

        public void DisplayAllMembers()
        {
            Console.WriteLine("\tSpeakers");
            Console.WriteLine("   ID \t\tName");
            foreach (var speaker in SpeakersList)
            {
                Console.WriteLine($"   #{speaker.Id} \t{speaker.FirstName} {speaker.LastName.ToUpper()}");
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
                    newPerson.HasPaid = true;
                    newPerson.PayedNumber = 2406;
                    SpeakersList.Add(newPerson);
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
            foreach (var person in SpeakersList)
            {
                output.Add($"{person.Id},{person.FirstName},{person.LastName}");
            }
            Console.WriteLine("Writing data to file...");
            try
            {
                File.WriteAllLines(@filePath, output);
                Console.WriteLine("All entries written succesfully");
            }
            catch (Exception)
            {
                throw new InvalidDataException();
            }
        }
    }
}