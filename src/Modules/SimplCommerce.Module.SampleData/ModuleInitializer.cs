using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using SimplCommerce.Infrastructure.Modules;
using SimplCommerce.Module.SampleData.Data;
using SimplCommerce.Module.SampleData.Services;

namespace SimplCommerce.Module.SampleData
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ISqlRepository, SqlRepository>();
            services.AddTransient<ISampleDataService, SampleDataService>();
            services.AddTransient<IImportDataService, ImportDataService>();
            var scope = services.BuildServiceProvider();
            var config = scope.GetService<IConfiguration>();
            services.AddScoped<IDbConnection>(db => new SqlConnection(config.GetConnectionString("SpiderConnection")));

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

        }
    }
}
