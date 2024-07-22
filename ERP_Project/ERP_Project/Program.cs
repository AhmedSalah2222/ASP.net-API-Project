
using ERP_Project.Models;
using ERP_Project.Services;

namespace ERP_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.Configure<NotificationDatabaseSettings>(
                builder.Configuration.GetSection("NotificationDatabase"));
            builder.Services.AddSingleton<UsersService>();
            builder.Services.AddSingleton<NotificationsService>();
            builder.Services.AddSingleton<OrganizationsService>();
            builder.Services.AddSingleton<PermissionsService>();
            //added by me
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                    });
            });
            builder.Services.AddControllers();
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
            //added by me
            app.UseCors();
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}
