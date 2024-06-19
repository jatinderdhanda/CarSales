namespace CarSales.Web.Controllers.CarDetail;

public sealed record AddCarDetailRequest
{
    public required string Name { get; set; } 
    public required string Color { get; set; } 
    public required string CompanyName { get; set; } 
    public required string ManufactureYear { get; set; } 
    public required string RegistrationNumber { get; set; }
    public required string FuelType { get; set; }
}
