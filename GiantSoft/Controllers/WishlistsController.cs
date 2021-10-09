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
    public class WishlistsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<WishlistsController> _logger;

        public WishlistsController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<WishlistsController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetWishlists()
        {
            var wishlists = await _unitOfWork.Whishlists.GetAll();
            var results = _mapper.Map<IList<WhishlistDTO>>(wishlists);
            return Ok(results);
        }
        [Authorize]
        [HttpGet("{id:int}", Name ="GetWishList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetWishlist(int id)
        {
            var wishlist = await _unitOfWork.Whishlists.Get(w => w.Id == id);
            var result = _mapper.Map<WhishlistDTO>(wishlist);
            return Ok(result);
        }

        public async Task<IActionResult> CreateWishlist([FromBody] WhishlistDTO whishlistDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Create attempt in {nameof(CreateWishlist)}");
                return BadRequest(ModelState);
            }
            var wishlist = _mapper.Map<Whishlist>(whishlistDTO);
            await _unitOfWork.Products.Insert(wishlist);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetWishList", new { id = wishlist.Id }, wishlist);
        }

        [HttpPut("{id:int")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public async Task<IActionResult> UpdateWishlist([FromBody] WhishlistDTO whishlistDTO, int id)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid Update attempt in {nameof(UpdateWishlist)}");
                return BadRequest(ModelState);
            }

            var wishlist = await _unitOfWork.Whishlists.Get(j => j.Id == id);
            if (wishlist == null)
            {
                _logger.LogError($"Invalid Update attempt in {nameof(UpdateWishlist)}");
                return BadRequest("Submited data is invalid");
            }
            _mapper.Map(whishlistDTO, wishlist);
            await _unitOfWork.Save();

            return NoContent();
        }

        [HttpDelete("{id:int")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteWishlist(int id)
        {
            var wishlist = await _unitOfWork.Whishlists.Get(j => j.Id == id);
            if (wishlist == null)
            {
                _logger.LogError($"Invalid Delete attempt in {nameof(DeleteWishlist)}");
                return BadRequest("Submited data is invalid");
            }
            await _unitOfWork.Whishlists.Delete(id);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}
