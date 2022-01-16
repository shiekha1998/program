

using Microsoft.EntityFrameworkCore;
using MyDemo.Data;
using MyDemo.Model;

namespace BlazorProducts.Server.Repository
{
    /// <summary>
    /// Repossitory class having CRUD methods implementation for Countries Entity
    /// </summary>
    public class CountriesRepository
    {
        /// <summary>
        /// DatabaseContext object
        /// </summary>
        private readonly DataContext Context;

        /// <summary>
        /// Repository Construcutor to assign the database context for operations
        /// </summary>
        /// <param name="context"></param>
        public CountriesRepository(DataContext Context)
        {
            this.Context = Context;
        }
        /// <summary>
        /// Add/Update the entity in specific DbSet for Countries entity. 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task AddEditEntity(Countries Countries)
        {
            if (Countries.Id == 0)
            {
                Countries.CreatedOn = System.DateTime.UtcNow;
                Countries.UpdatedOn = System.DateTime.UtcNow;
                await this.Context.Countries.AddAsync(Countries);
            }
            else
            {
                Countries.UpdatedOn = System.DateTime.UtcNow;
                this.Context.Entry(Countries).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

            this.Context.SaveChanges();

        }
        /// <summary>
        /// Method to find the Countries Entity object by provided Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Countries FindEntity(int Id)
        {
            //  return await _context.Set<T>().Add(t);
            return this.Context.Countries.Find(Id);


        }
        /// <summary>
        /// Get the list of Countries. 
        /// </summary>
        /// <returns></returns>
        public List<Countries> GetList()
        {
            return this.Context.Countries.Include(p => p.Students).ToList();
                       
        }
        /// <summary>
        /// Remove the Countries object from database
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public void RemoveEntity(Countries Countries)
        {
            this.Context.Countries.Remove(Countries);
            this.Context.SaveChanges();
        }
    }
}
