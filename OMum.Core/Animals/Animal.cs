using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using OMum.Users;

namespace OMum.Animals
{
    public class Animal : CreationAuditedEntity<int, User>
    {
        public virtual string Name { get; set; }
    }
}
