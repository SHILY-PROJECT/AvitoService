namespace AvitoService.Core.Common.Models;

public class BaseRequest
{
    public Guid RequestId { get; set; }  = Guid.NewGuid();
}