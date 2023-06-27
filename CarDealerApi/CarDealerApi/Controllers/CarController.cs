using AutoMapper;
using CarDealerApi.Dto;
using CarDealerApi.Interface;
using CarDealerApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarDealerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly UserInterface _userInterface;
        private readonly CarInterface _carInterface;
        private readonly IMapper _mapper;
        public CarController(UserInterface userInterface,CarInterface carInterface,IMapper mapper)
        {
            _userInterface = userInterface;
            _carInterface = carInterface;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200,Type=typeof(IEnumerable<Car>))]
        public IActionResult GetCars()
        {
            var cars=_mapper.Map<List<CarDto>>(_carInterface.GetCars());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(cars);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200,Type =typeof(Car))]
        public IActionResult GetCar(int id) 
        {
            if (!_carInterface.CarExits(id))
                return NotFound();

            var car = _mapper.Map<CarDto>(_carInterface.GetCar(id));

            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            
            return Ok(car);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        public IActionResult CreateCar([FromQuery]int UserId,[FromBody] CarDto car)
        {
            if (car == null)
                return BadRequest(ModelState);

            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            var carMap = _mapper.Map<Car>(car);
            carMap.User = _userInterface.GetUserById(UserId);

            if (!_carInterface.CreateCar(carMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }
    }
}
