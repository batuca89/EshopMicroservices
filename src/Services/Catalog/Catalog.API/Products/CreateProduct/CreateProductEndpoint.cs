

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price);

    public record CreateProductResponse(Guid Id);
    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products", async (CreateProductRequest request, ISender sender) =>
            {
                // asignamos la solicutd al objeto de comando crear producto
                var command = request.Adapt<CreateProductCommand>();
                // activa el manejador, y lo enviamos usando el metodo send de mediator 
                var result = await sender.Send(command);
                // ahora volvemos a convertir la respuesta que obtenemos
                var response = result.Adapt<CreateProductResponse>();

                return Results.Created($"/product/{response.Id}", response);
        
            })
            .WithName("CreateProduct")
            .Produces<CreateProductResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Product")
            .WithDescription("Create Product");
            
        }
    }
}
