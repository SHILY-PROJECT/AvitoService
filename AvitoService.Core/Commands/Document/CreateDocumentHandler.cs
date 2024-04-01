using MediatR;
using Microsoft.Extensions.Logging;

namespace AvitoService.Core.Commands.Document;

public class CreateDocumentHandler(ILogger<CreateDocumentHandler> logger) : IRequestHandler<CreateDocumentRequest, CreateDocumentResponse>
{
    public Task<CreateDocumentResponse> Handle(CreateDocumentRequest request, CancellationToken cancellationToken)
    {
        var response = new CreateDocumentResponse
        {
            Id = Guid.NewGuid(),
            Message = "Документ успешно создан.",
            IsSuccess = true,
            RequestId = request.RequestId
        };
        
        return Task.FromResult(response);
    }
}