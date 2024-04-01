using MediatR;
using Microsoft.Extensions.Logging;

namespace AvitoService.Core.Commands.DocumentCard;

public class CreateDocumentCardHandler(ILogger<CreateDocumentCardHandler> logger) : IRequestHandler<CreateDocumentCardRequest, CreateDocumentCardResponse>
{
    public Task<CreateDocumentCardResponse> Handle(CreateDocumentCardRequest request, CancellationToken cancellationToken)
    {
        var response = new CreateDocumentCardResponse
        {
            Id = Guid.NewGuid(),
            Message = "Карточка для документов успешно создана.",
            IsSuccess = true,
            RequestId = request.RequestId
        };

        return Task.FromResult(response);
    }
}