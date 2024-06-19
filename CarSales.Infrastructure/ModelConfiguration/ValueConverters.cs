
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarSales.Infrastructure.ModelConfiguration;
public static class ValueConverters
{
    public static ValueConverter<DateOnly, DateTime> DateOnlyConverter => new ValueConverter<DateOnly, DateTime>(
        v => v.ToDateTime(TimeOnly.MinValue),
        v => DateOnly.FromDateTime(v));
}
