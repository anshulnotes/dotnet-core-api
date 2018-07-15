using StructureMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore.BusinessServices
{
    public class BusinessServiceRegistry : Registry
    {
        public BusinessServiceRegistry()
        {
            Scan(s =>
            {
                s.AssemblyContainingType<BusinessServiceRegistry>();
                s.WithDefaultConventions();
            });
        }
    }
}
