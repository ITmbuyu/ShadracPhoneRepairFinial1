using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShadracPhoneRepairFinial1.Data;
using ShadracPhoneRepairFinial1.Models;

[assembly: HostingStartup(typeof(ShadracPhoneRepairFinial1.Areas.Identity.IdentityHostingStartup))]
namespace ShadracPhoneRepairFinial1.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}