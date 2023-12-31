﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProvaApi.Data;

#nullable disable

namespace ProvaApi.Migrations
{
    [DbContext(typeof(AppDataContext))]
    partial class AppDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.21");

            modelBuilder.Entity("ProvaApi.Models.Folha", b =>
                {
                    b.Property<int>("FolhaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Ano")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Fgts")
                        .HasColumnType("REAL");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Imposto_Renda")
                        .HasColumnType("REAL");

                    b.Property<float>("Inss")
                        .HasColumnType("REAL");

                    b.Property<int>("Mes")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Quantidade")
                        .HasColumnType("REAL");

                    b.Property<float>("Salario_Bruto")
                        .HasColumnType("REAL");

                    b.Property<float>("Salario_Liquido")
                        .HasColumnType("REAL");

                    b.Property<float>("Valor")
                        .HasColumnType("REAL");

                    b.HasKey("FolhaId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("Folhas");
                });

            modelBuilder.Entity("ProvaApi.Models.Funcionario", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("FuncionarioId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("ProvaApi.Models.Folha", b =>
                {
                    b.HasOne("ProvaApi.Models.Funcionario", "Funcionario")
                        .WithMany("Folhas")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("ProvaApi.Models.Funcionario", b =>
                {
                    b.Navigation("Folhas");
                });
#pragma warning restore 612, 618
        }
    }
}
