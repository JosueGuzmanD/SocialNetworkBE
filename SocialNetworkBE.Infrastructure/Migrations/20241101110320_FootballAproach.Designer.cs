﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialNetworkBE.Infrastructure;

#nullable disable

namespace SocialNetworkBE.Infrastructure.Migrations
{
    [DbContext(typeof(SocialNetworkDbContext))]
    [Migration("20241101110320_FootballAproach")]
    partial class FootballAproach
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SocialNetworkBE.Domain.Entities.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FieldId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("MatchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FieldId");

                    b.HasIndex("MatchId")
                        .IsUnique();

                    b.HasIndex("PlayerId");

                    b.ToTable("Bookings", (string)null);
                });

            modelBuilder.Entity("SocialNetworkBE.Domain.Entities.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("SocialNetworkBE.Domain.Entities.FootballField", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FieldCapacity")
                        .HasColumnType("int")
                        .HasColumnName("FieldCapacity");

                    b.Property<int>("FieldType")
                        .HasColumnType("int")
                        .HasColumnName("FieldType");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.Property<decimal>("PricePerHour")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("FootballFields");
                });

            modelBuilder.Entity("SocialNetworkBE.Domain.Entities.Match", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FootballFieldId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FootballFieldId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Match", (string)null);
                });

            modelBuilder.Entity("SocialNetworkBE.Domain.Entities.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("SocialNetworkBE.Domain.Entities.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AvatarUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("MatchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Positions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("SocialNetworkBE.Domain.Entities.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("MatchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PostType")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("SocialNetworkBE.Domain.Entities.Reaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CommentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Reactions");
                });

            modelBuilder.Entity("SocialNetworkBE.Domain.Entities.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isRecurrent")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("SocialNetworkBE.Domain.Entities.Booking", b =>
                {
                    b.HasOne("SocialNetworkBE.Domain.Entities.FootballField", "Field")
                        .WithMany("Bookings")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetworkBE.Domain.Entities.Match", "Match")
                        .WithOne()
                        .HasForeignKey("SocialNetworkBE.Domain.Entities.Booking", "MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetworkBE.Domain.Entities.Player", "ReservedBy")
                        .WithMany("Bookings")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Field");

                    b.Navigation("Match");

                    b.Navigation("ReservedBy");
                });

            modelBuilder.Entity("SocialNetworkBE.Domain.Entities.Comment", b =>
                {
                    b.HasOne("SocialNetworkBE.Domain.Entities.Player", "Player")
                        .WithMany("Comments")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SocialNetworkBE.Domain.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("SocialNetworkBE.Domain.Entities.FootballField", b =>
                {
                    b.OwnsOne("SocialNetworkBE.Domain.Value_Objects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("FootballFieldId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("City");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("Country");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("nvarchar(10)")
                                .HasColumnName("PostalCode");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Street");

                            b1.HasKey("FootballFieldId");

                            b1.ToTable("FootballFields");

                            b1.WithOwner()
                                .HasForeignKey("FootballFieldId");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("SocialNetworkBE.Domain.Entities.Match", b =>
                {
                    b.HasOne("SocialNetworkBE.Domain.Entities.FootballField", "FootballField")
                        .WithMany("Matches")
                        .HasForeignKey("FootballFieldId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SocialNetworkBE.Domain.Entities.Player", "CreatedBy")
                        .WithMany("CreatedMatches")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("SocialNetworkBE.Domain.Value_Objects.MatchDuration", "MatchDuration", b1 =>
                        {
                            b1.Property<Guid>("MatchId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<TimeSpan>("AddedTime")
                                .HasColumnType("time");

                            b1.Property<TimeSpan>("ExtraTime")
                                .HasColumnType("time");

                            b1.Property<TimeSpan>("HalfTimeDuration")
                                .HasColumnType("time");

                            b1.Property<TimeSpan>("TotalTime")
                                .HasColumnType("time");

                            b1.Property<TimeSpan>("WaterBreakDuration")
                                .HasColumnType("time");

                            b1.HasKey("MatchId");

                            b1.ToTable("MatchDuration", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("MatchId");
                        });

                    b.OwnsOne("SocialNetworkBE.Domain.Value_Objects.MatchStats", "Stats", b1 =>
                        {
                            b1.Property<Guid>("MatchId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("GoalsTeamA")
                                .HasColumnType("int");

                            b1.Property<int>("GoalsTeamB")
                                .HasColumnType("int");

                            b1.HasKey("MatchId");

                            b1.ToTable("Match");

                            b1.WithOwner()
                                .HasForeignKey("MatchId");

                            b1.OwnsMany("SocialNetworkBE.Domain.Entities.Scorer", "Scorers", b2 =>
                                {
                                    b2.Property<Guid>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<bool>("IsTeamA")
                                        .HasColumnType("bit");

                                    b2.Property<Guid>("MatchId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<Guid>("PlayerId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.HasKey("Id");

                                    b2.HasIndex("MatchId");

                                    b2.ToTable("Scorers", (string)null);

                                    b2.WithOwner()
                                        .HasForeignKey("MatchId");
                                });

                            b1.Navigation("Scorers");
                        });

                    b.Navigation("CreatedBy");

                    b.Navigation("FootballField");

                    b.Navigation("MatchDuration")
                        .IsRequired();

                    b.Navigation("Stats")
                        .IsRequired();
                });

            modelBuilder.Entity("SocialNetworkBE.Domain.Entities.Notification", b =>
                {
                    b.HasOne("SocialNetworkBE.Domain.Entities.Player", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialNetworkBE.Domain.Entities.Player", b =>
                {
                    b.HasOne("SocialNetworkBE.Domain.Entities.Match", null)
                        .WithMany("Players")
                        .HasForeignKey("MatchId");

                    b.HasOne("SocialNetworkBE.Domain.Entities.Team", null)
                        .WithMany("Players")
                        .HasForeignKey("TeamId");

                    b.OwnsOne("SocialNetworkBE.Domain.Value_Objects.PlayerStats", "Stats", b1 =>
                        {
                            b1.Property<Guid>("PlayerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("GoalsScored")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasDefaultValue(0);

                            b1.Property<int>("TotalMatchesPlayed")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasDefaultValue(0);

                            b1.Property<int>("Wins")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasDefaultValue(0);

                            b1.HasKey("PlayerId");

                            b1.ToTable("Players");

                            b1.WithOwner()
                                .HasForeignKey("PlayerId");
                        });

                    b.Navigation("Stats")
                        .IsRequired();
                });

            modelBuilder.Entity("SocialNetworkBE.Domain.Entities.Post", b =>
                {
                    b.HasOne("SocialNetworkBE.Domain.Entities.Player", "CreatedBy")
                        .WithMany("Posts")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("SocialNetworkBE.Domain.Entities.Reaction", b =>
                {
                    b.HasOne("SocialNetworkBE.Domain.Entities.Comment", "Comment")
                        .WithMany("Reactions")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SocialNetworkBE.Domain.Entities.Post", "Post")
                        .WithMany("Reactions")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetworkBE.Domain.Entities.Player", "User")
                        .WithMany("Reactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Comment");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialNetworkBE.Domain.Entities.Team", b =>
                {
                    b.OwnsOne("SocialNetworkBE.Domain.Value_Objects.TeamStats", "Stats", b1 =>
                        {
                            b1.Property<Guid>("TeamId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Losses")
                                .HasColumnType("int");

                            b1.Property<int>("TotalMatchesPlayed")
                                .HasColumnType("int");

                            b1.Property<int>("Wins")
                                .HasColumnType("int");

                            b1.HasKey("TeamId");

                            b1.ToTable("Teams");

                            b1.WithOwner()
                                .HasForeignKey("TeamId");
                        });

                    b.Navigation("Stats")
                        .IsRequired();
                });

            modelBuilder.Entity("SocialNetworkBE.Domain.Entities.Comment", b =>
                {
                    b.Navigation("Reactions");
                });

            modelBuilder.Entity("SocialNetworkBE.Domain.Entities.FootballField", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Matches");
                });

            modelBuilder.Entity("SocialNetworkBE.Domain.Entities.Match", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("SocialNetworkBE.Domain.Entities.Player", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Comments");

                    b.Navigation("CreatedMatches");

                    b.Navigation("Notifications");

                    b.Navigation("Posts");

                    b.Navigation("Reactions");
                });

            modelBuilder.Entity("SocialNetworkBE.Domain.Entities.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Reactions");
                });

            modelBuilder.Entity("SocialNetworkBE.Domain.Entities.Team", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
