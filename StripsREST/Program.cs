using StripsBL.Interfaces;
using StripsBL.Managers;
using StripsDL.Repositories;

namespace StripsREST
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Strips;Integrated Security=True;TrustServerCertificate=True"; ;
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            
            builder.Services.AddControllers();
            builder.Services.AddScoped<IStripsRepository>(r => new StripsRepository(connectionString)); // Assuming StripsRepository implements IStripsRepository
            builder.Services.AddScoped<StripsManager>();
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}