using System;
using LogisticInventorySystem.Areas.Identity.Data;
using LogisticInventorySystem.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(LogisticInventorySystem.Areas.Identity.IdentityHostingStartup))]
namespace LogisticInventorySystem.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<LogisticInventorySystemContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("LogisticInventorySystemContextConnection")));

                services.AddDefaultIdentity<LogisticInventorySystemUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<LogisticInventorySystemContext>();
            });
        }
    }
}