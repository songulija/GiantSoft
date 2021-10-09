using AutoMapper;
using GiantSoft.IRepository;
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
            var results = _mapper.Map<IList<WishlistDTO>>(wishlists);
            return Ok(results);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetWishlist(int id)
        {
            var wishlist = await _unitOfWork.Whishlists.Get(w => w.Id == id);
            var result = _mapper.Map<WishlistDTO>(wishlist);
            return Ok(result);
        }
    }
}
