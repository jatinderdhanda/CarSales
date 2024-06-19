namespace CarSales.Domain.Models;

public class BookingResponse
{
    public Guid CarId { get; init; }
    public Guid BookingId { get; init; }
    public Guid CustomerId { get; init; }
    public required string CarName { get; init; }
    public Guid EmployeeId { get; init; }
    public DateTime CreatedOnUtc { get; init; }
    public DateTime ModifiedOnUtc { get; init; }
    public DateTime? ConfirmedOnUtc { get; init; }
    public DateTime? RejectedOnUtc { get; init; }
    public DateTime? CompletedOnUtc { get; init; }
    public DateTime? CancelledOnUtc { get; init; }
}