﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CS3750TechnicalPrototypes.Data;
using CS3750TechnicalPrototypes.Models;

namespace CS3750TechnicalPrototypes.Migrations
{
    [DbContext(typeof(AuctionContext))]
    [Migration("20170719161037_SponsorsTable")]
    partial class SponsorsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CS3750TechnicalPrototypes.Models.Auction", b =>
                {
                    b.Property<int>("AuctionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuctionName");

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<int>("EventId");

                    b.Property<int>("ItemID");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("AuctionId");

                    b.ToTable("Auction");
                });

            modelBuilder.Entity("CS3750TechnicalPrototypes.Models.Bidder", b =>
                {
                    b.Property<int>("BidderID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmailAddress")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<bool>("IsRegistered");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Password");

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<int?>("RoleID");

                    b.Property<string>("Security");

                    b.HasKey("BidderID");

                    b.HasIndex("RoleID");

                    b.ToTable("Bidder");
                });

            modelBuilder.Entity("CS3750TechnicalPrototypes.Models.BidHistory", b =>
                {
                    b.Property<int>("BidHistoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("BidAmount");

                    b.Property<DateTime>("BidDate");

                    b.Property<int>("BidderId");

                    b.Property<int>("ItemId");

                    b.HasKey("BidHistoryId");

                    b.ToTable("BidHistory");
                });

            modelBuilder.Entity("CS3750TechnicalPrototypes.Models.Event", b =>
                {
                    b.Property<int>("EventID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuctionID");

                    b.Property<DateTime>("closingEventDate");

                    b.Property<string>("eventDescription");

                    b.Property<string>("eventTitle");

                    b.Property<DateTime>("openingEventDate");

                    b.HasKey("EventID");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("CS3750TechnicalPrototypes.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuctionId");

                    b.Property<int?>("BidHistoryId");

                    b.Property<double>("BidIncrement");

                    b.Property<string>("ItemDescription");

                    b.Property<string>("ItemName");

                    b.Property<double>("ItemValue");

                    b.Property<double>("OpeningBid");

                    b.Property<int>("SponsorId");

                    b.HasKey("ItemId");

                    b.HasIndex("AuctionId");

                    b.HasIndex("BidHistoryId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("CS3750TechnicalPrototypes.Models.Media", b =>
                {
                    b.Property<int>("PhotoID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ItemID");

                    b.Property<string>("MediaName");

                    b.Property<string>("MediaPath");

                    b.Property<int>("MediaTypeId");

                    b.Property<string>("PhotoToolTip");

                    b.HasKey("PhotoID");

                    b.HasIndex("ItemID")
                        .IsUnique();

                    b.HasIndex("MediaTypeId")
                        .IsUnique();

                    b.ToTable("Media");
                });

            modelBuilder.Entity("CS3750TechnicalPrototypes.Models.MediaType", b =>
                {
                    b.Property<int>("MediaTypeID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MediaDescription");

                    b.HasKey("MediaTypeID");

                    b.ToTable("MediaType");
                });

            modelBuilder.Entity("CS3750TechnicalPrototypes.Models.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ShortDescription");

                    b.Property<int>("UserRole");

                    b.HasKey("RoleID");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("CS3750TechnicalPrototypes.Models.Sponsor", b =>
                {
                    b.Property<int>("sponsorID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("sponsorEmail");

                    b.Property<string>("sponsorName")
                        .IsRequired();

                    b.HasKey("sponsorID");

                    b.ToTable("Sponsor");
                });

            modelBuilder.Entity("CS3750TechnicalPrototypes.Models.Bidder", b =>
                {
                    b.HasOne("CS3750TechnicalPrototypes.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID");
                });

            modelBuilder.Entity("CS3750TechnicalPrototypes.Models.Item", b =>
                {
                    b.HasOne("CS3750TechnicalPrototypes.Models.Auction", "Auction")
                        .WithMany("Item")
                        .HasForeignKey("AuctionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CS3750TechnicalPrototypes.Models.BidHistory", "BidHistory")
                        .WithMany("Item")
                        .HasForeignKey("BidHistoryId");
                });

            modelBuilder.Entity("CS3750TechnicalPrototypes.Models.Media", b =>
                {
                    b.HasOne("CS3750TechnicalPrototypes.Models.Item")
                        .WithOne("Media")
                        .HasForeignKey("CS3750TechnicalPrototypes.Models.Media", "ItemID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CS3750TechnicalPrototypes.Models.MediaType", "MediaType")
                        .WithOne("Media")
                        .HasForeignKey("CS3750TechnicalPrototypes.Models.Media", "MediaTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
