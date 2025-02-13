namespace MovieDatabase.API.Models;

public class ErrorDetail
{
    public int Code { get; set; }
    public string Message { get; set; } = default!;
}
