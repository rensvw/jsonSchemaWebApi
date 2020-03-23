using System;
using Microsoft.EntityFrameworkCore;

namespace jsonWebApiProject
{
    public class StepperSchemaContext : DbContext
    {
        
        public StepperSchemaContext(DbContextOptions<StepperSchemaContext> options)
            : base(options)
        {
        }

        public DbSet<StepperSchema> JsonSchema { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      
    }
    }
}