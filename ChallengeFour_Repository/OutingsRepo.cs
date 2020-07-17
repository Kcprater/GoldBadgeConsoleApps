using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFour_Repository
{
    public class OutingsRepo
    {
        public List<Outings> _outingsRepo = new List<Outings>();
        public bool CreateNewOuting(Outings newOuting)
        {
            int startingCount = _outingsRepo.Count;
            _outingsRepo.Add(newOuting);
            bool eventAdded = (_outingsRepo.Count > startingCount) ? true : false;
            return eventAdded;
        }
        public List<Outings> ViewAllOutings()
        {
            return _outingsRepo;
        }
        public double CostOfEvent(EventType eventType)
        {
            double eventCost = 0;
            foreach (Outings outing in _outingsRepo)
            {
                if(outing.TypeOfEvent == eventType)
                {
                    outing.CostOfEvent = outing.CostPerPerson * outing.PeopleAttended;
                    eventCost += outing.CostOfEvent;
                }
            }
            return eventCost;
        }
        public List<Outings> ViewByType(EventType eventType)
        {
            List<Outings> eventTypeList = new List<Outings>();
            foreach (Outings content in _outingsRepo)
            {
                if (content.TypeOfEvent == eventType)
                {
                    eventTypeList.Add(content);
                }
            }
            return eventTypeList;
        }
    }
}
