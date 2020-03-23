using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace jsonWebApiProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<JsonSchemaContext>(opt =>
               opt.UseInMemoryDatabase("JsonSchemaList"));
               services.AddDbContext<FormlySchemaContext>(opt =>
               opt.UseInMemoryDatabase("FormlySchemaList"));
                services.AddDbContext<FormlySchemaWithAnswersContext>(opt =>
               opt.UseInMemoryDatabase("FormlySchemaWithAnswersList"));
               services.AddDbContext<StepperSchemaContext>(opt =>
               opt.UseInMemoryDatabase("StepperSchemaList"));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(builder => builder.WithOrigins("http://localhost:8100"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
