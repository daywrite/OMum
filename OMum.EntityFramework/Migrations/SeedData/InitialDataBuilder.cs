using OMum.EntityFramework;

namespace OMum.Migrations.SeedData
{
    public class InitialDataBuilder
    {
        private readonly OMumDbContext _context;

        public InitialDataBuilder(OMumDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            new DefaultTenantRoleAndUserBuilder(_context).Build();
        }
    }
}
