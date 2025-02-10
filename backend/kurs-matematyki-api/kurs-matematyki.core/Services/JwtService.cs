using kurs_matematyki.Core.DTO;
using kurs_matematyki.Core.Identity;
using kurs_matematyki.Core.Services.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kurs_matematyki.Core.Services
{
    public class JwtService : IJwtService
    {
        public AuthenticationResponse CreateJwtToken(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}
