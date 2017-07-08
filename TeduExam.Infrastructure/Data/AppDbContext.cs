using TeduExam.Core.Interfaces;
using TeduExam.Core.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TeduExam.Core.Entities;
using TeduExam.Core.SharedKernel;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TeduExam.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IDomainEventDispatcher _dispatcher;

        public AppDbContext(DbContextOptions<AppDbContext> options, IDomainEventDispatcher dispatcher)
            : base(options)
        {
            _dispatcher = dispatcher;
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<Guestbook> Guestbooks { get; set; }
        public DbSet<GuestbookEntry> GuestbookEntries { get; set; }

        public override int SaveChanges()
        {
            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();
            var result = base.SaveChanges();
            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.Events.ToArray();
                entity.Events.Clear();
                foreach (var domainEvent in events)
                {
                    _dispatcher.Dispatch(domainEvent);
                }
            }
            return result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var navigation = modelBuilder.Entity<Guestbook>()
                .Metadata.FindNavigation(nameof(Guestbook.Entries));

            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            modelBuilder.Entity<ApplicationUser>().ToTable("AppUsers");

            modelBuilder.Entity<IdentityRole>().ToTable("AppRoles").HasKey(x => x.Id);

            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("AppUserClaims").HasKey(x => x.Id);

            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("AppRoleClaims")
                .HasKey(x => x.Id);

            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("AppUserRoles")
                .HasKey(x => new { x.RoleId, x.UserId });

            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("AppUserTokens")
               .HasKey(x => new { x.UserId });
        }
    }
}