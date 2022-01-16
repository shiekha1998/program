using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;

namespace MyDemo.Model
{
    /// <summary>
    /// Entity class to map with classes table in sqlite
    /// </summary>
    public class Classes
    {
        /// <summary>
        /// Property mapping mapping to id column
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Property mapping to class_name column
        /// </summary>
        [MaxLength(50)]
        public string? ClassName { get; set; }
        /// <summary>
        /// Property mapping to created_on column
        /// </summary>
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// Property mapping to updated_on column
        /// </summary>
        public DateTime UpdatedOn { get; set; } = System.DateTime.UtcNow;
        /// <summary>
        /// Return the list of Students associated with a classes id
        /// </summary>
        public List<Students>? Students { get; set; }

        
    }
}
