using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using WebApplication1.Entities;

namespace WebApplication1.DatabaseContext
{
    public class WebAppDBContext:DbContext, IWebAppDBContext
    {
        public WebAppDBContext(DbContextOptions<WebAppDBContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }

        public Task<int> SaveChangesAsync()
        {            
            return base.SaveChangesAsync();
        }
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
       
    }    
}
