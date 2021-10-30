﻿// <auto-generated />
using System;
using Chess.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Chess.DAL.Migrations
{
    [DbContext(typeof(ChessDbContext))]
    [Migration("20211025121756_LobbyFix")]
    partial class LobbyFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Chess.Models.Entities.ChatMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LobbyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LobbyId");

                    b.HasIndex("UserId");

                    b.ToTable("ChatMessages");
                });

            modelBuilder.Entity("Chess.Models.Entities.Lobby", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LobbyConfigId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LobbyConfigId");

                    b.ToTable("Lobbies");
                });

            modelBuilder.Entity("Chess.Models.Entities.LobbyConfig", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RoomCode")
                        .HasColumnType("int");

                    b.Property<int>("Round")
                        .HasColumnType("int");

                    b.Property<DateTime>("RoundStart")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("LobbyConfigs");
                });

            modelBuilder.Entity("Chess.Models.Entities.PieceLocation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Color")
                        .HasColumnType("int");

                    b.Property<int>("Column")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LobbyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Row")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LobbyId");

                    b.ToTable("PieceLocations");

                    b.HasDiscriminator<string>("Discriminator").HasValue("PieceLocation");
                });

            modelBuilder.Entity("Chess.Models.Entities.UserBase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LobbyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Team")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LobbyId");

                    b.ToTable("UserData");

                    b.HasDiscriminator<string>("Discriminator").HasValue("UserBase");
                });

            modelBuilder.Entity("Chess.Models.Entities.Vote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LobbyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MoveId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Round")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LobbyId");

                    b.HasIndex("MoveId");

                    b.HasIndex("UserId");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("Chess.Models.Entities.Move", b =>
                {
                    b.HasBaseType("Chess.Models.Entities.PieceLocation");

                    b.Property<int>("NewColumn")
                        .HasColumnType("int");

                    b.Property<int>("NewRow")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("UserId");

                    b.HasDiscriminator().HasValue("Move");
                });

            modelBuilder.Entity("Chess.Models.Entities.RegisteredUser", b =>
                {
                    b.HasBaseType("Chess.Models.Entities.UserBase");

                    b.Property<string>("UserProfileId")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("UserData");

                    b.HasDiscriminator().HasValue("RegisteredUser");
                });

            modelBuilder.Entity("Chess.Models.Entities.ChatMessage", b =>
                {
                    b.HasOne("Chess.Models.Entities.Lobby", "Lobby")
                        .WithMany()
                        .HasForeignKey("LobbyId");

                    b.HasOne("Chess.Models.Entities.UserBase", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Lobby");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Chess.Models.Entities.Lobby", b =>
                {
                    b.HasOne("Chess.Models.Entities.LobbyConfig", "LobbyConfig")
                        .WithMany()
                        .HasForeignKey("LobbyConfigId");

                    b.Navigation("LobbyConfig");
                });

            modelBuilder.Entity("Chess.Models.Entities.LobbyConfig", b =>
                {
                    b.HasOne("Chess.Models.Entities.RegisteredUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Chess.Models.Entities.PieceLocation", b =>
                {
                    b.HasOne("Chess.Models.Entities.Lobby", "Lobby")
                        .WithMany("Tiles")
                        .HasForeignKey("LobbyId");

                    b.Navigation("Lobby");
                });

            modelBuilder.Entity("Chess.Models.Entities.UserBase", b =>
                {
                    b.HasOne("Chess.Models.Entities.LobbyConfig", "Lobby")
                        .WithMany("Players")
                        .HasForeignKey("LobbyId");

                    b.Navigation("Lobby");
                });

            modelBuilder.Entity("Chess.Models.Entities.Vote", b =>
                {
                    b.HasOne("Chess.Models.Entities.Lobby", "Lobby")
                        .WithMany()
                        .HasForeignKey("LobbyId");

                    b.HasOne("Chess.Models.Entities.Move", "Move")
                        .WithMany()
                        .HasForeignKey("MoveId");

                    b.HasOne("Chess.Models.Entities.UserBase", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Lobby");

                    b.Navigation("Move");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Chess.Models.Entities.Move", b =>
                {
                    b.HasOne("Chess.Models.Entities.UserBase", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Chess.Models.Entities.Lobby", b =>
                {
                    b.Navigation("Tiles");
                });

            modelBuilder.Entity("Chess.Models.Entities.LobbyConfig", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
