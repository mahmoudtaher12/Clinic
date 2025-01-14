﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebPractice.Models;

#nullable disable

namespace WebPractice.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebPractice.Models.Entites.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Did")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PId")
                        .HasColumnType("int");

                    b.HasKey("AppointmentId");

                    b.HasIndex("Did");

                    b.HasIndex("PId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("WebPractice.Models.Entites.Doctor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialty")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("WebPractice.Models.Entites.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientId"));

                    b.Property<int?>("PatientAge")
                        .HasColumnType("int");

                    b.Property<string>("PatientName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("WebPractice.Models.Entites.Appointment", b =>
                {
                    b.HasOne("WebPractice.Models.Entites.Doctor", "Doctor")
                        .WithMany("appointments")
                        .HasForeignKey("Did")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebPractice.Models.Entites.Patient", "Patient")
                        .WithMany("appointments")
                        .HasForeignKey("PId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("WebPractice.Models.Entites.Doctor", b =>
                {
                    b.Navigation("appointments");
                });

            modelBuilder.Entity("WebPractice.Models.Entites.Patient", b =>
                {
                    b.Navigation("appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
