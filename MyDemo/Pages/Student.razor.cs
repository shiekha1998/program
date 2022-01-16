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
    public partial class Student : ComponentBase
    {
        /// <summary>
        /// Entity framewrok DatabaseContext factory object.
        /// </summary>
        [Inject]
        IDbContextFactory<DataContext> ContextFactory { get; set; }
        /// <summary>
        /// Navigation manager instance to move from one page to another.
        /// </summary>
        [Inject]
        public NavigationManager NavigationManager { get; set; }


    
       /// <summary>
       /// List Students Collection used dispaly the student grid in component.
       /// </summary>
        private List<Students> LstStudent = new();
        /// <summary>
        /// Students Entity to add/edit/delete Student entity record.
        /// </summary>
        private Students Students { get; set; } = new();
        /// <summary>
        /// Countries Entity to add/edit/delete Student entity record.
        /// </summary>
        private Countries Countries { get; set; } = new();
        /// <summary>
        /// /// <summary>
        /// Classes Entity to add/edit/delete Student entity record.
        /// </summary>
        /// </summary>
        private Classes Classes { get; set; } = new();
        /// <summary>
        /// Countries Collection used dispaly the dropdown. 
        /// </summary>
        private List<Countries> LstCountries = new();
        /// <summary>
        /// Countries Collection used dispaly the dropdown. 
        /// </summary>
        private List<Classes> LstClasses = new();
        /// <summary>
        /// Method callled on the initialization of component. 
        /// </summary>
        protected override void  OnInitialized()
        {
            
            using (var DataContext = ContextFactory.CreateDbContext())
            {
                StudentsRepository StudentsRepository = new StudentsRepository(DataContext);
                ClassesRepository ClassesRepository = new ClassesRepository(DataContext);
                CountriesRepository CountriesRepository = new CountriesRepository(DataContext);
                LstStudent = StudentsRepository.GetList();
                LstCountries = CountriesRepository.GetList();
                LstClasses = ClassesRepository.GetList();
            }
            
        }
        /// <summary>
        /// Handler methdo to manage the add/edit form of Sutdents Entity. 
        /// </summary>
        protected async void HandleValidSubmit()
        {
            using (var DataContext = ContextFactory.CreateDbContext())
            {
                StudentsRepository StudentsRepository = new StudentsRepository(DataContext);
                //using Faker.Net for Date of Birth.
                Students.DateOfBirth = Faker.Identification.DateOfBirth();
                await StudentsRepository.AddEditEntity(Students);
                Students = new();
                LstStudent = StudentsRepository.GetList();
                NavigationManager.NavigateTo("/students");


            }

        }
        /// <summary>
        /// Methdo to load the Students Entity in context which need to update. 
        /// </summary>
        /// <param name="id"></param>
        protected  void Edit(int id)
        {
            using (var DataContext = ContextFactory.CreateDbContext())
            {
                StudentsRepository StudentsRepository = new StudentsRepository(DataContext);
                Students = StudentsRepository.FindEntity(id);
                StateHasChanged();

            }

        }
        /// <summary>
        /// Delete the Students entity object from database. 
        /// </summary>
        /// <param name="id"></param>
        protected void Delete(int id)
        {
            using (var DataContext = ContextFactory.CreateDbContext())
            {
                StudentsRepository StudentsRepository = new StudentsRepository(DataContext);
                StudentsRepository.RemoveEntity(StudentsRepository.FindEntity(id));
                LstStudent = StudentsRepository.GetList();
                StateHasChanged();
            }

        }

       

    }

}
