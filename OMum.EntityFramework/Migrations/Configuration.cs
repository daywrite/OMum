using System.Data.Entity.Migrations;
using OMum.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace OMum.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<OMum.EntityFramework.OMumDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "OMum";
        }

        protected override void Seed(OMum.EntityFramework.OMumDbContext context)
        {
            context.DisableAllFilters();
            new InitialDataBuilder(context).Build();
        }
    }
}
