﻿// <auto-generated />
using System;
using BullMarket.Web.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BullMarket.Web.Migrations
{
    [DbContext(typeof(BullMarketContext))]
    [Migration("20190831184500_Ajustes")]
    partial class Ajustes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BullMarket.Web.Models.Corretagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AcaoId");

                    b.Property<string>("Corretora")
                        .IsRequired();

                    b.Property<decimal>("Custos")
                        .HasColumnType("decimal(18,8)");

                    b.Property<DateTime>("DataCompra");

                    b.Property<int>("Quantidade");

                    b.Property<string>("Status")
                        .IsRequired();

                    b.Property<decimal>("ValorAgora")
                        .HasColumnType("decimal(18,8)");

                    b.Property<decimal>("ValorCompra")
                        .HasColumnType("decimal(18,8)");

                    b.HasKey("Id");

                    b.HasIndex("AcaoId");

                    b.ToTable("Corretagens");
                });

            modelBuilder.Entity("BullMarket.Web.Models.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo");

                    b.Property<string>("Link");

                    b.Property<string>("Nome");

                    b.Property<string>("Ramo");

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("BullMarket.Web.Models.Corretagem", b =>
                {
                    b.HasOne("BullMarket.Web.Models.Empresa", "Acao")
                        .WithMany()
                        .HasForeignKey("AcaoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
