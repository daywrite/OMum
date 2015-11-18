using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.EntityFramework;
using OMum.Animals;

namespace OMum.EntityFramework.Repositories
{
    public class AnimalRepository : OMumRepositoryBase<Animal>, IAnimalRepository
    {
        public AnimalRepository(IDbContextProvider<OMumDbContext> dbContextProvider)
            : base(dbContextProvider)
        { 
        }
        public async Task<List<Animal>> GetAnimalBySql(string sql)
        {
            return  await Context.Database.SqlQuery<Animal>(sql).ToListAsync();
        }
    }
}
