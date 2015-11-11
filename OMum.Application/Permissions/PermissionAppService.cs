using Abp.Authorization;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace OMum.Permissions
{
    [AbpAuthorize]
    public class PermissionAppService : OMumAppServiceBase, IPermissionAppService
    {

        public PermissionAppService()
        {

        }

        public IList<Dto.PermissionDto> GetPermissions()
        {
            var results = new List<Dto.PermissionDto>();
            PermissionManager.GetAllPermissions(!PermissionChecker.IsGranted("Administration.TenantManagement.SuperOwner")).ToList().ForEach(p =>
            {
                results.Add(new Dto.PermissionDto()
                {
                    Id = p.Name,
                    Parent = p.Parent != null ? p.Parent.Name : "#",
                    Text = L(p.Name),
                    IsGrantedByDefault = p.IsGrantedByDefault,
                    Icon = "default"
                });

            });
            return results;
        }
    }
}
