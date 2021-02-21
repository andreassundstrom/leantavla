﻿// <auto-generated />
using System;
using Leantavla.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Leantavla.Server.Migrations
{
    [DbContext(typeof(LeantavlaContext))]
    partial class LenatavlaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Leantavla.Shared.Attribut", b =>
                {
                    b.Property<int>("AttributId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AttributtypId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateValue")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LappId")
                        .HasColumnType("int");

                    b.Property<string>("StringValue")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AttributId");

                    b.HasIndex("AttributtypId");

                    b.HasIndex("LappId");

                    b.ToTable("Attribut");
                });

            modelBuilder.Entity("Leantavla.Shared.Attributtyp", b =>
                {
                    b.Property<int>("AttributtypId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Attributbeskrivning")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Attributnamn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BrädaId")
                        .HasColumnType("int");

                    b.Property<int>("Datatyp")
                        .HasColumnType("int");

                    b.HasKey("AttributtypId");

                    b.HasIndex("BrädaId");

                    b.ToTable("Attributtyper");
                });

            modelBuilder.Entity("Leantavla.Shared.Bräda", b =>
                {
                    b.Property<int>("BrädaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("BrädaNamn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BrädaId");

                    b.ToTable("Bräda");
                });

            modelBuilder.Entity("Leantavla.Shared.Lapp", b =>
                {
                    b.Property<int>("LappId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BrädaId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("LappId");

                    b.HasIndex("BrädaId");

                    b.HasIndex("StatusId");

                    b.ToTable("Lappar");
                });

            modelBuilder.Entity("Leantavla.Shared.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BrädaId")
                        .HasColumnType("int");

                    b.Property<int>("Sortering")
                        .HasColumnType("int");

                    b.Property<string>("StatusNamn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.HasIndex("BrädaId");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Leantavla.Shared.Attribut", b =>
                {
                    b.HasOne("Leantavla.Shared.Attributtyp", "Attributtyp")
                        .WithMany()
                        .HasForeignKey("AttributtypId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Leantavla.Shared.Lapp", null)
                        .WithMany("Attribut")
                        .HasForeignKey("LappId");

                    b.Navigation("Attributtyp");
                });

            modelBuilder.Entity("Leantavla.Shared.Attributtyp", b =>
                {
                    b.HasOne("Leantavla.Shared.Bräda", "Bräda")
                        .WithMany("Attributtyper")
                        .HasForeignKey("BrädaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bräda");
                });

            modelBuilder.Entity("Leantavla.Shared.Lapp", b =>
                {
                    b.HasOne("Leantavla.Shared.Bräda", "Bräda")
                        .WithMany("Lappar")
                        .HasForeignKey("BrädaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Leantavla.Shared.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bräda");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Leantavla.Shared.Status", b =>
                {
                    b.HasOne("Leantavla.Shared.Bräda", "Bräda")
                        .WithMany("Statusar")
                        .HasForeignKey("BrädaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Bräda");
                });

            modelBuilder.Entity("Leantavla.Shared.Bräda", b =>
                {
                    b.Navigation("Attributtyper");

                    b.Navigation("Lappar");

                    b.Navigation("Statusar");
                });

            modelBuilder.Entity("Leantavla.Shared.Lapp", b =>
                {
                    b.Navigation("Attribut");
                });
#pragma warning restore 612, 618
        }
    }
}
