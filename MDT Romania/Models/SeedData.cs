﻿using MDT_Romania.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MDT_Romania.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService
                <DbContextOptions<ApplicationDbContext>>()))
            {
                // Verificam daca in baza de date exista cel putin un rol
                // insemnand ca a fost rulat codul 
                // De aceea facem return pentru a nu insera rolurile inca o data
                // Acesta metoda trebuie sa se execute o singura data 
                if (context.Roles.Any())
                {
                    return;   // baza de date contine deja roluri
                }

                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(
                    new Category { Title = "Crime Împotriva unei Persoane" },
                    new Category { Title = "Crime Împotriva unei Proprietăți" },
                    new Category { Title = "Crime Împotriva Integritatii Fizice" },
                    new Category { Title = "Crime Împotriva Demnității Publice" },
                    new Category { Title = "Infractiuni de audienta" },
                    new Category { Title = "Crime Împotriva Liniștii Publice" },
                    new Category { Title = "Crime Împotriva Siguranței Publice" },
                    new Category { Title = "Traffic Violation" },
                    new Category { Title = "Controlul Armelor și Echipamentului Mortal" },
                    new Category { Title = "Legislaţia rutieră" },
                    new Category { Title = "State Code Violations" }
                    );
                    context.SaveChanges();

                }

                // CREAREA ROLURILOR IN BD
                // daca nu contine roluri, acestea se vor crea
                context.Roles.AddRange(
                    new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Admin", NormalizedName = "Admin".ToUpper() },
                    new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7211", Name = "User", NormalizedName = "User".ToUpper() }

                );


                // o noua instanta pe care o vom utiliza pentru crearea parolelor utilizatorilor
                // parolele sunt de tip hash
                var hasher = new PasswordHasher<ApplicationUser>();

                // CREAREA USERILOR IN BD
                // Se creeaza cate un user pentru fiecare rol
                context.Users.AddRange(
                    new ApplicationUser
                    {
                        Id = "8e445865-a24d-4543-a6c6-9443d048cdb0", // primary key
                        UserName = "admin@test.com",
                        EmailConfirmed = true,
                        NormalizedEmail = "ADMIN@TEST.COM",
                        FirstName = "Admin",
                        LastName = "Test",
                        Email = "admin@test.com",
                        NormalizedUserName = "ADMIN@TEST.COM",
                        PasswordHash = hasher.HashPassword(null, "Admin1!")
                    },
                  /*  new ApplicationUser
                    {
                        Id = "8e445865-a24d-4543-a6c6-9443d048cdb1", // primary key
                        UserName = "mod@test.com",
                        EmailConfirmed = true,
                        FirstName = "Moderator",
                        LastName = "Test",
                        NormalizedEmail = "MOD@TEST.COM",
                        Email = "mod@test.com",
                        NormalizedUserName = "MOD@TEST.COM",
                        PasswordHash = hasher.HashPassword(null, "Moderator1!")
                    },*/
                    new ApplicationUser
                    {
                        Id = "8e445865-a24d-4543-a6c6-9443d048cdb2", // primary key
                        UserName = "user@test.com",
                        EmailConfirmed = true,
                        NormalizedEmail = "USER@TEST.COM",
                        FirstName = "User",
                        LastName = "Test",
                        Email = "user@test.com",
                        NormalizedUserName = "USER@TEST.COM",
                        PasswordHash = hasher.HashPassword(null, "User1!")
                    }
                ); ;
                context.UserRoles.AddRange(
                   new IdentityUserRole<string>
                   {
                       // Admin
                       RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                       UserId = "8e445865-a24d-4543-a6c6-9443d048cdb0"
                   },
                   new IdentityUserRole<string>
                   {
                       /// User
                       RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7211",
                       UserId = "8e445865-a24d-4543-a6c6-9443d048cdb2"
                   }
                  
               );
                context.SaveChanges();
            }

        }

    }
}