using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace OMum.Animals
{
    public interface IAnimalRepository :IRepository<Animal>
    {
        Task<List<Animal>> GetAnimalBySql(string sql);
    }
}
