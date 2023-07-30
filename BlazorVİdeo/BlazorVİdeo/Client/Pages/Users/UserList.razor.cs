using BlazorVİdeo.Shared.DTO;
using BlazorVİdeo.Shared.ResponseModels;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorVİdeo.Client.Pages.Users
{
    public partial class UserList
    {
        [Inject]
        public HttpClient Client { get; set; }

        //Html tarafında kullanmak için değişken olarak tanımlandı
        protected List<UserDTO> userList = new List<UserDTO>();

        protected async override Task OnInitializedAsync()
        {
            await LoadList();
        }

        protected async Task LoadList()
        {
            var serviceResponse = await Client.GetFromJsonAsync<ServiceResponse<List<UserDTO>>>("api/User/GetUsers");

            if (serviceResponse.Success)
                userList = serviceResponse.Value;



        }

    }
}
