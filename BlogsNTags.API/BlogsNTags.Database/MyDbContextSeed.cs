using Microsoft.EntityFrameworkCore;
using BlogsNTags.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogsNTags.Database
{
    public partial class MyDbContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>().HasData(
                new Tag
                {
                    Id = 1,
                    Name = "ios",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Tag
                {
                    Id = 2,
                    Name = "android",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Tag
                {
                    Id = 3,
                    Name = "AngularJS",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Tag
                {
                    Id = 4,
                    Name = "EntityFramework",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Tag
                {
                    Id = 5,
                    Name = "dotnet",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });

            modelBuilder.Entity<Blog>().HasData(
                new Blog
                {
                    Id = 1,
                    Slug = "upcoming-changes-in-angularjs",
                    Title = "Upcoming changes in AngularJS",
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut eleifend nec justo ut sagittis. Curabitur vestibulum lorem vel est suscipit varius ac sed tellus. Maecenas efficitur nibh a velit sollicitudin ornare. Proin ac dui imperdiet, tincidunt turpis in, finibus ligula. Donec sed massa quis magna imperdiet cursus vitae quis justo",
                    Description = "Short description about upcoming changes",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Blog
                {
                    Id = 2,
                    Slug = "testing-your-accented-characters-test-or",
                    Title = "țestíng your accëntëd čharacters teśt, or | .-> []",
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut eleifend nec justo ut sagittis. Curabitur vestibulum lorem vel est suscipit varius ac sed tellus. Maecenas efficitur nibh a velit sollicitudin ornare. Proin ac dui imperdiet, tincidunt turpis in, finibus ligula. Donec sed massa quis magna imperdiet cursus vitae quis justo",
                    Description = "Some description",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Blog
                {
                    Id = 3,
                    Slug = "adding-migrations-to-net-core-31-using-ef",
                    Title = "Adding migrations to .NET core 3.1 using EF",
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut eleifend nec justo ut sagittis. Curabitur vestibulum lorem vel est suscipit varius ac sed tellus. Maecenas efficitur nibh a velit sollicitudin ornare. Proin ac dui imperdiet, tincidunt turpis in, finibus ligula. Donec sed massa quis magna imperdiet cursus vitae quis justo",
                    Description = "Genning the migs",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });

            modelBuilder.Entity<BlogsTags>().HasData(
                new BlogsTags
                {
                    Id = 1,
                    BlogId = 1,
                    TagId = 3,

                },
                new BlogsTags
                {
                    Id = 2,
                    BlogId = 3,
                    TagId = 4,

                },
                new BlogsTags
                {
                    Id = 3,
                    BlogId = 3,
                    TagId = 5,

                });
        }
    }
}
