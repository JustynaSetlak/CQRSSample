using System;
using System.Threading.Tasks;
using CQRSSample.Commands;
using CQRSSample.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSSample.Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediatr;

        public ProductsController(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        [HttpGet]
        public async Task<IActionResult> Get(GetProductsQuery query)
        {
            var result = await mediatr.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommand command)
        {
            command.Id = Guid.NewGuid();

            var result = await mediatr.Send(command);

            return NoContent();
        }
    }
}