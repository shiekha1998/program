

using MyDemo.Data;
using MyDemo.Model;

namespace BlazorProducts.Server.Repository
{
    /// <summary>
    /// Repossitory class having CRUD methods implementation for Students entity. 
    /// </summary>
    public class StudentsRepository
    {
        /// <summary>
        /// DatabaseContext object
        /// </summary>
        private readonly DataContext Context;

        /// <summary>
        /// Repository Construcutor to assign the database context for operations
        /// </summary>
        /// <param name="context"></param>
        public StudentsRepository(DataContext Context)
        {
            this.Context = Context;
        }
        /// <summary>
        /// Method to add/edit entity of type Students 
        /// </summary>
        /// <param name="Students"></param>
        /// <returns></returns>
        public async Task AddEditEntity(Students Students)
        {
            if (Students.Id == 0)
            {
                Students.CreatedOn = System.DateTime.UtcNow;
                Students.UpdatedOn = System.DateTime.UtcNow;
                this.Context.Entry(Students.ClassId).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                this.Context.Entry(Students.CountryId).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                await this.Context.Students.AddAsync(Students);
                this.Context.SaveChanges();
            }
            else
            {
                Students.UpdatedOn = System.DateTime.UtcNow;
                this.Context.Entry(Students.ClassId).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                this.Context.Entry(Students.CountryId).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                this.Context.Entry(Students).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.Context.SaveChanges();
            }

           

           
        }
        /// <summary>
        /// Method to find the Students entity by id provided. 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Students FindEntity(int Id)
        {
            //  return await _context.Set<T>().Add(t);
            return this.Context.Students.Find(Id);


        }
        /// <summary>
        /// Get the List of Students. 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Students> GetList()
        {
            return this.Context.Students.ToList();
        }
        /// <summary>
        /// Method to remove the Students entity. 
        /// </summary>
        /// <param name="Students"></param>
        public void RemoveEntity(Students Students)
        {
            this.Context.Students.Remove(Students);
            this.Context.SaveChanges();
        }
    }
}
