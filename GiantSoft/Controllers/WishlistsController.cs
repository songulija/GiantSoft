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
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistsController : ControllerBase
    {
        // IUnitOfWork registers for every variation of GenericRepository
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<BrandsController> _logger;

        public WishlistsController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<BrandsController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetWhishlists()
        {
            var whishlists = await _unitOfWork.Whishlists.GetAll();
            var results = _mapper.Map<IList<WhishlistDTO>>(whishlists);
            return Ok(results);
        }

        [HttpGet("{id:int}", Name = "GetWhishlist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetWhishlist(int id)
        {
            var whishlist = await _unitOfWork.Whishlists.Get(w => w.Id == id);
            var result = _mapper.Map<WhishlistDTO>(whishlist);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateWhishlist([FromBody] CreateWhishlistDTO whishlistDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid CREATE attemt in {nameof(CreateWhishlist)}");
                return BadRequest();
            }
            whishlistDTO.Date = DateTime.Now;
            var whishlist = _mapper.Map<Whishlist>(whishlistDTO);
            await _unitOfWork.Whishlists.Insert(whishlist);
            await _unitOfWork.Save();
            return CreatedAtRoute("GetWhishlist", new { id = whishlist.Id }, whishlist);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateWhishlist([FromBody] CreateWhishlistDTO whishlistDTO, int id)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attemt in {nameof(UpdateWhishlist)}");
                return BadRequest();
            }


            var whishlist = await _unitOfWork.Whishlists.Get(g => g.Id == id);
            if (whishlist == null)
            {
                _logger.LogError($"Invalid UPDATE attemt in {nameof(UpdateWhishlist)}");
                return BadRequest("Submited invalid data");
            }
            //map whishlistDTO to whishlist domain object. puts all fields values from dto to whishlist object
            _mapper.Map(whishlistDTO, whishlist);
            _unitOfWork.Whishlists.Update(whishlist);
            await _unitOfWork.Save();
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteWhishlist(int id)
        {
            var whishlist = await _unitOfWork.Whishlists.Get(g => g.Id == id);
            if (whishlist == null)
            {
                _logger.LogError($"Invalid DELETE attemt in {nameof(UpdateWhishlist)}");
                return BadRequest();
            }
            //map whishlistDTO to whishlist domain object. puts all fields values from dto to whishlist object
            await _unitOfWork.Whishlists.Delete(id);
            await _unitOfWork.Save();
            return NoContent();
        }
    }
}
