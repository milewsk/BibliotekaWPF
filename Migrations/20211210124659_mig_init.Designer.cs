﻿// <auto-generated />
using System;
using BibliotekaWPF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BibliotekaWPF.Migrations
{
    [DbContext(typeof(Context.AppContext))]
    [Migration("20211210124659_mig_init")]
    partial class mig_init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BibliotekaWPF.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BibliotekaWPF.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("Available")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int>("IdCategory")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<int>("YearPublished")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("IdCategory");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BibliotekaWPF.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BibliotekaWPF.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MembersCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("BibliotekaWPF.Models.Loan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfLoan")
                        .HasColumnType("DateTime");

                    b.Property<int>("IdBook")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<int>("IsReturned")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("DateTime");

                    b.Property<DateTime>("UserReturn")
                        .HasColumnType("DateTime");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("IdUser");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("BibliotekaWPF.Models.Meeting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("DateTime");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("IdGroup")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdGroup");

                    b.ToTable("Meetings");
                });

            modelBuilder.Entity("BibliotekaWPF.Models.Penalty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("DateTime");

                    b.Property<int>("LoanID")
                        .HasColumnType("int");

                    b.Property<int>("Sum")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LoanID")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Penalties");
                });

            modelBuilder.Entity("BibliotekaWPF.Models.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("DateTime");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("BibliotekaWPF.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<int>("isAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BibliotekaWPF.Models.User_Group", b =>
                {
                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<int>("IdGroup")
                        .HasColumnType("int");

                    b.HasKey("IdUser", "IdGroup");

                    b.HasIndex("IdGroup");

                    b.ToTable("User_Groups");
                });

            modelBuilder.Entity("BibliotekaWPF.Models.Book", b =>
                {
                    b.HasOne("BibliotekaWPF.Models.Author", "BookAuthor")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BibliotekaWPF.Models.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("IdCategory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BibliotekaWPF.Models.Loan", b =>
                {
                    b.HasOne("BibliotekaWPF.Models.Book", "Book")
                        .WithMany("Loans")
                        .HasForeignKey("BookId");

                    b.HasOne("BibliotekaWPF.Models.User", "User")
                        .WithMany("Loans")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BibliotekaWPF.Models.Meeting", b =>
                {
                    b.HasOne("BibliotekaWPF.Models.Group", "Group")
                        .WithMany("Meetings")
                        .HasForeignKey("IdGroup")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BibliotekaWPF.Models.Penalty", b =>
                {
                    b.HasOne("BibliotekaWPF.Models.Loan", "loan")
                        .WithOne("Penalty")
                        .HasForeignKey("BibliotekaWPF.Models.Penalty", "LoanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BibliotekaWPF.Models.User", null)
                        .WithMany("Penalties")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("BibliotekaWPF.Models.Purchase", b =>
                {
                    b.HasOne("BibliotekaWPF.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BibliotekaWPF.Models.User", "User")
                        .WithMany("Purchases")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BibliotekaWPF.Models.User_Group", b =>
                {
                    b.HasOne("BibliotekaWPF.Models.Group", "Group")
                        .WithMany("User_Groups")
                        .HasForeignKey("IdGroup")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BibliotekaWPF.Models.User", "User")
                        .WithMany("User_Groups")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
