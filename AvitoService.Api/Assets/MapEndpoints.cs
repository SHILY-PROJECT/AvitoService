using AvitoService.Core.Commands.Document;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvitoService.Assets;

public static class MapEndpoints
{
    public static void AddEndpoints(this WebApplication app)
    {
        app.AddCardDocumentEndpoints();
    }
    
    private static void AddCardDocumentEndpoints(this WebApplication app)
    {
        var appCroup = app
            .MapGroup("/")
            .WithTags("api/CardDocuments");
        
        appCroup
            .MapPost("CreateDocument", async (IMediator mediator, [FromBody] CreateDocumentRequest request) => await mediator.Send(request))
            // .WithName("")
            .WithOpenApi();
    }
}