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
    public class BrandsController : ControllerBase
    {
        // IUnitOfWork registers for every variation of GenericRepository
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<BrandsController> _logger;

        public BrandsController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<BrandsController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        /// <summary>
        // <summary>
        /// GET request to api/brands route. Getting all records from brands table
        /// converting/mapping brands domain objects to IList of BrandDTO objects with Mapper help. I dont need try
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBrands()
        {
            var brands = await _unitOfWork.Brands.GetAll();
            var results = _mapper.Map<IList<BrandDTO>>(brands);
            return Ok(results);
        }
        /// <summary>
        /// HTTP GET request to api/brands/{id} route. Getting record from Brands table by id
        /// converting/mapping brand domain object to BrandDTO object and returning it
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{id:int}", Name = "GetBrand")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBrand(int id)
        {
            var brand = await _unitOfWork.Brands.Get(b => b.Id == id);
            var result = _mapper.Map<BrandDTO>(brand);
            return Ok(result);
        }


        /// <summary>
        /// POST request to api/brands route. Provide brandDTO in body
        /// Convert CreateBrandDTO to domain
        /// object Brand for database and create new brand record and save it
        /// </summary>
        /// <param name="brandDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateBrand([FromBody]CreateBrandDTO brandDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid CREATE attempt in {nameof(CreateBrand)}");
                return BadRequest(ModelState);
            }
            var brand = _mapper.Map<Brand>(brandDTO);
            await _unitOfWork.Brands.Insert(brand);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetBrand", new { id = brand.Id }, brand);
        }

        /// <summary>
        /// PUT request to api/brands route. Provide id, CreateBrandDTO in body. Check if brand with that id exist
        /// Convert dto to domain object Brand and update
        /// </summary>
        /// <param name="brandDTO"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateBrand([FromBody] CreateBrandDTO brandDTO, int id)
        {
            //check if model is valid by CreateBrandDTO requirements
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateBrand)}");
                return BadRequest(ModelState);
            }
            var brand = await _unitOfWork.Brands.Get(b => b.Id == id);
            if (brand == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateBrand)}");
                return BadRequest("Submited data is invalid");
            }
            //map/convert brandDTO into brand object. basically whatever is in brandDTO put it into brand
            _mapper.Map(brandDTO, brand);

            _unitOfWork.Brands.Update(brand);
            await _unitOfWork.Save();

            return NoContent();
        }

        /// <summary>
        /// DELETE request to api/brands/{id} route. Provide id. Find record by
        /// that id. Then delete it and save
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var brand = await _unitOfWork.Brands.Get(b => b.Id == id);
            if (brand == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(DeleteBrand)}");
                return BadRequest("Submited data is invalid");
            }
            await _unitOfWork.Brands.Delete(id);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
    
}
