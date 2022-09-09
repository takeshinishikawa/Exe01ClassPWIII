using PWIII.Core.Inteface;
using PWIII.Core.Service;
using PWIII.Filters;
using PWIII.Infra.Data.Repository;

namespace PWIII
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            

            builder.Services.AddScoped<ICadastroService, CadastroService>();
            builder.Services.AddScoped<ICadastroRepository, CadastroRepository>();
            builder.Services.AddScoped<ValidateCpfExistsActionFilter>();
            builder.Services.AddScoped<IsRegisteredActionFilter>();
            builder.Services.AddScoped<ValidateCpfExistsDeleteActionFilter>();

            

            builder.Services.AddMvc(options =>
            {
                options.Filters.Add<LogAuthorizationFilter>();
                options.Filters.Add<LogResourceFilter>();
                options.Filters.Add<LogActionFilter>();
                options.Filters.Add<LogResultFilter>();
                options.Filters.Add<GeneralExceptionFilter>();
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}