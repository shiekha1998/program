using Microsoft.EntityFrameworkCore;
using MyDemo.Model;

namespace MyDemo.Data
{
    /// <summary>
    /// Database Context class having all the entities registered for the sqlite database
    /// </summary>
    public class DataContext: DbContext
    {
        /// <summary>
        /// Constructure to register the DatabaseContext as a service in Project. 
        /// </summary>
        /// <param name="options"></param>
        public DataContext(DbContextOptions options):base(options)
        {
            this.Database.EnsureCreated();
        }
        /// <summary>
        /// DbSet to map with classes table. 
        /// </summary>
        public DbSet<Classes> Classes { get; set; }
        /// <summary>
        /// DbSet to map with countries tables
        /// </summary>
        public DbSet<Countries> Countries { get; set; }
        /// <summary>
        /// DbSet to map with students table. 
        /// </summary>
        public DbSet<Students> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
        }

    }
}
