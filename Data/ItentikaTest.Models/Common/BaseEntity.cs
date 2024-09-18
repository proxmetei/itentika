using System.ComponentModel.DataAnnotations;

namespace ItentikaTest.Models
{
    /// <summary>
    /// Base entity
    /// </summary>
    public abstract class BaseEntity
    {
        [Key]
        public virtual Guid Id { get; set; } = Guid.NewGuid();
    }
}
