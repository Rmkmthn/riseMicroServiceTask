﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Rise.ContactCore;

namespace Rise.ContactCore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220204123711_FirstMigration_!")]
    partial class FirstMigration_
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Rise.ContactCore.Models.Const", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("CDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ConstDesc")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("ConstID")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("ConstOrder")
                        .HasColumnType("text");

                    b.Property<string>("ConstValue")
                        .HasColumnType("text");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("MDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Const");
                });

            modelBuilder.Entity("Rise.ContactCore.Models.ConstLang", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("CDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ConstLangDesc")
                        .HasMaxLength(200)
                        .HasColumnType("integer");

                    b.Property<Guid>("ConstRID")
                        .HasColumnType("uuid");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("LangID")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("MDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("ConstLang");
                });

            modelBuilder.Entity("Rise.ContactCore.Models.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("CDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ContactCompany")
                        .HasColumnType("text");

                    b.Property<string>("ContactName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("ContactUserName")
                        .HasColumnType("text");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("MDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("Rise.ContactCore.Models.ContactInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("CDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ContactRID")
                        .HasColumnType("uuid");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("InfoTypeRID")
                        .HasColumnType("uuid");

                    b.Property<string>("InfoValue")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTimeOffset?>("MDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("ContactInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
