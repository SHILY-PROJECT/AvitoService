namespace AvitoService.Core.Common.Models;

public class BaseResponse
{
    public Guid RequestId { get; set; }
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
}