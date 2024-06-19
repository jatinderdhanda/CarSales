using CarSales.Domain.Abstraction;

namespace CarSales.Domain.Errors.Car;
public static class CarDetailError
{
    public static readonly Error NotAbleToAdd = new(
        "Car.NotRequired",
        "Car can't be added.");
}
