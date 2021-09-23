using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using Infrastructure;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.SqlCommand;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using nhcfg = NHibernate.Cfg;

namespace Persistance.InfrastructureRepository
{
    public class NHibernateConfigBuilder
    {
        public readonly string connectionString;
        public readonly Assembly mappingAssembly;
        public readonly Assembly modelAssembly;

        public NHibernateConfigBuilder(
          string connectionString,
          Assembly mappingAssembly,
          Assembly modelAssembly)
        {
            this.connectionString = connectionString;
            this.mappingAssembly = mappingAssembly;
            this.modelAssembly = modelAssembly;

            ConventionBuilder.Class.Always(x => x.Table(x.EntityType.Name.ToLower()));
            ConventionBuilder.Property.Always(x => x.Column(x.Property.Name.ToLower()));

        }

        public ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
               .Database(MsSqlConfiguration.MsSql2012
                 .ConnectionString(connectionString)
                 .UseOuterJoin()
           .ShowSql()
         )
               .Mappings(m =>
                  m.AutoMappings.Add(
                    AutoMap.Assembly(modelAssembly, CreateFluentNHAutomappingConfiguration())
                      .AddEntityAssembly(typeof(AuditableEntity).Assembly)
                      .UseOverridesFromAssembly(mappingAssembly)
                      .Conventions.Setup(c =>
                      {
                          c.Add<ForeignKeyMappingConvention>();
                          c.Add(ConventionBuilder.Id.Always(x => x.GeneratedBy.Assigned()));
                      })
                  )
               )
         .ExposeConfiguration(c => c.SetInterceptor(new SqlTraceInterceptor()))
             .BuildSessionFactory();
        }

        private Configuration CreateNHibernateConfiguration()
        {
            return new Configuration()
              .SetProperty(nhcfg.Environment.CommandTimeout, "180")
              .SetProperty(nhcfg.Environment.Isolation, "ReadCommitted")
              .SetProperty(nhcfg.Environment.BatchSize, "1000");
        }

        private IAutomappingConfiguration CreateFluentNHAutomappingConfiguration()
        {
            return new NHAutomappingConfiguration();
        }


        public class SqlTraceInterceptor : EmptyInterceptor
        {
            public override SqlString OnPrepareStatement(SqlString sql)
            {
                Trace.WriteLine(sql.ToString());
                return sql;
            }
        }
    }
}
