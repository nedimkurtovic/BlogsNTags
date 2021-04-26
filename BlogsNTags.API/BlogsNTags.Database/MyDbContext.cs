using Microsoft.EntityFrameworkCore;
using BlogsNTags.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogsNTags.Database
{
    public class MyDbContext: DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Tag> Tags{ get; set; }
        public DbSet<BlogsTags> BlogsTags { get; set; }

        public MyDbContext(){}
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BlogsTags>()
                .HasOne<Blog>(x => x.Blog)
                .WithMany(x => x.BlogsTags)
                .HasForeignKey(x => x.BlogId);

            modelBuilder.Entity<BlogsTags>()
                .HasOne<Tag>(x => x.Tag)
                .WithMany(x => x.BlogsTags)
                .HasForeignKey(x => x.TagId);
        }
        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseObject && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseObject)entityEntry.Entity).UpdatedAt = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseObject)entityEntry.Entity).CreatedAt = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}
