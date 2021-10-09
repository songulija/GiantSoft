using AutoMapper;
using GiantSoft.Data;
using GiantSoft.IRepository;
using GiantSoft.ModelsDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiantSoft.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProductsController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _unitOfWork.Products.GetAll();
            var results = _mapper.Map<IList<ProductDTO>>(products);
            return Ok(results);
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _unitOfWork.Products.Get(p => p.Id == id);
            var result = _mapper.Map<JournalDTO>(product);
            return Ok(result);
        }

        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Create attempt in {nameof(CreateProduct)}");
                return BadRequest(ModelState);
            }
            var product = _mapper.Map<Product>(productDTO);
            await _unitOfWork.Products.Insert(product);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public async Task<IActionResult> UpdateProduct([FromBody] CreateProductDTO productDTO, int id)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid Update attempt in {nameof(UpdateProduct)}");
                return BadRequest(ModelState);
            }

            var product = await _unitOfWork.Products.Get(j => j.Id == id);
            if (product == null)
            {
                _logger.LogError($"Invalid Update attempt in {nameof(UpdateProduct)}");
                return BadRequest("Submited data is invalid");
            }
            _mapper.Map(productDTO, product);
            _unitOfWork.Products.Update(product);
            await _unitOfWork.Save();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _unitOfWork.Products.Get(j => j.Id == id);
            if (product == null)
            {
                _logger.LogError($"Invalid Delete attempt in {nameof(DeleteProduct)}");
                return BadRequest("Submited data is invalid");
            }
            await _unitOfWork.Products.Delete(id);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}
