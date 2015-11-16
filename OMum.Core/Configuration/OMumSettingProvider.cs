using System;
using System.Collections.Generic;
using Abp.Configuration;

namespace OMum.Configuration
{
    public class OMumSettingProvider : SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new[]
            {
                new SettingDefinition(
                    OMumSettingNames.MaxAllowedEventRegistrationCountInLast30DaysPerUser,
                    defaultValue: "10",
                    scopes: SettingScopes.Tenant),
            };
        }
    }
}
