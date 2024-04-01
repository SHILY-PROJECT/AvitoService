using AvitoService.Core.Common.Models;
using MediatR;

namespace AvitoService.Core.Commands.Document;

public class CreateDocumentResponse : BaseResponse
{
    public Guid? Id { get; set; }
};