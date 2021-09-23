using Autofac;
using Autofac.Extras.DynamicProxy;
using Infrastructure;
using Infrastructure.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Autofac
{
    public class ApplicationDomainModule : Module
    {
        private readonly System.Reflection.Assembly modelAssembly;

        public ApplicationDomainModule(
          System.Reflection.Assembly modelAssembly)
        {
            this.modelAssembly = modelAssembly;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(modelAssembly)
                .Where(t => t.Name.EndsWith("Factory"))
                .AsClosedTypesOf(typeof(IDomainItemFactory<>))
                .InstancePerLifetimeScope();

            // Register all domain services
            builder.RegisterAssemblyTypes(modelAssembly)
              .AssignableTo<IDomainService>()
              .As(t => t.GetInterfaces().Any() ? t.GetInterfaces().Where(i => i.Name != "IDomainService").First() : t)
              .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(modelAssembly)
            .AssignableTo<IApplicationService>()
            .As(t => t.GetInterfaces().Any() ? t.GetInterfaces().Where(i => i.Name != "IApplicationService").First() : t)
            .EnableInterfaceInterceptors()
            .InterceptedBy(typeof(TransactionInterceptor))
            .InstancePerLifetimeScope();
        }
    }
}
