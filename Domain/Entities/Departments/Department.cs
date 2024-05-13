using Domain.Base;

namespace Domain.Entities.Departments
{
    public partial class Department : BaseEntity<int>
    {
        public string Name { get; private set; }
    }
}
