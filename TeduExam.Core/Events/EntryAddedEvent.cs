using TeduExam.Core.Entities;
using TeduExam.Core.Model;

namespace TeduExam.Core.Events
{
    public class EntryAddedEvent : BaseDomainEvent
    {
        public int GuestbookId { get; set; }
        public GuestbookEntry Entry { get; set; }

        public EntryAddedEvent(int guestbookId, GuestbookEntry entry)
        {
            GuestbookId = guestbookId;
            Entry = entry;
        }
    }
}