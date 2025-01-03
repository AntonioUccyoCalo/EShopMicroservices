


namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Description, string Imagefile, decimal Price) : IRequest<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    internal class CreateProductComamandHandler(IDocumentSession session) : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //create Product entity from comand
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                Imagefile = command.Imagefile,
                Price = command.Price
            };
            //Save to db
            session.Store(product);
            //cancellationToken serve per annullare la chiamata in corso se un utente o un processo decidde di fermarla, per farlo andrebbe assegnato/recuperato un id univoco
            await session.SaveChangesAsync(cancellationToken);

            //return 
            return new CreateProductResult(product.Id); 
        }
    }
}
