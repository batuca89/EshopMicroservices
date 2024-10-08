
namespace Catalog.API.Products.GetProductById
{
    public record GetPruductByIdQuery(Guid id) : IQuery<GetProductByIdResult>;

    public record GetProductByIdResult(Product Product);
    internal class GetProductByIdQueryHandler (IDocumentSession session, ILogger<GetProductByIdQueryHandler> logger)
        : IQueryHandler<GetPruductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetPruductByIdQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProctsByIdQueryHandler.Handle called with {@Query}", query);

            var product = await session.LoadAsync<Product>(query.id, cancellationToken);
            if(product is null) 
            {
                throw new ProductNotFoundException();
            }

            return new GetProductByIdResult(product);
        }
    }
}
