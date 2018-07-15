using StructureMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore.DataAccess
{
    public class DataAccessRegistry : Registry
    {
        public DataAccessRegistry()
        {
            Scan(s =>
            {
                s.AssemblyContainingType<DataAccessRegistry>();
                s.WithDefaultConventions();
            });

        }
    }
}
