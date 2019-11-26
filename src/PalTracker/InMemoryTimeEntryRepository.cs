using System;
using System.Collections.Generic;
using System.Linq;

namespace PalTracker
{
    public class InMemoryTimeEntryRepository : ITimeEntryRepository
    {
        private readonly IDictionary<long,TimeEntry> repo = new Dictionary<long, TimeEntry>();

        public bool Contains(long id) => repo.ContainsKey(id);

        public TimeEntry Create(TimeEntry timeEntry)
        {
           var count  = repo.Keys.Count()+1;
           timeEntry.Id = count;
           repo.Add(count,timeEntry);
           return repo[count];
        }

        public void Delete(long id) => repo.Remove(id);

        public TimeEntry Find(long id)=> repo[id];
        public IEnumerable<TimeEntry> List()=> repo.Values.ToList();

        public TimeEntry Update(long id, TimeEntry timeEntry)
        {
            timeEntry.Id = id;
            repo[id] = timeEntry;
            return timeEntry;
        }
    }
}