using BlazorVİdeo.Server.Services.Infrastruce;
using BlazorVİdeo.Shared.DTO;
using BlazorVİdeo.Shared.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorVİdeo.Server.Controllers
{
    [Route("api/User")]
    //[ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService UserService)
        {
            userService = UserService;
        }

        [HttpPost("Login")]
       // [AllowAnonymous]
        public async Task<ServiceResponse<UserLoginResponseDTO>> Login([FromBody]UserLoginRequestDTO UserRequest)
        {
            return new ServiceResponse<UserLoginResponseDTO>()
            {
                Value = await userService.Login(UserRequest.Email, UserRequest.Password)
            };
        }


        [HttpGet("GetUsers")]
        public async Task<ServiceResponse<List<UserDTO>>> GetUsers()
        {
            return new ServiceResponse<List<UserDTO>>()
            {
                Value= await userService.GetUsers()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<UserDTO>> CreateUser([FromBody] UserDTO User)
        {
            return new ServiceResponse<UserDTO>()
            {
                Value = await userService.CreateUser(User)
            };
        }

        [HttpPost("Update")]
        public async Task<ServiceResponse<UserDTO>> UpdateUser([FromBody] UserDTO User)
        {
            return new ServiceResponse<UserDTO>()
            {
                Value = await userService.UpdateUser(User)
            };
        }

        [HttpGet("UserById/{Id}")]
        public async Task<ServiceResponse<UserDTO>> GetUserById(Guid Id)
        {
            return new ServiceResponse<UserDTO>()
            {
                Value = await userService.GetUserById(Id)
            };
        }


        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteUser([FromBody] Guid id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await userService.DeleteUserById(id)
            };
        }
    }
}
