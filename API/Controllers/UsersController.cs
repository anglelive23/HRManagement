using Application.Models.DTOs.Users;
using Application.Services.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet]
        public async Task<ActionResult<GetUserResponse>> GetAll()
        {
            var users = await _userService
                .GetUsers();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserResponse>> GetById(int id)
        {
            var user = await _userService
                .GetUserById(id);

            if (user is null)
                return NotFound($"User with id: {id} not found!");

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<AddUserResponse>> AddUser([FromBody] AddUserRequest request)
        {
            var user = await _userService
                .AddNewUser(request);

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateUserResponse>> UpdateUser(int id, [FromBody] UpdateUserRequest request)
        {
            var user = await _userService
                .UpdateUser(id, request);

            if (user is null)
                return BadRequest("Something went wrong!");

            return Ok(user);
        }
    }
}
