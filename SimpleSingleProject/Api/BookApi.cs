using Microsoft.AspNetCore.Mvc;
using SimpleSingleProject.Commands;
using SimpleSingleProject.Dtos;
using SimpleSingleProject.Queries;

namespace SimpleSingleProject.Api;

public static class BookApi
{
    public static IEndpointRouteBuilder MapGetBooks(this IEndpointRouteBuilder app)
    {
        app
            .MapGet("/books", ([FromServices] IBookQueries bookQueries) => bookQueries.GetAll())
            .Produces<IQueryable<BookDto>>()
            .WithName("GetBooks");

        return app;
    }

    public static IEndpointRouteBuilder MapGetBook(this IEndpointRouteBuilder app)
    {
        app
            .MapGet("/book/{id:long}", async (long id, CancellationToken cancellationToken, [FromServices] IBookQueries bookQueries) =>
                await bookQueries.FindById(id, cancellationToken) switch
                {
                    { } obj => Results.Ok(obj),
                    _ => Results.NotFound()
                }
            )
            .Produces<BookDto>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithName("GetBook");

        return app;
    }

    public static IEndpointRouteBuilder MapPostBook(this IEndpointRouteBuilder app)
    {
        app
            .MapPost("/book", async (BookInputDto book, CancellationToken cancellationToken, [FromServices] IBookCommands bookCommands) =>
                await bookCommands.SaveBook(book, cancellationToken)
            )
            .Produces<long>(StatusCodes.Status200OK)
            .WithName("PostBook");

        return app;
    }
}
