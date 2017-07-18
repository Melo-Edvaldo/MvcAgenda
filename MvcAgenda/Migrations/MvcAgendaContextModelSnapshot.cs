﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MvcAgenda.Models;

namespace MvcAgenda.Migrations
{
    [DbContext(typeof(MvcAgendaContext))]
    partial class MvcAgendaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MvcAgenda.Models.Agenda", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClassName");

                    b.Property<string>("FirstPrayer");

                    b.Property<string>("HymnName");

                    b.Property<string>("LastPrayer");

                    b.Property<DateTime>("ReleaseDate");

                    b.HasKey("ID");

                    b.ToTable("Agenda");
                });
        }
    }
}
