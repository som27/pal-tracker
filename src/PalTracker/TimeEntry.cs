using System;

namespace PalTracker
{
    public class TimeEntry
    {
        public long? Id;
        public long ProjectId;
        public long UserId;
        public int Hours;
        public DateTime Date;

        public TimeEntry() { }

        public TimeEntry(long id, long projectId, long userId, DateTime date, int hours)
        {
            Id = id;
            ProjectId = projectId;
            UserId = userId;
            Hours = hours;
            Date = date;
        }

        public TimeEntry(long projectId, long userId, DateTime date, int hours)
        {
            Id = null;
            ProjectId = projectId;
            UserId = userId;
            Hours = hours;
            Date = date;
        }

        public override bool Equals(object obj)
        {
            return obj is TimeEntry entry &&
                   Id == entry.Id &&
                   ProjectId == entry.ProjectId &&
                   UserId == entry.UserId &&
                   Hours == entry.Hours &&
                   Date == entry.Date;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, ProjectId, UserId, Hours, Date);
        }
    }
}