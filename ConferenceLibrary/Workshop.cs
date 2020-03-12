using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConferenceLibrary
{
    public class Workshop : IFileWork, IDisplayMethod
    {
        public string WorkShopTitle { get; set; }
        public int SeatsAvaillable;
        public string DateTimes;
        public DateTime DateTime = new DateTime();
        private List<Workshop> Workshops = new List<Workshop>();
        private List<List<Person>> PeopleInWorkshop = new List<List<Person>>();
        private List<Person> Organzier = new List<Person>();

        public void AddWorkshopMeeting(List<Workshop> workshops)
        {
            foreach (var workshop in workshops)
            {
                workshop.DateTime = Convert.ToDateTime(workshop.DateTimes);
                Workshops.Add(workshop);
            }
        }

        public void AddPeopleToWrokshop(List<Person> people, string workshopTitle, List<Person> organizer, string idSpeaker)
        {
            foreach (var item in organizer)
            {
                if (item.Id == idSpeaker)
                {
                    Organzier.Add(item);
                }
            }
            for (int i = 0; i < Workshops.Count; i++)
            {
                if (Workshops[i].WorkShopTitle.Contains(workshopTitle))
                {
                    try
                    {
                        PeopleInWorkshop.Add(people);
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
            for (int i = 0; i < Workshops.Count; i++)
            {
                int nr = 1;
                Console.WriteLine();
                Console.WriteLine($"   {i + 1} Subject: << {Workshops[i].WorkShopTitle.ToUpper()} >> {Workshops[i].DateTime} Seats: {Workshops[i].SeatsAvaillable}");
                try
                {
                    Console.WriteLine($" Speaker: {Organzier[i].FullName} #{Organzier[i].Id}");
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
                    foreach (var person in PeopleInWorkshop[i])
                    {
                        if (nr <= Workshops[i].SeatsAvaillable)
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

        public void ReadFromFile(string filePath)
        {
            try
            {
                List<string> lines = File.ReadAllLines(@filePath).ToList();

                foreach (var line in lines)
                {
                    string[] fields = line.Split(',');
                    Workshop workshop = new Workshop();
                    workshop.WorkShopTitle = fields[0];
                    workshop.SeatsAvaillable = int.Parse(fields[1]);
                    workshop.DateTimes = fields[2];
                    workshop.DateTime = Convert.ToDateTime(workshop.DateTimes);
                    Workshops.Add(workshop);
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
            for (int i = 0; i < Workshops.Count - 1; i++)
            {
                output.Add($"{Workshops[i].WorkShopTitle},{Workshops[i].SeatsAvaillable},{Workshops[i].DateTime}");
                foreach (var person in PeopleInWorkshop[i])
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
