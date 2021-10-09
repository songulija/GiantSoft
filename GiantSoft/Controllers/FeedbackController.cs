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
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        // IUnitOfWork registers for every variation of GenericRepository
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<BrandsController> _logger;

        public FeedbacksController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<BrandsController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// GET request to api/feedbacks route. MAP/convert Feedback
        /// objects from DB to IList of FeedbackDTO.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFeedbacks()
        {
            var feedbacks = await _unitOfWork.Feedbacks.GetAll();
            var results = _mapper.Map<IList<FeedbackDTO>>(feedbacks);
            return Ok(results);
        }
        /// <summary>
        /// GET reques to api/feedbacks/{id} route. Provide id(int).
        /// Get method requers Expression how to get needed record
        /// Map/convert Feedback domain object to FeedbackDTO object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "GetFeedback")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFeedback(int id)
        {
            var feedback = await _unitOfWork.Feedbacks.Get(f => f.Id == id);
            var result = _mapper.Map<FeedbackDTO>(feedback);
            return Ok(result);
        }
        /// <summary>
        /// GET request to api/feedbacks/receiver/receiverId. provide receiver id. map to IList of FeedbackDTO objects
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("receiver/{id:int}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFeedbacksByReceiverId(int id)
        {
            var feedbacks = await _unitOfWork.Feedbacks.GetAll(f => f.ReceiverId == id);
            var results = _mapper.Map<IList<FeedbackDTO>>(feedbacks);
            return Ok(results);
        }
        /// <summary>
        /// GET request to api/feedbacks/sender/id. provide receiver senderId. map to IList of FeedbackDTO objects
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("sender/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFeedbacksBySenderId(int id)
        {
            var feedbacks = await _unitOfWork.Feedbacks.GetAll(f => f.SenderId == id);
            var results = _mapper.Map<IList<FeedbackDTO>>(feedbacks);
            return Ok(results);
        }

        /// <summary>
        /// POST request to api/feedbacks route. Provide dto, map/convert it to domain object
        /// & insert & save
        /// </summary>
        /// <param name="feedbackDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
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
