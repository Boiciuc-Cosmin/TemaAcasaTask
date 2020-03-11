using System.Collections.Generic;
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
                new Talks {Subjects = "All about C#", SeatsAvaillable = 2, Datetimes = "3/10/2020 11:10"},
                new Talks {Subjects = "All about python", SeatsAvaillable = 10, Datetimes = "7/10/2020 4:10"},
                new Talks {Subjects = "All about ciste", SeatsAvaillable = 30, Datetimes = "7/10/2020 4:10"}
            };
          

            var speakers = new Speakers();
            var attendees = new Attendees();
            var talks = new Talks();         
                   
            speakers.ReadFromFile("Data\\Speakers.csv");
            speakers.DisplayAllMembers();
            speakers.WriteToFile("Data\\DataSpeakers.csv");

            attendees.ReadFromFile("Data\\DataAttendees.csv");
            attendees.AddPeople(persons);              
            attendees.DisplayAllMembers();           
            attendees.WriteToFile("Data\\Attendees.csv");

            talks.AddTalkMeeting(talks1);

            talks.AddPeopleToTalk(persons, "python", speakers.SpeakersList, "603");            
            talks.AddPeopleToTalk(attendees.People, "C#", speakers.SpeakersList, "546");           
            talks.AddPeopleToTalk(attendees.People, "ciste", speakers.SpeakersList, "622");
            talks.AddPeopleToTalk(attendees.People, "ciste", speakers.SpeakersList, "660");
            talks.AddPeopleToTalk(attendees.People, "ciste", speakers.SpeakersList, "641");
           

            talks.ReadFromFile("Data\\DataTalks.csv");
            talks.DisplayAllMembers();

            talks.DisplayOneTalk(1);

            talks.WriteToFile("Data\\Talks.csv");






        }
    }
}
