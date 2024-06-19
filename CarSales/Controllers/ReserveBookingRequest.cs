namespace CarSales.Web.Controllers;

public sealed record ReserveBookingRequest
{
    public Guid CarId { get; set; }
    public Guid EmployeeId { get; set; }
    public Guid CustomerId { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}