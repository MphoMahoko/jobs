using System;
using System.Collections.Generic;
using System.Text;
using jobs.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace jobs.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<BusinessProfile> BusinessProfiles { get; set; }
        public DbSet<JobProfile> JobProfiles { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Inbox> Inboxes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

           // builder.Entity<IdentityUserRole>().HasKey(p => new { p.UserId, p.RoleId});

            builder.Entity<JobProfile>().HasKey(jp=> new {jp.JobId, jp.ProfileId});

            builder.Entity<JobProfile>().HasOne(jp => jp.Job).WithMany(j => j.JobProfiles).HasForeignKey(jp => jp.JobId);

            builder.Entity<JobProfile>().HasOne(jp => jp.Profile).WithMany(p => p.JobProfiles).HasForeignKey(jp=>jp.ProfileId);
             }
    } 
}
