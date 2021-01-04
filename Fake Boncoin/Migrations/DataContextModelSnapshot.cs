﻿// <auto-generated />
using System;
using Fake_Boncoin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fake_Boncoin.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Fake_Boncoin.Models.Annonce", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Prix")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Titre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Annonces");
                });

            modelBuilder.Entity("Fake_Boncoin.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AnnonceId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AnnonceId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("Fake_Boncoin.Models.Image", b =>
                {
                    b.HasOne("Fake_Boncoin.Models.Annonce", "Annonce")
                        .WithMany("Images")
                        .HasForeignKey("AnnonceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Annonce");
                });

            modelBuilder.Entity("Fake_Boncoin.Models.Annonce", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}