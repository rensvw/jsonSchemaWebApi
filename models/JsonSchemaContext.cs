using System;
using Microsoft.EntityFrameworkCore;

namespace jsonWebApiProject
{
    public class JsonSchemaContext : DbContext
    {
        
        public JsonSchemaContext(DbContextOptions<JsonSchemaContext> options)
            : base(options)
        {
        }

        public DbSet<JsonSchema> JsonSchema { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Schema>()
            .Property(e => e.Required)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
    }
    }
}