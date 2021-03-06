﻿namespace Mastilo.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.IO;
    using System.Web.Hosting;
    using System.Reflection;
    using System.Web;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Images.Any())
            {
                using (var memory = new MemoryStream())
                {
                    FileStream stream = new FileStream(this.MapPath("~/Content/Images/default-user.png"), FileMode.Open);

                    stream.CopyTo(memory);

                    var content = memory.GetBuffer();

                    var newImage = new Image
                    {
                        Content = content,
                        FileExtension = stream.Name.Split(new[] { '.' }).Last()
                    };

                    context.Images.Add(newImage);
                    context.SaveChanges();
                }
            }

            if (!context.Roles.Any())
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var adminRole = new IdentityRole { Name = "Administration" };
                var editorRole = new IdentityRole { Name = "Editor" };
                var userRole = new IdentityRole { Name = "User" };

                manager.Create(adminRole);
                manager.Create(editorRole);
                manager.Create(userRole);
            }

            var hasher = new PasswordHasher();

            var user = new User
            {
                Email = "test@test.bg",
                UserName = "test@test.bg",
                Age = 17,
                FirstName = "Rally",
                LastName = "Br.",
                UserNameCustom = "Lithiumm",
                PasswordHash = hasher.HashPassword("123456"),
                Image = context.Images.FirstOrDefault(),
                RegistrationDate = DateTime.UtcNow,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var secondUser = new User
            {
                Email = "pesho@pesho.bg",
                UserName = "pesho@pesho.bg",
                Age = 90,
                FirstName = "Petur",
                LastName = "Mitov",
                UserNameCustom = "Peshaka",
                PasswordHash = hasher.HashPassword("123456"),
                Image = context.Images.FirstOrDefault(),
                RegistrationDate = DateTime.UtcNow,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var admin = new User
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                UserNameCustom = "Admincho",
                PasswordHash = hasher.HashPassword("123456"),
                Image = context.Images.FirstOrDefault(),
                RegistrationDate = DateTime.UtcNow,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var editor = new User
            {
                UserName = "editor@editor.com",
                Email = "editor@editor.com",
                UserNameCustom = "Editorcho",
                PasswordHash = hasher.HashPassword("123456"),
                Image = context.Images.FirstOrDefault(),
                RegistrationDate = DateTime.UtcNow,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            if (!context.Users.Any())
            {
                var userManager = new UserManager<User>(new UserStore<User>(context));

                userManager.Create(admin);
                userManager.AddToRole(admin.Id, "Administration");

                userManager.Create(editor);
                userManager.AddToRole(editor.Id, "Editor");

                userManager.Create(user);
                userManager.AddToRole(user.Id, "User");

                userManager.Create(secondUser);
                userManager.AddToRole(secondUser.Id, "User");
            }

            if (!context.Genres.Any())
            {
                this.SeedGenresAndCategories(context);
            }

            if (!context.Masterpieces.Any())
            {
                this.SeedMasterpieces(context, user, secondUser);
            }
        }

        private void SeedGenresAndCategories(ApplicationDbContext context)
        {
            var prose = new Genre { Name = "Проза" };
            var poetry = new Genre { Name = "Поезия" };

            context.Genres.Add(prose);
            context.Genres.Add(poetry);

            List<Category> proseCategories = new List<Category>();
            proseCategories.Add(new Category { Name = "Любовна", Genre = prose });
            proseCategories.Add(new Category { Name = "Еротична", Genre = prose });
            proseCategories.Add(new Category { Name = "Хумористична", Genre = prose });
            proseCategories.Add(new Category { Name = "Пейзажна", Genre = prose });
            proseCategories.Add(new Category { Name = "За деца", Genre = prose });
            proseCategories.Add(new Category { Name = "Философска", Genre = prose });
            proseCategories.Add(new Category { Name = "Гражданска", Genre = prose });
            proseCategories.Add(new Category { Name = "Бели стихове", Genre = prose });
            proseCategories.Add(new Category { Name = "Оди и поеми", Genre = prose });
            proseCategories.Add(new Category { Name = "Източни форми", Genre = prose });
            proseCategories.Add(new Category { Name = "Пародии", Genre = prose });

            List<Category> poetryCategories = new List<Category>();
            poetryCategories.Add(new Category { Name = "Разкази", Genre = poetry });
            poetryCategories.Add(new Category { Name = "Повести и романи", Genre = poetry });
            poetryCategories.Add(new Category { Name = "Литературни очерци", Genre = poetry });
            poetryCategories.Add(new Category { Name = "Фантастика и фентъзи", Genre = poetry });
            poetryCategories.Add(new Category { Name = "Приказки и произведения за деца", Genre = poetry });
            poetryCategories.Add(new Category { Name = "Хумористична", Genre = poetry });
            poetryCategories.Add(new Category { Name = "Еротична", Genre = poetry });
            poetryCategories.Add(new Category { Name = "Писма", Genre = poetry });

            foreach (var category in proseCategories)
            {
                context.Categories.Add(category);
            }

            foreach (var category in poetryCategories)
            {
                context.Categories.Add(category);
            }

            context.SaveChanges();
        }

        private void SeedMasterpieces(ApplicationDbContext context, User user, User secondUser)
        {
            var prose = context.Genres.FirstOrDefault(x => x.Name == "Проза");

            for (int i = 1; i <= 20; i++)
            {
                var masterpiece = new Masterpiece
                {
                    Title = $"Hello {i}",
                    Content = $"Това е съдържание номер {i}",
                    SeenBy = new List<SeenBy> { new SeenBy { SeenByUsername = "Pesho" }, new SeenBy { SeenByUsername = "Gosho" } },
                    Author = user,
                    Genre = prose,
                    IsAssessed = true,
                    IsApproved = true,
                    IsEdited = false,
                    Comments = new List<Comment> { new Comment { User = secondUser, Text = "Много смешно" }, new Comment { User = secondUser, Text = "хахахах" } },
                    Rates = new List<Rate> { new Rate { User = secondUser, Value = 5 } }
                };

                context.Masterpieces.Add(masterpiece);
            }

            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

        private string MapPath(string seedFile)
        {
            if (HttpContext.Current != null)
            {
                return HostingEnvironment.MapPath(seedFile);
            }

            var absolutePath = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
            var directoryName = Path.GetDirectoryName(absolutePath);
            var path = Path.Combine(directoryName, ".." + seedFile.TrimStart('~').Replace('/', '\\'));

            return path;
        }
    }
}
