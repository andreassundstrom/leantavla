﻿// <auto-generated />
using System;
using Leantavla.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Leantavla.Server.Migrations
{
    [DbContext(typeof(LenatavlaContext))]
    [Migration("20210206125210_2")]
    partial class _2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("AttributtypId")
                        .HasColumnType("int");

                    b.Property<int?>("LappId")
                        .HasColumnType("int");

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

                    b.Property<int>("Datatyp")
                        .HasColumnType("int");

                    b.HasKey("AttributtypId");

                    b.ToTable("Attributtyp");
                });

            modelBuilder.Entity("Leantavla.Shared.Lapp", b =>
                {
                    b.Property<int>("LappId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Beskrivning")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sammanfattning")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LappId");

                    b.ToTable("Lappar");
                });

            modelBuilder.Entity("Leantavla.Shared.Attribut", b =>
                {
                    b.HasOne("Leantavla.Shared.Attributtyp", "Attributtyp")
                        .WithMany()
                        .HasForeignKey("AttributtypId");

                    b.HasOne("Leantavla.Shared.Lapp", null)
                        .WithMany("Attribut")
                        .HasForeignKey("LappId");

                    b.Navigation("Attributtyp");
                });

            modelBuilder.Entity("Leantavla.Shared.Lapp", b =>
                {
                    b.Navigation("Attribut");
                });
#pragma warning restore 612, 618
        }
    }
}
