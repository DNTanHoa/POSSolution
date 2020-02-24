using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace POSSolution.Application.Context
{
    public class POSContextFactory : IDesignTimeDbContextFactory<POSContext>
    {
        public POSContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                                                        .SetBasePath(Directory.GetCurrentDirectory())
                                                        .AddJsonFile("appsettings.json")
                                                        .Build();

            var connectionString = configurationRoot.GetConnectionString("POSContext");
            var optionsBuilder = new DbContextOptionsBuilder<POSContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new POSContext(optionsBuilder.Options);
        }
    }
}
