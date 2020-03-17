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
}
}