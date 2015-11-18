using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace OMum.EntityFramework.Repositories
{
    public abstract class OMumRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<OMumDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected OMumRepositoryBase(IDbContextProvider<OMumDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
        //public async Task<TEntity> GetEntityBySql(string sql)
        //{
        //    return await Context.Database.SqlQuery<TEntity>(sql).FirstOrDefaultAsync();
        //}
    }

    public abstract class OMumRepositoryBase<TEntity> : OMumRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected OMumRepositoryBase(IDbContextProvider<OMumDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
