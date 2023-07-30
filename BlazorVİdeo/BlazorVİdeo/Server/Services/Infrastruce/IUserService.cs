using BlazorVİdeo.Shared.DTO;

namespace BlazorVİdeo.Server.Services.Infrastruce
{
    public interface IUserService
    {

        public Task<UserDTO> GetUserById(Guid Id);
        public Task<List<UserDTO>> GetUsers();
        public Task<UserDTO> CreateUser(UserDTO User);
        public Task<UserDTO> UpdateUser(UserDTO User);
        public Task<bool> DeleteUserById(Guid Id);

        public Task<UserLoginResponseDTO> Login(string EMail, string Password);


    }
}
