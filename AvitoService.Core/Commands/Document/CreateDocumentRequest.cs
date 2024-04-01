using AvitoService.Core.Common.Models;
using MediatR;

namespace AvitoService.Core.Commands.Document;

public class CreateDocumentRequest : BaseRequest, IRequest<CreateDocumentResponse>;