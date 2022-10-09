using AutoMarket.DAL;
using AutoMarket.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AutoMarket.Controllers
{
    public class CarController: Controller
    {

        private readonly ICarRepository _carRepository;
        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            var response = await _carRepository.Select();
            return View(response);
        }
    }
}
