﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OzonePrime.Models;

namespace OzonePrime.Migrations
{
    [DbContext(typeof(ozoneprimeContext))]
    [Migration("20210304102035_test1")]
    partial class test1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("OzonePrime.Models.Cast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("last_name");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.ToTable("cast");
                });

            modelBuilder.Entity("OzonePrime.Models.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("ExpirationDays")
                        .HasColumnType("int")
                        .HasColumnName("expiration_days")
                        .HasDefaultValueSql("'15'");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,0)")
                        .HasColumnName("price");

                    b.Property<int?>("YearRelease")
                        .HasColumnType("int")
                        .HasColumnName("year_release");

                    b.HasKey("Id");

                    b.ToTable("films");
                });

            modelBuilder.Entity("OzonePrime.Models.FilmsCast", b =>
                {
                    b.Property<int>("CastId")
                        .HasColumnType("int")
                        .HasColumnName("cast_id");

                    b.Property<int>("FilmId")
                        .HasColumnType("int")
                        .HasColumnName("film_id");

                    b.HasIndex(new[] { "CastId" }, "cast_id");

                    b.HasIndex(new[] { "FilmId" }, "film_id");

                    b.ToTable("films_cast");
                });

            modelBuilder.Entity("OzonePrime.Models.FilmsGenre", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int")
                        .HasColumnName("film_id");

                    b.Property<int>("GenreId")
                        .HasColumnType("int")
                        .HasColumnName("genre_id");

                    b.HasIndex(new[] { "FilmId" }, "film_id");

                    b.HasIndex(new[] { "GenreId" }, "genre_id");

                    b.ToTable("films_genres");
                });

            modelBuilder.Entity("OzonePrime.Models.FilmsUser", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int")
                        .HasColumnName("film_id");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasIndex(new[] { "FilmId" }, "film_id");

                    b.HasIndex(new[] { "UserId" }, "user_id");

                    b.ToTable("films_users");
                });

            modelBuilder.Entity("OzonePrime.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("name");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.ToTable("genres");
                });

            modelBuilder.Entity("OzonePrime.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("OzonePrime.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("password");

                    //b.Property<string>("Username")
                    //    .IsRequired()
                    //    .HasMaxLength(40)
                    //    .HasColumnType("varchar(40)")
                    //    .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("OzonePrime.Models.UsersRole", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasIndex(new[] { "RoleId" }, "role_id");

                    b.HasIndex(new[] { "UserId" }, "user_id");

                    b.ToTable("users_roles");
                });

            modelBuilder.Entity("OzonePrime.Models.FilmsCast", b =>
                {
                    b.HasOne("OzonePrime.Models.Cast", "Cast")
                        .WithMany()
                        .HasForeignKey("CastId")
                        .HasConstraintName("films_cast_ibfk_2")
                        .IsRequired();

                    b.HasOne("OzonePrime.Models.Film", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .HasConstraintName("films_cast_ibfk_1")
                        .IsRequired();

                    b.Navigation("Cast");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("OzonePrime.Models.FilmsGenre", b =>
                {
                    b.HasOne("OzonePrime.Models.Film", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .HasConstraintName("films_genres_ibfk_1")
                        .IsRequired();

                    b.HasOne("OzonePrime.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .HasConstraintName("films_genres_ibfk_2")
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("OzonePrime.Models.FilmsUser", b =>
                {
                    b.HasOne("OzonePrime.Models.Film", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .HasConstraintName("films_users_ibfk_1")
                        .IsRequired();

                    b.HasOne("OzonePrime.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("films_users_ibfk_2")
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OzonePrime.Models.UsersRole", b =>
                {
                    b.HasOne("OzonePrime.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("users_roles_ibfk_2")
                        .IsRequired();

                    b.HasOne("OzonePrime.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("users_roles_ibfk_1")
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
