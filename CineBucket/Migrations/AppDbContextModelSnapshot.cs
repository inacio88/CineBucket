﻿// <auto-generated />
using System;
using CineBucket.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CineBucket.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CineBucket.Models.FavoriteMovie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AddedAt")
                        .HasColumnType("TIMESTAMP");

                    b.Property<string>("OriginalTitle")
                        .IsRequired()
                        .HasMaxLength(65)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("PosterPath")
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR");

                    b.Property<short>("Priority")
                        .HasColumnType("SMALLINT");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("Runtime")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR");

                    b.Property<int>("TmdbId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("FavoriteMovies", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
