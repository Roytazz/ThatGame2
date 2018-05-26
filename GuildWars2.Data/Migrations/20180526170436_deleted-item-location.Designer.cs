﻿// <auto-generated />
using System;
using GuildWars2.Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GuildWars2.Data.Migrations
{
    [DbContext(typeof(UserDbContext))]
    [Migration("20180526170436_deleted-item-location")]
    partial class deleteditemlocation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("GuildWars2.UserData")
                .HasAnnotation("ProductVersion", "2.1.0-rc1-32029")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GuildWars2.Data.Model.CategoryValue", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Category");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Delta");

                    b.Property<int>("UserID");

                    b.Property<int>("Value");

                    b.HasKey("ID");

                    b.ToTable("CategoryValue");
                });

            modelBuilder.Entity("GuildWars2.Data.Model.Dye", b =>
                {
                    b.Property<int>("UserID");

                    b.Property<int>("DyeID");

                    b.Property<DateTime>("Date");

                    b.HasKey("UserID", "DyeID");

                    b.ToTable("Dye");
                });

            modelBuilder.Entity("GuildWars2.Data.Model.Item", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Delta");

                    b.Property<int>("ItemID");

                    b.Property<int>("SkinID");

                    b.Property<int>("StatID");

                    b.Property<int>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("GuildWars2.Data.Model.Key", b =>
                {
                    b.Property<int>("UserID");

                    b.Property<string>("APIKey");

                    b.HasKey("UserID", "APIKey");

                    b.ToTable("Key");
                });

            modelBuilder.Entity("GuildWars2.Data.Model.Mini", b =>
                {
                    b.Property<int>("UserID");

                    b.Property<int>("MiniID");

                    b.Property<DateTime>("Date");

                    b.Property<int>("ItemID");

                    b.HasKey("UserID", "MiniID");

                    b.ToTable("Mini");
                });

            modelBuilder.Entity("GuildWars2.Data.Model.Skin", b =>
                {
                    b.Property<int>("UserID");

                    b.Property<int>("SkinID");

                    b.Property<DateTime>("Date");

                    b.HasKey("UserID", "SkinID");

                    b.ToTable("Skin");
                });

            modelBuilder.Entity("GuildWars2.Data.Model.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountName");

                    b.HasKey("ID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("GuildWars2.Data.Model.WalletEntry", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurrencyID");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Delta");

                    b.Property<int>("UserID");

                    b.Property<int>("Value");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Wallet");
                });

            modelBuilder.Entity("GuildWars2.Data.Model.Dye", b =>
                {
                    b.HasOne("GuildWars2.Data.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GuildWars2.Data.Model.Item", b =>
                {
                    b.HasOne("GuildWars2.Data.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GuildWars2.Data.Model.Key", b =>
                {
                    b.HasOne("GuildWars2.Data.Model.User", "User")
                        .WithMany("Keys")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GuildWars2.Data.Model.Mini", b =>
                {
                    b.HasOne("GuildWars2.Data.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GuildWars2.Data.Model.Skin", b =>
                {
                    b.HasOne("GuildWars2.Data.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GuildWars2.Data.Model.WalletEntry", b =>
                {
                    b.HasOne("GuildWars2.Data.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
