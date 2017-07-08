using System.Collections.Generic;
using System.Linq;
using TeduExam.Core.Events;
using TeduExam.Core.SharedKernel;

namespace TeduExam.Core.Entities
{
    public class Guestbook : BaseEntity
    {
        public string Name { get; set; }
        private readonly List<GuestbookEntry> _entries = new List<GuestbookEntry>();
        public IEnumerable<GuestbookEntry> Entries => _entries.ToList();

        public void AddEntry(GuestbookEntry entry)
        {
            _entries.Add(entry);
            Events.Add(new EntryAddedEvent(this.Id, entry));
        }
    }
}