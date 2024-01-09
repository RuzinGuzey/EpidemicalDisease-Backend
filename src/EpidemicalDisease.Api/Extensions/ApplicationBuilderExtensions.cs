using EpidemicalDisease.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EpidemicalDisease.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigration(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();
        }
    }
}
