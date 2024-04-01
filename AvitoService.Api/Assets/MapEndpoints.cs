using AvitoService.Core.Commands.Document;
using AvitoService.Core.Commands.DocumentCard;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvitoService.Assets;

public static class MapEndpoints
{
    public static void AddEndpoints(this WebApplication app)
    {
        app.AddCardDocumentEndpoints();
        app.AddDocumentsEndpoints();
    }
    
    private static void AddCardDocumentEndpoints(this WebApplication app)
    {
        var appCroup = app
            .MapGroup("/")
            .WithTags("DocumentCards");
        
        appCroup
            .MapPost("Api/CreateDocumentCard", async (IMediator mediator, [FromBody] CreateDocumentCardRequest request) => await mediator.Send(request))
            .WithName("CreateDocumentCard")
            .WithOpenApi();
    }

    private static void AddDocumentsEndpoints(this WebApplication app)
    {
        var appCroup = app
            .MapGroup("/")
            .WithTags("Documents");
        
        appCroup
            .MapPost("Api/CreateDocument", async (IMediator mediator, [FromBody] CreateDocumentRequest request) => await mediator.Send(request))
            .WithName("CreateDocument")
            .WithOpenApi();
    }
}