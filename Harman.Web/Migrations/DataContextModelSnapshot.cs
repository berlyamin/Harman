﻿// <auto-generated />
using Harman.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Harman.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Harman.Web.Data.Entities.Cliente", b =>
                {
                    b.Property<int>("Customerid")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("CustomerCellPhone")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("CustomerEmail")
                        .IsRequired();

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("CustomerPhone")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("Customeridentification")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("Customerlastname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Customerid");

                    b.ToTable("Clientes");
                });
#pragma warning restore 612, 618
        }
    }
}
