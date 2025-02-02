using Microsoft.AspNetCore.Identity;
using CalisthenicsApp.Data.Enum;
using CalisthenicsApp.Models;
using System.Diagnostics;
using System.Net;

namespace CalisthenicsApp.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Clubs.Any())
                {
                    context.Clubs.AddRange(new List<Club>()
                    {
                        new Club()
                        {
                            Title = "Club",
                            Image = "https://t3.ftcdn.net/jpg/01/65/71/48/360_F_165714866_P2HiXnR9yOcAxR7F8IxvtlWBCAZvm5j1.jpg",
                            Description = "Test Description",
                            ClubCategory = ClubCategory.PullUp,
                            Address = new Address()
                            {
                                Street = "5419",
                                City = "Isparta",
                                State = "Merkez"
                            }
                         }
                       
                    });
                    context.SaveChanges();
                }
                //Exercises
                if (!context.Exercises.Any())
                {
                    context.Exercises.AddRange(new List<Exercise>()
                    {
                        new Exercise()
                        {
                            Title = "Exercise",
                            Image = "https://t3.ftcdn.net/jpg/01/65/71/48/360_F_165714866_P2HiXnR9yOcAxR7F8IxvtlWBCAZvm5j1.jpg",
                            Description = "Test Exercise",
                            ExerciseCategory = ExerciseCategory.PullUp,
                            Address = new Address()
                            {
                                Street = "5419",
                                City = "Isparta",
                                State = "Cunur"
                            }
                        }
                    });
                    context.SaveChanges();
                }
            }

        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "batuhancetin@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "batuhanCetin",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        Address = new Address()
                        {
                            Street = "Isparta",
                            City = "Isparta",
                            State = "Isparta"
                        }
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@gmail.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        UserName = "testUser",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        Address = new Address()
                        {
                            Street = "Isparta",
                            City = "Isparta",
                            State = "Isparta"
                        }
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
