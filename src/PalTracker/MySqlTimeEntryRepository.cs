using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PalTracker
{
    public class MySqlTimeEntryRepository : ITimeEntryRepository
    {
        private readonly TimeEntryContext _context;

        public MySqlTimeEntryRepository(TimeEntryContext context)
        {
            _context = context;
        }

        public TimeEntry Create(TimeEntry timeEntry)
        {
            var recordToCreate = timeEntry.ToRecord();

            _context.TimeEntryRecords.Add(recordToCreate);
            _context.SaveChanges();

            return Find(recordToCreate.Id.Value);
        }

        public TimeEntry Find(long id) => FindRecord(id).ToEntity();

        public bool Contains(long id) =>
            _context.TimeEntryRecords.AsNoTracking().Any(t => t.Id == id);

        public IEnumerable<TimeEntry> List() =>
            _context.TimeEntryRecords.AsNoTracking().Select(t => t.ToEntity());

        public TimeEntry Update(long id, TimeEntry timeEntry)
        {
            var recordToUpdate = timeEntry.ToRecord();
            recordToUpdate.Id = id;

            _context.Update(recordToUpdate);
            _context.SaveChanges();

            return Find(id);
        }

        public void Delete(long id)
        {
            _context.TimeEntryRecords.Remove(FindRecord(id));
            _context.SaveChanges();
        }

        private TimeEntryRecord FindRecord(long id) =>
            _context.TimeEntryRecords.AsNoTracking().Single(t => t.Id == id);
    }
}












// using System;
// using System.Collections.Generic;
// using System.Linq;
// using Microsoft.EntityFrameworkCore;

// namespace PalTracker
// {
//     public class MySqlTimeEntryRepository : ITimeEntryRepository
//     {
//         private readonly TimeEntryContext context;
//         public MySqlTimeEntryRepository(TimeEntryContext context)
//         {
//             this.context = context;
//         }

//         public TimeEntry Create(TimeEntry timeEntry)
//         {
//             var recordToCreate = timeEntry.ToRecord();
//             context.TimeEntryRecords.Add(recordToCreate);
//             context.SaveChanges();

//             return Find(recordToCreate.Id.Value);
//         }
//         public TimeEntry Find(long id) => FindRecord(id).ToEntity();
//         public bool Contains(long id) => context.TimeEntryRecords.AsNoTracking().Any(r=> r.Id == id);        

//         public TimeEntry Update(long id, TimeEntry timeEntry)
//         {
//             timeEntry.Id = id;
//             context.Update(timeEntry.ToRecord());
//             context.SaveChanges();
//             return Find(id);
//         }

//         public void Delete(long id)
//         {
//             context.TimeEntryRecords.Remove(FindRecord(id));
//             context.SaveChanges();
//         }

//         public IEnumerable<TimeEntry> List() =>  context.TimeEntryRecords.AsNoTracking().Select(r=>r.ToEntity());            
        

//         private TimeEntryRecord FindRecord(long id) => context.TimeEntryRecords.AsNoTracking().Single(r=>r.Id == id);

//     }

// }

