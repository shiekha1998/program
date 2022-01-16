using BlazorProducts.Server.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using MyDemo.Data;
using MyDemo.Model;

namespace MyDemo.Pages

{
    /// <summary>
    /// Code Behind class for Contact page.
    /// </summary>
    public partial class Class : ComponentBase
    {
        /// <summary>
        /// Entity framewrok DatabaseContext factory object.
        /// </summary>
        [Inject]
        IDbContextFactory<DataContext> ContextFactory { get; set; }
    
        
        
        /// <summary>
        /// Object to store the collection of classes
        /// </summary>
        private List<Classes> LstClasses = new();
        /// <summary>
        /// Classes Object to store the add/edit classes data.
        /// </summary>
        private Classes Classes { get; set; } = new();

        /// <summary>
        /// Method which will initialized when component will load. 
        /// </summary>
        protected override void  OnInitialized()
        {
            
            using (var DataContext = ContextFactory.CreateDbContext())
            {
                ClassesRepository ClassesRepository = new ClassesRepository(DataContext);
                LstClasses=  ClassesRepository.GetList();
            }
            
        }
        /// <summary>
        /// Handler to manage the add/edit operations for Classes entity. 
        /// </summary>
        protected async void HandleValidSubmit()
        {
            using (var DataContext = ContextFactory.CreateDbContext())
            {
                ClassesRepository ClassesRepository = new ClassesRepository(DataContext);
                await ClassesRepository.AddEditEntity(Classes);
                LstClasses = ClassesRepository.GetList();
                Classes = new();
                StateHasChanged();
                
            }

        }
        
        /// <summary>
        /// Method to create the fake classess inside database. 
        /// </summary>
        /// <returns></returns>
        protected async Task CreateFakeClasses()
        {
           
            using (var DataContext = ContextFactory.CreateDbContext())
            {
                ClassesRepository ClassesRepository = new ClassesRepository(DataContext);
                for (int i = 0; i < 20; i++)
                {
                    Classes Classes = new Classes();
                    Classes.ClassName = "Class" + (i + 1);
                    
                    await ClassesRepository.AddEditEntity(Classes);
                    LstClasses = ClassesRepository.GetList();
                    Classes = new();
                    StateHasChanged();

                }

            }
        
        }
        /// <summary>
        /// Method to edit a record of Classes entity. 
        /// </summary>
        /// <param name="id"></param>
        protected  void Edit(int id)
        {
            using (var DataContext = ContextFactory.CreateDbContext())
            {
                ClassesRepository ClassesRepository = new ClassesRepository(DataContext);
                Classes = ClassesRepository.FindEntity(id);
                StateHasChanged();

            }

        }
        /// <summary>
        /// Method to delete a record from classes entity. 
        /// </summary>
        /// <param name="id"></param>
        protected void Delete(int id)
        {
            using (var DataContext = ContextFactory.CreateDbContext())
            {
                ClassesRepository ClassesRepository = new ClassesRepository(DataContext);
                ClassesRepository.RemoveEntity(ClassesRepository.FindEntity(id));
                LstClasses = ClassesRepository.GetList();
                StateHasChanged();
            }

        }



    }

}
