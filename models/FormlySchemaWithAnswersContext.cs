using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace jsonWebApiProject
{
    public class FormlySchemaWithAnswersContext : DbContext
    {
        
        public FormlySchemaWithAnswersContext(DbContextOptions<FormlySchemaWithAnswersContext> options)
            : base(options)
        {
        }

        public DbSet<FormlySchemaWithAnswers> FormlySchemaWithAnswers { get; set; }

}
}