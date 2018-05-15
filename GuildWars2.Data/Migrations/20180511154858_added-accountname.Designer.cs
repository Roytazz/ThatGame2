﻿// <auto-generated />
using GuildWars2.Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GuildWars2.Data.Migrations
{
    [DbContext(typeof(GW2DataContext))]
    [Migration("20180511154858_added-accountname")]
    partial class addedaccountname
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("GuildWars2.Data")
                .HasAnnotation("ProductVersion", "2.1.0-rc1-32029")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GuildWars2.Data.Model.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Type");

                    b.HasKey("ID");

                    b.ToTable("Category");

                    b.HasData(
                        new { ID = 1, Type = 0 },
                        new { ID = 2, Type = 1 },
                        new { ID = 3, Type = 2 },
                        new { ID = 4, Type = 3 },
                        new { ID = 5, Type = 4 },
                        new { ID = 6, Type = 5 },
                        new { ID = 7, Type = 6 },
                        new { ID = 8, Type = 7 }
                    );
                });

            modelBuilder.Entity("GuildWars2.Data.Model.CategoryValue", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID");

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

                    b.HasKey("UserID", "DyeID");

                    b.ToTable("Dye");
                });

            modelBuilder.Entity("GuildWars2.Data.Model.Item", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<int>("Delta");

                    b.Property<int>("ItemID");

                    b.Property<int>("Location");

                    b.Property<int>("SkinID");

                    b.Property<int>("StatID");

                    b.Property<int>("UserID");

                    b.HasKey("ID");

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

                    b.HasKey("UserID", "MiniID");

                    b.ToTable("Mini");
                });

            modelBuilder.Entity("GuildWars2.Data.Model.Skin", b =>
                {
                    b.Property<int>("UserID");

                    b.Property<int>("SkinID");

                    b.HasKey("UserID", "SkinID");

                    b.ToTable("Skin");
                });

            modelBuilder.Entity("GuildWars2.Data.Model.User", b =>
                {
                    b.Property<int>("ID");

                    b.Property<string>("AccountName");

                    b.HasKey("ID", "AccountName");

                    b.ToTable("User");
                });

            modelBuilder.Entity("GuildWars2.Data.Model.WalletEntry", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<int>("CurrencyID");

                    b.Property<int>("Delta");

                    b.Property<int>("UserID");

                    b.HasKey("ID");

                    b.ToTable("Wallet");
                });
#pragma warning restore 612, 618
        }
    }
}
