using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using OrderDelayAnnouncement.Infrastructure.Persistance;

namespace OrderDelayAnnouncement.API.Tests.Integration
{
    public class TestingWebAppFactory<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<OMSContext>));

                if (descriptor != null)
                    services.Remove(descriptor);

                services.AddDbContext<OMSContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryOMSTest");
                });


                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                using (var appContext = scope.ServiceProvider.GetRequiredService<OMSContext>())
                {
                    try
                    {
                        appContext.Database.EnsureCreated();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            });
            builder.UseEnvironment("Development");
        }
    }
    
}