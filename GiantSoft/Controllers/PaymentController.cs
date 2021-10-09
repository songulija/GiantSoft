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
    public class PaymentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<PaymentController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        // <summary>
        /// GET request to api/payment route. Getting all records from payment table
        /// converting/mapping payment domain objects to IList of paymentDTO objects with Mapper help. I dont need try
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPayment()
        {
            var payments = await _unitOfWork.Payments.GetAll();
            var results = _mapper.Map<IList<PaymentDTO>>(payments);
            return Ok(results);
        }

        /// <summary>
        /// HTTP GET request to api/payment/{id} route. Getting record from payment table by id
        /// converting/mapping payment domain object to paymentDTO object and returning it
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPayment(int id)
        {
            var payments = await _unitOfWork.Payments.Get(b => b.Id == id);
            var results = _mapper.Map<PaymentDTO>(payments);
            return Ok(results);
        }

    }
}
