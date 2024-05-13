using Application.Models.DTOs.Users;
using Domain.Entities.Users;
using Domain.Interfaces;
using Domain.Shared.ValueObjects;

namespace Application.Services.Users
{
    public class UserService : BaseService
    {
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<List<GetUserResponse>> GetUsers()
        {
            var repository = _unitOfWork.Repository<User>();
            var users = await repository.GetListAsync();

            if (users.Count() == 0)
                return new List<GetUserResponse>();

            var data = users.Select(u => new GetUserResponse
            {
                Id = u.Id,
                UserName = u.UserName,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Address = u.Address,
                BirthDate = u.BirthDate,
                CoefficientsSalary = u.CoefficientsSalary,
                DepartmentId = u.DepartmentId,
                Salary = u.Salary,
            }).ToList();

            return data;
        }

        public async Task<GetUserResponse?> GetUserById(int id)
        {
            if (id == 0)
                throw new ArgumentException("Id value is wrong.", nameof(id));

            var repository = _unitOfWork.Repository<User>();
            var user = await repository
                .GetAsync(u => u.Id == id);

            if (user is null)
                return null;

            var response = new GetUserResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                BirthDate = user.BirthDate,
                CoefficientsSalary = user.CoefficientsSalary,
                DepartmentId = user.DepartmentId,
                Salary = user.Salary,
            };

            return response;
        }

        public async Task<AddUserResponse> AddNewUser(AddUserRequest request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var user = new User(request.UserName,
                request.FirstName,
                request.LastName,
                request.Address,
                request.BirthDate,
                request.DepartmentId,
                new Salary(request.Salary.Amount, new Currency(request.Salary.Currency.Value)));

            var repository = _unitOfWork.Repository<User>();
            await repository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            var response = new AddUserResponse
            {
                Id = user.Id,
                UserName = user.UserName,
            };

            return response;
        }

        public async Task<UpdateUserResponse> UpdateUser(int id, UpdateUserRequest request)
        {
            var userRepository = _unitOfWork.Repository<User>();

            var user = await userRepository.GetAsync(u => u.Id == id);
            if (user is null)
                throw new Exception("User not found!");

            user.Update(request.UserName,
                request.FirstName,
                request.LastName,
                request.Address,
                request.BirthDate,
                request.DepartmentId,
                request.CoefficientsSalary,
                request.Salary != null ? new Salary(request.Salary.Amount, new Currency(request.Salary.Currency.Value)) : null);

            await userRepository.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();
            var response = new UpdateUserResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Address = user.Address,
                BirthDate = user.BirthDate,
                DepartmentId = user.DepartmentId,
                CoefficientsSalary = user.CoefficientsSalary,
                Salary = user.Salary,
            };
            return response;
        }
    }
}
