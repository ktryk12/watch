﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimeRecordingMicroservice.Modellayer;

#nullable disable

namespace TimeRecordingMicroservice.Migrations
{
    [DbContext(typeof(ServiceContext))]
    [Migration("20240226203432_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TimeRecordingMicroservice.Modellayer.TimeRegistration", b =>
                {
                    b.Property<int>("TimeRegistrationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TimeRegistrationId"));

                    b.Property<DateTime>("CheckInTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOutTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("OvertimeHours")
                        .HasColumnType("float");

                    b.Property<double>("TotalWorkHours")
                        .HasColumnType("float");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.HasKey("TimeRegistrationId");

                    b.ToTable("TimeRegistration");
                });
#pragma warning restore 612, 618
        }
    }
}
