using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMum.Permissions.Dto;

namespace OMum.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        IList<PermissionDto> GetPermissions();
    }
}
