using Application.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    internal sealed class AppDbContext : DbContext,IApplicationDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions):base(dbContextOptions) { }
        public IQueryable<User> User => Set<User>().AsQueryable();

        public IQueryable<Order> Order => Set<Order>().AsQueryable();

    }
}
