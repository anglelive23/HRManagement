using Domain.Base;

namespace Domain.Entities.Users.Events
{
    public class OnDepartmentUpdateEvent : BaseDomainEvent
    {
        public int UserId { get; set; }
        public int DepartmentId { get; set; }
    }
}
