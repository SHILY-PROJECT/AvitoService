namespace AvitoService.Core.Common.Models;

public class ResponseBase
{
    public Guid RequestId { get; set; }
    public bool IsSuccess { get; set; }
}