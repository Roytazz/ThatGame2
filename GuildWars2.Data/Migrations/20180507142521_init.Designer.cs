﻿// <auto-generated />
using GuildWars2.Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace GuildWars2.Data.Migrations
{
    [DbContext(typeof(GW2DataContext))]
    [Migration("20180507142521_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("GuildWars2.Data")
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GuildWars2.Data.Model.User", b =>
                {
                    b.Property<string>("Key")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Key");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
