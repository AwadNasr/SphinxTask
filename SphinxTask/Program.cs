using Microsoft.EntityFrameworkCore;
using Sphinx.Core;
using Sphinx.Repository;
using Sphinx.Repository.Data;

namespace SphinxTask
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            // DB Of SphinxContext
            builder.Services.AddDbContext<SphinxContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            var app = builder.Build();

            #region Update Db in every Program Run
            using var scope = app.Services.CreateScope();
            var service = scope.ServiceProvider;
            var Context = service.GetRequiredService<SphinxContext>();
            await Context.Database.MigrateAsync();
            #endregion

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
