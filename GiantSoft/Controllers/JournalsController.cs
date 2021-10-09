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
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetJournal(int id)
        {
            var journal = await _unitOfWork.Journals.Get(j => j.Id == id);
            var result = _mapper.Map<JournalDTO>(journal);
            return Ok(result);
        }
    }
}
