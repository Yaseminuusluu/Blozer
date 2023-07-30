using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorVİdeo.Shared.DTO
{
    public class UserLoginResponseDTO
    {
        public String ApiToken { get; set; }

        public UserDTO User { get; set; }
    }
}
