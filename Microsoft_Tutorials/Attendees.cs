
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task
{
    public class Attendees : IAddFromFile 
    {
        public List<Person> People = new List<Person>();
        Random Random = new Random();
      
       
        public void AddPeople(List<Person> people)
        {
            foreach (var person in people)
            {
                People.Add(person);
                int random = Random.Next(1000, 10000);
                if (random != person.PayedNumber && person.HasPayed)
                {
                    person.PayedNumber = random;
                }
            }
        }
      
        public void DisplayAllPeople()
        {            
            Console.WriteLine();
            Console.WriteLine($"   ID    PayID \tName");            
            foreach (var person in People)
            {
                Console.WriteLine($"   #{person.Id}  {person.PayedNumber}  \t{person.FirstName} {person.LastName.ToUpper()} {person.HasPayed}");
            }        
        }    

        public void SelectPersonById(string id)
        {
            var personById = from person in People
                             where person.Id == id
                             select person;

            foreach (var personBy in personById)
            {
                Console.WriteLine($"   {personBy.Id}  {personBy.PayedNumber}  \t{personBy.FirstName} {personBy.LastName.ToUpper()}");
            }
        }

        public void SelectHasPayedPeople()
        {
            Console.WriteLine();
            var hasPayed = from person in People
                           where person.HasPayed == true
                           orderby person.Id ascending
                           select person;
            Console.WriteLine("Poeple who payed the entrance: ");
            Console.WriteLine($"   ID    PayID \tName");

            foreach (var people in hasPayed)
            {
                Console.WriteLine($"   #{people.Id}  {people.PayedNumber}  \t{people.FirstName} {people.LastName.ToUpper()}");
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
                    int payed = int.Parse(fields[4]);
                    if (fields[3] == "TRUE")
                    {
                        newPerson.HasPayed = true;
                        newPerson.PayedNumber = payed;
                    }
                    else if (fields[3] == "FALSE")
                    {
                        newPerson.HasPayed = false;                        
                    }                      
                    People.Add(newPerson);

                }

            }
            catch (Exception)
            {
                throw new FileNotFoundException();
            }
        }

       
    }
}
