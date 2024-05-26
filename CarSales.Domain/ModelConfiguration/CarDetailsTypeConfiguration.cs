using CarSales.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarSales.Infrastructure.ModelConfiguration
{
    public class CarDetailsTypeConfiguration : IEntityTypeConfiguration<CarDetails>
    {
        public void Configure(EntityTypeBuilder<CarDetails> builder)
        {
            builder.ToTable("car_detials")
                .HasKey(k => k.Id);

            builder.Property(k => k.Id)
                .HasColumnName("id");

            builder.Property(k => k.RegistrationNumber)
                .HasColumnName("registration_number")
                .IsRequired();

            builder.Property(k => k.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(k => k.CompanyName)
                .HasColumnName("company_name")
                .IsRequired();
            builder.Property(k => k.Color)
                .HasColumnName("color");

            builder.Property(k => k.ManufactureYear)
                .HasColumnName("manufacture_year");

            builder.Property(k => k.Status)
                .HasColumnName("status");

            builder.Property(k => k.FuelType)
                .HasColumnName("fuel_type");
        }
    }
}
