using BlazorProducts.Server.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using MyDemo.Data;
using MyDemo.Model;

namespace MyDemo.Pages

{
    /// <summary>
    /// Code Behind class for Index page- run the initial setup of database table creation etc. 
    /// </summary>
    public partial class Index : ComponentBase
    {
        /// <summary>
        /// Entity framewrok DatabaseContext factory object.
        /// </summary>
        [Inject]
        IDbContextFactory<DataContext> ContextFactory { get; set; }
        /// <summary>
        /// Dumping the data on the initialization of component, like data for students,classes,countries.
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync()
        {
            
            //using (var DataContext = ContextFactory.CreateDbContext())
            //{
            //    Classes Class= new Classes { ClassName = "Nursery", CreatedOn = System.DateTime.UtcNow };
            //    Countries Country = new Countries { Name = "Inida", CreatedOn = System.DateTime.UtcNow };
                
            //    await DataContext.Classes.AddAsync(Class);
               
            //}
            
        }
       


    }

}
