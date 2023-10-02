﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace server.Migrations
{
    [DbContext(typeof(ConnectionContext))]
    partial class ConnectionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("server.Models.CategoriaServico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("categoriaservico");
                });

            modelBuilder.Entity("server.Models.Cliente", b =>
                {
                    b.Property<string>("Cpf")
                        .HasColumnType("text");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Cpf");

                    b.ToTable("clientes");
                });

            modelBuilder.Entity("server.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf_Cliente")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cpf_cliente");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<int>("Id_Servico")
                        .HasColumnType("integer")
                        .HasColumnName("id_servico");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("Cpf_Cliente");

                    b.HasIndex("Id_Servico");

                    b.ToTable("pedidos");
                });

            modelBuilder.Entity("server.Models.Prestadores", b =>
                {
                    b.Property<string>("Cpf")
                        .HasColumnType("text");

                    b.Property<string>("Biografia")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Cpf");

                    b.ToTable("prestadores");
                });

            modelBuilder.Entity("server.Models.Servicos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Valor")
                        .HasColumnType("double precision");

                    b.Property<string>("cpf_prestador")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("id_categoria_servico")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("cpf_prestador");

                    b.HasIndex("id_categoria_servico");

                    b.ToTable("servicos");
                });

            modelBuilder.Entity("server.Models.Pedido", b =>
                {
                    b.HasOne("server.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("Cpf_Cliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server.Models.Servicos", "Servicos")
                        .WithMany()
                        .HasForeignKey("Id_Servico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Servicos");
                });

            modelBuilder.Entity("server.Models.Servicos", b =>
                {
                    b.HasOne("server.Models.Prestadores", "Prestadores")
                        .WithMany()
                        .HasForeignKey("cpf_prestador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server.Models.CategoriaServico", "CategoriaServico")
                        .WithMany()
                        .HasForeignKey("id_categoria_servico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaServico");

                    b.Navigation("Prestadores");
                });
#pragma warning restore 612, 618
        }
    }
}
