using IdeaManager.Data.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace IdeaManager.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<IdeaDbContext>
    {
        public IdeaDbContext CreateDbContext(string[] args)
        {
            var dbPath = Path.GetFullPath("ideas_fixed.db");
        


            //Verifier 
            Console.WriteLine(">>> DB utilisé = " + dbPath);
            var optionsBuilder = new DbContextOptionsBuilder<IdeaDbContext>();

            optionsBuilder.UseSqlite($"Data Source={dbPath}");
            return new IdeaDbContext(optionsBuilder.Options);
        }
    }
}
