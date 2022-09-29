﻿// <auto-generated />
using System;
using MedprDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MedprDB.Migrations
{
    [DbContext(typeof(MedprDBContext))]
    partial class MedprDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MedprDB.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("DateTime2");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("UserId");

                    b.ToTable("Appointment", (string)null);
                });

            modelBuilder.Entity("MedprDB.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doctor", (string)null);
                });

            modelBuilder.Entity("MedprDB.Drug", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PharmGroup")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Drug", (string)null);
                });

            modelBuilder.Entity("MedprDB.Family", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Family", (string)null);
                });

            modelBuilder.Entity("MedprDB.FamilyMember", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FamilyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.HasIndex("UserId");

                    b.ToTable("FamilyMember", (string)null);
                });

            modelBuilder.Entity("MedprDB.Prescription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Dose")
                        .HasColumnType("int");

                    b.Property<Guid>("DrugId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("DateTime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("DateTime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("DrugId");

                    b.HasIndex("UserId");

                    b.ToTable("Prescription", (string)null);
                });

            modelBuilder.Entity("MedprDB.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("DateTime2");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("MedprDB.Vaccination", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("DateTime2");

                    b.Property<int>("DaysOfProtection")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VaccineId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VaccineId");

                    b.ToTable("Vaccination", (string)null);
                });

            modelBuilder.Entity("MedprDB.Vaccine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vaccine", (string)null);
                });

            modelBuilder.Entity("MedprDB.Appointment", b =>
                {
                    b.HasOne("MedprDB.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedprDB.User", "User")
                        .WithMany("Appointments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MedprDB.FamilyMember", b =>
                {
                    b.HasOne("MedprDB.Family", "Family")
                        .WithMany("FamilyMember")
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedprDB.User", "User")
                        .WithMany("FamilyMember")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Family");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MedprDB.Prescription", b =>
                {
                    b.HasOne("MedprDB.Doctor", "Doctor")
                        .WithMany("Prescriptions")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedprDB.Drug", "Drug")
                        .WithMany("Prescriptions")
                        .HasForeignKey("DrugId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedprDB.User", "User")
                        .WithMany("Prescriptions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Drug");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MedprDB.Vaccination", b =>
                {
                    b.HasOne("MedprDB.User", "User")
                        .WithMany("Vaccinations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedprDB.Vaccine", "Vaccine")
                        .WithMany("Vaccinations")
                        .HasForeignKey("VaccineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Vaccine");
                });

            modelBuilder.Entity("MedprDB.Doctor", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("MedprDB.Drug", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("MedprDB.Family", b =>
                {
                    b.Navigation("FamilyMember");
                });

            modelBuilder.Entity("MedprDB.User", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("FamilyMember");

                    b.Navigation("Prescriptions");

                    b.Navigation("Vaccinations");
                });

            modelBuilder.Entity("MedprDB.Vaccine", b =>
                {
                    b.Navigation("Vaccinations");
                });
#pragma warning restore 612, 618
        }
    }
}
