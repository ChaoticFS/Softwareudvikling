﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Notit.API.Models;

#nullable disable

namespace Notit.API.Migrations
{
    [DbContext(typeof(NotitContext))]
    [Migration("20230326092945_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.15");

            modelBuilder.Entity("Notit.Shared.Models.Comment", b =>
                {
                    b.Property<long>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("Score")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long?>("ThreadId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CommentId");

                    b.HasIndex("ThreadId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Notit.Shared.Models.Thread", b =>
                {
                    b.Property<long>("ThreadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("Score")
                        .HasColumnType("INTEGER");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ThreadId");

                    b.ToTable("Threads");
                });

            modelBuilder.Entity("Notit.Shared.Models.Comment", b =>
                {
                    b.HasOne("Notit.Shared.Models.Thread", null)
                        .WithMany("Comments")
                        .HasForeignKey("ThreadId");
                });

            modelBuilder.Entity("Notit.Shared.Models.Thread", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}