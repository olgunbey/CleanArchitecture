using Application.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Persistance
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services,string connectionString)
        {
            services.AddDbContext<AppDbContext>(y => y.UseSqlServer(connectionString));

            services.AddScoped<IApplicationDbContext,AppDbContext>();
            services.AddScoped(typeof(ICommandApplicationDbContext<>), typeof(CommandDbContext<>));
        }
    }
}
