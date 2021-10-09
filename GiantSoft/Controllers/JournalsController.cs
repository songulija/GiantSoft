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
    public class JournalsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<JournalsController> _logger;
        public JournalsController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<JournalsController> logger)
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
        [Authorize]
        [HttpGet("{id:int}", Name = "GetJournal")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetJournal(int id)
        {
            var journal = await _unitOfWork.Journals.Get(j => j.Id == id);
            var result = _mapper.Map<JournalDTO>(journal);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateJournal([FromBody] CreateJournalDTO journalDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Create attempt in {nameof(CreateJournal)}");
                return BadRequest(ModelState);
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

        public async Task<IActionResult> UpdateJournal([FromBody] CreateJournalDTO journalDTO, int id)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid Update attempt in {nameof(UpdateJournal)}");
                return BadRequest(ModelState);
            }

            var journal = await _unitOfWork.Journals.Get(j => j.Id == id);
            if (journal == null)
            {
                _logger.LogError($"Invalid Update attempt in {nameof(UpdateJournal)}");
                return BadRequest("Submited data is invalid");
            }
            _mapper.Map(journalDTO, journal);
            await _unitOfWork.Save();

            return NoContent();
        }

        [HttpDelete("{id:int")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteJournal(int id)
        {
            var journal = await _unitOfWork.Journals.Get(j => j.Id == id);
            if(journal == null)
            {
                _logger.LogError($"Invalid Delete attempt in {nameof(DeleteJournal)}");
                return BadRequest("Submited data is invalid");
            }
            await _unitOfWork.Journals.Delete(id);
            await _unitOfWork.Save();

            return NoContent();
        }
    }

}
