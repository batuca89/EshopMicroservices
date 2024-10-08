
namespace Catalog.API.Products.CreateFolder
{
    public record CreateProductCommand( string Name,List<string> Category ,string Description, string ImageFile, decimal Price) 
        : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler (IDocumentSession session)
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

            // almacenadomos nuestra informacion del producto como una base de datos de documentos

            session.Store(Product);
            await session.SaveChangesAsync(cancellationToken);


            // return createProductResult when we create the product and save to databse we response with guid


            return new  CreateProductResult(Product.Id);


        }
    }
}
