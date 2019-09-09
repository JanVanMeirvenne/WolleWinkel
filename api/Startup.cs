
    using System;
    using Microsoft.Azure.Functions.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using server.core.interfaces;

    [assembly: FunctionsStartup(typeof(api.Startup))]

    namespace api
    {
        public class Startup : FunctionsStartup
        {
            public override void Configure(IFunctionsHostBuilder builder)
            {
               builder.Services.AddSingleton<IRepository<>>()
            }
        }
    }