﻿using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base (options)
        {
        }

        public DbSet<Value> Values { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Value>().HasData(
                new Value {Id = 1, Name = "Test Name 1"},
                new Value {Id = 2, Name = "Test Name 2"},
                new Value {Id = 3, Name = "Test Name 3"}
            );

            builder.Entity<UserActivity>(x => x.HasKey(ua => 
                new {ua.AppUserId, ua.ActivityId}));

                builder.Entity<UserActivity>().HasOne(u => u.AppUser)
                                              .WithMany(a => a.UserActivities)
                                              .HasForeignKey(u => u.AppUserId);
                                              
                builder.Entity<UserActivity>().HasOne(a => a.Activity)
                                              .WithMany(a => a.UserActivities)
                                              .HasForeignKey(a => a.ActivityId);
        }
    }
}
