using AutoMapper;
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
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBrand(int id)
        {
            var brand = await _unitOfWork.Brands.Get(b => b.Id == id);
            var result = _mapper.Map<BrandDTO>(brand);
            return Ok(result);
        }
    }
    
}
