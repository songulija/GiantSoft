using AutoMapper;
using GiantSoft.Data;
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
        [HttpGet("{id:int}", Name = "GetCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetCategory(int id)
        {
            var categories = await _unitOfWork.Categories.Get(b => b.Id == id);
            var result = _mapper.Map<CategoryDTO>(categories);
            return Ok(result);
        }


        /// <summary>
        /// POST request to api/categories route. Provide CreateCategoryDTO object
        /// check if model is valid. Map/convert DTO object to Category  object & insert it
        /// </summary>
        /// <param name="categoryDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid CREATE attempt in {nameof(CreateCategory)}");
                return BadRequest(ModelState);
            }
            var category = _mapper.Map<Category>(categoryDTO);
            await _unitOfWork.Categories.Insert(category);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetCategory", new { id = category.Id }, category);
        }

        /// <summary>
        /// PUT request to api/categories/{id} route. Provide id & categoryDTO in body
        /// check if model valid, check if category exist with that id , map/convert dto
        /// to Category domain object for db. update and save
        /// </summary>
        /// <param name="categoryDTO"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateCategory([FromBody] CreateCategoryDTO categoryDTO, int id)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateCategory)}");
                return BadRequest(ModelState);
            }

            var category = await _unitOfWork.Categories.Get(c => c.Id == id);
            if (category == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateCategory)}");
                return BadRequest("Submited invalid data");
            }
            //map/convert brandDTO into brand object. basically whatever is in brandDTO put it into brand
            _mapper.Map(categoryDTO, category);
            _unitOfWork.Categories.Update(category);
            await _unitOfWork.Save();
            return NoContent();
        }

        /// <summary>
        /// DELETE request to api/categories route. Check if record exist. Delete and save it
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _unitOfWork.Categories.Get(c => c.Id == id);
            if (category == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteCategory)}");
                return BadRequest("Submited data is invalid");
            }

            await _unitOfWork.Categories.Delete(id);
            await _unitOfWork.Save();
            return NoContent();
        }




    }

}
