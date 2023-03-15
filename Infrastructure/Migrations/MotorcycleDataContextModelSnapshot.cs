﻿// <auto-generated />
using System;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(MotorcycleDataContext))]
    partial class MotorcycleDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ApplicationCore.Models.Entities.Motorcycle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EnginePower")
                        .HasColumnType("integer");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ModelType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Motorcycles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e662b658-404b-4078-afff-523fc6889253"),
                            Company = "Triumph",
                            EnginePower = 70,
                            ModelName = "Bonnevile T100",
                            ModelType = "Naked",
                            Price = 14000.0
                        },
                        new
                        {
                            Id = new Guid("f6ca9445-898d-405b-be7d-97ed33aac317"),
                            Company = "Kawasaki",
                            EnginePower = 7,
                            ModelName = "KLX110R",
                            ModelType = "Motocross",
                            Price = 3195.0
                        },
                        new
                        {
                            Id = new Guid("4f81dc65-1a56-44bb-90c2-0468c90c308d"),
                            Company = "BMW",
                            EnginePower = 136,
                            ModelName = "R 1250 RS",
                            ModelType = "Sport",
                            Price = 20000.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
