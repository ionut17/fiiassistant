﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Server.Logger;

namespace Server.Migrations
{
    [DbContext(typeof(DatabaseLoggerContext))]
    internal class DatabaseLoggerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Server.Logger.LogMessage", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<string>("Message");

                b.Property<string>("Method");

                b.Property<string>("Source");

                b.HasKey("Id");

                b.ToTable("LogMessages");
            });
#pragma warning restore 612, 618
        }
    }
}