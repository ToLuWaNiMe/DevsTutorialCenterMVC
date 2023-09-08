using DevsTutorialCenterMVC.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DevsTutorialCenterMVC.Data
{
    public class DevsTutorialCenterMVCContext: IdentityDbContext<AppUser>
	{
		public DevsTutorialCenterMVCContext(DbContextOptions<DevsTutorialCenterMVCContext> options):
			base(options)
		{
		}

    }
}

