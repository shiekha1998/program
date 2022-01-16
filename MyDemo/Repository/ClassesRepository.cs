

using Microsoft.EntityFrameworkCore;
using MyDemo.Data;
using MyDemo.Model;

namespace BlazorProducts.Server.Repository
{
    /// <summary>
    /// Classes Repository class having CRUD methods implementation 
    /// </summary>
    public class ClassesRepository
    {
        /// <summary>
        /// DatabaseContext object
        /// </summary>
        private readonly DataContext Context;

        /// <summary>
        /// Classes Repository Construcutor to assign the database context for operations
        /// </summary>
        /// <param name="context"></param>
        public ClassesRepository(DataContext Context)
        {
            this.Context = Context;
        }
        /// <summary>
        /// Add/Update the entity in specific DbSet of Classes Entity
        /// </summary>
        /// <param name="Classes"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task AddEditEntity(Classes Classes) 
        {
            if (Classes.Id == 0)
            {
                Classes.CreatedOn = System.DateTime.UtcNow;
                Classes.UpdatedOn = System.DateTime.UtcNow;
                await this.Context.Classes.AddAsync(Classes);
            }
            else 
            {
                Classes.UpdatedOn = System.DateTime.UtcNow;
                this.Context.Entry(Classes).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

            this.Context.SaveChanges();

        }
        /// <summary>
        /// Method to find the Classes Object by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public  Classes FindEntity(int Id)
        {
            //  return await _context.Set<T>().Add(t);
           return   this.Context.Classes.Find(Id);


        }
        /// <summary>
        /// Method to list all the Classes.
        /// </summary>
        /// <returns></returns>
        public List<Classes> GetList()
        {
            return this.Context.Classes.Include(p => p.Students).ToList();
        }
         /// <summary>
         /// Method to remove the Classes Entity object 
         /// </summary>
         /// <param name="Classes"></param>
        public void RemoveEntity(Classes Classes)
        {
            this.Context.Classes.Remove(Classes);
            this.Context.SaveChanges();
        }
    }
}
