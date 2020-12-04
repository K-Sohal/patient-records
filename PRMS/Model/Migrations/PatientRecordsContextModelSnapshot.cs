﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model;

namespace Model.Migrations
{
    [DbContext(typeof(PatientRecordsContext))]
    partial class PatientRecordsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Model.Allergy", b =>
                {
                    b.Property<int>("AllergyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AllergyID")
                        .UseIdentityColumn();

                    b.Property<string>("Allergen")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("ReactionType")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.HasKey("AllergyId");

                    b.ToTable("Allergy");
                });

            modelBuilder.Entity("Model.Concern", b =>
                {
                    b.Property<int>("ConcernId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ConcernID")
                        .UseIdentityColumn();

                    b.Property<string>("Concern1")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Concern");

                    b.Property<DateTime?>("ConcernDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("ConcernId1")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int")
                        .HasColumnName("PatientID");

                    b.HasKey("ConcernId");

                    b.HasIndex("ConcernId1");

                    b.HasIndex("PatientId");

                    b.ToTable("Concerns");
                });

            modelBuilder.Entity("Model.Gp", b =>
                {
                    b.Property<int>("Gpid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("GPID")
                        .UseIdentityColumn();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Gpid");

                    b.ToTable("GP");
                });

            modelBuilder.Entity("Model.Medication", b =>
                {
                    b.Property<int>("MedicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MedicationID")
                        .UseIdentityColumn();

                    b.Property<string>("MedicationName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("MedicationId");

                    b.ToTable("Medication");
                });

            modelBuilder.Entity("Model.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PatientID")
                        .UseIdentityColumn();

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasMaxLength(120)
                        .IsUnicode(false)
                        .HasColumnType("varchar(120)");

                    b.Property<string>("Address2")
                        .HasMaxLength(120)
                        .IsUnicode(false)
                        .HasColumnType("varchar(120)");

                    b.Property<string>("Address3")
                        .HasMaxLength(120)
                        .IsUnicode(false)
                        .HasColumnType("varchar(120)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<int>("Gpid")
                        .HasColumnType("int")
                        .HasColumnName("GPID");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("PatientId");

                    b.HasIndex("Gpid");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("Model.PatientAllergy", b =>
                {
                    b.Property<int>("AllergyId")
                        .HasColumnType("int")
                        .HasColumnName("AllergyID");

                    b.Property<int>("PatientId")
                        .HasColumnType("int")
                        .HasColumnName("PatientID");

                    b.HasIndex("AllergyId");

                    b.HasIndex("PatientId");

                    b.ToTable("PatientAllergies");
                });

            modelBuilder.Entity("Model.PatientImmunisation", b =>
                {
                    b.Property<int>("PatientId")
                        .HasColumnType("int")
                        .HasColumnName("PatientID");

                    b.Property<DateTime>("VaccineDate")
                        .HasColumnType("datetime");

                    b.Property<int>("VaccineId")
                        .HasColumnType("int")
                        .HasColumnName("VaccineID");

                    b.HasIndex("PatientId");

                    b.HasIndex("VaccineId");

                    b.ToTable("PatientImmunisations");
                });

            modelBuilder.Entity("Model.PatientMedication", b =>
                {
                    b.Property<int>("PatientMedicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PatientMedicationID")
                        .UseIdentityColumn();

                    b.Property<string>("Dosage")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Frequency")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("MedicationId")
                        .HasColumnType("int")
                        .HasColumnName("MedicationID");

                    b.Property<int>("PatientId")
                        .HasColumnType("int")
                        .HasColumnName("PatientID");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("StopDate")
                        .HasColumnType("datetime");

                    b.HasKey("PatientMedicationId");

                    b.HasIndex("MedicationId");

                    b.HasIndex("PatientId");

                    b.ToTable("PatientMedications");
                });

            modelBuilder.Entity("Model.Vaccine", b =>
                {
                    b.Property<int>("VaccineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("VaccineID")
                        .UseIdentityColumn();

                    b.Property<string>("Vaccine1")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Vaccine");

                    b.HasKey("VaccineId");

                    b.ToTable("Vaccine");
                });

            modelBuilder.Entity("Model.Concern", b =>
                {
                    b.HasOne("Model.Concern", null)
                        .WithMany("InversePatient")
                        .HasForeignKey("ConcernId1");

                    b.HasOne("Model.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Model.Patient", b =>
                {
                    b.HasOne("Model.Gp", "Gp")
                        .WithMany()
                        .HasForeignKey("Gpid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gp");
                });

            modelBuilder.Entity("Model.PatientAllergy", b =>
                {
                    b.HasOne("Model.Allergy", "Allergy")
                        .WithMany()
                        .HasForeignKey("AllergyId")
                        .HasConstraintName("FK__PatientAl__Aller__31EC6D26")
                        .IsRequired();

                    b.HasOne("Model.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .HasConstraintName("FK__PatientAl__Patie__30F848ED")
                        .IsRequired();

                    b.Navigation("Allergy");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Model.PatientImmunisation", b =>
                {
                    b.HasOne("Model.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .HasConstraintName("FK__PatientIm__Patie__2C3393D0")
                        .IsRequired();

                    b.HasOne("Model.Vaccine", "Vaccine")
                        .WithMany()
                        .HasForeignKey("VaccineId")
                        .HasConstraintName("FK__PatientIm__Vacci__2D27B809")
                        .IsRequired();

                    b.Navigation("Patient");

                    b.Navigation("Vaccine");
                });

            modelBuilder.Entity("Model.PatientMedication", b =>
                {
                    b.HasOne("Model.Medication", "Medication")
                        .WithMany("PatientMedications")
                        .HasForeignKey("MedicationId")
                        .HasConstraintName("FK__PatientMe__Medic__37A5467C")
                        .IsRequired();

                    b.HasOne("Model.Patient", "Patient")
                        .WithMany("PatientMedications")
                        .HasForeignKey("PatientId")
                        .HasConstraintName("FK__PatientMe__Patie__36B12243")
                        .IsRequired();

                    b.Navigation("Medication");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Model.Concern", b =>
                {
                    b.Navigation("InversePatient");
                });

            modelBuilder.Entity("Model.Medication", b =>
                {
                    b.Navigation("PatientMedications");
                });

            modelBuilder.Entity("Model.Patient", b =>
                {
                    b.Navigation("PatientMedications");
                });
#pragma warning restore 612, 618
        }
    }
}
