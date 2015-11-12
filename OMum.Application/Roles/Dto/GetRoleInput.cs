﻿using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Extensions;

namespace OMum.Roles.Dto
{
    public class GetRoleInput : IInputDto, IPagedResultRequest, ISortedResultRequest, ICustomValidate
    {

        [Range(0, 1000)]
        public int MaxResultCount { get; set; }

        public int SkipCount { get; set; }

        public string Sorting { get; set; }
        /// <summary>
        /// 租户ID
        /// </summary>
        public int? TenantId { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public string RoleDisplayName { get; set; }
        public void AddValidationErrors(List<ValidationResult> results)
        {
            var validSortingValues = new[] { "CreationTime DESC" };
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "CreationTime DESC";
            }
            else
                if (!Sorting.IsIn(validSortingValues))
                {
                    results.Add(new ValidationResult("Sorting is not valid. Valid values: " + string.Join(", ", validSortingValues)));
                }
        }
    }
}

