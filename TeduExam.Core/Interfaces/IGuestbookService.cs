using TeduExam.Core.Entities;

namespace TeduExam.Core.Interfaces
{
    public interface IGuestbookService
    {
        void RecordEntry(Guestbook guestbook, GuestbookEntry entry);
    }
}