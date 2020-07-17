using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFour_Repository
{
    public enum EventType
    {
        Golf,
        Bowling,
        Amusement_Park,
        Concert
    }
    public class Outings
    {
        public EventType TypeOfEvent { get; set; }
        public DateTime EventDate { get; set; }
        public int PeopleAttended { get; set; }
        public double CostPerPerson { get; set; }
        public double CostOfEvent { get; set; }
        public double CostOfAllEvents
        {
            get
            {
                return (PeopleAttended * CostPerPerson);
            }
        }
        public Outings() { }
        public Outings(EventType eventType, DateTime eventDate, int peopleAttended, double costPerPerson)
        {
            TypeOfEvent = eventType;
            EventDate = eventDate;
            PeopleAttended = peopleAttended;
            CostPerPerson = costPerPerson;
        }
    }
}

