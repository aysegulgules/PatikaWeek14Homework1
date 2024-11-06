
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using PatikaWeek14Homework1.Data.Context;
using PatikaWeek14Homework1.Data.Repositories;
using PatikaWeek14Homework1.Data.UnitOfWork;
using PatikaWeek14Homework1.User;

namespace PatikaWeek14Homework1
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
            var connectionString = builder.Configuration.GetConnectionString("default");
            builder.Services.AddDbContext<IdentityDataProtectionDbContext>(options => options.UseSqlServer(connectionString));

            var keysDirectory = new DirectoryInfo(Path.Combine(builder.Environment.ContentRootPath, "App_Data", "Keys"));

            builder.Services.AddDataProtection()
                    .SetApplicationName("PatikaWeek14Homework1")//baþka bir yere taþýndýðýnda þifreler açýlmasý için eklendi.
                    .PersistKeysToFileSystem(keysDirectory);//baþka bir yerde açýlmasý için


            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IUserService, UserManager>();

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
