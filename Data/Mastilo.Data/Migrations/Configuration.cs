namespace Mastilo.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using Models;
    using Microsoft.AspNet.Identity;
    using System.Linq;
    using System.Collections.Generic;
    using System;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var hasher = new PasswordHasher();

            var user = new User
            {
                Email = "test@test.bg",
                UserName = "Lithiumm",
                Age = 17,
                FirstName = "Rally",
                LastName = "Br.",
                PasswordHash = hasher.HashPassword("1234")
            };

            var secondUser = new User
            {
                Email = "pesho@pesho.bg",
                UserName = "peshaka",
                Age = 90,
                FirstName = "Petur",
                LastName = "Mitov",
                PasswordHash = hasher.HashPassword("1234")
            };

            if (!context.Users.Any())
            {
                context.Users.Add(user);
                context.Users.Add(secondUser);

                context.SaveChanges();
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
            var othersCategory = new Category { Name = "�����" };

            List<Category> proseCategories = new List<Category>();
            proseCategories.Add(new Category { Name = "�������" });
            proseCategories.Add(new Category { Name = "��������" });
            proseCategories.Add(new Category { Name = "������������" });
            proseCategories.Add(new Category { Name = "��������" });
            proseCategories.Add(new Category { Name = "�� ����" });
            proseCategories.Add(new Category { Name = "����������" });
            proseCategories.Add(new Category { Name = "����������" });
            proseCategories.Add(new Category { Name = "���� �������" });
            proseCategories.Add(new Category { Name = "��� � �����" });
            proseCategories.Add(new Category { Name = "������� �����" });
            proseCategories.Add(new Category { Name = "�������" });

            List<Category> poetryCategories = new List<Category>();
            poetryCategories.Add(new Category { Name = "�������" });
            poetryCategories.Add(new Category { Name = "������� � ������" });
            poetryCategories.Add(new Category { Name = "����������� ������" });
            poetryCategories.Add(new Category { Name = "���������� � �������" });
            poetryCategories.Add(new Category { Name = "�������� � ������������ �� ����" });
            poetryCategories.Add(new Category { Name = "������������" });
            poetryCategories.Add(new Category { Name = "��������" });
            poetryCategories.Add(new Category { Name = "�����" });

            foreach (var category in proseCategories)
            {
                context.Categories.Add(category);
            }

            foreach (var category in poetryCategories)
            {
                context.Categories.Add(category);
            }

            context.Categories.Add(othersCategory);
            poetryCategories.Add(othersCategory);
            proseCategories.Add(othersCategory);

            context.Genres.Add(new Genre { Name = "�����", Categories = proseCategories });
            context.Genres.Add(new Genre { Name = "������", Categories = poetryCategories });

            context.SaveChanges();

        }

        private void SeedMasterpieces(ApplicationDbContext context, User user, User secondUser)
        {
            var prose = context.Genres.FirstOrDefault(x => x.Name == "�����");

            for (int i = 1; i <= 20; i++)
            {
                var masterpiece = new Masterpiece
                {
                    Title = $"Hello {i}",
                    Content = $"���� � ���������� ����� {i}",
                    SeenBy = new List<SeenBy> { new SeenBy { SeenByUsername = "Pesho" }, new SeenBy { SeenByUsername = "Gosho" } },
                    Author = user,
                    Genre = prose,
                    Categories = prose.Categories.Take(3).ToList(),
                    Comments = new List<Comment> { new Comment { User = secondUser, Text = "����� ������" }, new Comment { User = secondUser, Text = "�������" } },
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
    }
}
