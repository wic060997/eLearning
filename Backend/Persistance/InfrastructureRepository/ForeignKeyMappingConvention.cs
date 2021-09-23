using FluentNHibernate;
using FluentNHibernate.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.InfrastructureRepository
{
    public class ForeignKeyMappingConvention : ForeignKeyConvention
    {
        protected override string GetKeyName(Member property, Type type)
        {
            if (property == null)
                return type.Name + "Id";

            return property.Name + "Id";
        }
    }
}
