﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using web_1.Context;

#nullable disable

namespace web_1.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20231213224813_sdsdsds")]
    partial class sdsdsds
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EfCore2C.Models.Firma", b =>
                {
                    b.Property<int>("firma_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("firma_id"));

                    b.Property<string>("firma_adi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("firma_id");

                    b.ToTable("Firmas");
                });

            modelBuilder.Entity("EfCore2C.Models.Havalimani", b =>
                {
                    b.Property<int>("havalimani_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("havalimani_id"));

                    b.Property<string>("havalimani_adi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("sehir_id")
                        .HasColumnType("integer");

                    b.HasKey("havalimani_id");

                    b.HasIndex("sehir_id");

                    b.ToTable("Havalimanis");
                });

            modelBuilder.Entity("EfCore2C.Models.Sefer", b =>
                {
                    b.Property<int>("sefer_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("sefer_id"));

                    b.Property<int>("firma_id")
                        .HasColumnType("integer");

                    b.Property<int>("kalkis_havalimani_id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("kalkis_saati")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("sefer_fiati")
                        .HasColumnType("numeric");

                    b.Property<int>("varis_havalimani_id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("varis_saati")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("sefer_id");

                    b.HasIndex("firma_id");

                    b.HasIndex("kalkis_havalimani_id");

                    b.HasIndex("varis_havalimani_id");

                    b.ToTable("Sefers");
                });

            modelBuilder.Entity("EfCore2C.Models.Sehir", b =>
                {
                    b.Property<int>("sehir_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("sehir_id"));

                    b.Property<string>("sehir_adi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("sehir_id");

                    b.ToTable("Sehirs");
                });

            modelBuilder.Entity("EfCore2C.Models.airline.Models.Rezervasyon", b =>
                {
                    b.Property<int>("rezervasyon_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("rezervasyon_id"));

                    b.Property<int>("koltuk_sayisi")
                        .HasColumnType("integer");

                    b.Property<string>("rezervasyonTipi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("sefer_id")
                        .HasColumnType("integer");

                    b.HasKey("rezervasyon_id");

                    b.HasIndex("sefer_id");

                    b.ToTable("Rezervasyon");
                });

            modelBuilder.Entity("web_1.Models.Person", b =>
                {
                    b.Property<int>("person_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("person_id"));

                    b.Property<string>("ad")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("dogum_tarihi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("gmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("sifre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("soyad")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("telefon")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("person_id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("EfCore2C.Models.Havalimani", b =>
                {
                    b.HasOne("EfCore2C.Models.Sehir", "Sehir")
                        .WithMany("Havalimanis")
                        .HasForeignKey("sehir_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sehir");
                });

            modelBuilder.Entity("EfCore2C.Models.Sefer", b =>
                {
                    b.HasOne("EfCore2C.Models.Firma", "Firma")
                        .WithMany("Seferler")
                        .HasForeignKey("firma_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfCore2C.Models.Havalimani", "KalkisHavalimani")
                        .WithMany()
                        .HasForeignKey("kalkis_havalimani_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfCore2C.Models.Havalimani", "VarisHavalimani")
                        .WithMany()
                        .HasForeignKey("varis_havalimani_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Firma");

                    b.Navigation("KalkisHavalimani");

                    b.Navigation("VarisHavalimani");
                });

            modelBuilder.Entity("EfCore2C.Models.airline.Models.Rezervasyon", b =>
                {
                    b.HasOne("EfCore2C.Models.Sefer", "Sefer")
                        .WithMany("Rezervasyons")
                        .HasForeignKey("sefer_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sefer");
                });

            modelBuilder.Entity("EfCore2C.Models.Firma", b =>
                {
                    b.Navigation("Seferler");
                });

            modelBuilder.Entity("EfCore2C.Models.Sefer", b =>
                {
                    b.Navigation("Rezervasyons");
                });

            modelBuilder.Entity("EfCore2C.Models.Sehir", b =>
                {
                    b.Navigation("Havalimanis");
                });
#pragma warning restore 612, 618
        }
    }
}
