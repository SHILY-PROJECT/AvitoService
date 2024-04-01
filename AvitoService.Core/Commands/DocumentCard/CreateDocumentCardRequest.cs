using AvitoService.Core.Common.Models;
using MediatR;

namespace AvitoService.Core.Commands.DocumentCard;

public class CreateDocumentCardRequest : BaseRequest, IRequest<CreateDocumentCardResponse>;