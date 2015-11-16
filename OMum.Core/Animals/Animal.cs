using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using OMum.Users;

namespace OMum.Animals
{
    [Table("t_animal")]
    public class Animal : FullAuditedEntity<int, User>, IMustHaveTenant
    {
        public virtual string Name { get; set; }

        public virtual int TenantId { get; set; }
    }
}
