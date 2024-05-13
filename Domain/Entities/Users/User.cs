using Domain.Base;
using Domain.Entities.Departments;
using Domain.Shared.ValueObjects;

namespace Domain.Entities.Users
{
    public partial class User : BaseEntity<int>
    {
        private User()
        {

        }
        public User(string userName,
            string firstName,
            string lastName,
            string address,
            DateTime? birthDate,
            int? departmentId,
            Salary salary
            )
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            BirthDate = birthDate ?? null;
            DepartmentId = departmentId;
            Salary = salary;
        }

        public string UserName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public float CoefficientsSalary { get; private set; }
        public int? DepartmentId { get; private set; }
        public virtual Department Department { get; private set; }
        public Salary Salary { get; private set; }

        public void Update(string userName,
            string firstName,
            string lastName,
            string address,
            DateTime? birthDate,
            int? departmentId,
            float coefficientsSalary,
            Salary? salary)
        {
            this.UserName = userName;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.BirthDate = birthDate ?? null;
            this.DepartmentId = departmentId;
            this.CoefficientsSalary = coefficientsSalary;

            if (salary != null)
                UpdateSalary(salary);
        }

        public void UpdateName(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                throw new ArgumentNullException("first name and last name cannot be null!");
            FirstName = firstName;
            LastName = lastName;
        }

        public void UpdateAddress(string newAdress)
        {
            if (string.IsNullOrEmpty(newAdress))
                throw new ArgumentNullException(nameof(newAdress));
            this.Address = newAdress;
        }
    }
}
