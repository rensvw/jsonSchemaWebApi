using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace jsonWebApiProject
{
    public class FormlySchemaContext : DbContext
    {
        
        public FormlySchemaContext(DbContextOptions<FormlySchemaContext> options)
            : base(options)
        {
        }

        public DbSet<FormlySchema> FormlySchema { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
     }
}
}