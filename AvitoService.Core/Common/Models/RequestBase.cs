namespace AvitoService.Core.Common.Models;

public class RequestBase
{
    public Guid RequestId { get; set; }  = Guid.NewGuid();
}