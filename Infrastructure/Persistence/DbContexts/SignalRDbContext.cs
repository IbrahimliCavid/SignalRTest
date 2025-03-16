using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence.DbContexts
{
    public class SignalRDbContext : IdentityDbContext<User, Role, string>
    {
        public SignalRDbContext(DbContextOptions<SignalRDbContext> options) : base(options)
        {
        }

        public DbSet<Notification> Notifications { get; set; }
    }
}