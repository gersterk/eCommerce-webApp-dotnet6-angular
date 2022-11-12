
using AppAPI.Application.Validators.Products;
using AppAPI.Infrastructure;
using AppAPI.Infrastructure.Filters;
using AppAPI.Infrastructure.Services.Storage.Local;
using AppAPI.Persistence;
using FluentValidation.AspNetCore;

namespace AppAPI.API
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddPersistenceService();
            builder.Services.AddInfrastructureServices();
            builder.Services.AddStorage<LocalStorage>();
            builder.Services.AddCors(options=>options.AddDefaultPolicy(policy=>
            policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod()
            ));
            //This service configure and sets CORS(cross-origin resource sharing) SAME ORIGIN POLICY

            builder.Services.AddControllers(options=>options.Filters.Add<ValidationFilter>())
                .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>
                ()).ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles(); //to use wwwroot

            app.UseCors();

            app.UseHttpsRedirection();
            

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}