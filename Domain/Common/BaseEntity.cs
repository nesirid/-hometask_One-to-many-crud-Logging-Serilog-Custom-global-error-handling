

namespace Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool SoftDelete { get; set; }
        public DateTime CreatedData { get; set; } = DateTime.UtcNow;
    }
}
