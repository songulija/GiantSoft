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
    public class FeedbackController : ControllerBase
    {
        // IUnitOfWork registers for every variation of GenericRepository
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<FeedbackController> _logger;

        public FeedbackController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<FeedbackController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        // <summary>
        /// GET request to api/feedback route. Getting all records from feedback table
        /// converting/mapping feedback domain objects to IList of FeedbackDTO objects with Mapper help. I dont need try
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetFeedback()
        {
            var feedbacks = await _unitOfWork.Feedbacks.GetAll();
            var results = _mapper.Map<IList<FeedbackDTO>>(feedbacks);
            return Ok(results);
        }

        /// <summary>
        /// HTTP GET request to api/feedback/{id} route. Getting record from feedback table by id
        /// converting/mapping feedback domain object to feedbackDTO object and returning it
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetFeedback(int id)
        {
            var feedback = await _unitOfWork.Feedbacks.Get(b => b.Id == id);
            var result = _mapper.Map<FeedbackDTO>(feedback);
            return Ok(result);
        }

    }
}
