﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using kayaseker.DAL.Contexts;

namespace kayaseker.DAL.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20210813140204_yeniproje")]
    partial class yeniproje
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("kayaseker.DAL.Entities.ContentsComments", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ContentsPlacesID")
                        .HasColumnType("int");

                    b.Property<int>("Like")
                        .HasColumnType("int");

                    b.Property<int?>("MemberID")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasMaxLength(400)
                        .HasColumnType("Varchar(400)");

                    b.Property<string>("Title")
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<string>("UserName")
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<int?>("pictureID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ContentsPlacesID");

                    b.HasIndex("MemberID");

                    b.HasIndex("pictureID");

                    b.ToTable("ContentsComments");
                });

            modelBuilder.Entity("kayaseker.DAL.Entities.ContentsPlaces", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Title")
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.HasKey("ID");

                    b.ToTable("ContentsPlaces");
                });

            modelBuilder.Entity("kayaseker.DAL.Entities.ImageComments", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ContentsPlacesID")
                        .HasColumnType("int");

                    b.Property<int>("Like")
                        .HasColumnType("int");

                    b.Property<int?>("MemberID")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasMaxLength(400)
                        .HasColumnType("Varchar(400)");

                    b.Property<string>("Title")
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<string>("UserName")
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<int?>("pictureID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ContentsPlacesID");

                    b.HasIndex("MemberID");

                    b.HasIndex("pictureID");

                    b.ToTable("ImageComments");
                });

            modelBuilder.Entity("kayaseker.DAL.Entities.MediaPicture", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ContentsID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(400)
                        .HasColumnType("Varchar(400)");

                    b.Property<string>("ImageData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Like")
                        .HasColumnType("int");

                    b.Property<DateTime>("LogDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Owner")
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Title")
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<int>("View")
                        .HasColumnType("int");

                    b.Property<int>("contentID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ContentsID");

                    b.ToTable("MediaPicture");
                });

            modelBuilder.Entity("kayaseker.DAL.Entities.Member", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Mail")
                        .HasColumnType("varchar(60)");

                    b.Property<string>("NameSurName")
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Password")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<int>("RoleNumber")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("kayaseker.DAL.Entities.PlacesPictures", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("contentsPlacesID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("contentsPlacesID");

                    b.ToTable("PlacesPictures");
                });

            modelBuilder.Entity("kayaseker.DAL.Entities.ContentsComments", b =>
                {
                    b.HasOne("kayaseker.DAL.Entities.ContentsPlaces", null)
                        .WithMany("ContentsComments")
                        .HasForeignKey("ContentsPlacesID");

                    b.HasOne("kayaseker.DAL.Entities.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberID");

                    b.HasOne("kayaseker.DAL.Entities.MediaPicture", "Picture")
                        .WithMany()
                        .HasForeignKey("pictureID");

                    b.Navigation("Member");

                    b.Navigation("Picture");
                });

            modelBuilder.Entity("kayaseker.DAL.Entities.ImageComments", b =>
                {
                    b.HasOne("kayaseker.DAL.Entities.ContentsPlaces", null)
                        .WithMany("Comments")
                        .HasForeignKey("ContentsPlacesID");

                    b.HasOne("kayaseker.DAL.Entities.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberID");

                    b.HasOne("kayaseker.DAL.Entities.MediaPicture", "Picture")
                        .WithMany("Comments")
                        .HasForeignKey("pictureID");

                    b.Navigation("Member");

                    b.Navigation("Picture");
                });

            modelBuilder.Entity("kayaseker.DAL.Entities.MediaPicture", b =>
                {
                    b.HasOne("kayaseker.DAL.Entities.ContentsPlaces", "Contents")
                        .WithMany("MediaPictures")
                        .HasForeignKey("ContentsID");

                    b.Navigation("Contents");
                });

            modelBuilder.Entity("kayaseker.DAL.Entities.PlacesPictures", b =>
                {
                    b.HasOne("kayaseker.DAL.Entities.ContentsPlaces", "contentsPlaces")
                        .WithMany("PlacesPictures")
                        .HasForeignKey("contentsPlacesID");

                    b.Navigation("contentsPlaces");
                });

            modelBuilder.Entity("kayaseker.DAL.Entities.ContentsPlaces", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("ContentsComments");

                    b.Navigation("MediaPictures");

                    b.Navigation("PlacesPictures");
                });

            modelBuilder.Entity("kayaseker.DAL.Entities.MediaPicture", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
