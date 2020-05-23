using System;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Action = System.Action;

namespace DAL
{
    public class AppDbContext: IdentityDbContext<Pupil, AppRole, int>
    {
        public DbSet<PupilAction> Actions { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<HabitLoop> HabitLoops { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Trigger> Triggers { get; set; }
        public DbSet<WatchList> WatchLists { get; set; }
        public DbSet<WatchListHabitLoop> WatchListHabitLoops { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}