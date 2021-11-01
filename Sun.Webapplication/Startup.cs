using Framework.Application.Auth;
using Framework.Application.Email;
using Framework.Application.Infrastructure;
using Framework.Application.Password;
using Framework.Application.Sms;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sun.Application;
using Sun.Application.Contaracts.Admin;
using Sun.Application.Contaracts.Contact;
using Sun.Application.Contaracts.Product;
using Sun.Application.Contaracts.ProductBrand;
using Sun.Application.Contaracts.ProductCategory;
using Sun.Application.Contaracts.Role;
using Sun.Application.Contaracts.Unit;
using Sun.Domain.AdminAgg;
using Sun.Domain.ContactAgg;
using Sun.Domain.ProductAgg;
using Sun.Domain.ProductBrandAgg;
using Sun.Domain.ProductCategoryAgg;
using Sun.Domain.RoleAgg;
using Sun.Domain.UnitAgg;
using Sun.Infrastructure.EFCore;
using Sun.Infrastructure.EFCore.Repository;
using Sun.Webapplication.Controller;
using System.Collections.Generic;

namespace Sun.Webapplication
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
            
            services.AddDbContext<SunContext>(x => x.UseSqlServer(Configuration.GetConnectionString("SunProject")));

            services.AddHttpContextAccessor();

            services.AddTransient<ICategoryApplication, CategoryApplication>();
            services.AddTransient<ICategoryRepositroy, CategoryRepository>();

            services.AddTransient<IBrandApplication, BrandApplication>();
            services.AddTransient<IBrandRepository, BrandRepository>();

            services.AddTransient<IProductApplication, ProductApplication>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<IContactApplication, ContactApplication>();
            services.AddTransient<IContactRepository, ContactRepository>();

            services.AddTransient<IAdminApplication, AdminApplication>();
            services.AddTransient<IAdminRepository, AdminRepository>();

            services.AddTransient<IRoleApplication, RoleApplication>();
            services.AddTransient<IRoleRepository, RoleRepository>();

            services.AddTransient<IUnitApplication, UnitApplication>();
            services.AddTransient<IUnitRepository, UnitRepository>();

            services.AddSingleton<ISmsService, SmsService>();
            SmsService.Configure(Configuration);

            services.AddSingleton<IEmailService, EmailService>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<IAuthHelper, AuthHelper>();


            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Lax;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
                {
                    o.LoginPath = new PathString("/Login");
                    o.LogoutPath = new PathString("/Index");
                    o.AccessDeniedPath = new PathString("/AccessDenied");
                });

            services.AddAuthorization(options =>
            {
                // roles
                options.AddPolicy("CreateEditRole", builder => builder.RequireRole(new List<string> { RolesSystem.Developer }));
                options.AddPolicy("IndexRole", builder => builder.RequireRole(new List<string> { RolesSystem.Developer, RolesSystem.Admin }));
                options.AddPolicy("Contacts", builder => builder.RequireRole(new List<string> { RolesSystem.Developer, RolesSystem.Admin,
                    RolesSystem.Accountent, RolesSystem.OrderManager, RolesSystem.ProductManager, RolesSystem.ShipmentManager }));
                // products - unit - category - brand
                options.AddPolicy("IndexProduct", builder => builder.RequireRole(new List<string> { RolesSystem.Developer, RolesSystem.Admin,
                    RolesSystem.Accountent, RolesSystem.OrderManager, RolesSystem.OrderUser, RolesSystem.ProductManager, RolesSystem.ProductUser }));
                options.AddPolicy("TProduct", builder => builder.RequireRole(new List<string> { RolesSystem.Developer, RolesSystem.Admin,
                    RolesSystem.Accountent, RolesSystem.OrderManager, RolesSystem.ProductManager }));
            });

            services.AddRazorPages()
                .AddRazorPagesOptions(options =>
                {
                    /// roles
                    //options.Conventions.AuthorizePage("/Role/Create", "CreateEditRole");
                    //options.Conventions.AuthorizePage("/Role/Edit", "CreateEditRole");
                    //options.Conventions.AuthorizePage("/Role/Index", "IndexRole");
                    ///// Product
                    //options.Conventions.AuthorizePage("/Product/Index", "IndexProduct");
                    //options.Conventions.AuthorizePage("/Product/Edit", "TProduct");
                    //options.Conventions.AuthorizePage("/Product/Crete", "TProduct");
                    ////Brand
                    //options.Conventions.AuthorizePage("/Brand/Index", "IndexProduct");
                    //options.Conventions.AuthorizePage("/Brand/Info", "IndexProduct");
                    //options.Conventions.AuthorizePage("/Brand/Edit", "TProduct");
                    //options.Conventions.AuthorizePage("/Brand/Crete", "TProduct");
                    ////category
                    //options.Conventions.AuthorizePage("/Category/Index", "IndexProduct");
                    //options.Conventions.AuthorizePage("/Category/Info", "IndexProduct");
                    //options.Conventions.AuthorizePage("/Category/Edit", "TProduct");
                    //options.Conventions.AuthorizePage("/Category/Crete", "TProduct");
                    ////unit
                    //options.Conventions.AuthorizePage("/Unit/Index", "IndexProduct");
                    //options.Conventions.AuthorizePage("/Unit/Info", "IndexProduct");
                    //options.Conventions.AuthorizePage("/Unit/Edit", "TProduct");
                    //options.Conventions.AuthorizePage("/Unit/Crete", "TProduct");
                    ////contacts
                    //options.Conventions.AuthorizePage("/Contact/Index", "Contacts");
                    //options.Conventions.AuthorizePage("/Contact/Info", "Contacts");
                    //options.Conventions.AuthorizePage("/Contact/Edit", "Contacts");
                    //options.Conventions.AuthorizePage("/Contact/Crete", "Contacts");
                })
                .AddApplicationPart(typeof(ProductController).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            //{
            //    var context = serviceScope.ServiceProvider.GetRequiredService<SunContext>();
            //    context.Database.Migrate();
            //}

            //using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            //{
            //    var context = serviceScope.ServiceProvider.GetRequiredService<SunContext>();
            //    context.Database.EnsureCreated();
            //}

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
