using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kurs_matematyki.Core.DTO;
using kurs_matematyki.Core.Identity;

namespace kurs_matematyki.Core.Services.ServiceContracts
{
    public interface IJwtService
    {
        AuthenticationResponse CreateJwtToken(ApplicationUser user);
    }
}
