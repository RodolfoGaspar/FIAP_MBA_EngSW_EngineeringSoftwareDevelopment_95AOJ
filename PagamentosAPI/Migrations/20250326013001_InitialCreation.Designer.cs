﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PagamentosAPI.Data;

namespace PagamentosAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250326013001_InitialCreation")]
    partial class InitialCreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("Pagamentos", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("AlteradoEm")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdReserva")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("TEXT");

                    b.Property<int>("MetodoPagamento")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatusPagamento")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Valor")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Pagamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
