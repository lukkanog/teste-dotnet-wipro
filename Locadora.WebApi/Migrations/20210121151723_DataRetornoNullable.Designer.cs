﻿// <auto-generated />
using System;
using Locadora.WebApi.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Locadora.WebApi.Migrations
{
    [DbContext(typeof(LocadoraContext))]
    [Migration("20210121151723_DataRetornoNullable")]
    partial class DataRetornoNullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Locadora.WebApi.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasColumnType("VARCHAR(150)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("VARCHAR(250)");

                    b.HasKey("IdCliente");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Locadora.WebApi.Models.Filme", b =>
                {
                    b.Property<int>("IdFilme")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("VARCHAR(250)");

                    b.HasKey("IdFilme");

                    b.ToTable("Filmes");
                });

            modelBuilder.Entity("Locadora.WebApi.Models.Locacao", b =>
                {
                    b.Property<int>("IdLocacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataEsperada")
                        .HasColumnName("DataEsperada")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("DataLocacao")
                        .HasColumnName("DataLocacao")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime?>("DataRetorno")
                        .HasColumnName("DataRetorno")
                        .HasColumnType("DATETIME");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdFilme")
                        .HasColumnType("int");

                    b.HasKey("IdLocacao");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdFilme");

                    b.ToTable("Locacoes");
                });

            modelBuilder.Entity("Locadora.WebApi.Models.Locacao", b =>
                {
                    b.HasOne("Locadora.WebApi.Models.Cliente", "Cliente")
                        .WithMany("Locacoes")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Locadora.WebApi.Models.Filme", "Filme")
                        .WithMany("Locacoes")
                        .HasForeignKey("IdFilme")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
