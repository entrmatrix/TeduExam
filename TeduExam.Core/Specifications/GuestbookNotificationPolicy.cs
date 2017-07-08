using System;
using System.Linq.Expressions;
using TeduExam.Core.Entities;
using TeduExam.Core.Interfaces;

namespace TeduExam.Core.Specifications
{
    public class GuestbookNotificationPolicy : ISpecification<GuestbookEntry>
    {
        private readonly int _entryId;

        public GuestbookNotificationPolicy(int entryId)
        {
            _entryId = entryId;
        }

        public Expression<Func<GuestbookEntry, bool>> Criteria {
            get
            {
                return e => 
                    e.DateTimeCreated > DateTimeOffset.UtcNow.AddDays(-1)
                 && e.Id != _entryId;
            }
        }

        public Expression<Func<GuestbookEntry, object>> Include
        {
            get { return e => e; }
        }
    }
}
