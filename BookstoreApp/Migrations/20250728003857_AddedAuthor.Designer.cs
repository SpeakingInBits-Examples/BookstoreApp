﻿// <auto-generated />
using BookstoreApp.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookstoreApp.Migrations
{
    [DbContext(typeof(BookStoreDb))]
    [Migration("20250728003857_AddedAuthor")]
    partial class AddedAuthor
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookGenre", b =>
                {
                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.Property<int>("GenresGenreId")
                        .HasColumnType("int");

                    b.HasKey("BooksId", "GenresGenreId");

                    b.HasIndex("GenresGenreId");

                    b.ToTable("BookGenre");
                });

            modelBuilder.Entity("BookstoreApp.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("BookstoreApp.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookAuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookAuthorId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookstoreApp.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            Name = "Fiction"
                        },
                        new
                        {
                            GenreId = 2,
                            Name = "Non-Fiction"
                        },
                        new
                        {
                            GenreId = 3,
                            Name = "Science Fiction"
                        },
                        new
                        {
                            GenreId = 4,
                            Name = "Fantasy"
                        },
                        new
                        {
                            GenreId = 5,
                            Name = "Mystery"
                        },
                        new
                        {
                            GenreId = 6,
                            Name = "Biography"
                        },
                        new
                        {
                            GenreId = 7,
                            Name = "Romance"
                        },
                        new
                        {
                            GenreId = 8,
                            Name = "Historical"
                        },
                        new
                        {
                            GenreId = 9,
                            Name = "Horror"
                        },
                        new
                        {
                            GenreId = 10,
                            Name = "Young Adult"
                        });
                });

            modelBuilder.Entity("BookGenre", b =>
                {
                    b.HasOne("BookstoreApp.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookstoreApp.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresGenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookstoreApp.Models.Book", b =>
                {
                    b.HasOne("BookstoreApp.Models.Author", "BookAuthor")
                        .WithMany("Books")
                        .HasForeignKey("BookAuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookAuthor");
                });

            modelBuilder.Entity("BookstoreApp.Models.Author", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
