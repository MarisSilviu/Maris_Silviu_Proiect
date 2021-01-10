﻿// <auto-generated />
using System;
using Maris_Silviu_Proiect.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Maris_Silviu_Proiect.Migrations
{
    [DbContext(typeof(Maris_Silviu_ProiectContext))]
    [Migration("20210108134339_Specializare")]
    partial class Specializare
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Maris_Silviu_Proiect.Models.Medic", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MedicName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MedicSpecializare")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Medic");
                });

            modelBuilder.Entity("Maris_Silviu_Proiect.Models.Pacient", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataInternare")
                        .HasColumnType("datetime2");

                    b.Property<string>("Diagnostic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MedicID")
                        .HasColumnType("int");

                    b.Property<string>("Nume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salon")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MedicID");

                    b.ToTable("Pacient");
                });

            modelBuilder.Entity("Maris_Silviu_Proiect.Models.Sectie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SectieName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Sectie");
                });

            modelBuilder.Entity("Maris_Silviu_Proiect.Models.SectiePacient", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PacientID")
                        .HasColumnType("int");

                    b.Property<int>("SectieID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PacientID");

                    b.HasIndex("SectieID");

                    b.ToTable("SectiePacient");
                });

            modelBuilder.Entity("Maris_Silviu_Proiect.Models.Pacient", b =>
                {
                    b.HasOne("Maris_Silviu_Proiect.Models.Medic", "Medic")
                        .WithMany("Pacienti")
                        .HasForeignKey("MedicID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Maris_Silviu_Proiect.Models.SectiePacient", b =>
                {
                    b.HasOne("Maris_Silviu_Proiect.Models.Pacient", "Pacient")
                        .WithMany("SectiePacienti")
                        .HasForeignKey("PacientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Maris_Silviu_Proiect.Models.Sectie", "Sectie")
                        .WithMany("SectiePacienti")
                        .HasForeignKey("SectieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
