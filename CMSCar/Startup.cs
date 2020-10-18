using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using CMSCar.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using CMSCar.Areas.CPanel.Models.User;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace CMSCar
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //Start => SendMail - ConfigureServices
        public class CustomEmailConfirmationTokenProvider<ApplcationUser> : DataProtectorTokenProvider<ApplcationUser> where ApplcationUser : class
        {
            public CustomEmailConfirmationTokenProvider(IDataProtectionProvider dataProtectionProvider, IOptions<DataProtectionTokenProviderOptions> options, ILogger<DataProtectorTokenProvider<ApplcationUser>> logger) : base(dataProtectionProvider, options, logger)
            {
            }
        }
        public class EmailConfirmationTokenProviderOptions : DataProtectionTokenProviderOptions
        {
            public EmailConfirmationTokenProviderOptions()
            {
                Name = "EmailDataProtectorTokenProvider";
                TokenLifespan = TimeSpan.FromDays(365);
            }
        }

        //End => SendMail - ConfigureServices

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddLocalization(opts =>
            {
                opts.ResourcesPath = "Resources";
            });
            services.AddAutoMapper(typeof(Startup));
            services.AddDistributedMemoryCache();
            services.AddCors();
            services.AddHttpClient();
            services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme,opt =>{opt.LoginPath = "/Identity/Account/Login"; opt.AccessDeniedPath = "/Identity/Account/AccessDenied"; });
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.Name = ".AdventureWorks.Session";
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));


            var dataProtectionProviderType = typeof(DataProtectorTokenProvider<ApplicationUser>);
            var phoneNumberProviderType = typeof(PhoneNumberTokenProvider<ApplicationUser>);
            var emailTokenProviderType = typeof(EmailTokenProvider<ApplicationUser>);
            services.AddIdentity<ApplicationUser , IdentityRole>(options =>
            {
                
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.Tokens.ProviderMap.Add("CustomEmailConfirmation",
                    new TokenProviderDescriptor(
                        typeof(CustomEmailConfirmationTokenProvider<ApplicationUser>)));
                options.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddTokenProvider(TokenOptions.DefaultProvider, dataProtectionProviderType)
                .AddTokenProvider(TokenOptions.DefaultEmailProvider, emailTokenProviderType)
                .AddTokenProvider(TokenOptions.DefaultPhoneProvider, phoneNumberProviderType);

            services.AddControllersWithViews();
            services.AddRazorPages();
            //Start => SendMail - ConfigureServices
            services.AddTransient<CustomEmailConfirmationTokenProvider<ApplicationUser>>();
            //End => SendMail - ConfigureServices
            //Start => Language - ConfigureServices

            services.AddMvc()
                .AddViewLocalization(
                    opts => { opts.ResourcesPath = "Resources"; })
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization()
           .SetCompatibilityVersion(CompatibilityVersion.Version_3_0); ;

            services.Configure<RequestLocalizationOptions>(opts =>
            {
                var supportedCulures = new List<CultureInfo> {
                    new CultureInfo("en-US"),
                    new CultureInfo("ar-EG"),//Arabic Egypt
                };
                opts.DefaultRequestCulture = new RequestCulture("ar-EG");
                opts.SupportedCultures = supportedCulures;
                opts.SupportedUICultures = supportedCulures;
            });
            //End => Language - ConfigureServices
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            Data.DBInitialize.Initialize(app);
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();
            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            //Start => Language - Configure

            var Options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(Options.Value);

            //End => Language - Configure

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                   name: "areas",
                   areaName: "Admin",
                   pattern: "{area:Admin}/{controller=exists}/{action=exists}/{id?}");

                endpoints.MapRazorPages();
            });


        }
    }
}
