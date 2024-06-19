using CarSales.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CarSales.Domain.Abstraction;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarSales.Infrastructure.ModelConfiguration;

internal sealed class BookingEntityConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        var dateOnlyConverter = new ValueConverter<DateOnly, DateTime>(
            v => v.ToDateTime(TimeOnly.MinValue),
            v => DateOnly.FromDateTime(v));

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

        builder.OwnsOne(booking => booking.Duration, duration =>
        {
            duration.Property(d => d.Start)
                    .HasColumnName("start_date")
                    .HasConversion(ValueConverters.DateOnlyConverter)
                    .IsRequired();

            duration.Property(d => d.End)
                    .HasColumnName("end_date")
                    .HasConversion(ValueConverters.DateOnlyConverter)
                    .IsRequired();
        });

        builder.Property(k => k.Status)
            .HasColumnName("status")
            .HasConversion<string>(); 

        builder.Property(k => k.CreatedOnUtc)
            .HasColumnName("created_on_utc");

        builder.Property(k => k.ModifiedOnUtc)
            .HasColumnName("modified_on_utc")
            .IsConcurrencyToken();

        builder.Property(k => k.ConfirmedOnUtc)
            .HasColumnName("confirmed_on_utc");

        builder.Property(k => k.RejectedOnUtc)
            .HasColumnName("rejected_on_utc");

        builder.Property(k => k.CompletedOnUtc)
            .HasColumnName("completed_on_utc");

        builder.Property(k => k.CancelledOnUtc)
            .HasColumnName("cancelled_on_utc");

        builder.HasOne<CarDetail>()
        .WithMany()
        .HasForeignKey(booking => booking.CarId);
    }
}
