using FluentNHibernate;
using FluentNHibernate.Automapping;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.InfrastructureRepository
{
    public class NHAutomappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            bool shouldMap = typeof(Entity).IsAssignableFrom(type);
            return shouldMap;
        }

        public override bool ShouldMap(Member member)
        {
            bool shouldMap = base.ShouldMap(member) && member.CanWrite &&
                !member.MemberInfo.IsDefined(typeof(NotMappedAttribute), false);
            return shouldMap;
        }

        public override bool IsComponent(Type type)
        {
            return Attribute.GetCustomAttribute(type, typeof(ValueObjectAttribute)) != null;
        }
    }
}
