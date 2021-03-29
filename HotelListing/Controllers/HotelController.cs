using AutoMapper;
using HotelListing.Data;
using HotelListing.DTOs;
using HotelListing.Services.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HotelController> _logger;
        private readonly IMapper _mapper;

        public HotelController(IUnitOfWork unitOfWork, ILogger<HotelController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHotels()
        {
            try
            {
                var countries = await _unitOfWork.Hotels.GetAll();
                var results = _mapper.Map<IList<HotelDTO>>(countries);
                return Ok(countries);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong in the {nameof(GetHotels)}");
                return StatusCode(500, "Internal server error. Try again later.");
            }
        }

        [HttpGet("{id:int}", Name = "GetHotel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHotel(int id)
        {
            try
            {
                var country = await _unitOfWork.Hotels.Get(expression: q => q.Id == id, new List<string> { "Country" });
                var results = _mapper.Map<HotelDTO>(country);
                return Ok(country);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong in the {nameof(GetHotel)}");
                return StatusCode(500, "Internal server error. Try again later.");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateHotel([FromBody] CreateHotelDTO hotelDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateHotel)}");
                return BadRequest(ModelState);
            }
            try
            {
                var hotel = _mapper.Map<Hotel>(hotelDTO);
                await _unitOfWork.Hotels.Insert(hotel);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetHotel", new { id = hotel.Id }, hotel);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong in the {nameof(CreateHotel)}");
                return StatusCode(500, "Internal server error. Try again later.");
            }
        }

    }
}
