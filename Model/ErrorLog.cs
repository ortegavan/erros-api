public class ErrorLog
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string? Message { get; set; }
    public string? Stack { get; set; }
    public string? Environment { get; set; }
    public string? Url { get; set; }
    public int? Status { get; set; }
    public DateTime Timestamp { get; set; }
    public string? UserId { get; set; }
    public object? AdditionalInfo { get; set; }
}