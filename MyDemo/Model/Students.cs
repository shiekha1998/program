using System.ComponentModel.DataAnnotations;

namespace MyDemo.Model
{
    /// <summary>
    /// Entity class to map with students table in sqlite
    /// </summary>
    public class Students
    {
        /// <summary>
        /// Property mapping to id column
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Property mapping to class_id column
        /// </summary>
        public Classes? ClassId { get; set; }
        /// <summary>
        /// Property mapping to country_id column
        /// </summary>
        public Countries? CountryId { get; set; }
        /// <summary>
        /// Property mapping to name column
        /// </summary>
        [MaxLength(50)]
        public string? Name { get; set; }
        /// <summary>
        /// Property mapping to date_of_birth column
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Property mapping to created_on column
        /// </summary>
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// Property mapping mapping to updated_on column
        /// </summary>
        public DateTime UpdatedOn { get; set; } = System.DateTime.UtcNow;
    }
}
