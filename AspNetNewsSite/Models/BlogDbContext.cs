using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetNewsSite.Models
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<PostTag>()
            //     .HasOne(pt => pt.Post)
            //     .WithMany(p => p.PostTags)
            //     .HasForeignKey(pt => pt.PostId);


            //modelBuilder.Entity<PostTag>()
            //     .HasOne(pt => pt.Tag)
            //     .WithMany(p => p.PostTags)
            //     .HasForeignKey(pt => pt.TagId);
        }


        public DbSet<Person> Persons { get; set; }
        public DbSet<Сomment> Сomments { get; set; }
        /*public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }*/
    }
}

