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
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(k => k.CarRegistrationNumber)
                .HasColumnName("car_registration_number")
                .IsRequired();

            builder.Property(k => k.CarName)
                .HasColumnName("car_name")
                .IsRequired();
            builder.Property(k => k.CarCompanyName)
                .HasColumnName("car_company_name")
                .IsRequired();
            builder.Property(k => k.CarDescription)
                .HasColumnName("car_description");
            builder.Property(k => k.CarColor)
                .HasColumnName("car_color");
            builder.Property(k => k.CarManufactureYear)
                .HasColumnName("car_manufacture_year");

        }
    }
}
