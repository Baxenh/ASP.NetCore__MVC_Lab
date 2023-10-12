using Lesson10_Identity_Applycation.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lesson10_Identity_Applycation.Areas.Identity.Data;

public class Lesson10_ApplycationContext : IdentityDbContext<ApplycationUser>
{
    public Lesson10_ApplycationContext(DbContextOptions<Lesson10_ApplycationContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
