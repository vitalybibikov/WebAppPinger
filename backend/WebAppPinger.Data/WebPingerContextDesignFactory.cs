using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace WebAppPinger.Data
{
    public class WebPingerContextDesignFactory : IDesignTimeDbContextFactory<WebPingerDbContext>
    {
        private IConfigurationRoot configuration;
        private string MainProject = "WebAppPinger";

        public WebPingerDbContext CreateDbContext(string[] args)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (String.IsNullOrEmpty(env))
            {
                throw new ArgumentException("Set ASPNETCORE_ENVIRONMENT env variable first.");
            }
            var path = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            path = Path.Combine(path, MainProject);
            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env}.json",
                    optional: true);

            configuration = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<WebPingerDbContext>();
            optionsBuilder.UseSqlServer(
                configuration.GetSection("AppSettings:ConnectionString").Value,
                m => { m.EnableRetryOnFailure(); }
            );

            return new WebPingerDbContext(optionsBuilder.Options);
        }
    }
}