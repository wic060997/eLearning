using Autofac;
using Backend.Infrastructure.Security;
using Infrastructure;
using Infrastructure.Security;
using Infrastructure.Transactions;
using Microsoft.Extensions.Logging;
using Model.InfrastructureModel.Security;
using NLog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Autofac
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Register authentication service
            builder.RegisterType<RestAuthenticationService>().As<IAuthenticationService>()
              .InstancePerLifetimeScope();

            // Register transaction interceptor
            builder.Register(c => new TransactionInterceptor())
              .InstancePerDependency();

            // Register password hasher
            builder.RegisterType<Md5PasswordHasher>().As<IPasswordHasher>()
              .InstancePerLifetimeScope();

            builder.RegisterType<ClaimsService>().As<IClaimsService>()
             .InstancePerLifetimeScope();

            //builder.RegisterType<CacheHelper>().As<ICacheHelper>()
            //  .SingleInstance();

            builder.RegisterType<TokenService>().AsSelf()
              .SingleInstance();

            builder.RegisterInstance(new NLogLoggerFactory())
                      .As<ILoggerFactory>();
        }
    }
}
