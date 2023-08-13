namespace AssignmentPorfolio_MedVision.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Flybook")
        {
        }

        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
  
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
        public virtual DbSet<CT> CTs { get; set; }

        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Registrations)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.Patient_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Registration>()
                .HasOptional(e => e.Rating)
                .WithRequired(e => e.Registration);


            modelBuilder.Entity<CT>()
                .HasMany(e => e.Registrations)
                .WithRequired(e => e.CT)
                .HasForeignKey(e => e.CT_id)
                .WillCascadeOnDelete(false);
        }*/
    }
}
