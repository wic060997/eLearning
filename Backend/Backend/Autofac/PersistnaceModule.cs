using Autofac;
using Infrastructure;
using NHibernate;
using Persistance.InfrastructureRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Autofac
{
    public class PersistnaceModule : Module
    {
        private readonly string connectionString;
        private readonly System.Reflection.Assembly persistenceAssembly;
        private readonly System.Reflection.Assembly modelAssembly;
        public PersistnaceModule(
            string connectionString,
            System.Reflection.Assembly persistenceAssembly,
            System.Reflection.Assembly modelAssembly)
        {
            this.connectionString = connectionString;
            this.persistenceAssembly = persistenceAssembly;
            this.modelAssembly = modelAssembly;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var nhConfigBuilder = new NHibernateConfigBuilder(
                connectionString,
                persistenceAssembly,
                modelAssembly);

            builder.Register(c => nhConfigBuilder.CreateSessionFactory())
                .As<ISessionFactory>()
                .SingleInstance();

            builder.Register(c => c.Resolve<ISessionFactory>()
            .WithOptions()
                .OpenSession())
            .As<ISession>()
            .InstancePerLifetimeScope();

            builder.RegisterType<NHUnitOfWork>().As<IUnitOfWork>()
            .InstancePerLifetimeScope();

            // Register all CRUD repositories from NHibernate persistence assembly
            builder.RegisterAssemblyTypes(persistenceAssembly)
              .Where(t => t.Name.EndsWith("Repository"))
              .AsClosedTypesOf(typeof(ICrudRepository<>))
              .InstancePerLifetimeScope();

            // Register all non-CRUD repositories from NHibernate persistence assembly
            builder.RegisterAssemblyTypes(persistenceAssembly)
              .Where(t => t.Name.EndsWith("Repository"))
              .AssignableTo<IRepository>()
              .AsImplementedInterfaces()
              .InstancePerLifetimeScope();
        }
    }
}
