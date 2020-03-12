using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConferenceLibrary
{
    public class Talks : IFileWork, IDisplayMethod
    {
        public string Subjects { get; set; }
        public int SeatsAvaillable;
        public string Datetimes;
        private DateTime dateTime = new DateTime();
        private List<Talks> Talk = new List<Talks>();
        private List<List<Person>> People = new List<List<Person>>();
        private List<Person> Speakers = new List<Person>();

        public void AddTalkMeeting(List<Talks> talks)
        {
            foreach (var talk in talks)
            {
                talk.dateTime = Convert.ToDateTime(talk.Datetimes);
                Talk.Add(talk);
            }
        }

        public void AddPeopleToTalk(List<Person> people, string talk, List<Person> speakers, string idSpeaker)
        {
            foreach (var item in speakers)
            {
                if (item.Id == idSpeaker)
                {
                    Speakers.Add(item);
                }
            }
            for (int i = 0; i < Talk.Count; i++)
            {
                if (Talk[i].Subjects.Contains(talk))
                {
                    try
                    {
                        People.Add(people);
                    }
                    catch
                    {
                        Console.WriteLine("eroare");
                    }
                }
            }
        }

        public void DisplayAllMembers()
        {
            for (int i = 0; i < Talk.Count; i++)
            {
                int nr = 1;
                Console.WriteLine();
                Console.WriteLine($"   {i + 1} Subject: << {Talk[i].Subjects.ToUpper()} >> {Talk[i].dateTime} Seats: {Talk[i].SeatsAvaillable}");
                try
                {
                    Console.WriteLine($" Speaker: {Speakers[i].FullName} #{Speakers[i].Id}");
                }
                catch
                {
                    Console.WriteLine("Index out of Range");
                }
                Console.WriteLine();
                Console.WriteLine("   People attending to this talk:");
                Console.WriteLine($"    ID   PayID \tName");
                try
                {
                    foreach (var person in People[i])
                    {
                        if (nr <= Talk[i].SeatsAvaillable)
                        {
                            if (person.HasPaid)
                            {
                                Console.WriteLine($"{nr}   {person.Id}  {person.PayedNumber}   {person.FullName}");
                                nr++;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("   No person has register to this talk");
                }
            }
        }

        public void DisplayOneTalk(int nrTalk)
        {
            Console.WriteLine($"{Talk[nrTalk].Subjects} {Talk[nrTalk].SeatsAvaillable} {Talk[nrTalk].dateTime}");
            try
            {
                foreach (var person in People[nrTalk])
                {
                    if (person.HasPaid)
                    {
                        Console.WriteLine($" {person.Id}  {person.PayedNumber}  \t{person.FullName}");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Not enough members");
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
                    talk.Datetimes = fields[2];
                    talk.dateTime = Convert.ToDateTime(talk.Datetimes);
                    Talk.Add(talk);
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
            for (int i = 0; i < Talk.Count - 1; i++)
            {
                output.Add($"{Talk[i].Subjects},{Talk[i].SeatsAvaillable},{Talk[i].dateTime}");
                foreach (var person in People[i])
                {
                    output.Add($"{person.Id},{person.FullName}");
                }
            }
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