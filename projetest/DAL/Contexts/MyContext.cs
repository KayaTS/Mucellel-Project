
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Contexts
{
    public class MyContext : IdentityDbContext<AppUser>
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            //  ContentsPlaces - MediaImages ( 1:N )
            /*modelBuilder.Entity<ContentsPlaces>()
            .HasMany(L => L.MediaPictures)
            .WithOne(c => c.Contents).HasForeignKey(f => f.contentID).OnDelete(DeleteBehavior.SetNull);
            */
        }

        public DbSet<ContentsPlaces> ContentsPlaces{ get; set; }
        public DbSet<ImageComments> ImageComments{ get; set; }
        public DbSet<MediaPicture> MediaPictures{ get; set; }
        public DbSet<Member> Members{ get; set; }
        public DbSet<AppUser> AppUser { get; set; }

    }
}
