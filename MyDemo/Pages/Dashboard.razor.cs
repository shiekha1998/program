using BlazorProducts.Server.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using MyDemo.Data;
using MyDemo.Model;

namespace MyDemo.Pages

{
    /// <summary>
    /// Code Behind class for Dashboard page. 
    /// </summary>
    public partial class Dashboard : ComponentBase
    {
        /// <summary>
        /// Entity framewrok DatabaseContext factory object.
        /// </summary>
        [Inject]
        IDbContextFactory<DataContext> ContextFactory { get; set; }
        
        /// <summary>
        /// Collection of countries
        /// </summary>
        private List<Countries> LstCountries = new();
        /// <summary>
        /// Collection of Classes
        /// </summary>
        private List<Classes> LstClasses = new();
        /// <summary>
        /// Collection of Students
        /// </summary>
        private List<Students> LstStudents = new();
        /// <summary>
        /// Countries entity object
        /// </summary>
        private Countries Countries { get; set; } = new();
        /// <summary>
        /// List having total counts of student for all classes
        /// </summary>
        List<double>DataClasses = new List<double>();
        /// <summary>
        /// List having all the classes name. 
        /// </summary>
        List<string> LabelsClasses = new List<string>();
        /// <summary>
        /// List having total counts of student for all countries
        /// </summary>
        List<double> DataCountries = new List<double>();
        /// <summary>
        /// List having all countries name. 
        /// </summary>
        List<string> LabelsCountries= new List<string>();
        /// <summary>
        /// Property showing average age of student. 
        /// </summary>
        int AverageAge = 0;
        /// <summary>
        /// Method to fill the dataset for filling the Student Counts per Class report
        /// </summary>
        protected void RenderStudentCountPerClass()
        {
            
          
            
            foreach (Classes InnerClasses in LstClasses)
            {
                if (InnerClasses.Students != null && InnerClasses.Students.Count > 0)
                {

                    DataClasses.Add( InnerClasses.Students != null ? InnerClasses.Students.Count():0);
                    LabelsClasses.Add(InnerClasses.ClassName != null ? InnerClasses.ClassName+"- Total Students:"+ InnerClasses.Students.Count() : "" );
                   
                }
            }
            

        }
        /// <summary>
        /// Method to fill the dataset for filling the Student Count per Countries report
        /// </summary>
        protected void RenderStudentCountPerCountry()
        {



            foreach (Countries Countries in LstCountries)
            {
                if (Countries.Students != null && Countries.Students.Count > 0)
                {

                    DataCountries.Add(Countries.Students != null ? Countries.Students.Count() : 0);
                    LabelsCountries.Add(Countries.Name != null ? Countries.Name + "- Total Students:" + Countries.Students.Count() : "");

                }
            }


        }
        /// <summary>
        /// Mehtod to fetch the average age of student. 
        /// </summary>
        protected void RenderAverageAgeStudent()
        {

            int TotalAge = 0;
           

            foreach (Students Students in LstStudents)
            {
                int StudentAge = CalculateDateDifference(DateTime.UtcNow, Students.DateOfBirth);
                TotalAge = TotalAge + StudentAge;

            }
            AverageAge = TotalAge / LstStudents.Count();




        }
        /// <summary>
        /// Helper class the calculae the difference of Two dates in years. 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        protected int CalculateDateDifference(DateTime start, DateTime end)
        {

            DateTime zeroTime = new DateTime(1, 1, 1);

           

            TimeSpan span = start - end;
            // Because we start at year 1 for the Gregorian
            // calendar, we must subtract a year here.
            int years = (zeroTime + span).Year - 1;
            return years;
        }
        /// <summary>
        /// Method which will load at the time of Dashobard component load and will render all the helping data. 
        /// </summary>
        protected override void  OnInitialized()
        {
            
            using (var DataContext = ContextFactory.CreateDbContext())
            {
                CountriesRepository CountriesRepository = new CountriesRepository(DataContext);
                LstCountries = CountriesRepository.GetList();
            }
            using (var DataContext = ContextFactory.CreateDbContext())
            {
                ClassesRepository ClassesRepository = new ClassesRepository(DataContext);
                LstClasses = ClassesRepository.GetList();
            }
            using (var DataContext = ContextFactory.CreateDbContext())
            {
                StudentsRepository StudentsRepository = new StudentsRepository(DataContext);
                LstStudents = StudentsRepository.GetList();
            }
            RenderStudentCountPerClass();
            RenderStudentCountPerCountry();
            RenderAverageAgeStudent();
        }
       



    }

}
