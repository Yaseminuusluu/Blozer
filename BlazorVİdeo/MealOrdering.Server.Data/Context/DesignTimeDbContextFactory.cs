using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace MealOrdering.Server.Data.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MealOrderingDbContext>
    {
        public MealOrderingDbContext CreateDbContext(string[] args)
        {
            String connectionString = "User ID=postgres;password=12345;Host=localhost;Port=5432;Database=mealordering;SearchPath=public";

            var builder = new DbContextOptionsBuilder<MealOrderingDbContext>();

            builder.UseNpgsql(connectionString);

            return new MealOrderingDbContext(builder.Options);
        }
    }
}
