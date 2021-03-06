// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VolvoTruck.Data;

namespace VolvoTruck.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VolvoTruck.Domain.Entities.Truck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ManufactureYear")
                        .HasColumnType("int");

                    b.Property<int>("ModelYear")
                        .HasColumnType("int");

                    b.Property<int>("TruckModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TruckModelId");

                    b.ToTable("Trucks");
                });

            modelBuilder.Entity("VolvoTruck.Domain.Entities.TruckModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TruckModels");
                });

            modelBuilder.Entity("VolvoTruck.Domain.Entities.Truck", b =>
                {
                    b.HasOne("VolvoTruck.Domain.Entities.TruckModel", "TruckModel")
                        .WithMany()
                        .HasForeignKey("TruckModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TruckModel");
                });
#pragma warning restore 612, 618
        }
    }
}
