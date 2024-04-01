using AvitoService.Core.Common.Models;

namespace AvitoService.Core.Commands.DocumentCard;

public class CreateDocumentCardResponse : BaseResponse
{
    public Guid? Id { get; set; }
}