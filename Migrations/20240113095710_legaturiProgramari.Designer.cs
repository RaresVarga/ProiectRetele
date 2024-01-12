﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProiectRetele.Data;

#nullable disable

namespace ProiectRetele.Migrations
{
    [DbContext(typeof(ProiectReteleContext))]
    [Migration("20240113095710_legaturiProgramari")]
    partial class legaturiProgramari
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProiectRetele.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("ProiectRetele.Models.Factura", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("ID_Programare")
                        .HasColumnType("int");

                    b.Property<int>("Pret")
                        .HasColumnType("int");

                    b.Property<int?>("ProgramareID")
                        .HasColumnType("int");

                    b.Property<string>("Serviciu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ProgramareID");

                    b.ToTable("Factura");
                });

            modelBuilder.Entity("ProiectRetele.Models.Masina", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("AnFabricatie")
                        .HasColumnType("int");

                    b.Property<int?>("ClientID")
                        .HasColumnType("int");

                    b.Property<int>("ID_Client")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumarInmatriculare")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.ToTable("Masina");
                });

            modelBuilder.Entity("ProiectRetele.Models.Mecanic", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Mecanic");
                });

            modelBuilder.Entity("ProiectRetele.Models.Programare", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("ID_Masina")
                        .HasColumnType("int");

                    b.Property<int>("ID_Mecanic")
                        .HasColumnType("int");

                    b.Property<int?>("MasinaID")
                        .HasColumnType("int");

                    b.Property<int?>("MecanicID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MasinaID");

                    b.HasIndex("MecanicID");

                    b.ToTable("Programare");
                });

            modelBuilder.Entity("ProiectRetele.Models.Factura", b =>
                {
                    b.HasOne("ProiectRetele.Models.Programare", "Programare")
                        .WithMany("Facturi")
                        .HasForeignKey("ProgramareID");

                    b.Navigation("Programare");
                });

            modelBuilder.Entity("ProiectRetele.Models.Masina", b =>
                {
                    b.HasOne("ProiectRetele.Models.Client", "Client")
                        .WithMany("Masini")
                        .HasForeignKey("ClientID");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("ProiectRetele.Models.Programare", b =>
                {
                    b.HasOne("ProiectRetele.Models.Masina", "Masina")
                        .WithMany("Programari")
                        .HasForeignKey("MasinaID");

                    b.HasOne("ProiectRetele.Models.Mecanic", "Mecanic")
                        .WithMany("Programari")
                        .HasForeignKey("MecanicID");

                    b.Navigation("Masina");

                    b.Navigation("Mecanic");
                });

            modelBuilder.Entity("ProiectRetele.Models.Client", b =>
                {
                    b.Navigation("Masini");
                });

            modelBuilder.Entity("ProiectRetele.Models.Masina", b =>
                {
                    b.Navigation("Programari");
                });

            modelBuilder.Entity("ProiectRetele.Models.Mecanic", b =>
                {
                    b.Navigation("Programari");
                });

            modelBuilder.Entity("ProiectRetele.Models.Programare", b =>
                {
                    b.Navigation("Facturi");
                });
#pragma warning restore 612, 618
        }
    }
}
