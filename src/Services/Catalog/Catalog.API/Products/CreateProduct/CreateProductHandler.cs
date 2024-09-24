using BuildingBlocks.CQRS;
using Catalog.API.Models;
using MediatR;


namespace Catalog.API.Products.CreateFolder
{
    public record CreateProductCommand( string Name,List<string> Category ,string Description, string ImageFile, decimal Price) 
        : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid id);
    internal class CreateProductCommandHandler 
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //create Product entity from command object

            var Product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price,
            };

            // save to database



            // return createProductResult when we create the product and save to databse we response with guid


            return new  CreateProductResult(Guid.NewGuid());


        }
    }
}
