using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class DesingTimeDbContextFactory : IDesignTimeDbContextFactory<SignalRDbContext>
    {
        public SignalRDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/SignalR"))
               .AddJsonFile("appsettings.json")
               .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            DbContextOptionsBuilder<SignalRDbContext> optionsBuilder = new();
            optionsBuilder.UseSqlServer(connectionString);
            return new SignalRDbContext(optionsBuilder.Options);
        }
    }
}
