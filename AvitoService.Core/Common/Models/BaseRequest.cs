namespace AvitoService.Core.Common.Models;

public abstract class BaseRequest
{
    public Guid RequestId { get; set; }  = Guid.NewGuid();
}