namespace Clean_Code_Services.Core.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public bool Deactivated { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedDateTime { get; set; } 
        public Guid? CreatedBy { get; set; } = Guid.Empty;
        public Guid? ModifiedBy { get; set; } = Guid.Empty;
    }
}
