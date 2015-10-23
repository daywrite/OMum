using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Auditing;
using OMum.Initialize;

namespace OMum.ModelConfiguration
{
    public class AuditLogConfiguration : EntityConfigurationBase<AuditLog, long>
    {
        public AuditLogConfiguration()
        {
            ToTable("a_auditlog");
        }
    }
}