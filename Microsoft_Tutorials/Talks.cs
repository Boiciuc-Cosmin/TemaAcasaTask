using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task
{
    public class Talks : IFileWork
    {
        public string Subjects { get; set; }
        public int SeatsAvaillable;
        public string Datetimes;
        DateTime dateTime = new DateTime();
        private List<Talks> Talk = new List<Talks>();
       
       
        
        public void AddTalkMeeting(List<Talks> talks)
        {            
            foreach (var talk in talks)
            {
                talk.dateTime = Convert.ToDateTime(talk.Datetimes);
                Talk.Add(talk);
            }
        }    
        public void Add()
        {
            Attendees attendees = new Attendees();
            var filter = from person in attendees.People
                         select person;
           
            
                           
        }
        public void DisplayTalk()
        {
            foreach (var talk in Talk)
            {
                Console.WriteLine(talk.dateTime + talk.Subjects + talk.SeatsAvaillable);
         
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
                    Talks talk = new Talks();
                    talk.Subjects = fields[0];
                    talk.SeatsAvaillable = int.Parse(fields[1]);               
                    dateTime = Convert.ToDateTime(fields[2]);
                    Talk.Add(talk);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void WriteToFile(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}