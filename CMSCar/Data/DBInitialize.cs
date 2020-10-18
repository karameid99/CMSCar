﻿using CMSCar.Areas.CPanel.Models.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Data
{
    public class DBInitialize
    {
        public static async void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                var _userManager =
                         serviceScope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
                var _roleManager =
                         serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                //-------------- Initialize Admin -------------------
                try
                {
                    if (!context.Roles.Any())
                    {
                        IdentityResult result2 = await _roleManager.CreateAsync(new IdentityRole("Admin"));
                        IdentityResult result3 = await _roleManager.CreateAsync(new IdentityRole("Provider"));
                    }
                     if (!context.Users.Any())
                    {
                        var FullName = "Admin Admin";
                        var UserName = "admin_admin";
                        var EmailAdmin = "admin@gmail.com";
                        var PasswordAdmin = "Admin11$";
                        var PhoneNumberAdmin = "10002000";
                        var user = new ApplicationUser
                        {
                            UserName = EmailAdmin,
                            Email = EmailAdmin,
                            FullName = FullName,
                            PhoneNumber = PhoneNumberAdmin,
                            EmailConfirmed = true,
                            IsActive = true,
                            CreatedAt = DateTime.Now,
                        };
                        IdentityRole adminRole = new IdentityRole();
                        adminRole.Name = "Admin";
                        adminRole.NormalizedName = "ADMIN";

                    var result = await _userManager.CreateAsync(user, PasswordAdmin);
                    IdentityResult identityResult = await _userManager.AddToRoleAsync(user, "Provider");
                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }

    }
}
