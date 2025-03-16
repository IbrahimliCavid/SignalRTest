using Application.Repositories;
using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        readonly SignalRDbContext _context;

        public ReadRepository(SignalRDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if(!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public Task GetById(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();

            if(!tracking)
                query = query.AsNoTracking();

            return query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }
    }
}
