using System;
using System.Linq.Expressions;
using TeduExam.Core.Entities;
using TeduExam.Core.Interfaces;

namespace TeduExam.Core.Specifications
{
    public class GuestbookWithEntriesSpec : ISpecification<Guestbook>
    {
        public Expression<Func<Guestbook, bool>> Criteria
        {
            get { return e => true; }
        }

        public Expression<Func<Guestbook, object>> Include
        {
            get { return e => e.Entries; }
        }
    }
}