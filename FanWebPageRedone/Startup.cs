using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FanWebPageRedone.Models;
using FanWebPageRedone.Repos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FanWebPageRedone
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication("CookieAuthentication").AddCookie("CookieAuthentication", config => {
                config.Cookie.Name = "FanWebPageRedoneUserLogin";
                config.LoginPath = "/Account/Login";
                config.AccessDeniedPath = "/Account/Login";
            });

            services.AddControllersWithViews();
           
            services.AddTransient<Istories, StoryRepo>();
            services.AddDbContext<StoriesContext>(options =>
            options.UseSqlServer(Configuration["ConnectionStrings:ConnectionString"]));
            
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<StoriesContext>().AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<StoriesContext>();

               // context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();

                context.Database.Migrate();
                var serviceProvider = app.ApplicationServices;
                var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                SeedData.init(context,userManager,roleManager);
            }



            //var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>();
            //var context = serviceScope.CreateScope().ServiceProvider.GetRequiredService<StoriesContext>();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            // context.Database.Migrate();
            /*
            if (!context.Story.Any()) //add only if not exist
            {
                //instantiate models
                var story = new Story();
                // seed data.
                var stories = story.Seed();
                //add list of models to the user context
                context.Story.AddRange(stories);
                //save
                context.SaveChanges();
            }
            */
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
