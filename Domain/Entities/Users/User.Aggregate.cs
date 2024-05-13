using Domain.Base;
using Domain.Entities.Departments;
using Domain.Entities.Users.Events;
using Domain.Shared.ValueObjects;

namespace Domain.Entities.Users
{
    public partial class User : IAggregateRoot
    {
        public void UpdateDepartment(Department newDepartment)
        {
            if (Department == null)
                throw new ArgumentNullException(nameof(newDepartment));

            this.DepartmentId = newDepartment.Id;

            var updateEvent = new OnDepartmentUpdateEvent
            {
                DepartmentId = newDepartment.Id,
                UserId = this.Id
            };

            AddEvent(updateEvent);
        }

        public void UpdateSalary(Salary newSalary)
        {
            if (newSalary == null)
                throw new ArgumentNullException(nameof(newSalary));

            if (Salary.Equals(newSalary))
                throw new ArgumentException("New salary is equal to current salary", nameof(newSalary));

            Salary = newSalary;
        }
    }
}
