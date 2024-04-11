using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.DTOs.CustomerDTOs.Requests
{
    public class LogInRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
