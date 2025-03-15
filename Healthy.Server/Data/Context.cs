using Healthy.Server.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Healthy.Server.Data
{
    public class Context:IdentityDbContext<User>
    {
        public Context(DbContextOptions<Context> options)
         : base(options)
        {
            //  InitializeData();
        }

    }
}
