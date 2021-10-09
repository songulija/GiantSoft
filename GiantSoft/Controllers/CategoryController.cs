using AutoMapper;
using GiantSoft.IRepository;
using GiantSoft.ModelsDTO;
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
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryController> _logger;
        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CategoryController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        // <summary>
        /// GET request to api/category route. Getting all records from categories table
        /// converting/mapping categories domain objects to IList of CategoryDTO objects with Mapper help. I dont need try
        /// </summary>
        /// <returns></returns> 

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> getCategories()
        {
            var categories = await _unitOfWork.Categories.GetAll();
            var results = _mapper.Map<IList<CategoryDTO>>(categories);
            return Ok(results);
        }

        /// <summary>
        /// HTTP GET request to api/category/{id} route. Getting record from Category table by id
        /// converting/mapping category domain object to CategoryDTO object and returning it
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetCategory(int id)
        {
            var categories = await _unitOfWork.Categories.Get(b => b.Id == id);
            var result = _mapper.Map<CategoryDTO>(categories);
            return Ok(result);
        }
    }

}
