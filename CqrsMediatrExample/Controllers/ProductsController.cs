using CqrsMediatrExample.Commands;
using CqrsMediatrExample.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediatrExample.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //private readonly IMediator mediator;//previous usage, DI already done
        private readonly ISender _sender;//newer usage

        public ProductsController(ISender sender) => _sender = sender;

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _sender.Send(new GetProductsQuery());
            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await _sender.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Product product)
        { 
            var producToReturn = await _sender.Send(new AddProductCommand(product));

            //return StatusCode(201);
            return CreatedAtAction("GetProductById", new { id = product.Id}, producToReturn);
        }


    }
}
