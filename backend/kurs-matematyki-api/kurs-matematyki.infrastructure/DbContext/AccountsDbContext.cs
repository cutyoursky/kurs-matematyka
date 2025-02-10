using kurs_matematyki.Core.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kurs_matematyki.infrastructure.DbContext
{
    public class AccountsDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public AccountsDbContext(DbContextOptions<AccountsDbContext> options) : base(options)
        {
        }

    }
}
