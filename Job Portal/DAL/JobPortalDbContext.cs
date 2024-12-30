using Microsoft.EntityFrameworkCore;
namespace Job_Portal.DAL
{
    public class JobPortalDbContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobDetails> JobDetails { get; set; }
        public DbSet<ApplyForm> ApplyForms { get; set; }

        public JobPortalDbContext(DbContextOptions<JobPortalDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>()
                .HasOne(j => j.JobDetails)
                .WithOne(jd => jd.Job)
                .HasForeignKey<JobDetails>(jd => jd.JobId);

            modelBuilder.Entity<ApplyForm>()
                .HasOne(af => af.Job)
                .WithMany(j => j.Applications)
                .HasForeignKey(af => af.JobId);

            base.OnModelCreating(modelBuilder);
        }
    }

}
