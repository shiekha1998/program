using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;

namespace MyDemo.Model
{
    /// <summary>
    /// Entity class to map with countries table in sqlite
    /// </summary>
    public class Countries
    {
        /// <summary>
        /// Property mapping to id column
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Property mapping to name column
        /// </summary>
        [MaxLength(50)]
        public string? Name { get; set; }
        /// <summary>
        /// Property mapping to created_on column
        /// </summary>
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// Property mapping to updated_on column
        /// </summary>
        public DateTime UpdatedOn { get; set; } = System.DateTime.UtcNow;
        /// <summary>
        /// Return the list of Students associated with a country id.
        /// </summary>
        public List<Students>? Students { get; set; }

    }
}
