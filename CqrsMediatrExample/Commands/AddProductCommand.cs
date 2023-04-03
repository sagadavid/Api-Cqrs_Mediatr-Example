using MediatR;

namespace CqrsMediatrExample.Commands
{
    //public record AddProductCommand (Product product) : IRequest; //irequest has no parameter here, 'cause returning no value
    //we use domain entity as parameter for command for simplicity,
    //instead  we should use dto 

    public record AddProductCommand(Product product) : IRequest<Product>;

}
