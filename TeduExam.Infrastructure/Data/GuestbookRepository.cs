using System.Collections.Generic;
using System.Linq;
using TeduExam.Core.Entities;
using TeduExam.Core.Interfaces;
using TeduExam.Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace TeduExam.Infrastructure.Data
{
    public class GuestbookRepository : EfRepository<Guestbook>, IGuestbookRepository
    {
        public GuestbookRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override Guestbook GetById(int id)
        {
            var spec = new GuestbookWithEntriesSpec();
            return _dbContext.Guestbooks
                .Include(spec.Include)
                .FirstOrDefault(g => g.Id == id);
        }

        public List<GuestbookEntry> ListEntries(ISpecification<GuestbookEntry> spec)
        {
            return _dbContext.GuestbookEntries
                .Where(spec.Criteria)
                .ToList();
        }
    }
}