using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;

namespace Task
{
    public class Speakers : IAddFromFile
    {
        
        List<Person> SpeakersList = new List<Person>();  
        public void AddSpeakers(List<Person> people)
        {
            foreach (var speaker in people)
            {
                SpeakersList.Add(speaker);
            }
        }
        public void AddSpeaker(Person person)
        {
            SpeakersList.Add(person);
           
        }
        public void DisplaySpeakers()
        {
            foreach (var speaker in SpeakersList)
            {
                Console.WriteLine($"   #{speaker.Id} \t{speaker.FirstName} {speaker.LastName.ToUpper()}");
            }          
        }

        public void AddFromFile(string filePath)
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
                    if (fields[3] == "true")
                    {
                        newPerson.HasPayed = true;
                    }
                    else if(fields[3] == "false")
                    {
                        newPerson.HasPayed = false;
                    }
                    SpeakersList.Add(newPerson);
                    
                }          
               
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
