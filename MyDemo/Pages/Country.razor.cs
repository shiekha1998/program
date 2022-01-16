using BlazorProducts.Server.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using MyDemo.Data;
using MyDemo.Model;

namespace MyDemo.Pages

{
    /// <summary>
    /// Code Behind class for Countries page
    /// </summary>
    public partial class Country : ComponentBase
    {
        /// <summary>
        /// Entity framewrok DatabaseContext factory object.
        /// </summary>
        [Inject]
        IDbContextFactory<DataContext> ContextFactory { get; set; }
    
        
       /// <summary>
       /// Collection of Countries
       /// </summary>
        private List<Countries> LstCountries = new();
        /// <summary>
        /// Countries entity class object. 
        /// </summary>
        private Countries Countries { get; set; } = new();

        /// <summary>
        /// Method will be called when the component will be initialized. 
        /// </summary>
        protected override void  OnInitialized()
        {
            
            using (var DataContext = ContextFactory.CreateDbContext())
            {
                CountriesRepository CountriesRepository = new CountriesRepository(DataContext);
                LstCountries = CountriesRepository.GetList();
            }
            
        }
        /// <summary>
        /// Handler method for add/edit countries entity submission. 
        /// </summary>
        protected async void HandleValidSubmit()
        {
            using (var DataContext = ContextFactory.CreateDbContext())
            {
                CountriesRepository CountriesRepository = new CountriesRepository(DataContext);
                await CountriesRepository.AddEditEntity(Countries);
                LstCountries = CountriesRepository.GetList();
                Countries = new();
                StateHasChanged();
                
            }

        }
        /// <summary>
        /// Method to load the Countries record to edit in context. 
        /// </summary>
        /// <param name="id"></param>
        protected  void Edit(int id)
        {
            using (var DataContext = ContextFactory.CreateDbContext())
            {
                CountriesRepository CountriesRepository = new CountriesRepository(DataContext);
                Countries = CountriesRepository.FindEntity(id);
                StateHasChanged();

            }

        }
        /// <summary>
        /// Method to delete the Countries entity from database
        /// </summary>
        /// <param name="id"></param>
        protected void Delete(int id)
        {
            using (var DataContext = ContextFactory.CreateDbContext())
            {
                CountriesRepository CountriesRepository = new CountriesRepository(DataContext);
                CountriesRepository.RemoveEntity(CountriesRepository.FindEntity(id));
                LstCountries = CountriesRepository.GetList();
                StateHasChanged();
            }

        }

        protected async Task CreateFakeCountries()
        {

            using (var DataContext = ContextFactory.CreateDbContext())
            {
                CountriesRepository CountriesRepository = new CountriesRepository(DataContext);
                for (int i = 0; i < 100; i++)
                {
                    Countries Countries = new Countries();
                    Countries.Name = Faker.Country.Name();

                    await CountriesRepository.AddEditEntity(Countries);
                    LstCountries = CountriesRepository.GetList();
                    
                    StateHasChanged();

                }

            }

        }



    }

}
