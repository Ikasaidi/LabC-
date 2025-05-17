using IdeaManager.Core.Interfaces;
using IdeaManager.Core.Entities;
using IdeaManager.Data.Db;
using IdeaManager.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IdeaManager.Data
{
    //Enregiste DBContext pour EF Core, 
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<IdeaDbContext>(options =>
                options.UseSqlite(connectionString));

            //Branche un IRepo a Generic
            services.AddScoped<IRepository<Idea>, GenericRepository<Idea>>();
            services.AddScoped<IRepository<User>, GenericRepository<User>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}