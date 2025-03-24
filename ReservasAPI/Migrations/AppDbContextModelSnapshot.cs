﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReservasAPI.Data;

namespace ReservasAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("Reservas", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdEstacionamento")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdVaga")
                        .HasColumnType("TEXT");

                    b.Property<int>("StatusReserva")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("reservas");
                });
#pragma warning restore 612, 618
        }
    }
}
