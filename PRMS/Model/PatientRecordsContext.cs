using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Model
{
    public partial class PatientRecordsContext : DbContext
    {
        public PatientRecordsContext()
        {
        }

        public PatientRecordsContext(DbContextOptions<PatientRecordsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Allergy> Allergies { get; set; }
        public virtual DbSet<Concern> Concerns { get; set; }
        public virtual DbSet<Gp> Gps { get; set; }
        public virtual DbSet<Medication> Medications { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<PatientAllergy> PatientAllergies { get; set; }
        public virtual DbSet<PatientImmunisation> PatientImmunisations { get; set; }
        public virtual DbSet<PatientMedication> PatientMedications { get; set; }
        public virtual DbSet<Vaccine> Vaccines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PatientRecords;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Allergy>(entity =>
            {
                entity.ToTable("Allergy");

                entity.Property(e => e.AllergyId).HasColumnName("AllergyID");

                entity.Property(e => e.Allergen)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ReactionType)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Concern>(entity =>
            {
                entity.Property(e => e.ConcernId).HasColumnName("ConcernID");

                entity.Property(e => e.Concern1)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Concern");

                entity.Property(e => e.ConcernDate).HasColumnType("datetime");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.InversePatient)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Concerns__Patien__286302EC");
            });

            modelBuilder.Entity<Gp>(entity =>
            {
                entity.ToTable("GP");

                entity.Property(e => e.Gpid).HasColumnName("GPID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Medication>(entity =>
            {
                entity.ToTable("Medication");

                entity.Property(e => e.MedicationId).HasColumnName("MedicationID");

                entity.Property(e => e.MedicationName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Address3)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Gpid).HasColumnName("GPID");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Gp)
                    .WithMany(p => p.InverseGp)
                    .HasForeignKey(d => d.Gpid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Patient__GPID__25869641");
            });

            modelBuilder.Entity<PatientAllergy>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AllergyId).HasColumnName("AllergyID");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.HasOne(d => d.Allergy)
                    .WithMany()
                    .HasForeignKey(d => d.AllergyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PatientAl__Aller__31EC6D26");

                entity.HasOne(d => d.Patient)
                    .WithMany()
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PatientAl__Patie__30F848ED");
            });

            modelBuilder.Entity<PatientImmunisation>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.Property(e => e.VaccineDate).HasColumnType("datetime");

                entity.Property(e => e.VaccineId).HasColumnName("VaccineID");

                entity.HasOne(d => d.Patient)
                    .WithMany()
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PatientIm__Patie__2C3393D0");

                entity.HasOne(d => d.Vaccine)
                    .WithMany()
                    .HasForeignKey(d => d.VaccineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PatientIm__Vacci__2D27B809");
            });

            modelBuilder.Entity<PatientMedication>(entity =>
            {
                entity.Property(e => e.PatientMedicationId).HasColumnName("PatientMedicationID");

                entity.Property(e => e.Dosage)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Frequency)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MedicationId).HasColumnName("MedicationID");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StopDate).HasColumnType("datetime");

                entity.HasOne(d => d.Medication)
                    .WithMany(p => p.PatientMedications)
                    .HasForeignKey(d => d.MedicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PatientMe__Medic__37A5467C");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientMedications)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PatientMe__Patie__36B12243");
            });

            modelBuilder.Entity<Vaccine>(entity =>
            {
                entity.ToTable("Vaccine");

                entity.Property(e => e.VaccineId).HasColumnName("VaccineID");

                entity.Property(e => e.Vaccine1)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Vaccine");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
