using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Configuration;

namespace OMum.Configuration
{
    public class MySettingProvider : SettingProvider
    {
        public const string AnimalsDefaultPageSize = "AnimalsDefaultPageSize";

        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new[]
                   {
                       new SettingDefinition(AnimalsDefaultPageSize, "10")
                   };
        }
    }
}

