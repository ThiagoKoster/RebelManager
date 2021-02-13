﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RebelManager.Infrastructure;

namespace RebelManager.Infrastructure.Migrations
{
    [DbContext(typeof(RebelManagerDbContext))]
    partial class RebelManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RebelManager.Domain.Aggregates.FleetAggregate.Fleet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fleet");
                });

            modelBuilder.Entity("RebelManager.Domain.Aggregates.FleetAggregate.Pilot", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ShipId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ShipId");

                    b.ToTable("Pilot");
                });

            modelBuilder.Entity("RebelManager.Domain.Aggregates.FleetAggregate.Ship", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Class")
                        .HasColumnType("int");

                    b.Property<long?>("FleetId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FleetId");

                    b.ToTable("Ship");
                });

            modelBuilder.Entity("RebelManager.Domain.Aggregates.FleetAggregate.Pilot", b =>
                {
                    b.HasOne("RebelManager.Domain.Aggregates.FleetAggregate.Ship", null)
                        .WithMany("Pilots")
                        .HasForeignKey("ShipId");
                });

            modelBuilder.Entity("RebelManager.Domain.Aggregates.FleetAggregate.Ship", b =>
                {
                    b.HasOne("RebelManager.Domain.Aggregates.FleetAggregate.Fleet", null)
                        .WithMany("Ships")
                        .HasForeignKey("FleetId");
                });

            modelBuilder.Entity("RebelManager.Domain.Aggregates.FleetAggregate.Fleet", b =>
                {
                    b.Navigation("Ships");
                });

            modelBuilder.Entity("RebelManager.Domain.Aggregates.FleetAggregate.Ship", b =>
                {
                    b.Navigation("Pilots");
                });
#pragma warning restore 612, 618
        }
    }
}
