﻿// <auto-generated />
using FurnitureStorage.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FurnitureStorage.Data.Migrations
{
    [DbContext(typeof(FurnitureStorageContext))]
    partial class FurnitureStorageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FurnitureStorage.Data.Entities.Dimensions", b =>
                {
                    b.Property<int>("FurnitureId")
                        .HasColumnType("int");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<double>("Length")
                        .HasColumnType("float");

                    b.Property<double>("Width")
                        .HasColumnType("float");

                    b.HasKey("FurnitureId");

                    b.ToTable("Dimensions", (string)null);
                });

            modelBuilder.Entity("FurnitureStorage.Data.Entities.Furniture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Furniture");
                });

            modelBuilder.Entity("FurnitureStorage.Data.Entities.Dimensions", b =>
                {
                    b.HasOne("FurnitureStorage.Data.Entities.Furniture", "Furniture")
                        .WithOne("FurnitureDimensions")
                        .HasForeignKey("FurnitureStorage.Data.Entities.Dimensions", "FurnitureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Furniture");
                });

            modelBuilder.Entity("FurnitureStorage.Data.Entities.Furniture", b =>
                {
                    b.Navigation("FurnitureDimensions")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
