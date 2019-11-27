using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Repository.Factory
{
    public class TrabaIoContextFactory : IDesignTimeDbContextFactory<TrabaIoContext>
    {
        public TrabaIoContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TrabaIoContext>();
            optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("MAIN_CONNECTION_STRING") ?? "User ID=postgres;Password=21101974;Host=localhost;Port=5432;Database=trabaio;");

            return new TrabaIoContext(optionsBuilder.Options);

        }
    }
}