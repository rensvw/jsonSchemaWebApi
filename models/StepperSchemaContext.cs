using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace jsonWebApiProject
{
    public class StepperSchemaContext : DbContext
    {
        
        public StepperSchemaContext(DbContextOptions<StepperSchemaContext> options)
            : base(options)
        {
        }

        public DbSet<StepperSchema> JsonSchema { get; set; }
        
     
        
    }
}