﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskTracker.DAL.Context;

namespace TaskTracker.DAL.Migrations
{
    [DbContext(typeof(TaskTrackerContext))]
    [Migration("20181012235511_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TaskTracker.DAL.Enitty.AuthClientConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BaseUri");

                    b.Property<string>("PrivateKey");

                    b.HasKey("Id");

                    b.ToTable("AuthClientConfigs");
                });

            modelBuilder.Entity("TaskTracker.DAL.Entity.Board", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("TaskTracker.DAL.Entity.Member", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("BoardID");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.HasIndex("BoardID");

                    b.ToTable("BoardMembers");
                });

            modelBuilder.Entity("TaskTracker.DAL.Entity.Sprint", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("ID");

                    b.ToTable("Sprints");
                });

            modelBuilder.Entity("TaskTracker.DAL.Entity.Member", b =>
                {
                    b.HasOne("TaskTracker.DAL.Entity.Board", "Board")
                        .WithMany()
                        .HasForeignKey("BoardID");
                });
#pragma warning restore 612, 618
        }
    }
}
