using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Application.Commands;
using ProductAPI.Application.DTOs;
using ProductAPI.Application.Queries;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : BaseController
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retorna todos os produtos
        /// </summary>
        /// <returns>Retorna uma lista de produtos</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllProductsQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Adiciona um novo produto
        /// </summary>
        /// <param name="command">Os dados do produto a ser criado.</param>
        /// <returns>Confirmação de criação de produto.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateCommand command)
        {
            var result = await _mediator.Send(command);

            return ResponseFromResult(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetProductByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


    }
}