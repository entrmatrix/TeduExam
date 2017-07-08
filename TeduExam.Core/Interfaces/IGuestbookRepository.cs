using System.Collections.Generic;
using TeduExam.Core.Entities;

namespace TeduExam.Core.Interfaces
{
    public interface IGuestbookRepository : IRepository<Guestbook>
    {
        List<GuestbookEntry> ListEntries(ISpecification<GuestbookEntry> spec);
    }
}