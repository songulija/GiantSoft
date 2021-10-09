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
        /// converting/mapping feedback dto to feedback domain object and inserting it
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id:int}", Name = "GetFeedback")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetFeedback(int id)
        {
            var feedback = await _unitOfWork.Feedbacks.Get(b => b.Id == id);
            var result = _mapper.Map<FeedbackDTO>(feedback);
            return Ok(result);
        }
        /// <summary>
        //// POST request to api/feedbacks route. Provide dto, map/convert it to domain object
        /// & insert & save
        /// </summary>
        /// <param name="feedbackDTO"></param>
        /// <returns></returns>
        public async Task<IActionResult> CreateFeedback([FromBody] CreateFeedbackDTO feedbackDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid CREATE attempt in {nameof(CreateFeedback)}");
                return BadRequest(ModelState);
            }
            var feedback = _mapper.Map<Feedback>(feedbackDTO);
            await _unitOfWork.Feedbacks.Insert(feedback);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetFeedback", new { id = feedback.Id }, feedback);
        }

        /// <summary>
        /// PUT request to api/feedbakc/id route. provide id,feedbackDTO. Check if record
        /// exist. Map dto to domain object. Put its values to Feedback object & update it
        /// </summary>
        /// <param name=""></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateFeedback([FromBody] CreateFeedbackDTO feedbackDTO, int id)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateFeedback)}");
                return BadRequest(ModelState);
            }
            var feedback = await _unitOfWork.Feedbacks.Get(f => f.Id == id);
            if (feedback == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateFeedback)}");
                return BadRequest("Submited invalid data");
            }
            //map/convert brandDTO into brand object. basically whatever is in brandDTO put it into brand
            _mapper.Map(feedbackDTO, feedback);
            _unitOfWork.Feedbacks.Update(feedback);
            await _unitOfWork.Save();
            return NoContent();

        }

        /// <summary>
        /// DELETE request to api/feedbakcs.{id} route. Provide id. Check if record exist, delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            var feedback = await _unitOfWork.Feedbacks.Get(f => f.Id == id);
            if (feedback == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteFeedback)}");
                return BadRequest("Submited invalid data");
            }
            await _unitOfWork.Feedbacks.Delete(id);
            await _unitOfWork.Save();
            return NoContent();
        }



    }
}
