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
    [Route("/api/[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ImagesController> _logger;

        public ImagesController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ImagesController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetImages()
        {
            var images = await _unitOfWork.Images.GetAll();
            var results = _mapper.Map<IList<ImageDTO>>(images);
            return Ok(results);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetImage(int id)
        {
            var image = await _unitOfWork.Images.Get(i => i.Id == id);
            var result = _mapper.Map<ImageDTO>(image);
            return Ok(result);
        }

        /// <summary>
        /// POST request to api/images route. 
        /// </summary>
        /// <param name="imageDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateImage([FromBody] CreateImageDTO imageDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid CREATE attempt in {nameof(CreateImage)}");
                return BadRequest();
            }
            var image = _mapper.Map<Image>(imageDTO);
            await _unitOfWork.Images.Insert(image);
            await _unitOfWork.Save();
            return CreatedAtRoute("GetImage", new { id = image.Id }, image);
        }
        /// <summary>
        /// PUT request to api/images/id route. provide id, imageDTO. check if exist, map & update
        /// </summary>
        /// <param name="imageDTO"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateImage([FromBody] CreateImageDTO imageDTO, int id)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateImage)}");
                return BadRequest();
            }
            var image = await _unitOfWork.Images.Get(i => i.Id == id);
            if (image == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateImage)}");
                return BadRequest("Submited invalid data");
            }
            //map/convert imageDTO to image. all fields values from imageDTO goes to image domain object
            _mapper.Map(imageDTO, image);
            _unitOfWork.Images.Update(image);
            await _unitOfWork.Save();

            return NoContent();
        }
        /// <summary>
        /// DELETE reuqest to api/images/id route. provide id, check if exist & delete it
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteImage(int id)
        {
            var image = await _unitOfWork.Images.Get(m => m.Id == id);
            if (image == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteImage)}");
                return BadRequest();
            }
            await _unitOfWork.Images.Delete(id);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}
