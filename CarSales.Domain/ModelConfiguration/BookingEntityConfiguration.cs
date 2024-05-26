using CarSales.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace CarSales.Domain.ModelConfiguration
{
    public class BookingEntityConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("booking")
                .HasKey(k => k.Id);

            builder.Property(k => k.Id)
                .HasColumnName("id");

            builder.Property(k => k.EmployeeId)
                .HasColumnName("employee_id")
                .IsRequired();

            builder.Property(k => k.CustomerId)
                .HasColumnName("customer_id")
                .IsRequired();

            builder.Property(k => k.CarId)
                .HasColumnName("car_id")
                .IsRequired();

            builder.Property(k => k.Duration)
                .HasColumnName("duration");

            builder.Property(k => k.BookingStatus)
                .HasColumnName("status");

            builder.Property(k => k.CreatedOnUtc)
                .HasColumnName("created_on_utc");

            builder.Property(k => k.ConfirmedOnUtc)
                .HasColumnName("confirmed_on_utc");

            builder.Property(k => k.RejectedOnUtc)
                .HasColumnName("rejected_on_utc");

            builder.Property(k => k.CompletedOnUtc)
                .HasColumnName("completed_on_utc");

            builder.Property(k => k.CancelledOnUtc)
                .HasColumnName("cancelled_on_utc");
        }
    }
}
