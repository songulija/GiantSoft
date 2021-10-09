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
    public class JournalsController : ControllerBase
    {
        // IUnitOfWork registers for every variation of GenericRepository
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<BrandsController> _logger;

        public JournalsController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<BrandsController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetJournals()
        {
            var journals = await _unitOfWork.Journals.GetAll();
            var results = _mapper.Map<IList<JournalDTO>>(journals);
            return Ok(results);
        }
        [HttpGet("{id:int}", Name = "GetJournal")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetJournal(int id)
        {
            var journal = await _unitOfWork.Journals.Get(j => j.Id == id);
            var result = _mapper.Map<JournalDTO>(journal);
            return Ok(result);
        }
        [HttpGet("product/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetJournalsByProductId(int id)
        {
            var journals = await _unitOfWork.Journals.GetAll(j => j.ProductId == id);
            var results = _mapper.Map<IList<JournalDTO>>(journals);
            return Ok(results);
        }

        [HttpGet("user/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetJournalsByUserId(int id)
        {
            var journals = await _unitOfWork.Journals.GetAll(j => j.UserId == id);
            var results = _mapper.Map<IList<JournalDTO>>(journals);
            return Ok(results);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateJournals([FromBody] CreateJournalDTO journalDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid CREATE attempt in {nameof(CreateJournals)}");
                return BadRequest();
            }
            var journal = _mapper.Map<Journal>(journalDTO);
            await _unitOfWork.Journals.Insert(journal);
            await _unitOfWork.Save();
            return CreatedAtRoute("GetJournal", new { id = journal.Id }, journal);

        }
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateJournal(int id, [FromBody] CreateJournalDTO journalDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE ettempt in {nameof(UpdateJournal)}");
                return BadRequest();
            }
            var journal = await _unitOfWork.Journals.Get(j => j.Id == id);
            if (journal == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateJournal)}");
                return BadRequest("Submited invalid data");
            }
            //map journalDTO to journal domain object. puts all fields values from dto to journal object
            _mapper.Map(journalDTO, journal);
            _unitOfWork.Journals.Update(journal);
            await _unitOfWork.Save();

            return NoContent();
        }
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteJournal(int id)
        {
            var journal = await _unitOfWork.Journals.Get(g => g.Id == id);
            if (journal == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteJournal)}");
                return BadRequest();
            }
            await _unitOfWork.Journals.Delete(id);
            await _unitOfWork.Save();
            return NoContent();
        }


    }

}
