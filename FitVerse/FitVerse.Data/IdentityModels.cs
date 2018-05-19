using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using FitVerse.Model.Models;
using FitVerse.Model;
using FitVerse;

namespace WebApp.Models
{
    public class FitVerseEntities : IdentityDbContext<ApplicationUser>
    {
        public FitVerseEntities()
            : base("FitVerseEntities", throwIfV1Schema: false)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        /* FROM THE TUTORIAL */
        public DbSet<Gadget> Gadgets { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Week> Weeks { get; set; }
        //public DbSet<WeekAndDays> WeeksAndDays { get; set; }
        public DbSet<Day> Days { get; set; }
        //public DbSet<DayAndComponents> DaysAndComponents { get; set; }

        /* COMPONENTS BASE */
        public DbSet<Component> Components { get; set; }

        /* POINTERS TO TYPES OF COMPONENTS */
        public DbSet<StudyHour> StudyHours { get; set; }
        public DbSet<FreeTime> FreeTimes { get; set; }
        public DbSet<EduTime> EduTimes { get; set; }
        public DbSet<FitnessTime> FitnessTimes { get; set; }

        public DbSet<Eating> Eatings { get; set; }
        public DbSet<EatingComponent> EatingComponents { get; set; }
        public DbSet<ThingToEat> ThingsToEat { get; set; }

        /* DIFFERENT TYPES OF COMPONENTS */
        public DbSet<Subject> Subjects { get; set; }
        //public DbSet<Meal> Meals { get; set; }

        /* TYPES OF COMPONENTS DETAILS - WORKOUT */
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseInWorkout> ExercisesInWorkout { get; set; }

        public DbSet<Stats> Stats { get; set; }
        public DbSet<StatusLevel> StatusLevels { get; set; }
        public DbSet<Priorities> Priorities { get; set; }

        public DbSet<UserFitnessGoals> UserFitnessGoals { get; set; }
        public DbSet<News> NewsReadByUsers { get; set; }

        public DbSet<Challenge> Challenges { get; set; }

        public static FitVerseEntities Create()
        {
            return new FitVerseEntities();
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}