using System;
using TeduExam.Core.SharedKernel;

namespace TeduExam.Core.Entities
{
    public class GuestbookEntry : BaseEntity
    {
        public int GuestbookId { get; set; }
        public string EmailAddress { get; set; }
        public string Message { get; set; }
        public DateTimeOffset DateTimeCreated { get; set; } = DateTime.UtcNow;
    }
}