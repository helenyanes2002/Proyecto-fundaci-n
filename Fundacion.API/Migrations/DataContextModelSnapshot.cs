﻿// <auto-generated />
using System;
using Fundacion.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fundacion.API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Fundacion.Shared.Entidades.Beneficiario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Edad")
                        .HasMaxLength(5)
                        .HasColumnType("int");

                    b.Property<string>("Informacion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Programa")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Beneficiarios");
                });

            modelBuilder.Entity("Fundacion.Shared.Entidades.DonacionMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cantidad")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("DonanteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProgramaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DonanteId");

                    b.HasIndex("ProgramaId");

                    b.ToTable("DonacionesMateriales");
                });

            modelBuilder.Entity("Fundacion.Shared.Entidades.DonacionMonetaria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DonanteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("MetodoPago")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Monto")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.Property<string>("Proposito")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("DonanteId");

                    b.ToTable("DonacionesMonetarias");
                });

            modelBuilder.Entity("Fundacion.Shared.Entidades.DonacionMonetariaGasto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DonacionMonetariaId")
                        .HasColumnType("int");

                    b.Property<int>("GastoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DonacionMonetariaId");

                    b.HasIndex("GastoId");

                    b.ToTable("DonacionesMonetariasGastos");
                });

            modelBuilder.Entity("Fundacion.Shared.Entidades.Donante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("Donantes");
                });

            modelBuilder.Entity("Fundacion.Shared.Entidades.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Salario")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("Fundacion.Shared.Entidades.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ProgramaId")
                        .HasColumnType("int");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ProgramaId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("Fundacion.Shared.Entidades.EventoVoluntario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.Property<int>("VoluntarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.HasIndex("VoluntarioId");

                    b.ToTable("EventosVoluntarios");
                });

            modelBuilder.Entity("Fundacion.Shared.Entidades.Gasto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("Monto")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Gastos");
                });

            modelBuilder.Entity("Fundacion.Shared.Entidades.Programa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Presupuesto")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Programas");
                });

            modelBuilder.Entity("Fundacion.Shared.Entidades.ProgramaBeneficiario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BeneficiarioId")
                        .HasColumnType("int");

                    b.Property<int>("ProgramaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BeneficiarioId");

                    b.HasIndex("ProgramaId");

                    b.ToTable("ProgramasBeneficiarios");
                });

            modelBuilder.Entity("Fundacion.Shared.Entidades.Voluntario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Disponibilidad")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Voluntarios");
                });

            modelBuilder.Entity("Fundacion.Shared.Entidades.DonacionMaterial", b =>
                {
                    b.HasOne("Fundacion.Shared.Entidades.Donante", "Donantes")
                        .WithMany()
                        .HasForeignKey("DonanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fundacion.Shared.Entidades.Programa", "Programas")
                        .WithMany()
                        .HasForeignKey("ProgramaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Donantes");

                    b.Navigation("Programas");
                });

            modelBuilder.Entity("Fundacion.Shared.Entidades.DonacionMonetaria", b =>
                {
                    b.HasOne("Fundacion.Shared.Entidades.Donante", "Donantes")
                        .WithMany()
                        .HasForeignKey("DonanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Donantes");
                });

            modelBuilder.Entity("Fundacion.Shared.Entidades.DonacionMonetariaGasto", b =>
                {
                    b.HasOne("Fundacion.Shared.Entidades.DonacionMonetaria", "DonacionesMonetarias")
                        .WithMany("DonacionesMonetariasGastos")
                        .HasForeignKey("DonacionMonetariaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fundacion.Shared.Entidades.Gasto", "Gastos")
                        .WithMany("DonacionesMonetariasGastos")
                        .HasForeignKey("GastoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonacionesMonetarias");

                    b.Navigation("Gastos");
                });

            modelBuilder.Entity("Fundacion.Shared.Entidades.Donante", b =>
                {
                    b.HasOne("Fundacion.Shared.Entidades.Empleado", "Empleados")
                        .WithMany()
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("Fundacion.Shared.Entidades.Evento", b =>
                {
                    b.HasOne("Fundacion.Shared.Entidades.Programa", "Programas")
                        .WithMany()
                        .HasForeignKey("ProgramaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Programas");
                });

            modelBuilder.Entity("Fundacion.Shared.Entidades.EventoVoluntario", b =>
                {
                    b.HasOne("Fundacion.Shared.Entidades.Evento", "Eventos")
                        .WithMany("EventosVoluntarios")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fundacion.Shared.Entidades.Voluntario", "Voluntarios")
                        .WithMany("EventosVoluntarios")
                        .HasForeignKey("VoluntarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Eventos");

                    b.Navigation("Voluntarios");
                });

            modelBuilder.Entity("Fundacion.Shared.Entidades.ProgramaBeneficiario", b =>
                {
                    b.HasOne("Fundacion.Shared.Entidades.Beneficiario", "Beneficiarios")
                        .WithMany("ProgramasBeneficiarios")
                        .HasForeignKey("BeneficiarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fundacion.Shared.Entidades.Programa", "Programas")
                        .WithMany("ProgramasBeneficiarios")
                        .HasForeignKey("ProgramaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Beneficiarios");

                    b.Navigation("Programas");
                });

            modelBuilder.Entity("Fundacion.Shared.Entidades.Beneficiario", b =>
                {
                    b.Navigation("ProgramasBeneficiarios");
                });

            modelBuilder.Entity("Fundacion.Shared.Entidades.DonacionMonetaria", b =>
                {
                    b.Navigation("DonacionesMonetariasGastos");
                });

            modelBuilder.Entity("Fundacion.Shared.Entidades.Evento", b =>
                {
                    b.Navigation("EventosVoluntarios");
                });

            modelBuilder.Entity("Fundacion.Shared.Entidades.Gasto", b =>
                {
                    b.Navigation("DonacionesMonetariasGastos");
                });

            modelBuilder.Entity("Fundacion.Shared.Entidades.Programa", b =>
                {
                    b.Navigation("ProgramasBeneficiarios");
                });

            modelBuilder.Entity("Fundacion.Shared.Entidades.Voluntario", b =>
                {
                    b.Navigation("EventosVoluntarios");
                });
#pragma warning restore 612, 618
        }
    }
}